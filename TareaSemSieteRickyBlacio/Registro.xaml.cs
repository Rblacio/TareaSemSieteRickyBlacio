using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TareaSemSieteRickyBlacio.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaSemSieteRickyBlacio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;

        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datosRegistro = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasena = txtContrasena.Text };
                con.InsertAsync(datosRegistro);
                Navigation.PushAsync(new Login());
            }
            catch (Exception)
            {

                DisplayAlert("Alerta", "Usuario ingresado", "ok");
            }

        }
    }
}