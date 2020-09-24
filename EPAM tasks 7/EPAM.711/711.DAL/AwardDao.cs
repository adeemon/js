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
    public class AwardDao : IAwardDao
    {
        public string AwardPath = Environment.CurrentDirectory + @"\Awards\";

        public int Add(Award Award)
        {
            if (!Directory.Exists(AwardPath))
            {
                Directory.CreateDirectory(AwardPath);
            }

            int jsonId = Award.Id;
            List<Award> _Award = new List<Award>();
            _Award.Add(new Award()
            {
                Id = Award.Id,
                Title = Award.Title,

            });

            string json = JsonConvert.SerializeObject(_Award.ToArray());

            var pathToJson = AwardPath + jsonId + ".txt";
            System.IO.File.WriteAllText(pathToJson, json);

            return Award.Id;
        }

        public void DeleteById(int id)
        {
            var pathOfDeleted = AwardPath + id + ".txt";
            File.Delete(pathOfDeleted);
        }

        public IEnumerable<Award> GetAll()
        {
            List<Award> AwardNotes = new List<Award>();

            foreach (var AwardPath in Directory.GetFiles(AwardPath))
            {
                string json = File.ReadAllText(AwardPath);
                json = json.Substring(1, json.Length - 2);
                Award temp = JsonConvert.DeserializeObject<Award>(json);
                AwardNotes.Add(temp);
            }
            return AwardNotes;
        }

    }
}
