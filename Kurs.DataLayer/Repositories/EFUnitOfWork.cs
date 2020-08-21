using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs.DataLayer.EFContext;
using Kurs.DataLayer.Entities;
using Kurs.DataLayer.Interfaces;

namespace Kurs.DataLayer.Repositories
{
    public class EntityUnitOfWork : IUnitOfWork
    {
        CoursesContext context;
        RacksRepository racksRepository;
        ProductsRepository productsRepository;

        public EntityUnitOfWork(string name)
        {
            context = new CoursesContext(name);
        }

        public IRepository<Rack> Racks
        {
            get
            {
                if (racksRepository == null)
                    racksRepository = new RacksRepository(context);
                return racksRepository;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productsRepository == null)
                    productsRepository =
                    new ProductsRepository(context);
                return productsRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
