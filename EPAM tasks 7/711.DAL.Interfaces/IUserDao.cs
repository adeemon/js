using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _711.Entities;

namespace _711.DAL.Interfaces
{
    public interface IUserDao
    {
        int Add(User user);

        void DeleteById(int id);

        IEnumerable<User> GetAll();
    }
}
