using ArmyTechTask.interfaces;
using ArmyTechTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyTechTask.interfaces
{
    public interface IRepositeryCashier: Ibase
    {
        Task<Cashier> GetById(int? id);
        Task<IEnumerable<Cashier>> GetByIDTolist(string data);
        int GetByIDTolistConnt(string data);
        Task<IEnumerable<Cashier>> GetAll();
    }
}
