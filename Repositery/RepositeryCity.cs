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
    public class RepositeryCity : IRepositeryCity
    {
        private readonly ArmyTechTaskContext context;

        public RepositeryCity(ArmyTechTaskContext context)
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
        public async Task<IEnumerable<City>> GetAll()
        {
            return await context.Cities.ToListAsync();
        }

        public async Task<City> GetById(int? id)
        {
            return await context.Cities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<City>> GetByIDTolist(string name)
        {
            return await context.Cities.Where(x => x.CityName == name).ToListAsync();
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
