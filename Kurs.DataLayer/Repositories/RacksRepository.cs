using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs.DataLayer.EFContext;
using Kurs.DataLayer.Entities;
using Kurs.DataLayer.Interfaces;

namespace Kurs.DataLayer.Repositories
{
    class RacksRepository : IRepository<Rack>
    {
        CoursesContext context;

        public RacksRepository(CoursesContext context)
        {
            this.context = context;
        }

        public void Create(Rack t)
        {
            context.Racks.Add(t);
        }

        public void Delete(int id)
        {
            var rack = context.Racks.Find(id);
            context.Racks.Remove(rack);
        }

        public IEnumerable<Rack> Find(Func<Rack, bool> predicate)
        {
            return context
            .Racks
            .Include(g => g.Products)
            .Where(predicate)
            .ToList();
        }

        public Rack Get(int id)
        {
            return context.Racks.Find(id);
        }

        public IEnumerable<Rack> GetAll()
        {
            return context.Racks.Include(g => g.Products);
        }

        public void Update(Rack t)
        {      
            var rack = context.Racks.Find(t.RackId);
            rack.RackNumber = t.RackNumber;
            rack.RackCategory = t.RackCategory;
            rack.Capacity = t.Capacity;
        }
    }
}
