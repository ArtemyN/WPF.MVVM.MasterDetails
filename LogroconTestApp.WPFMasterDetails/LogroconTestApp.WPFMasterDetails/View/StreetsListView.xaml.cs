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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogroconTestApp.WPFMasterDetails.ViewModel;

namespace LogroconTestApp.WPFMasterDetails.View
{
    /// <summary>
    /// Interaction logic for StreetsListView.xaml
    /// </summary>
    public partial class StreetsListView : UserControl
    {
        public StreetsListView()
        {
            InitializeComponent();
        }

        private void btnAddStreet_Click(object sender, RoutedEventArgs e)
        {
            StreetsView view = new StreetsView();
            StreetsViewModel street = new StreetsViewModel();

            street.Cities = (CitiesViewModel)DataContext;
            street.OperationType = OperationType.Insert;
            view.DataContext = street;
            view.ShowDialog();
        }

        private void btnEditStreet_Click(object sender, RoutedEventArgs e)
        {
            StreetsView view = new StreetsView();
            StreetsViewModel street = (StreetsViewModel)((Button)sender).DataContext;
            street.OperationType = OperationType.Update;
            view.DataContext = street;
            view.ShowDialog();
        }
    }
}
