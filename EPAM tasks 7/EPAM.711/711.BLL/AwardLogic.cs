using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _711.Entities;
using _711.BLL.Interfaces;
using _711.DAL.Interfaces;
using System.ComponentModel;

namespace _711.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardDao _awardDao;

        public AwardLogic (IAwardDao awardDao)
        {
            _awardDao = awardDao;
        }

        public int Add (Award award)
        {
            return _awardDao.Add(award);
        }

        public void DeleteById (int awardId)
        {
            _awardDao.DeleteById(awardId);
        }

        public IEnumerable<Award> GetAll()
        {
            return _awardDao.GetAll();
        }

        public void ChangeAwardByID(int awardId)
        {

        }

        public Award GetById (int id)
        {
            return _awardDao.GetAll().FirstOrDefault(item => item.Id == id);
        }
    }
}
