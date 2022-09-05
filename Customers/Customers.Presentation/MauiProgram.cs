using Customers.Data;
using Customers.Presentation.Common;
using Customers.Presentation.Pages;

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
		var dbPath = FileAccessHelper.GetLocalFilePath("Customers.db3");
        builder.AddData(dbPath);

        return builder.Build();
	}
}
