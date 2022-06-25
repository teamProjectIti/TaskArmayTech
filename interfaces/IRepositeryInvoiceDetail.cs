using ArmyTechTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyTechTask.interfaces
{
    public interface IRepositeryInvoiceDetail: Ibase
    {
        Task<InvoiceDetail> GetById(int? id);
        Task<IEnumerable<InvoiceDetail>> GetByIDTolist(long data);
        int GetByIDTolistConnt(string data);
        Task<IEnumerable<InvoiceDetail>> GetAll();
    }
}
