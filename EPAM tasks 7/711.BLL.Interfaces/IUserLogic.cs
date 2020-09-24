using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _711.Entities;


namespace _711.BLL.Interfaces
{
    public interface IUserLogic
    {
        int Add(User user);

        void DeleteById(int id);

        IEnumerable<User> GetAll();

        void ChangeUserById(int userId);
    }
}
