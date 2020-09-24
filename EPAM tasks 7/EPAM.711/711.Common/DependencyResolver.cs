using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _711.BLL;
using _711.BLL.Interfaces;
using _711.DAL;
using _711.DAL.Interfaces;

namespace _711.Common
{
    public static class DependencyResolver
    {
        private static readonly IAwardLogic _awardLogic;
        private static readonly IAwardDao _awardDao;

        private static readonly IUserLogic _userLogic;
        private static readonly IUserDao _userDao;

        private static readonly IRewardLogic _rewardLogic;
        private static readonly IRewardDao _rewardDao;

        public static IAwardLogic AwardLogic => _awardLogic;
        public static IAwardDao AwardDao => _awardDao;

        public static IUserLogic UserLogic => _userLogic;
        public static IUserDao UserDao => _userDao;

        public static IRewardLogic RewardLogic => _rewardLogic;
        public static IRewardDao RewardDao => _rewardDao;

        static DependencyResolver ()
        {
            _awardDao = new AwardDao();
            _awardLogic = new AwardLogic(_awardDao);

        }
    }
}
