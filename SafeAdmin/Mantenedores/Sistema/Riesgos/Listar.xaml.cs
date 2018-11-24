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

namespace SafeAdmin.Mantenedores.Sistema.Riesgos
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
                IList<TipoRiesgo> oTipoRiesgos = new List<TipoRiesgo>();
                TipoRiesgoServices tipoRiesgoServicios = new TipoRiesgoServices(this.hash);
                oTipoRiesgos = tipoRiesgoServicios.getAll();
                grdTipoRiesgos.ItemsSource = oTipoRiesgos;
            }
            catch (Exception)
            {

            }
        }

        private void grdTipoRiesgos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            TipoRiesgo oTipoRiesgo = dg.SelectedItem as TipoRiesgo;
            if (oTipoRiesgo != null && oTipoRiesgo.id > 0)
            {
                Crear crear = new Crear(hash, oTipoRiesgo.id);
                crear.Show();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Crear oCrear = new Crear(hash);
            oCrear.Show();
            this.Close();
        }
    }
}
