using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YandexGo.Data.IRepositories;
using YandexGo.Data.Repositories;
using YandexGo.Domain.Entities.Users;
using YandexGo.Service.DTOs.UserDTOs;
using YandexGo.Service.Extensions;
using YandexGo.Service.Interfaces;
using YandexGo.Service.Maper;

#pragma warning disable
namespace YandexGo.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        User user;

        public UserService()
        {
            userRepository = new UserRepository();
            mapper = new MapperConfiguration(cfg => cfg
                         .AddProfile<MappingProfile>())
                         .CreateMapper();

            user = new User();
        }
        public async Task<User> CreateAsync(UserForCreation userForCreationDTO)
        {
            if (!userForCreationDTO.Password.IsValidPassword())
                throw new Exception(message: "Password should contain at least 8 chars" +
                    " at least one letter " +
                    "and at list one number");

            if (!userForCreationDTO.Email.IsValidEmail())
                throw new Exception("Email can contain only numbers, letters, '.' and should end with @gmail.com");

            userForCreationDTO.Password = userForCreationDTO.Password.GetHashPasword();

            user = await userRepository.CreateAsync(mapper.Map<User>(userForCreationDTO));

            try
            {
                await userRepository.SaveAsync();
            }
            catch
            {
                throw new Exception("Username, Email or Login such already exists");
            }

            return user;
        }

        public async Task DeleteAsync(Expression<Func<User, bool>> expression)
        {
            if (!await userRepository.DeleteAsync(expression))
                throw new Exception("Admin not found");

            await userRepository.SaveAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var users = userRepository.GetAll(expression);

            return pagination == null
                ? users.Take(10)
                : (IEnumerable<User>)users.Skip((pagination.Item1 - 1) * pagination.Item2)
                      .Take(pagination.Item2);

        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> expression)
        {
            user = await userRepository.GetAsync(expression);

            return user ?? throw new Exception("Admin not found");
        }

        public async Task<User> UpdateAsync(long id, UserForCreation userForCreationDTO)
        {

            user = await GetAsync(a => a.Id == id);

            if (!userForCreationDTO.Password.IsValidPassword())
                throw new Exception(message: "Password should contain at least 8 chars" +
                    " at least one letter " +
                    "and at list one number");

            if (!userForCreationDTO.Email.IsValidEmail())
                throw new Exception("Email can contain only numbers, letters, '.' and should end with @gmail.com");

            userForCreationDTO.Password = userForCreationDTO.Password.GetHashPasword();


            user = userRepository.Update(mapper.Map(userForCreationDTO, user));
            await userRepository.SaveAsync();

            return user;
        }
    }
}
