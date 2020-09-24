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
    public class RewardLogic : IRewardLogic
    {
        private readonly IRewardDao _rewardDao;

        public RewardLogic (IRewardDao rewardDao)
        {
            _rewardDao = rewardDao;
        }

        public void Add (Reward reward)
        {
            _rewardDao.Add(reward);
        }

        public void DeleteByUser (User user)
        {
            _rewardDao.DeleteByUser(user);
        }

        public void DeleteByAward (User user, Award award, bool flag)
        {
            _rewardDao.DeleteByAward(user, award, flag);
        }

        public IEnumerable<Reward> GetAll()
        {
            return _rewardDao.GetAll();
        }
    }
}
