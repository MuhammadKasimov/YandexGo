using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YandexGo.Domain.Entities.Ratings;
using YandexGo.Service.DTOs.RatingDTOs;

namespace YandexGo.Service.Interfaces
{
    public interface IRatingService
    {
        Task<Rating> CreateAsync(RatingForCreation adminForCreationDTO);
        Task<Rating> UpdateAsync(long id, RatingForCreation adminForCreationDTO);
        Task DeleteAsync(Expression<Func<Rating, bool>> expression);
        Task<Rating> GetAsync(Expression<Func<Rating, bool>> expression);
        Task<IEnumerable<Rating>> GetAll(Expression<Func<Rating, bool>> expression = null, Tuple<int, int> pagination = null);

    }
}
