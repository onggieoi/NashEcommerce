using System.Threading.Tasks;
using ViewModelShare.Rate;

namespace backend.Repositories.RatingRepo
{
    public interface IRatingRepository
    {
        Task<bool> Create(RateRequest rateRequest);
    }
}