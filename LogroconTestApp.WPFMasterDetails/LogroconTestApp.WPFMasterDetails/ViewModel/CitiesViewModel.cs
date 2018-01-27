using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using BusinessLayer;
using DomainModel;
using LogroconTestApp.WPFMasterDetails.Common;
using LogroconTestApp.WPFMasterDetails.Interface;
using LogroconTestApp.WPFMasterDetails.View;

namespace LogroconTestApp.WPFMasterDetails.ViewModel
{
    public class CitiesViewModel : ViewModelBase, IDataErrorInfo
    {
        private string _name;
        private string _region;
        private bool _isRegionCenter;
        private ObservableCollection<StreetsViewModel> _streets;

        private ICommand _showEditCommand;

        private ICommand _updateCommand;

        private ICommand _deleteCommand;

        private ICommand _cancelCommand;

        private CitiesViewModel _originalValue;

        public int CitiesId { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public bool IsRegionCenter
        {
            get { return _isRegionCenter; }
            set
            {
                _isRegionCenter = value;
                OnPropertyChanged("IsRegionCenter");
            }
        }

        public string Region
        {
            get { return _region; }
            set
            {
                _region = value;
                OnPropertyChanged("Region");
            }
        }

        public OperationType OperationType { get; set; }

        public CitiesListViewModel Container
        {
            get { return CitiesListViewModel.Instance(); }
        }

        public ObservableCollection<StreetsViewModel> Streets
        {
            get { return GetStreets(); }
            set
            {
                _streets = value;
                OnPropertyChanged("Streets");
            }
        }

        public ICommand ShowEditCommand
        {
            get
            {
                if (_showEditCommand == null)
                {
                    _showEditCommand = new CommandBase(i => ShowEditDialog(), null);
                }
                return _showEditCommand;
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new CommandBase(i => Update(), null);
                }
                return _updateCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new CommandBase(i => Delete(), null);
                }
                return _deleteCommand;
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new CommandBase(i => Undo(), null);
                }
                return _cancelCommand;
            }
        }

        public CitiesViewModel(Cities c)
        {
            CitiesId = c.Number;
            Name = c.Name;
            Region = c.Region;
            IsRegionCenter = c.IsRegionCenter;

            _originalValue = (CitiesViewModel)MemberwiseClone();
        }

        internal CitiesViewModel()
        {
        }

        internal ObservableCollection<StreetsViewModel> GetStreets()
        {
            _streets = new ObservableCollection<StreetsViewModel>();
            IBusinessLayer businessLayer = new BuinessLayer();
            foreach (var i in businessLayer.GetStreetssByCitiesNumber(CitiesId))
            {
                StreetsViewModel street = new StreetsViewModel(i);
                street.Cities = this;
                _streets.Add(street);
            }
            return _streets;
        }

        private void ShowEditDialog()
        {
            OperationType = OperationType.Update;

            IModalDialog dialog = new CitiesViewDialog();
            dialog.BindViewModel(this);
            dialog.ShowDialog();
        }

        private void Update()
        {
            IBusinessLayer businessLayer = new BuinessLayer();
            if (OperationType == OperationType.Insert)
            {
                businessLayer.AddCities(new Cities
                {
                    Number = CitiesId,
                    Name = Name,
                    Region = Region,
                    IsRegionCenter = IsRegionCenter,
                });
                Container.CitiesList = Container.GetCitiess();
            }
            else if (OperationType == OperationType.Update)
            {
                businessLayer.UpdateCities(new Cities
                {
                    Number = CitiesId,
                    Name = Name,
                    Region = Region,
                    IsRegionCenter = IsRegionCenter
                });
                _originalValue = (CitiesViewModel)MemberwiseClone();
            }
        }

        private void Delete()
        {
            IBusinessLayer businessLayer = new BuinessLayer();
            businessLayer.RemoveCities(new Cities
            {
                Number = CitiesId,
                Name = Name,
                Region = Region,
                IsRegionCenter = IsRegionCenter
            });
            Container.CitiesList = Container.GetCitiess();
        }

        private void Undo()
        {
            if (OperationType == OperationType.Update)
            {
                Name = _originalValue.Name;
                Region = _originalValue.Region;
                IsRegionCenter = _originalValue.IsRegionCenter;
            }
        }

        #region IDataErrorInfo Members

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (columnName == "Name")
                {
                    if (Name == null)
                        return "Please enter a Name";
                    if (Name.Trim() == string.Empty)
                        return "Name is Required";
                }
                if (columnName == "Region")
                {
                    if (Name == null)
                        return "Please enter a Region";
                    if (Name.Trim() == string.Empty)
                        return "Region is Required";
                }
                return null;
            }
        }

        string IDataErrorInfo.Error
        {
            get { return string.Empty; }
        }

        #endregion
    }
}