using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs.DataLayer.Entities;

namespace Kurs.DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Rack> Racks { get; }
        IRepository<Product> Products { get; }
        void Save();
    }
}
