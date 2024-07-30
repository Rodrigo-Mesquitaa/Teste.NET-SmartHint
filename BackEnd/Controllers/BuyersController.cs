using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class BuyersController : ControllerBase
{
    private readonly IBuyerService _buyerService;

    public BuyersController(IBuyerService buyerService)
    {
        _buyerService = buyerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBuyers(int page = 1, string search = "")
    {
        var result = await _buyerService.GetBuyersAsync(page, search);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBuyer(int id)
    {
        var result = await _buyerService.GetBuyerByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBuyer([FromBody] BuyerDto buyerDto)
    {
        try
        {
            await _buyerService.AddBuyerAsync(buyerDto);
            return CreatedAtAction(nameof(GetBuyer), new { id = buyerDto.Id }, buyerDto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBuyer(int id, [FromBody] BuyerDto buyerDto)
    {
        try
        {
            await _buyerService.UpdateBuyerAsync(id, buyerDto);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
