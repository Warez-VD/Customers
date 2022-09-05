using Customers.Presentation.ViewModels;

namespace Customers.Presentation.Pages;

public partial class CustomersPage : ContentPage
{
	public CustomersPage(CustomersViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

