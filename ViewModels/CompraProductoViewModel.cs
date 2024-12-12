

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Examen_Mvvm.ViewModels
{
    public partial class CompraProductoViewModel: ObservableObject
    {
        [ObservableProperty] private double producto1;
        [ObservableProperty] private double producto2;
        [ObservableProperty] private double producto3;
        [ObservableProperty] private string subtotal;
        [ObservableProperty] private string descuento;
        [ObservableProperty] private string totalPagar;

        private void Alerta(string titulo, string mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(titulo, mensaje, "Aceptar"));
        }

        [RelayCommand] 
        private void Calcular()
        {
            if (validarEntradas() == true)
            {
                double subtotalR, descuentoR, totalPagarR;
                subtotalR = Producto1 + Producto2 + Producto3;
                descuentoR = calcularDescuento(subtotalR);
                totalPagarR = subtotalR - descuentoR;

                Subtotal = "Lps. " + Math.Round(subtotalR, 2);
                Descuento= "Lps. " + Math.Round(descuentoR, 2);
                TotalPagar= "Lps. " + Math.Round(totalPagarR, 2);
            }
            else
            {
                Alerta("ABVERTENCIA", "Corrige las entradas para generar la venta.");
            }
            


        }

        [RelayCommand]
        private void Limpiar()
        {
            Producto1 = 0;
            Producto2 = 0;
            Producto3 = 0;
            Subtotal = "0";
            Descuento = "0";
            TotalPagar = "0";
        }

        private double calcularDescuento(double subtotal)
        {
            double desc = 0;

            if(subtotal >=1000 && subtotal < 5000)
            {
                desc = subtotal*0.10;
                return desc;
            }else if(subtotal >=5000 &&  subtotal < 10000)
            {
                desc = subtotal * 0.20;
                return desc;
            }
            else if (subtotal >= 10000)
            {
                desc = subtotal * 0.30;
                return desc;
            }
            else
            {
                return 0;
            }

        }

        private bool validarEntradas()
        {
            if(Producto1 < 0)
            {
                Alerta("ERROR", "El costo del producto 1 debe ser mayor a 0");
                return false;
            } else if(Producto2 < 0)
            {
                Alerta("ERROR", "El costo del producto 2 debe ser mayor a 0");
                return false;
            } else if(Producto3 < 0)
            {
                Alerta("ERROR", "El costo del producto 3 debe ser mayor a 0");
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
