using Microsoft.AspNetCore.Mvc;
using WTP2024.DTO;
using WTP2024.Services.Beer;

namespace WTP2024.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeerController : Controller
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBeers()
        {
            var beers = await _beerService.GetAllBeersAsync();
            return Ok(beers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBeerById(int id)
        {
            var beer = await _beerService.FindByIdAsync(id);
            if (beer == null)
            {
                return NotFound("Nie znaleziono piwa.");
            }
            return Ok(beer);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddBeer([FromBody] BeerDto beerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _beerService.AddAsync(beerDto);
            return Ok("Piwo zostało dodane");
        }
        //test
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Działa");
        }
    }
}
