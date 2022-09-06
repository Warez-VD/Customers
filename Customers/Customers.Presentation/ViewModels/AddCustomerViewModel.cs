using System.ComponentModel;
using System.Windows.Input;
using Customers.Data.Entities;
using Customers.Data.Repositories.Interfaces;

namespace Customers.Presentation.ViewModels
{
    public class AddCustomerViewModel : INotifyPropertyChanged
    {
        private readonly ICustomerRepository _customerRepository;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DoneEditingCommand { get; private set; }

        public ICommand SaveCommand { get; private set; }

        string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                {
                    return;
                }

                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (_phoneNumber == value)
                {
                    return;
                }

                _phoneNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhoneNumber)));
            }
        }

        public AddCustomerViewModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            DoneEditingCommand = new Command(async () => await DoneEditing());
            SaveCommand = new Command(async () => await SaveData());
        }

        private async Task SaveData()
        {
            var customer = new Customer()
            {
                Name = Name,
                PhoneNumber = PhoneNumber
            };
            _customerRepository.Create(customer);

            MessagingCenter.Send(this, "refresh");

            await Shell.Current.GoToAsync("..");
        }

        private async Task DoneEditing()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
