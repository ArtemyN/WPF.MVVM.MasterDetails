using System.ComponentModel;
using System.Windows.Input;
using BusinessLayer;
using DomainModel;
using LogroconTestApp.WPFMasterDetails.Common;

namespace LogroconTestApp.WPFMasterDetails.ViewModel
{
    public class StreetsViewModel : ViewModelBase, IDataErrorInfo
    {
        private string _name;

        private ICommand _updateCommand;
        private ICommand _deleteCommand;
        private ICommand _cancelCommand;

        private StreetsViewModel _originalValue;

        public CitiesViewModel Cities
        {
            get;
            set;
        }

        public int StreetsId
        {
            get;
            set;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        
        public OperationType OperationType
        {
            get;
            set;
        }

        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new CommandBase(i => this.Update(), null);
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
                    _deleteCommand = new CommandBase(i => this.Delete(), null);
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
                    _cancelCommand = new CommandBase(i => this.Undo(), null);
                }
                return _cancelCommand;
            }
        }

        internal StreetsViewModel(Streets streets)
        {
            StreetsId = streets.Number;
            Name = streets.Name;
            _originalValue = (StreetsViewModel)MemberwiseClone();
        }

        internal StreetsViewModel()
        {
        }

        private void Update()
        {
            IBusinessLayer businessLayer = new BuinessLayer();

            if (OperationType == OperationType.Insert) 
            {
                businessLayer.AddStreet(new Streets
                {
                    Name = Name,
                    CityNumber = Cities.CitiesId
                });
                Cities.Streets = Cities.GetStreets();
            }
            else if (OperationType == OperationType.Update)
            {
                businessLayer.UpdateStreet(new Streets
                {
                    Number = StreetsId,
                    Name = Name,
                    CityNumber = Cities.CitiesId
                });
                _originalValue = (StreetsViewModel)MemberwiseClone();
            }
        }

        private void Delete()
        {
            IBusinessLayer businessLayer = new BuinessLayer();
            businessLayer.RemoveStreet(new Streets
            {
                Number = StreetsId,
                Name = Name,
                CityNumber = Cities.CitiesId
            });
            Cities.Streets = Cities.GetStreets();
        }

        private void Undo()
        {
            if (OperationType == OperationType.Update)
            {
                Name = _originalValue.Name;
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
