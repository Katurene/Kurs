using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kurs.BusinessLayer.Interfaces;
using Kurs.BusinessLayer.Models;
using Kurs.DataLayer.Entities;
using Kurs.DataLayer.Interfaces;
using Kurs.DataLayer.Repositories;

namespace Kurs.BusinessLayer.Services
{
    public class RackService : IRackService
    {
        IUnitOfWork dataBase;

        public RackService(string name)
        {
            dataBase = new EntityUnitOfWork(name);
        }

        public void AddProductToRack(int rackId, ProductViewModel productViewModel)
        {
            var rack = dataBase.Racks.Get(rackId);

            // Конфигурировани AutoMapper            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductViewModel, Product>());
            var mapper = new Mapper(config);

            // Отображение объекта ProductViewModel на объект Product           
            var product = mapper.Map<ProductViewModel, Product>(productViewModel);

            //// Определение цены для Product
            //student.IndividualPrice = studentViewModel.HasDiscount == true
            //                        ? group.BasePrice * (decimal)0.8
            //                        : group.BasePrice;

            // Добавить Product
            rack.Products.Add(product);
            // Сохранить изменения
            dataBase.Save();
        }

        public void CreateRack(RackViewModel rackvm)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RackViewModel, Rack>());
            var mapper = new Mapper(config);
            Rack rack = mapper.Map<RackViewModel, Rack>(rackvm);
            dataBase.Racks.Create(rack);
            dataBase.Save();
        }

        public void DeleteRack(int rackId)
        {
            dataBase.Racks.Delete(rackId);
            dataBase.Save();
        }

        public RackViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<RackViewModel> GetAll()
        {
            // Конфигурировани AutoMapper          
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<Rack, RackViewModel>();
            });
            var mapper = new Mapper(config);

            // Отображение List<Group> на ObservableCollection<GroupViewModel>
            var racks = mapper.Map<IEnumerable<Rack>, ObservableCollection<RackViewModel>>(dataBase.Racks.GetAll());
            return racks;
        }

        public void RemoveProductFromRack(int rackId, int productId)
        {
            dataBase.Products.Delete(productId);
            dataBase.Save();
        }

        public void UpdateProduct(ProductViewModel productViewModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductViewModel, Product>();
            });
            var mapper = new Mapper(config);
            Product product = mapper.Map<ProductViewModel, Product>(productViewModel);

            dataBase.Products.Update(product);
            dataBase.Save();
        }

        public void UpdateRack(RackViewModel rackvm)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductViewModel, Product>();
                cfg.CreateMap<RackViewModel, Rack>();
            });
            var mapper = new Mapper(config);
            Rack rack = mapper.Map<RackViewModel, Rack>(rackvm);

            dataBase.Racks.Update(rack);
            dataBase.Save();
        }
    }
}
