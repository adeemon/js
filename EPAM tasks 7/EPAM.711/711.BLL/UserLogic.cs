using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _711.Entities;
using _711.BLL.Interfaces;
using _711.DAL.Interfaces;

namespace _711.BLL
{
    public class UserLogic : IUserLogic
    {
        static readonly IUserDao _userDao;

        public int Add (User user)
        {
            return _userDao.Add(user);
        }

        public void DeleteById (int id)
        {
            _userDao.DeleteById(id);
        }

        public IEnumerable<User> GetAll ()
        {
            return _userDao.GetAll();
        }

        public void ChangeUserById (int id)
        {

        }
    }
}
