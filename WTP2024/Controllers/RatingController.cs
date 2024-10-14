using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WTP2024.DTO;
using WTP2024.Services.Rating;

namespace WTP2024.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : Controller
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost("add rating")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> AddRating([FromBody] RatingDto ratingDto)
        {
            if (ratingDto == null || ratingDto.Rating < 0 || ratingDto.Rating > 10)
            {
                return BadRequest("Invalid rating data.");
            }
            ratingDto.AddedDate = DateTime.Now;

            await _ratingService.AddRatingAsync(ratingDto);
            return Ok("Dodano ocene.");
        }
    }

}

