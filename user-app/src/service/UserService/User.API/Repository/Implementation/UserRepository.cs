using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using User.Api.Entities;

namespace User.Api.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {

        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ILogger<UserRepository> logger)
        {
            _logger = logger;
        }

        public void Delete(int Id)
        {
            try
            {
                _logger.LogInformation("Start Delete");

                throw new NotImplementedException();
                _logger.LogInformation("Completed Delete");
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception", ex.Message);
            }

        }

      

        public async Task<IEnumerable<UserDto>> GetList()
        {
            try
            {
                _logger.LogInformation("Start Get");

                var result = GetUsers();

                _logger.LogInformation("Completed Get");
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception", ex.Message);
                throw;
            }
        }

        public async Task<UserDto> GetUserByID(int Id)
        {
            try
            {
                _logger.LogInformation("Start GetUserByID");

                var result = GetUsers()?.Where(x=>x.id.Equals(Id))?.FirstOrDefault();

              
              
                _logger.LogInformation("Completed GetUserByID");
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception", ex.Message);
                throw;
            }
        }

        public void Insert(UserDto user)
        {
            try
            {
                _logger.LogInformation("Start Insert");

                throw new NotImplementedException();
                _logger.LogInformation("Completed Insert");
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception", ex.Message);
                throw;
            }
        }

        public void Save(UserDto user)
        {
            try
            {
                _logger.LogInformation("Start Save");

                throw new NotImplementedException();
                _logger.LogInformation("Completed Save");
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception", ex.Message);
                throw;
            }
        }

        public void Update(UserDto user)
        {
            try
            {
                _logger.LogInformation("Start Update");

                throw new NotImplementedException();
                _logger.LogInformation("Completed Update");
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception", ex.Message);
                throw;
            }
        }

        private List<UserDto> GetUsers()
        {
            try
            {
                var response =  new List<UserDto>();
                _logger.LogInformation("Start GetUsers");
                //..\\..\\junk\\
                using (StreamReader r = new StreamReader(@"..\User.API\Repository\Data\MOCK_DATA.json"))
                {
                    string jsonString = r.ReadToEnd();
                    response = JsonConvert.DeserializeObject<List<UserDto>>(jsonString);

                };

                
                _logger.LogInformation("Completed GetUsers");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception", ex.Message);
                throw;
            }
        }

    }
}
