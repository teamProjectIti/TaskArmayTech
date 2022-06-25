using ArmyTechTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyTechTask.interfaces
{
    public interface IRepositeryBranch: Ibase
    {
        Task<Branch> GetById(int? id);
        Task<IEnumerable<Branch>> GetByIDTolist(string data);
        int GetByIDTolistConnt(string data);
        Task<IEnumerable<Branch>> GetAll();
    }
}
