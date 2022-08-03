using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YandexGo.Domain.Entities.Cars;
using YandexGo.Service.DTOs.CarDTOs;

namespace YandexGo.Service.Interfaces
{
    public interface ICarService
    {
        Task<Car> CreateAsync(CarForCreation adminForCreationDTO);
        Task<Car> UpdateAsync(long id, CarForCreation adminForCreationDTO);
        Task DeleteAsync(Expression<Func<Car, bool>> expression);
        Task<Car> GetAsync(Expression<Func<Car, bool>> expression);
        Task<IEnumerable<Car>> GetAllAsync(Expression<Func<Car, bool>> expression = null, Tuple<int, int> pagination = null);
    }
}
