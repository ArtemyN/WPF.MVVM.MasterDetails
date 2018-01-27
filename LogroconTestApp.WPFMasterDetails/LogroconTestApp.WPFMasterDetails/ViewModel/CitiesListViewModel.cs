using System.Collections.ObjectModel;
using System.Windows.Input;
using BusinessLayer;
using LogroconTestApp.WPFMasterDetails.Common;
using LogroconTestApp.WPFMasterDetails.Interface;
using LogroconTestApp.WPFMasterDetails.View;

namespace LogroconTestApp.WPFMasterDetails.ViewModel
{
    public class CitiesListViewModel : ViewModelBase
    {
        private static CitiesListViewModel _instance;

        private CitiesViewModel _selectedCity;

        private ObservableCollection<CitiesViewModel> _citiesList;

        private ICommand _showAddCommand;

        public ObservableCollection<CitiesViewModel> CitiesList
        {
            get => GetCitiess();
            set
            {
                _citiesList = value;
                OnPropertyChanged("CitiesList");
            }
        }

        public CitiesViewModel SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged("SelectedCity");
            }
        }

        public ICommand ShowAddCommand
        {
            get
            {
                if (_showAddCommand == null)
                {
                    _showAddCommand = new CommandBase(i => ShowAddDialog(), null);
                }
                return _showAddCommand;
            }
        }

        private CitiesListViewModel()
        {
            CitiesList = GetCitiess();
        }

        public static CitiesListViewModel Instance()
        {
            if (_instance == null)
                _instance = new CitiesListViewModel();
            return _instance;
        }

        internal ObservableCollection<CitiesViewModel> GetCitiess()
        {
            if (_citiesList == null)
                _citiesList = new ObservableCollection<CitiesViewModel>();
            _citiesList.Clear();

            IBusinessLayer businessLayer = new BuinessLayer();

            foreach (var i in businessLayer.GetAllCities())
            {
                CitiesViewModel cities = new CitiesViewModel(i);
                _citiesList.Add(cities);
            }
            return _citiesList;
        }

        private void ShowAddDialog()
        {
            CitiesViewModel cities = new CitiesViewModel();
            cities.OperationType = OperationType.Insert;

            IModalDialog dialog = new CitiesViewDialog();
            dialog.BindViewModel(cities);
            dialog.ShowDialog();
        }

    }
}
