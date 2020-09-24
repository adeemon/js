using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _711.Entities;
using _711.Common;

namespace _711.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            var userLogic = DependencyResolver.UserLogic;
            var awardLogic = DependencyResolver.AwardLogic;
            var rewardLogic = DependencyResolver.RewardLogic;


            //User test = new User();
            //test.Id = 10;
            //test.Name = "asdad";
            //test.DateOfBirth = DateTime.Now;
            //test.Age = 10;
            

            //User test2 = new User();
            //test2.Id = 12;
            //test2.Name = "asdad";
            //test2.DateOfBirth = DateTime.Now;
            //test2.Age = 10;


            Award testAward = new Award();
            testAward.Id = 1;
            testAward.Title = "For the HORDE";

            awardLogic.DeleteById(1);

            awardLogic.Add(testAward);

            awardLogic.GetById(1);

            //var awardBuf = new AwardDao();
            //awardBuf.Add(testAward);

            //Console.WriteLine("adasdad");
            //Console.ReadKey();

            //Reward tesrReward = new Reward();
            //var rewardTesting = new RewardDao();

            //tesrReward.UserId = test.Id;
            //tesrReward.AwardId = testAward.Id;




            //rewardTesting.Add(tesrReward);

            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
