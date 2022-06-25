using ArmyTechTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyTechTask.interfaces
{
    public interface IRepositeryInvoiceHeader: Ibase
    {
        Task<InvoiceHeader> GetById(int? id);
        Task <IEnumerable<InvoiceHeader>> GetByIDUser(int data);
        int GetByIDTolistConnt(string data);
        Task<IEnumerable<InvoiceHeader>> GetAll();
    }
}
