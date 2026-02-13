using Microsoft.AspNetCore.Mvc;

namespace TCGStore.Api.Features.Cards;

[ApiController]
[Route("api/[controller]")]
public class CardsController : ControllerBase
{
    private readonly ICardsService _cardsService;
    private readonly ILogger<CardsController> _logger;

    public CardsController(ICardsService cardsService, ILogger<CardsController> logger)
    {
        _cardsService = cardsService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Card>>> GetCards()
    {
        var cards = await _cardsService.GetAllCardsAsync();
        return Ok(cards);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Card>> GetCard(string id)
    {
        var card = await _cardsService.GetCardByIdAsync(id);
        if (card == null)
        {
            return NotFound();
        }

        return Ok(card);
    }

    [HttpPost]
    public async Task<ActionResult<Card>> CreateCard(CreateCardRequest request)
    {
        var card = await _cardsService.CreateCardAsync(request);
        return CreatedAtAction(nameof(GetCard), new { id = card.Id }, card);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCard(string id, UpdateCardRequest request)
    {
        var result = await _cardsService.UpdateCardAsync(id, request);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCard(string id)
    {
        var result = await _cardsService.DeleteCardAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
