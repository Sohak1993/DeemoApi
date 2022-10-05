using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUserRepo
    {
        void Create(User u);
        User GetById(int id);
        IEnumerable<User> GetAll();
        void Update(User u);
        void Delete(int id);
    }
}
