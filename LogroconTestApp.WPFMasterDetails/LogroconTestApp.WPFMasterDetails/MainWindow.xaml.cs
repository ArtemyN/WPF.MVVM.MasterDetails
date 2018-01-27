using System.Windows;
using LogroconTestApp.WPFMasterDetails.ViewModel;

namespace LogroconTestApp.WPFMasterDetails
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = CitiesListViewModel.Instance();
        }
    }
}
