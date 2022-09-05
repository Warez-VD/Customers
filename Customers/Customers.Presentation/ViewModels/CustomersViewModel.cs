using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Customers.Data.Repositories.Interfaces;

namespace Customers.Presentation.ViewModels
{
    public class CustomersViewModel : INotifyPropertyChanged
    {
        private readonly ICustomerRepository _customerRepository;
        private ObservableCollection<CustomerDto> _customers;

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (_isRefreshing == value)
                    return;

                _isRefreshing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRefreshing)));
            }
        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CustomersViewModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _customers = new ObservableCollection<CustomerDto>();
            LoadDataCommand = new Command(() => LoadData());
            AddCustomerCommand = new Command(async () => await Shell.Current.GoToAsync("addcustomer"));

            MessagingCenter.Subscribe<AddCustomerViewModel>(this, "refresh", (sender) => LoadData());

            LoadData();
        }

        public ObservableCollection<CustomerDto> Customers
        {
            get => _customers;
            set => _customers = value;
        }

        public ICommand LoadDataCommand { get; private set; }

        public ICommand AddCustomerCommand { get; private set; }

        public void LoadData()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsRefreshing = true;
                IsBusy = true;

                var customers = 
                    _customerRepository
                        .GetAll()
                        .Select(x => new CustomerDto 
                        {
                            Id = x.Id,
                            Name = x.Name,
                            PhoneNumber = x.PhoneNumber
                        })
                        .ToList();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Customers.Clear();

                    foreach (var customer in customers)
                    {
                        Customers.Add(customer);
                    }
                });
            }
            finally
            {
                IsRefreshing = false;
                IsBusy = false;
            }
        }
    }
}
