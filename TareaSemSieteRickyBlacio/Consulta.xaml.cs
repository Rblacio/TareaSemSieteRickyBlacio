using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Consulta : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tablaEstudiante;

        public Consulta()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            get();
        }
        public async void get()
        {
            try
            {
                var Resultado = await con.Table<Estudiante>().ToListAsync();
                tablaEstudiante = new ObservableCollection<Estudiante>(Resultado);
                listaUsuario.ItemsSource = tablaEstudiante;
                
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void listaUsuario_ItemSelected_2(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var item = obj.Id.ToString();
            var ID = Convert.ToInt32(item);
            var nombreItem = obj.Nombre;
            string nombre = nombreItem.ToString();

            var usuarioIten = obj.Usuario;
            string usuario = usuarioIten.ToString();

            var contrasenaIten = obj.Contrasena;
            string contrasena = usuarioIten.ToString();

            Navigation.PushAsync(new Elemento(ID, nombre, usuario, contrasena));
        }
    }
}