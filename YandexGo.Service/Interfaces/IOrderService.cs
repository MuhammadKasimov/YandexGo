using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YandexGo.Domain.Entities.Orders;
using YandexGo.Service.DTOs.OrderDTOs;

namespace YandexGo.Service.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateAsync(OrderForCreation adminForCreationDTO);
        Task<Order> UpdateAsync(long id, OrderForCreation adminForCreationDTO);
        Task DeleteAsync(Expression<Func<Order, bool>> expression);
        Task<Order> GetAsync(Expression<Func<Order, bool>> expression);
        Task<IEnumerable<Order>> GetAllAsync(Expression<Func<Order, bool>> expression = null, Tuple<int, int> pagination = null);
    }
}