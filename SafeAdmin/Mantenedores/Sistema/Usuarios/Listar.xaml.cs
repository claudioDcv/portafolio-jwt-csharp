using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DTO.Modelo;
using Services = DTO.Servicios;

namespace SafeAdmin.Mantenedores.Sistema.Usuarios
{
    /// <summary>
    /// Lógica de interacción para Listar.xaml
    /// </summary>
    public partial class Listar : Window
    {
        string hash;
        public Listar(string hash)
        {
            InitializeComponent();
            this.hash = hash;
            try
            {
                Services.UsuarioServices oUsuarioServicios = new Services.UsuarioServices(hash);

                IList<Usuario> oUsuarios = oUsuarioServicios.getAll();
                grdUsuarios.ItemsSource = oUsuarios;
            }
            catch (Exception)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var crear = new Sistema.Usuarios.Crear(this.hash);
            crear.Show();
            this.Close();
        }

        private void grdUsuarios_MouseDoubleClick(object sender, SelectionChangedEventArgs e)
        {
            
            DataGrid dg = (DataGrid)sender;
            Usuario oUsuario = dg.SelectedItem as Usuario;
            if(oUsuario != null && oUsuario.id > 0)
            {
                var crear = new Sistema.Usuarios.Crear(this.hash,oUsuario.id);
                crear.Show();
                this.Close();
            }
        }
    }
}
