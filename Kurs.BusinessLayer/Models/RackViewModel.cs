using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.BusinessLayer.Models
{
    public class RackViewModel
    {
        public int RackId { get; set; }
        public int RackNumber { get; set; }   // номер стеллажа
        public string RackCategory { get; set; } //категория
        public int Capacity { get; set; } //ёмкость вместимость        
        public ObservableCollection<ProductViewModel> Products { get; set; }
    }
}
