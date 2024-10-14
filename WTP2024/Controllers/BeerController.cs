using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<IEnumerable<RatingDto>>> GetAllBeersWithAvgRating()
        {
            var beers = await _beerService.GetAllBeersWithAvgRatingAsync();
            return Ok(beers);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BeerWithAvgRatingDto>> GetBeerWithAvgRating(int id)
        {
            var beer = await _beerService.GetBeerWithAvgRatingAsync(id);

            if (beer == null)
            {
                return NotFound();
            }

            return Ok(beer);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBeer([FromBody] BeerDto beerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _beerService.AddAsync(beerDto);
            return Ok("Piwo zostało dodane");
        }
    }
}
