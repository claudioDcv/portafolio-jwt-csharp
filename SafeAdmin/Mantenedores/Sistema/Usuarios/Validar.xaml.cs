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

namespace SafeAdmin.Mantenedores.Sistema.Usuarios
{
    /// <summary>
    /// Lógica de interacción para Validar.xaml
    /// </summary>
    public partial class Validar : Window
    {
        string hash;
        Crear crear;
        public Validar(string hash, Crear crear)
        {
            InitializeComponent();
            this.hash = hash;
            this.crear = crear;
        }

        private void btnValidar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsuarioServices usuarioServicios = new UsuarioServices(this.hash);
                string rut = txtRut.Text;
                if (usuarioServicios.validateMedic(rut))
                {
                    crear.btnGuardar.IsEnabled = true;
                    MessageBox.Show("Medico válido.");
                    this.Close();
                }
                else
                {
                    crear.btnGuardar.IsEnabled = false;
                    MessageBox.Show("Medico no válido.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al validar el medico. Intente nuevamente.");
            }
        }
    }
}
