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

namespace SafeAdmin.Mantenedores.Sistema.Examenes
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
                ExamenServices examenServicios = new ExamenServices(this.hash);
                IList<Examen> oExamenes = examenServicios.getAll();
                grdExamenes.ItemsSource = oExamenes;
            }
            catch (Exception)
            {

            }
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Crear crear = new Crear(this.hash);
            crear.Show();
            this.Close();
        }
    }
}
