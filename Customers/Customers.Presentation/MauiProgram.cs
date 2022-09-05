using Customers.Data;
using Customers.Presentation.Common;
using Customers.Presentation.Pages;
using Customers.Presentation.ViewModels;

namespace Customers.Presentation;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<CustomersPage>();
		builder.Services.AddTransient<CustomersViewModel>();
		builder.Services.AddTransient<AddCustomerPage>();
		builder.Services.AddTransient<AddCustomerViewModel>();
		var dbPath = FileAccessHelper.GetLocalFilePath(Constants.DbName);
		builder.AddData(dbPath);

		return builder.Build();
	}
}
