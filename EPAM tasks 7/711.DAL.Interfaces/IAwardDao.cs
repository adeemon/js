using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _711.Entities;

namespace _711.DAL.Interfaces
{
    public interface IAwardDao
    {
        int Add(Award award);

        void DeleteById(int id);

        IEnumerable<Award> GetAll();
    }
}
