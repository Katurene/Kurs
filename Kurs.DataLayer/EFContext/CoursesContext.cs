using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs.DataLayer.Entities;

namespace Kurs.DataLayer.EFContext
{
    class CoursesContext : DbContext
    {
        public CoursesContext(string name) : base(name)
        {
            Database.SetInitializer(new CoursesInitializer());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rack> Racks { get; set; }
    }
}
