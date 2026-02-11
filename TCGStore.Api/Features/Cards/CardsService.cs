using Microsoft.AspNetCore.Mvc;
using TCGStore.Api.Features.Cards.Persistence;

namespace TCGStore.Api.Features.Cards;

public class CardsService : ICardsService
{
    private readonly ILogger<CardsService> _logger;
    private readonly ICardCatalogRepository _cardRepository;

    public CardsService(ILogger<CardsService> logger, ICardCatalogRepository cardRepository)
    {
        _logger = logger;
        _cardRepository = cardRepository;
    }

    public async Task<IEnumerable<Card>> GetAllCardsAsync()
    {
        _logger.LogInformation("Getting all cards");
        return await _cardRepository.GetAllCardsAsync();
    }

    public async Task<Card?> GetCardByIdAsync(string id)
    {
        _logger.LogInformation("Getting card with ID: {CardId}", id);
        return await _cardRepository.GetCardByIdAsync(id);
    }

    public async Task<Card> CreateCardAsync(CreateCardRequest request)
    {
        _logger.LogInformation("Creating new card: {CardName}", request.Name);
        
        var card = new Card{
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            SetName = request.SetName,
            SetCode = request.SetCode,
            CollectorNumber = request.CollectorNumber,
            Rarity = request.Rarity,
            Price = request.Price,
            ImageUrl = request.ImageUrl,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return await _cardRepository.CreateCardAsync(card);
    }

    public async Task<bool> UpdateCardAsync(string id, UpdateCardRequest request)
    {
        _logger.LogInformation("Updating card with ID: {CardId}", id);
        
        var existingCard = await _cardRepository.GetCardByIdAsync(id);
        if (existingCard == null)
        {
            _logger.LogWarning("Card with ID {CardId} not found", id);
            return false;
        }

        var updatedCard = new Card{
            Id = id,
            Name = request.Name,
            SetName = request.SetName,
            SetCode = request.SetCode,
            CollectorNumber = request.CollectorNumber,
            Rarity = request.Rarity,
            Price = request.Price,
            ImageUrl = request.ImageUrl,
            Description = request.Description,
            CreatedAt = existingCard.CreatedAt,
            UpdatedAt = DateTime.UtcNow
        };

        return await _cardRepository.UpdateCardAsync(id, updatedCard);
    }

    public async Task<bool> DeleteCardAsync(string id)
    {
        _logger.LogInformation("Deleting card with ID: {CardId}", id);
        return await _cardRepository.DeleteCardAsync(id);
    }
}
