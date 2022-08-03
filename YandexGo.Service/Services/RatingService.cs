using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YandexGo.Data.IRepositories;
using YandexGo.Data.Repositories;
using YandexGo.Domain.Entities.Ratings;
using YandexGo.Service.DTOs.RatingDTOs;
using YandexGo.Service.Interfaces;
using YandexGo.Service.Maper;

namespace YandexGo.Service.Services
{
#pragma warning disable
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository ratingRepository;
        private readonly IMapper mapper;
        private Rating rating;

        public RatingService()
        {
            ratingRepository = new RatingRepository();
            mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile<MappingProfile>()).CreateMapper();
            rating = new Rating();
        }
        public async Task<Rating> CreateAsync(RatingForCreation ratingForCreationDTO)
        {
            rating = await ratingRepository.CreateAsync(mapper.Map<Rating>(ratingForCreationDTO));

            return rating;

        }

        public async Task DeleteAsync(Expression<Func<Rating, bool>> expression)
        {
            if (!await ratingRepository.DeleteAsync(expression))
                throw new Exception("Order not found");

            await ratingRepository.SaveAsync();
        }

        public async Task<IEnumerable<Rating>> GetAll(Expression<Func<Rating, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var ratings = ratingRepository.GetAll(expression);

            return pagination == null
                ? ratings.Take(10)
                : (IEnumerable<Rating>)ratings.Skip((pagination.Item1 - 1) * pagination.Item2)
                      .Take(pagination.Item2);
        }

        public async Task<Rating> GetAsync(Expression<Func<Rating, bool>> expression)
        {
            rating = await ratingRepository.GetAsync(expression);

            return rating ?? throw new Exception("Admin not found");
        }

        public async Task<Rating> UpdateAsync(long id, RatingForCreation ratingForCreationDTO)
        {
            rating = await GetAsync(c => c.Id == id);

            rating = ratingRepository.Update(mapper.Map(ratingForCreationDTO, rating));
            await ratingRepository.SaveAsync();

            return rating;
        }
    }
}
