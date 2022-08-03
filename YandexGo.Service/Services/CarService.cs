using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YandexGo.Data.IRepositories;
using YandexGo.Data.Repositories;
using YandexGo.Domain.Entities.Cars;
using YandexGo.Service.DTOs.CarDTOs;
using YandexGo.Service.Interfaces;
using YandexGo.Service.Maper;

namespace YandexGo.Service.Services
{
#pragma warning disable
    public class CarService : ICarService
    {
        private readonly ICarRepository carRepository;
        private readonly IMapper mapper;
        private Car car;

        public CarService()
        {
            carRepository = new CarRepository();
            mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile<MappingProfile>()).CreateMapper();
            car = new Car();
        }
        public async Task<Car> CreateAsync(CarForCreation carForCreationDTO)
        {
            car = await carRepository.CreateAsync(mapper.Map<Car>(carForCreationDTO));
            try
            {
                await carRepository.SaveAsync();
            }
            catch
            {
                throw new Exception("Car with such number already exists such already exists");
            }

            return car;
        }

        public async Task DeleteAsync(Expression<Func<Car, bool>> expression)
        {
            if (!await carRepository.DeleteAsync(expression))
                throw new Exception("Car not found");

            await carRepository.SaveAsync();
        }

        public async Task<IEnumerable<Car>> GetAllAsync(Expression<Func<Car, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var cars = carRepository.GetAll(expression);

            return pagination == null
                ? cars.Take(10)
                : (IEnumerable<Car>)cars.Skip((pagination.Item1 - 1) * pagination.Item2)
                      .Take(pagination.Item2);
        }

        public async Task<Car> GetAsync(Expression<Func<Car, bool>> expression)
        {
            car = await carRepository.GetAsync(expression);

            return car ?? throw new Exception("Admin not found");
        }

        public async Task<Car> UpdateAsync(long id, CarForCreation carForCreationDTO)
        {
            car = await GetAsync(c => c.Id == id);
            try
            {
                await carRepository.SaveAsync();
            }
            catch
            {
                throw new Exception("Car with such number already exists such already exists");
            }


            car = carRepository.Update(mapper.Map(carForCreationDTO, car));
            await carRepository.SaveAsync();

            return car;
        }
    }
}
