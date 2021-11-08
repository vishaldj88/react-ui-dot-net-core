using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Api.Entities;

namespace User.Api.Repository
{
    /// <summary>>
    /// User Repository
    /// </summary>
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetList();
        Task<UserDto> GetUserByID(int Id);
        void  Insert(UserDto user);
        void Delete(int Id);
        void Update(UserDto user);
        void Save(UserDto user);
    }
}
