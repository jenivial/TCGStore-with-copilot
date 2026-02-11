using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace TCGStore.Api.Features.Cards.Persistence;

public class DynamoCardRepository : ICardCatalogRepository
{
    private readonly IDynamoDBContext _context;
    private readonly ILogger<DynamoCardRepository> _logger;
    public static readonly string TableName = "cards";
    public DynamoCardRepository(IDynamoDBContext context, ILogger<DynamoCardRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Card>> GetAllCardsAsync()
    {

        var conditions = new List<ScanCondition>();
        var cards = await _context.ScanAsync<DynamoCard>(conditions).GetRemainingAsync();
        return cards.Select(dynamoCard => dynamoCard.ToCard());
    }

    public async Task<Card?> GetCardByIdAsync(string id)
    {
        return (await _context.LoadAsync<DynamoCard>(id)).ToCard();
    }

    public async Task<Card> CreateCardAsync(Card card)
    {
        await _context.SaveAsync(card.ToDynamoCard());
        return card;
    }

    public async Task<bool> UpdateCardAsync(string id, Card card)
    {
        var existing = await _context.LoadAsync<DynamoCard>(id);
        if (existing == null) return false;
        await _context.SaveAsync(card.ToDynamoCard());
        return true;
    }

    public async Task<bool> DeleteCardAsync(string id)
    {
        var existing = await _context.LoadAsync<DynamoCard>(id);
        if (existing == null) return false;
        await _context.DeleteAsync<DynamoCard>(id);
        return true;
    }
}
