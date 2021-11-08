using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Api.Core.Interface;
using User.Api.Entities;
using User.Api.Repository;

namespace User.Api.Core.Implementation
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(ILogger<UserService> logger, IMapper mapper, IUserRepository userRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetList()
        {
            var response = new List<User>();
            try
            {
                _logger.LogInformation("Start Get");

                
                var dtoList = await _userRepository.GetList();
                response = _mapper.Map<List<User>>(dtoList);

                _logger.LogInformation("Completed Get");

              
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception", ex.Message);
            }
            return response;
        }

        public async Task<User> Get(int Id)
        {
            var response = new User();
            try
            {
                _logger.LogInformation("Start Get user");
                var dtoUser = await _userRepository.GetUserByID(Id);
                response = _mapper.Map<User>(dtoUser);
                _logger.LogInformation("Completed Get user");
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception", ex.Message);
            }
            return response;
        }

        public bool Insert(User user)
        {
            try
            {
                _logger.LogInformation("Start Get Insert");
                var userData = _mapper.Map<UserDto>(user);
                _userRepository.Insert(userData);
               
                _logger.LogInformation("Completed Get Insert");
                return true;
            }
            catch (Exception ex)
            {
              
                _logger.LogError("Exception", ex.Message);
    
                return false;
            }
        }

        public bool Save(User user)
        {
            try
            {
                _logger.LogInformation("Start Get Save");
                var userData = _mapper.Map<UserDto>(user);
                _userRepository.Save(userData);

                _logger.LogInformation("Completed Get Save");
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError("Exception", ex.Message);

                return false;
            }
        }

        public bool Update(User user)
        {
            try
            {
                _logger.LogInformation("Start Get Update");
                var userData = _mapper.Map<UserDto>(user);
                _userRepository.Update(userData);

                _logger.LogInformation("Completed Get Update");
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError("Exception", ex.Message);

                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                _logger.LogInformation("Start Get Delete");
               
                _userRepository.Delete(Id);

                _logger.LogInformation("Completed Get Delete");
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError("Exception", ex.Message);

                return false;
            }
        }

       
    }
}
