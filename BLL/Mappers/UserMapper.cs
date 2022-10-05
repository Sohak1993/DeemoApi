using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLLM = BLL.Models;
using DALM = DAL.Models;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static BLLM.User ToBll(this DALM.User user)
        {
            return new BLLM.User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };
        }

        public static DALM.User ToDal(this BLLM.User user)
        {
            return new DALM.User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
