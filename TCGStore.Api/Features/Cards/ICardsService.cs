namespace TCGStore.Api.Features.Cards;

public interface ICardsService
{
    Task<IEnumerable<Card>> GetAllCardsAsync();
    Task<Card?> GetCardByIdAsync(string id);
    Task<Card> CreateCardAsync(CreateCardRequest request);
    Task<bool> UpdateCardAsync(string id, UpdateCardRequest request);
    Task<bool> DeleteCardAsync(string id);
}
