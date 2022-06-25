using ArmyTechTask.interfaces;
using ArmyTechTask.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyTechTask.Repositery
{
    public class RepositeryInvoiceHeader : IRepositeryInvoiceHeader
    {
        private readonly ArmyTechTaskContext context;

        public RepositeryInvoiceHeader(ArmyTechTaskContext context )
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

        public async Task<IEnumerable<InvoiceHeader>> GetAll()
        {
            return await context.InvoiceHeaders.Include(i => i.Branch).Include(i => i.Cashier).ToListAsync();
        }

        public async Task<InvoiceHeader> GetById(int? id)
        {
            var res=await context.InvoiceHeaders.Include(i => i.Branch).Include(i => i.Cashier).FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }

        public async Task<IEnumerable<InvoiceHeader>> GetByIDUser(int id)
        {

            return await context.InvoiceHeaders.Include(i => i.Branch).Include(i => i.Cashier).Where(x => x.Id == id).ToListAsync();
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
