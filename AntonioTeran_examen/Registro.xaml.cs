using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AntonioTeran_examen
{
    public partial class Registro : ContentPage
    {

        public double totalPagar = 0;
        public String usuarioLog = "";

        public Registro(String user, String password)
        {
            InitializeComponent();
            String usuario = lblUsuario.Text;
            lblUsuario.Text = usuario + user;
            usuarioLog = user;
        }

        private async void btnGuardar_Clicked(System.Object sender, System.EventArgs e)
        {
            bool saltoPaginaResumen = false;
            String nombre = txtNombre.Text;
            totalPagar = 0;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                await DisplayAlert("Mensaje", "Porfavor ingresar un Nombre para continuar ", "ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMontoInicial.Text))
            {
                await DisplayAlert("Mensaje", "Porfavor ingresar un Monto para continuar ", "ok");
                return;
            }

            saltoPaginaResumen = calcular();

            if (saltoPaginaResumen == true)
            {
                await DisplayAlert("Excelente", "Elemento Guardado conExito! " + nombre, "ok");
                await Navigation.PushAsync(new Resumen(usuarioLog, nombre, totalPagar));
            }




        }

        void btnCalcular_Clicked(System.Object sender, System.EventArgs e)
        {
            calcular();


        }


        public bool calcular()
        {
            double totalCuota = 1800;
            double interes = 0.05;


            try
            {
                double montoInicial = Convert.ToDouble(txtMontoInicial.Text);
                if (montoInicial >= 0 && montoInicial <= 1800)
                {



                    double montoCalcular = totalCuota - montoInicial;
                    double cuota = (montoCalcular / 3);
                    double cuotaInteres = (cuota * interes) + cuota;


                    txtPagoMensual.Text = cuotaInteres.ToString();

                    totalPagar = cuotaInteres * 3;
                    return true;
                }
                else
                {
                    DisplayAlert("Mensaje", "Porfavor ingresar un valor entre 0 a 1800 ", "ok");
                    return false;
                }




            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje", ex.Message, "ok");
                return false;
            }



        }

    }
}
