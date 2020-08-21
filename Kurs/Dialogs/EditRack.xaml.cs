using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Kurs.BusinessLayer.Models;

namespace Kurs.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для EditRack.xaml
    /// </summary>
    public partial class EditRack : Window
    {
        RackViewModel rackViewModel;
        public EditRack(RackViewModel rackViewModel)
        {
            InitializeComponent();
            this.rackViewModel = rackViewModel;
            grid.DataContext = rackViewModel;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
