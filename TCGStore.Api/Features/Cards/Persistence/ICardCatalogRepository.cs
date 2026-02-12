namespace TCGStore.Api.Features.Cards.Persistence;

public interface ICardCatalogRepository
{
    Task<IEnumerable<Card>> GetAllCardsAsync();
    Task<Card?> GetCardByIdAsync(string id);
    Task<Card> CreateCardAsync(Card card);
    Task<bool> UpdateCardAsync(string id, Card card);
    Task<bool> DeleteCardAsync(string id);
}
