using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _711.Entities;
using System.IO;
using Newtonsoft.Json;
using _711.DAL.Interfaces;


namespace _711.DAL
{
    public class RewardDao : IRewardDao
    {
        public string RewardPath = Environment.CurrentDirectory + @"\Reward\";

        public void Add(Reward reward)
        {
            var userRewardPath = RewardPath + reward.UserId + @"\";

            if (!Directory.Exists(userRewardPath))
            {
                Directory.CreateDirectory(userRewardPath);
            }

            List<Reward> _Reward = new List<Reward>();
            _Reward.Add(new Reward()
            {
                UserId = reward.UserId,
                AwardId = reward.AwardId,

            });

            string json = JsonConvert.SerializeObject(_Reward.ToArray());

            var pathToJson = userRewardPath +
                reward.AwardId  + ".txt";
            System.IO.File.WriteAllText(pathToJson, json);

        }

        public void DeleteByUser(User user)
        {
            var pathOfDeleted = RewardPath + user.Id ;
            Directory.Delete(pathOfDeleted);
        }

        public void DeleteByAward (User user, Award award, bool deleteForAll)
        {
            string[] ListOfUsers;

            if (deleteForAll)
            {
                ListOfUsers = Directory.GetDirectories(RewardPath);
            }
            else
            {
                ListOfUsers = new string[1];
                ListOfUsers[0] = RewardPath + user.Id;
            }

            foreach (var userDirectory in ListOfUsers)
            {
                var rewardFilePath = userDirectory + @"\" + award.Id + ".txt";
                if (File.Exists(rewardFilePath))
                {
                    File.Delete(rewardFilePath);
                }
            }

        }

        public IEnumerable<Reward> GetAll()
        {
            List<Reward> RewardNotes = new List<Reward>();

            foreach (var RewardPath in Directory.GetFiles(RewardPath))
            {
                string json = File.ReadAllText(RewardPath);
                json = json.Substring(1, json.Length - 2);
                Reward temp = JsonConvert.DeserializeObject<Reward>(json);
                RewardNotes.Add(temp);
            }
            return RewardNotes;
        }
    }
}
