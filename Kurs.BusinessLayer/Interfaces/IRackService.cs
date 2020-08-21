using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs.BusinessLayer.Models;

namespace Kurs.BusinessLayer.Interfaces
{
    public interface IRackService
    {
        ObservableCollection<RackViewModel> GetAll();
        RackViewModel Get(int id);
        void AddProductToRack(int rackId, ProductViewModel product);
        void RemoveProductFromRack(int rackId, int productId);
        void CreateRack(RackViewModel rack);
        void DeleteRack(int rackId);
        void UpdateRack(RackViewModel rack);
        void UpdateProduct(ProductViewModel productViewModel);
    }
}
