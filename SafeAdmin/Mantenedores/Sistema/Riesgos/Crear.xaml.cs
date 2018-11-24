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
using Modelo = DTO.Modelo;
using DTO.Servicios;

namespace SafeAdmin.Mantenedores.Sistema.Riesgos
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

        public Crear(string hash, int idRiesgos)
        {
            InitializeComponent();
            this.hash = hash;
            txtID.Text = idRiesgos.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Modelo.TipoRiesgo oTipoRiesgo = new Modelo.TipoRiesgo();
                TipoRiesgoServices tipoRiesgoServicios = new TipoRiesgoServices(this.hash);
                oTipoRiesgo.id = Convert.ToInt32(txtID.Text);
                oTipoRiesgo.nombre = txtNombre.Text;
                oTipoRiesgo.codigo = txtCodigo.Text;
                int resultado = tipoRiesgoServicios.create(oTipoRiesgo);
                if (resultado > 0)
                {
                    MessageBox.Show("Tipo de Riesgo guardado con exito.");
                    Listar listar = new Listar(this.hash);
                    listar.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el Tipo de Riesgo con los datos ingresados.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un problema al guardar el Tipo de Riesgo. Intente nuevamente");
            }
        }
    }
}
