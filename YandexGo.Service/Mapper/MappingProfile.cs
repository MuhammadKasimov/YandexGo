using AutoMapper;
using YandexGo.Domain.Entities.Cars;
using YandexGo.Domain.Entities.Orders;
using YandexGo.Domain.Entities.Ratings;
using YandexGo.Domain.Entities.Users;
using YandexGo.Service.DTOs.CarDTOs;
using YandexGo.Service.DTOs.OrderDTOs;
using YandexGo.Service.DTOs.RatingDTOs;
using YandexGo.Service.DTOs.UserDTOs;

namespace YandexGo.Service.Maper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarForCreation>().ReverseMap();
            CreateMap<Order, OrderForCreation>().ReverseMap();
            CreateMap<Rating, RatingForCreation>().ReverseMap();
            CreateMap<User, UserForCreation>().ReverseMap();
        }
    }
}
