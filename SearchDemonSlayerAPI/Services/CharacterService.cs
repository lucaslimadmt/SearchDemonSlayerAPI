using System.Text.Json;
using SearchDemonSlayerAPI.Models;

namespace SearchDemonSlayerAPI.Services;

public sealed class CharacterService(HttpClient http)
{
    public async Task<IReadOnlyList<Character>> GetCharactersAsync(int page, CancellationToken cancellationToken = default)
    {
        using var response = await http.GetAsync($"api/v1/characters?page={page}", cancellationToken);
        response.EnsureSuccessStatusCode();
        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        using var json = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);
        var root = json.RootElement;
        var list = FindArray(root);
        if (list.ValueKind != JsonValueKind.Array)
            throw new JsonException("A API não retornou uma lista de personagens.");

        var characters = new List<Character>();
        foreach (var item in list.EnumerateArray())
        {
            if (item.ValueKind != JsonValueKind.Object) continue;
            characters.Add(new Character(
                GetString(item, "name"),
                GetString(item, "age"),
                GetString(item, "race"),
                GetString(item, "quote"),
                GetString(item, "img", "image")
            ));
        }
        return characters;
    }

    private static JsonElement FindArray(JsonElement root)
    {
        if (root.ValueKind == JsonValueKind.Array) return root;
        if (root.ValueKind == JsonValueKind.Object)
        {
            foreach (var name in new[] { "data", "characters", "results", "items" })
            {
                if (root.TryGetProperty(name, out var value))
                {
                    if (value.ValueKind == JsonValueKind.Array) return value;
                    if (value.ValueKind == JsonValueKind.Object)
                    {
                        var nested = FindArray(value);
                        if (nested.ValueKind == JsonValueKind.Array) return nested;
                    }
                }
            }
        }
        return default;
    }

    private static string GetString(JsonElement item, params string[] names)
    {
        foreach (var name in names)
        {
            if (item.TryGetProperty(name, out var value))
                return value.ValueKind switch
                {
                    JsonValueKind.String => value.GetString() ?? "",
                    JsonValueKind.Number => value.ToString(),
                    _ => ""
                };
        }
        return "";
    }
}
