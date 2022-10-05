using BLL.Interface;
using BLL.Mappers;
using BLL.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public void Create(User m)
        {
            _userRepo.Create(m.ToDal());
        }

        public void Delete(int id)
        {
            _userRepo.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepo.GetAll().Select(item => item.ToBll());
        }

        public User GetById(int id)
        {
            return _userRepo.GetById(id).ToBll();
        }

        public void Update(User u)
        {
            _userRepo.Update(u.ToDal());
        }
    }
}
