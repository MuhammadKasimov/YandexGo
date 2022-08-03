using YandexGo.Data.IRepositories;
using YandexGo.Domain.Entities.Users;

namespace YandexGo.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
    }
}
