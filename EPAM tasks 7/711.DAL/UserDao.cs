using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using _711.Entities;
using _711.DAL.Interfaces;
using Newtonsoft.Json;

namespace _711.DAL
{
    public class UserDao : IUserDao
    {
        public string UserPath = Environment.CurrentDirectory + @"\Users\";

        public int Add(User user)
        {
            if (!Directory.Exists(UserPath))
            {
                Directory.CreateDirectory(UserPath);
            }

            int jsonId = user.Id;
            List<User> _user = new List<User>();
            _user.Add(new User()
            {
                Id = user.Id,
                Name = user.Name,
                DateOfBirth = user.DateOfBirth,
                Age = user.Age,

            });

            string json = JsonConvert.SerializeObject(_user.ToArray());

            var pathToJson = UserPath + jsonId + ".txt";
            System.IO.File.WriteAllText(pathToJson, json);

            return user.Id;
        }

        public void DeleteById(int id)
        {
            var pathOfDeleted = UserPath + id + ".txt";
            File.Delete(pathOfDeleted);
        }

        public IEnumerable<User> GetAll()
        {
            List<User> userNotes = new List<User>();

            foreach (var userPath in Directory.GetFiles(UserPath))
            {
                string json = File.ReadAllText(userPath);
                json = json.Substring(1,json.Length-2);
                User temp = JsonConvert.DeserializeObject<User>(json);
                userNotes.Add(temp);
            }
            return userNotes;
        }

    }
}
