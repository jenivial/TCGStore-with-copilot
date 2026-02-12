namespace TCGStore.Api.Features.Cards;

public record CreateCardRequest(
    string Name,
    string SetName,
    string? SetCode,
    int CollectorNumber,
    string Rarity,
    decimal Price,
    string? ImageUrl,
    string? Description
);

public record UpdateCardRequest(
    string Name,
    string SetName,
    string? SetCode,
    int CollectorNumber,
    string Rarity,
    decimal Price,
    string? ImageUrl,
    string? Description
);
