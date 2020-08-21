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
    class ProductsRepository : IRepository<Product>
    {
        CoursesContext context;

        public ProductsRepository(CoursesContext context)
        {
            this.context = context;
        }

        public void Create(Product t)
        {
            context.Products.Add(t);
        }

        public void Delete(int id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return context.Products
                          .Where(predicate)
                          .ToList();
        }

        public Product Get(int id)
        {
            return context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }

        public void Update(Product t)
        {
            var product = context.Products.Find(t.ProductId);
            product.Name = t.Name;
            product.Quantity = t.Quantity;
            product.Category = t.Category;
            product.DateOfArrival = t.DateOfArrival;
        }
    }
}
