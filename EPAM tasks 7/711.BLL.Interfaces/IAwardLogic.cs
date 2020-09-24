using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _711.Entities;

namespace _711.BLL.Interfaces
{
    public interface IAwardLogic
    {
        int Add(Award award);

        void DeleteById(int id);

        IEnumerable<Award> GetAll();

        //void ChangeAwardById(int awardId);

        Award GetById(int id);
    }
}
