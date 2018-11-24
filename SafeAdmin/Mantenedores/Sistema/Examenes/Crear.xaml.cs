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
    /// Lógica de interacción para Crear.xaml
    /// </summary>
    public partial class Crear : Window
    {
        string hash;
        public Crear(string hash)
        {
            InitializeComponent();
            this.hash = hash;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Examen oExamen = new Examen();
                ExamenServices examenServicios = new ExamenServices(this.hash);
                oExamen.id = Convert.ToInt32(txtID.Text);
                oExamen.nombre = txtNombre.Text;
                oExamen.codigo = txtCodigo.Text;
                int resultado = examenServicios.create(oExamen);
                if(resultado > 0)
                {
                    MessageBox.Show("Examen guardado con exito.");
                    Listar listar = new Listar(this.hash);
                    listar.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Examen no pudo ser guardado con los datos ingresados.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al tratar de guardar el examen. Intente nuevamente.");
            }
        }
    }
}
