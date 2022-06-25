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
    public class RepositeryBranch : IRepositeryBranch
    {
        private readonly ArmyTechTaskContext context;

        public RepositeryBranch(ArmyTechTaskContext context)
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
        public async Task<IEnumerable<Branch>> GetAll()
        {
            return await context.Branches.Include(b => b.City).ToListAsync();
        }
        public async Task<Branch> GetById(int? id)
        {
            return await context.Branches.Include(b => b.City).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Branch>> GetByIDTolist(string name)
        {
            return await context.Branches.Include(b => b.City).Where(x => x.BranchName == name).ToListAsync();
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
