using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YandexGo.Domain.Entities.Users;
using YandexGo.Service.DTOs.UserDTOs;

namespace YandexGo.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateAsync(UserForCreation adminForCreationDTO);
        Task<User> UpdateAsync(long id, UserForCreation adminForCreationDTO);
        Task DeleteAsync(Expression<Func<User, bool>> expression);
        Task<User> GetAsync(Expression<Func<User, bool>> expression);
        Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null, Tuple<int, int> pagination = null);
    }
}
