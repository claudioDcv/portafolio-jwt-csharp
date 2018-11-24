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

namespace SafeAdmin.Mantenedores.Sistema.Personal
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
                TrabajadorServices oTrabajadorServicio = new TrabajadorServices(hash);
                IList<Trabajador> oTrabajadores = oTrabajadorServicio.getAllByCompanyId(empresaId);
                grdTrabajadores.ItemsSource = oTrabajadores;
            }
            catch (Exception)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Crear crear = new Crear(this.hash, this.empresaId);
            crear.Show();
            this.Close();
        }

        private void grdTrabajadores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = (DataGrid)sender;
                Trabajador oTrabajador = dg.SelectedItem as Trabajador;
                if (oTrabajador != null && oTrabajador.id > 0)
                {
                    var crear = new Crear(this.hash, oTrabajador.id, oTrabajador.empresaEntity.id);
                    crear.Show();
                    this.Close();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
