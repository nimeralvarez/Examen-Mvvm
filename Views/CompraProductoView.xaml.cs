using Examen_Mvvm.ViewModels;
namespace Examen_Mvvm.Views;

public partial class CompraProductoView : ContentPage
{
	CompraProductoViewModel viewModel;
	public CompraProductoView()
	{
		InitializeComponent();
		viewModel = new CompraProductoViewModel();
		BindingContext=viewModel;
	}
}