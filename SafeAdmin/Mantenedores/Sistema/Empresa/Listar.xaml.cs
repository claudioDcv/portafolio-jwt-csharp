using System;
using System.Collections.Generic;
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
using DTO.Servicios;

namespace SafeAdmin.Mantenedores.Sistema.Empresa
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
                EmpresaServices oEmpresaServicios = new EmpresaServices(hash);
                IList<DTO.Modelo.Empresa> oEmpresas = oEmpresaServicios.getAll();
                grdEmpresas.ItemsSource = oEmpresas.OrderBy(x => x.id);
            }
            catch (Exception)
            {

            }
        }

        private void grdEmpresas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DTO.Modelo.Empresa oEmpresa = dg.SelectedItem as DTO.Modelo.Empresa;
            if (oEmpresa != null && oEmpresa.id > 0)
            {
                var crear = new Sistema.Empresa.Crear(this.hash, oEmpresa.id);
                crear.Show();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Crear crear = new Crear(this.hash);
            crear.Show();
            this.Close();
        }
    }
}
