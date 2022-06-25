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
    public class RepositeryCashier : IRepositeryCashier
    {
        private readonly ArmyTechTaskContext context;

        public RepositeryCashier(ArmyTechTaskContext context)
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

        public async Task<IEnumerable<Cashier>> GetAll()
        {
            return await context.Cashiers.Include(c => c.Branch).ToListAsync();
        }

        public async Task<Cashier> GetById(int? id)
        {
            return await context.Cashiers.Include(c => c.Branch).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Cashier>> GetByIDTolist(string name)
        {
            return await context.Cashiers.Include(c => c.Branch).Where(x => x.CashierName == name).ToListAsync();
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
