using Microsoft.AspNetCore.Mvc;

namespace TCGStore.Api.Features.Inventory;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;
    private readonly ILogger<InventoryController> _logger;

    public InventoryController(IInventoryService inventoryService, ILogger<InventoryController> logger)
    {
        _inventoryService = inventoryService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InventoryItem>>> GetInventory()
    {
        var inventory = await _inventoryService.GetAllInventoryAsync();
        return Ok(inventory);
    }

    [HttpGet("card/{cardId}")]
    public async Task<ActionResult<InventoryItem>> GetInventoryByCardId(int cardId)
    {
        var item = await _inventoryService.GetInventoryByCardIdAsync(cardId);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<InventoryItem>> AddInventory(AddInventoryRequest request)
    {
        var item = await _inventoryService.AddInventoryAsync(request);
        return CreatedAtAction(nameof(GetInventoryByCardId), new { cardId = item.CardId }, item);
    }

    [HttpPut("{id}/quantity")]
    public async Task<IActionResult> UpdateQuantity(int id, UpdateQuantityRequest request)
    {
        var result = await _inventoryService.UpdateQuantityAsync(id, request.Quantity);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
