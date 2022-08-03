using YandexGo.Data.IRepositories;
using YandexGo.Domain.Entities.Ratings;

namespace YandexGo.Data.Repositories
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
    }
}
