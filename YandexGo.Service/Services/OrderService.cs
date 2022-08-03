using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YandexGo.Data.IRepositories;
using YandexGo.Data.Repositories;
using YandexGo.Domain.Entities.Orders;
using YandexGo.Service.DTOs.OrderDTOs;
using YandexGo.Service.Interfaces;
using YandexGo.Service.Maper;

namespace YandexGo.Service.Services
{
#pragma warning disable
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;
        private Order order;

        public OrderService()
        {
            orderRepository = new OrderRepository();
            mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile<MappingProfile>()).CreateMapper();
            order = new Order();
        }

        public async Task<Order> CreateAsync(OrderForCreation orderForCreationDTO)
        {
            order = await orderRepository.CreateAsync(mapper.Map<Order>(orderForCreationDTO));

            return order;

        }

        public async Task DeleteAsync(Expression<Func<Order, bool>> expression)
        {
            if (!await orderRepository.DeleteAsync(expression))
                throw new Exception("Order not found");

            await orderRepository.SaveAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync(Expression<Func<Order, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var orders = orderRepository.GetAll(expression);

            return pagination == null
                ? orders.Take(10)
                : (IEnumerable<Order>)orders.Skip((pagination.Item1 - 1) * pagination.Item2)
                      .Take(pagination.Item2);
        }

        public async Task<Order> GetAsync(Expression<Func<Order, bool>> expression)
        {
            order = await orderRepository.GetAsync(expression);

            return order ?? throw new Exception("Admin not found");
        }

        public async Task<Order> UpdateAsync(long id, OrderForCreation orderForCreationDTO)
        {
            order = await GetAsync(c => c.Id == id);

            order = orderRepository.Update(mapper.Map(orderForCreationDTO, order));
            await orderRepository.SaveAsync();

            return order;
        }
    }
}
