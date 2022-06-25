using ArmyTechTask.interfaces;
using ArmyTechTask.Models;
 using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyTechTask.Repositery
{
    public class RepositeryInvoiceDetail : IRepositeryInvoiceDetail
    {
        private readonly ArmyTechTaskContext context;

        public RepositeryInvoiceDetail(ArmyTechTaskContext context)
        {
            this.context = context;
        }

        public async Task Add<T>(T entity) where T : class
        {
            await context.AddAsync(entity);
            SaveChanges();
        }
        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
            SaveChanges();
        }
        public async Task<IEnumerable<InvoiceDetail>> GetAll()
        {
            return await context.InvoiceDetails.Include(i => i.InvoiceHeader).ToListAsync();
        }
        public async Task<InvoiceDetail> GetById(int? id)
        {
            return await context.InvoiceDetails.Include(i => i.InvoiceHeader).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<InvoiceDetail>> GetByIDTolist(long id_user)
        {
            var res = await context.InvoiceDetails.Include(i => i.InvoiceHeader).Where(x => x.InvoiceHeaderId == id_user).ToListAsync();
            return res;
        }
        public int GetByIDTolistConnt(string data)
        {
            throw new NotImplementedException();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public void update<T>(T entity) where T : class
        {
            context.Update(entity);
            SaveChanges();
        }

        
    }
}
