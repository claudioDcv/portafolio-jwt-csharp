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

namespace SafeAdmin.Mantenedores.Sistema.Instalacion
{
    /// <summary>
    /// Lógica de interacción para Crear.xaml
    /// </summary>
    public partial class Crear : Window
    {
        string hash;
        int empresaId;
        public Crear(string hash, int empresaId)
        {
            InitializeComponent();
            this.hash = hash;
            try
            {
                this.empresaId = empresaId;
                txtIDEmpresa.Text = empresaId.ToString();
            }
            catch (Exception)
            {

            }
        }

        public Crear(string hash, int empresaId, int instalacionId)
        {
            InitializeComponent();
            this.hash = hash;
            try
            {
                this.empresaId = empresaId;
                InstalacionServices instalacionServicios = new InstalacionServices(this.hash);
                DTO.Modelo.Instalacion oInstalacion = instalacionServicios.getOne(instalacionId);
                if (oInstalacion.id > 0)
                {
                    txtCodigo.Text = oInstalacion.codigo;
                    txtID.Text = oInstalacion.id.ToString();
                    txtIDEmpresa.Text = oInstalacion.empresaEntity.id.ToString();
                    txtNombre.Text = oInstalacion.nombre;
                    lblTitulo.Text = "Editar Instalación";
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Modelo.Instalacion oInstalacion = new Modelo.Instalacion();
                InstalacionServices instalacionServicios = new InstalacionServices(this.hash);
                oInstalacion.id = Convert.ToInt32(txtID.Text);
                oInstalacion.nombre = txtNombre.Text;
                oInstalacion.codigo = txtCodigo.Text;
                oInstalacion.empresaEntity.id = Convert.ToInt32(txtIDEmpresa.Text);
                string respuesta = instalacionServicios.create(oInstalacion);
                int id = default(int);
                if (respuesta.Length > 0 && int.TryParse(respuesta, out id))
                {
                    if(id > 0)
                    {
                        MessageBox.Show("Instalación creada con exito.");
                        Listar listar = new Listar(this.hash, this.empresaId);
                        listar.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo crear la instalación con los datos ingresados.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al tratar de crear la instalación.");
            }
        }
    }
}
