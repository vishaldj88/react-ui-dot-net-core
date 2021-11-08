using System;
using System.Collections.Generic;
using System.Text;
using User.Api.Core.Interface;
using User.Api;
using System.Threading.Tasks;
using System.Linq;

namespace User.UnitTests.Setup
{
    public class UserServiceFake : IUserService
    {
        private readonly List<User.Api.User> _UserList;

        public UserServiceFake()
        {
            _UserList = new List<User.Api.User>()
            {
                new User.Api.User() { Id = 10,
                    FirstName = "Orange",LastName="D", Gender="Male", EmailId = "orange@test.com" },
                new User.Api.User() { Id = 11,
                    FirstName = "Diary", LastName="B", Gender="Female", EmailId = "Diary@test.com" },
                new User.Api.User() { Id = 12,
                    FirstName = "Pizza",LastName="Hek", Gender="Male", EmailId = "Pizza@test.com"  }
            };
        }

        public IEnumerable<User.Api.User> GetAllItems()
        {
            return _UserList;
        }

        public User.Api.User Add(User.Api.User newItem)
        {
            newItem.Id =1001;
            _UserList.Add(newItem);
            return newItem;
        }

         async Task<List<Api.User>> GetList()
        {

            return await Task.FromResult(_UserList);
        }

         async Task<Api.User> Get(int Id)
        {
            return (Api.User)await Task.FromResult(_UserList.Select(x=>x.Id==Id));
        }

     
        public bool Insert(Api.User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Api.User user)
        {
            throw new NotImplementedException();
        }

        public bool Save(Api.User user)
        {
            throw new NotImplementedException();
        }

        Task<List<Api.User>> IUserService.GetList()
        {
           return Task.FromResult(_UserList);
        }

        Task<Api.User> IUserService.Get(int Id)
        {

            var res = _UserList.Find(x => x.Id == Id);
            return Task.FromResult(res);
        }
    }
}
