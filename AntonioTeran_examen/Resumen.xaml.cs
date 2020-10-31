using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AntonioTeran_examen
{
    public partial class Resumen : ContentPage
    {
        public double totalPagar = 0;
        public String usuario = "";

        public Resumen(String user, String nombre, double total)
        {
            InitializeComponent();
            usuario = lblUsuario.Text;
            lblUsuario.Text = usuario + user;

            txtNombre.Text = nombre;
            txtTotalPagar.Text = total.ToString();

        }
    }
}
