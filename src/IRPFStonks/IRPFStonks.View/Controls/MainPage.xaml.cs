using IRPFStonks.View.ViewModel;

namespace IRPFStonks.View;

public partial class MainPage : ContentPage
{

	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

