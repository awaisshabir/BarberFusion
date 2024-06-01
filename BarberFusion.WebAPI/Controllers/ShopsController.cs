using BarberFusion.Application.Interfaces.Services;
using BarberFusion.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberFusion.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopsController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shop>> GetShopById(Guid id)
        {
            try
            {
                var shop = await _shopService.GetByIdAsync(id);
                if (shop == null) return NotFound();
                return Ok(shop);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>> GetAllShops()
        {
            try
            {
                var shops = await _shopService.GetAllAsync();
                return Ok(shops);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddShop(Shop shop)
        {
            try
            {
                await _shopService.AddAsync(shop);
                return CreatedAtAction(nameof(GetShopById), new { id = shop.Id }, shop);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateShop(Guid id, Shop shop)
        {
            try
            {
                if (id != shop.Id) return BadRequest("Shop ID mismatch");
                await _shopService.UpdateAsync(shop);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShop(Guid id)
        {
            try
            {
                await _shopService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
