using System.Threading.Tasks;
using backend.Constans;
using backend.Repositories.RatingRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.Rate;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatesController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository;

        public RatesController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> Create(RateRequest rateRequest)
        {
            var result = await _ratingRepository.Create(rateRequest);

            return Created(Endpoints.Rate, result);
        }
    }
}