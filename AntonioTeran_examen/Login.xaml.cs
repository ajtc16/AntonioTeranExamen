using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AntonioTeran_examen
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(System.Object sender, System.EventArgs e)
        {
            String usuarioAut = "estudiante2020";
            String passAut = "uisrael2020";


            String user = txtUsuario.Text;
            String password = txtPassword.Text;

            if (usuarioAut.Equals(user))
            {

                if (passAut.Equals(password))
                {

                    DisplayAlert("Bienvenido", "Se ha autenticado Exitosamente " + user, "ok");
                    await Navigation.PushAsync(new Registro(user, password));
                }
                else
                {
                    DisplayAlert("Mensaje", "Contraseña incorrecta para usario " + user, "ok");
                }


            }
            else
            {
                DisplayAlert("Mensaje", "Usuario incorrecto" + user, "ok");

            }
        }
    }
}
