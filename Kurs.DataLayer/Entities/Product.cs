using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.DataLayer.Entities
{
    public class Product
    {
        public int ProductId { get; set; } // ключ    
        public string Name { get; set; }  //название
        public int Quantity { get; set; } //количество
        public string Category { get; set; } //категория
        public DateTime DateOfArrival { get; set; } // дата поступления

        // Навигационные свойства
        public int RackId { get; set; }     // ключ группы
        public Rack Rack { get; set; }   //стеллаж
    }
}
