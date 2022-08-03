using YandexGo.Data.IRepositories;
using YandexGo.Domain.Entities.Orders;

namespace YandexGo.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
    }
}
