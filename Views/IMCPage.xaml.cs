using IMCMVVM_CALC.ViewModels;

namespace IMCMVVM_CALC.Views;

public partial class IMCPage : ContentPage
{
	public IMCPage()
	{
		InitializeComponent();
		//conecta la pantalla con sus datos y comandos del viewmodel
		BindingContext = new IMCViewMoel();
	}
}