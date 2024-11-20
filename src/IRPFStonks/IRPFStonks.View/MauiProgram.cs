using CommunityToolkit.Maui;
using IRPFStonks.View.Controls;
using IRPFStonks.View.ViewModel;

namespace IRPFStonks.View;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("materialdesignicons-webfont.ttf", "MaterialDesignIcons");
            });

		builder.Services.AddSingleton<MainPage, MainViewModel>();

		builder.Services.AddSingleton<MainPageHeader, MainPageHeaderViewModel>();

		builder.Services.AddSingleton(FilePicker.Default);

        return builder.Build();
	}
}
