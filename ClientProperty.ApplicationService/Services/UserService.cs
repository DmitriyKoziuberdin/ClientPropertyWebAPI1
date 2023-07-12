using ClientProperty.ApplicationService.Interfaces;
using ClientProperty.ApplicationService.Models.Request;
using ClientProperty.ApplicationService.Models.Response;
using ClientProperty.Domain.Entities;
using Common.Exceptions;
using System.Data;

namespace ClientProperty.ApplicationService.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<UserResponseModel> GetUserById(long id)
        {
            var isExist = await _userRepository.AnyUserById(id);
            if (!isExist)
            {
                throw new UserNotFoundException($"User with this ID: {id} not found.");
            }
            var userById = await _userRepository.GetUserById(id);
            var userResponse = new UserResponseModel
            {
                Id = userById.Id,
                Name = userById.Name,
                Address = userById.Address,
                Telephone = userById.Telephone,
                Email = userById.Email
            };
            return userResponse;
        }

        public async Task CreateUser(UserRequestModel userRequest)
        {
            var isExist = await _userRepository.AnyUserWithEmail(userRequest.Email);
            if (isExist)
            {
                throw new UserDuplicateEmail($"User with this Email - {userRequest.Email} already exist.");
            }
            await _userRepository.CreateUser(new User
            {
                Name = userRequest.Name,
                Address = userRequest.Address,
                Telephone = userRequest.Telephone,
                Email = userRequest.Email
            });
        }

        public async Task<UserResponseModel> UpdateUser(UserUpdateRequestModel userRequest)
        {
            var user = new User
            {
                Id = userRequest.Id,
                Name = userRequest.Name,
                Address = userRequest.Address,
                Telephone = userRequest.Telephone,
                Email = userRequest.Email
            };
            var isExist = await _userRepository.AnyUserById(user.Id);
            if (!isExist)
            {
                throw new UserNotFoundException($"User with this ID: {user.Id} not found.");
            }
            await _userRepository.UpdateUser(user);
            var userResponse = await _userRepository.GetUserById(user.Id);
            return new UserResponseModel
            {
                Id = userResponse.Id,
                Name = userResponse.Name,
                Address = userResponse.Address,
                Telephone = userResponse.Telephone,
                Email = userResponse.Email
            };
        }

        public async Task DeleteUser(long id)
        {
            var isExist = await _userRepository.AnyUserById(id);
            if (!isExist)
            {
                throw new UserNotFoundException($"User with this ID: {id} not found.");
            }
            await _userRepository.DeleteUser(id);
        }
    }
}
