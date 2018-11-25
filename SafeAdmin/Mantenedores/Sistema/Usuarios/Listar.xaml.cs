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
                Services.EmpresaServices oEmpresaServicios = new Services.EmpresaServices(hash);
                IList<Usuario> oUsuarios = oUsuarioServicios.getAll();
                IList<UsuarioEmpresa> oUsuariosEmpresa = new List<UsuarioEmpresa>();
                foreach (Usuario item in oUsuarios)
                {
                    UsuarioEmpresa oUsuarioEmpresa = new UsuarioEmpresa();
                    oUsuarioEmpresa.id = item.id;
                    oUsuarioEmpresa.name = item.name;
                    oUsuarioEmpresa.surname = item.surname;
                    oUsuarioEmpresa.email = item.email;
                    oUsuarioEmpresa.profiles = item.profiles;
                    oUsuarioEmpresa.empresaFk = item.empresaFk;
                    if(oUsuarioEmpresa.empresaFk > 0)
                    {
                        oUsuarioEmpresa.nombreEmpresa = oEmpresaServicios.getOne(oUsuarioEmpresa.empresaFk).nombre;
                    }
                    oUsuariosEmpresa.Add(oUsuarioEmpresa);
                }
                grdUsuarios.ItemsSource = oUsuariosEmpresa;
            }
            catch (Exception ex)
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
