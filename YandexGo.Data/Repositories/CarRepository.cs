using YandexGo.Data.IRepositories;
using YandexGo.Domain.Entities.Cars;

namespace YandexGo.Data.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
    }
}
