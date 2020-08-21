using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.DataLayer.Entities
{
    public class Rack
    {
        public Rack()
        {
            Products = new List<Product>();
        }

        public int RackId { get; set; }      // ключ
        public int RackNumber { get; set; }   // номер стеллажа
        public string RackCategory { get; set; } //категория
        public int Capacity { get; set; } //ёмкость вместимость

        // навигационное свойство
        public List<Product> Products { get; set; }
    }
}
