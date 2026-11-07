namespace SearchDemonSlayerAPI.Models;

public sealed record Character(
    string Name,
    string Age,
    string Race,
    string Quote,
    string Image
);
