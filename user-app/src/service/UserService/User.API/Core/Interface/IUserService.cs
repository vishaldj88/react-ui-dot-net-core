using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Api.Core.Interface
{
   public interface IUserService 
    {
        public Task<List<User>> GetList();
        public Task<User> Get(int Id);
        public bool Insert(User user);
        public bool Delete(int Id);
        public bool Update(User user);
        public bool Save(User user);
    }
}
