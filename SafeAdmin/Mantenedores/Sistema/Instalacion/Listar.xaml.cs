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

namespace SafeAdmin.Mantenedores.Sistema.Instalacion
{
    /// <summary>
    /// Lógica de interacción para Listar.xaml
    /// </summary>
    public partial class Listar : Window
    {
        string hash;
        int empresaId;
        public Listar(string hash, int empresaId)
        {
            InitializeComponent();
            this.hash = hash;
            try
            {
                this.empresaId = empresaId;
                InstalacionServices instalacionServicios = new InstalacionServices(hash);
                IList<DTO.Modelo.Instalacion> oInstalaciones = instalacionServicios.getAllByCompanyId(empresaId);
                grdInstalaciones.ItemsSource = oInstalaciones;
            }
            catch (Exception)
            {

            }
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Crear crear = new Crear(this.hash, this.empresaId);
                crear.Show();
                this.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void grdInstalaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = (DataGrid)sender;
                DTO.Modelo.Instalacion oInstalacion = dg.SelectedItem as DTO.Modelo.Instalacion;
                if (oInstalacion != null && oInstalacion.id > 0)
                {
                    var crear = new Crear(this.hash, oInstalacion.empresaEntity.id, oInstalacion.id);
                    crear.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
