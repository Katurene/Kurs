using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.BusinessLayer.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; } //количество
        public string Category { get; set; } //категория
        public DateTime DateOfArrival { get; set; } // дата поступления
        
        //public bool HasDiscount { get; set; }
    }
}
