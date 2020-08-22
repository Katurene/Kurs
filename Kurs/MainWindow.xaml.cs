using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kurs.BusinessLayer.Interfaces;
using Kurs.BusinessLayer.Models;
using Kurs.BusinessLayer.Services;
using Kurs.Dialogs;

namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<RackViewModel> racks;
        IRackService rackService;

        public MainWindow()
        {
            InitializeComponent();
            rackService = new RackService("CoursesContextKurs");
            racks = rackService.GetAll();
            cBoxWork.DataContext = racks;
        }

        private void ButtonAddRack_Click(object sender, RoutedEventArgs e)
        {
            RackViewModel rackViewModel = new RackViewModel();
            //rackViewModel.Begin = new DateTime(1990, 01, 01);
            EditRack dialog = new EditRack(rackViewModel);
            var result = dialog.ShowDialog();
            if (result == true)
                rackService.CreateRack(rackViewModel);
            racks = rackService.GetAll();
            cBoxWork.DataContext = racks;
        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = new ProductViewModel();
            product.DateOfArrival = new DateTime(1990, 01, 01);
            var dialog = new EditProduct(product);
            var result = dialog.ShowDialog();
            if (result == true)
            {
                var rack = (RackViewModel)cBoxWork.SelectedItem;
                rack.Products.Add(product);
                rackService.AddProductToRack(rack.RackId, product);
                dialog.Close();
            }
        }

        private void cBoxRack_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete)
            {// удаление по клавише delete
                if (cBoxWork.SelectedIndex > -1)
                {
                    rackService.DeleteRack((cBoxWork.SelectedItem as RackViewModel).RackId);
                    racks = rackService.GetAll();
                    cBoxWork.DataContext = racks;
                    cBoxWork.SelectedIndex = 0;
                }
            }
            if (e.Key == System.Windows.Input.Key.Insert)
            {// обновление по клавише Insert                
                if (cBoxWork.SelectedIndex > -1)
                {
                    RackViewModel rackViewModel = cBoxWork.SelectedItem as RackViewModel;
                    EditRack dialog = new EditRack(rackViewModel);
                    var result = dialog.ShowDialog();
                    if (result == true)
                        rackService.UpdateRack(rackViewModel);
                    racks = rackService.GetAll();
                    cBoxWork.DataContext = racks;
                }
            }
        }

        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {            
            e.Row.Header = e.Row.GetIndex() + 1;
        }
        
        //удаляет только после перезапуска
        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (listBox.SelectedIndex > -1)
                {
                    int si = cBoxWork.SelectedIndex;
                    RackViewModel rackViewModel = cBoxWork.SelectedItem as RackViewModel;
                    ProductViewModel productViewModel = listBox.SelectedItem as ProductViewModel;

                    rackService.RemoveProductFromRack(rackViewModel.RackId, productViewModel.ProductId);
                    racks = rackService.GetAll();
                    cBoxWork.DataContext = racks;
                    cBoxWork.SelectedIndex = si;
                }              
            }
        }

        //изменяет только после перезапуска
        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex > -1)
            {
                ProductViewModel productViewModel = listBox.SelectedItem as ProductViewModel;
                var dialog = new EditProduct(productViewModel);
                var result = dialog.ShowDialog();
                if (result == true)
                {
                    rackService.UpdateProduct(productViewModel);
                    dialog.Close();
                }
            }
        }
    }
}
