using Customers.Presentation.Pages;

namespace Customers.Presentation;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("addcustomer", typeof(AddCustomerPage));
	}
}
