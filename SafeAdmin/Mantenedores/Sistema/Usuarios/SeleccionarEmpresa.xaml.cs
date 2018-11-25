using DTO.Servicios;
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

namespace SafeAdmin.Mantenedores.Sistema.Usuarios
{
    /// <summary>
    /// Lógica de interacción para SeleccionarEmpresa.xaml
    /// </summary>
    public partial class SeleccionarEmpresa : Window
    {
        string hash;
        TextBox crear;
        public SeleccionarEmpresa(string hash, ref TextBox crear)
        {
            InitializeComponent();
            try
            {
                this.hash = hash;
                this.crear = crear;
                EmpresaServices oEmpresaServicios = new EmpresaServices(hash);
                IList<DTO.Modelo.Empresa> oEmpresas = oEmpresaServicios.getAll();
                grdEmpresas.ItemsSource = oEmpresas.OrderBy(x => x.id);
            }
            catch (Exception ex)
            {

            }
        }

        private void grdEmpresas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = (DataGrid)sender;
                DTO.Modelo.Empresa oEmpresa = dg.SelectedItem as DTO.Modelo.Empresa;
                if (oEmpresa != null && oEmpresa.id > 0)
                {
                    crear.Text = oEmpresa.id.ToString();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
