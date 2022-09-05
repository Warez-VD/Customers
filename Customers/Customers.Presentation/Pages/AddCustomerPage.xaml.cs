using Customers.Presentation.ViewModels;

namespace Customers.Presentation.Pages;

public partial class AddCustomerPage : ContentPage
{
    private AddCustomerViewModel _viewModel;

    public AddCustomerPage(AddCustomerViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
	}
}