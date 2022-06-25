using ArmyTechTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyTechTask.interfaces
{
    public interface IRepositeryCity: Ibase
    {
        Task<City> GetById(int? id);
        Task<IEnumerable<City>> GetByIDTolist(string data);
        int GetByIDTolistConnt(string data);
        Task<IEnumerable<City>> GetAll();
    }
}
