using Customers.Data.Repositories;
using Customers.Data.Repositories.Interfaces;

namespace Customers.Presentation.Pages;

public partial class CustomersPage : ContentPage
{
	int count = 0;

	public CustomersPage(ICustomerRepository customerRepository)
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

