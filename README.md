# SearchDemonSlayerAPI

Aplicação web para consultar personagens do universo **Demon Slayer: Kimetsu no Yaiba**, desenvolvida com **Blazor WebAssembly e .NET 10**.

## Objetivo

Atividade acadêmica da disciplina de Desenvolvimento Web, com foco no consumo de uma API REST e na apresentação dos dados recebidos em uma interface web.

## Funcionalidades

- Listagem de personagens a partir da API de Demon Slayer;
- Exibição de nome, idade, raça, frase marcante e imagem;
- Busca por nome, raça ou frase entre os personagens da página atual;
- Paginação para consultar outros resultados;
- Mensagens de carregamento, erro e ausência de resultados;
- Layout responsivo.

## Tecnologias utilizadas

**C#**, **.NET 10**, **Blazor WebAssembly**, **HTML**, **CSS**, **HttpClient** e **System.Text.Json**.

## Executando o projeto

Instale o [SDK do .NET 10](https://dotnet.microsoft.com/download/dotnet/10.0) e execute:

```bash
git clone https://github.com/lucaslimadmt/SearchDemonSlayerAPI.git
cd SearchDemonSlayerAPI/SearchDemonSlayerAPI
dotnet restore
dotnet run
```

Acesse no navegador o endereço local informado no terminal.

**Observação:** a aplicação precisa de conexão com a internet para consultar a API. A busca filtra os personagens da página carregada.

## Organização

```text
SearchDemonSlayerAPI/
├── SearchDemonSlayerAPI/
│   ├── Layout/       # Layout principal
│   ├── Models/       # Modelo de personagem
│   ├── Pages/        # Página de listagem e busca
│   ├── Services/     # Comunicação com a API
│   ├── wwwroot/      # HTML e CSS
│   ├── App.razor
│   ├── Program.cs
│   └── SearchDemonSlayerAPI.csproj
├── .gitignore
└── README.md
```

## Referências

- [Documentação da Demon Slayer API](https://www.demonslayer-api.com/documentation)
- [Endpoint de personagens](https://www.demonslayer-api.com/api/v1/characters?page=1)

Os dados e imagens são disponibilizados pela API de terceiros.

## Informações acadêmicas

**Instituição:** Centro Universitário de Belo Horizonte (UniBH)  
**Disciplina:** Desenvolvimento Web  
**Professor:** Daniel Henrique Matos de Paiva  
**Aluno:** Lucas Eduardo Lima Demetrio

## Autor

**Lucas Lima** — [github.com/lucaslimadmt](https://github.com/lucaslimadmt)

Projeto desenvolvido para fins acadêmicos.
