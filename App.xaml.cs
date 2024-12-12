using Examen_Mvvm.Views;
namespace Examen_Mvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new CompraProductoView());
        }
    }
}