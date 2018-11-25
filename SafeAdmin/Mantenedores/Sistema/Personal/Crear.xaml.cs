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
    /// Lógica de interacción para Crear.xaml
    /// </summary>
    public partial class Crear : Window
    {
        string hash;

        public Crear(string hash, int idEmpresa)
        {
            InitializeComponent();
            this.hash = hash;
            try
            {
                txtEmpresaID.Text = idEmpresa.ToString();
                TipoRiesgoServices tipoRiesgoServicios = new TipoRiesgoServices(this.hash);
                IList<TipoRiesgo> oTipoRiesgos = tipoRiesgoServicios.getAll();
                lstReisgos.ItemsSource = oTipoRiesgos;
            }
            catch (Exception)
            {

            }

        }
        public Crear(string hash, int idTrabajador, int idEmpresa)
        {
            InitializeComponent();
            this.hash = hash;
            try
            {
                TrabajadorServices trabajadorServicios = new TrabajadorServices(this.hash);
                Trabajador oTrabajador = trabajadorServicios.getOne(idTrabajador);
                TipoRiesgoServices tipoRiesgoServicios = new TipoRiesgoServices(this.hash);
                IList<TipoRiesgo> oTipoRiesgos = tipoRiesgoServicios.getAll();
                lstReisgos.ItemsSource = oTipoRiesgos;
                if (oTrabajador.id > 0)
                {
                    lblTitulo.Text = "Editar Trabajador";
                    txtID.Text = oTrabajador.id.ToString();
                    txtEmpresaID.Text = oTrabajador.empresaEntity.id.ToString();
                    txtNombre.Text = oTrabajador.nombre;
                    txtApellidoPaterno.Text = oTrabajador.apellidoPaterno;
                    txtApellidoMaterno.Text = oTrabajador.apellidoMaterno;
                    txtEmail.Text = oTrabajador.email;
                    txtRut.Text = oTrabajador.run;
                    foreach (var tmp in lstReisgos.Items)
                    {
                        if (oTrabajador.riesgosEntity.Any(x => x.id == ((TipoRiesgo)tmp).id))
                        {
                            int indice = lstReisgos.Items.IndexOf(tmp);
                            lstReisgos.SelectedItems.Add(tmp);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Trabajador oTrabajador = new Trabajador();
                TrabajadorServices trabajadorServicios = new TrabajadorServices(this.hash);
                oTrabajador.id = Convert.ToInt32(txtID.Text);
                oTrabajador.run = txtRut.Text;
                oTrabajador.nombre = txtNombre.Text;
                oTrabajador.apellidoPaterno = txtApellidoPaterno.Text;
                oTrabajador.apellidoMaterno = txtApellidoMaterno.Text;
                oTrabajador.email = txtEmail.Text;
                oTrabajador.empresaEntity.id = Convert.ToInt32(txtEmpresaID.Text);
                foreach (var tmp in lstReisgos.SelectedItems)
                {
                    oTrabajador.riesgosEntity.Add((TipoRiesgo)tmp);
                }
                if (oTrabajador.id > 0)
                {
                    string respuesta = trabajadorServicios.assignRisks(oTrabajador);
                    MessageBox.Show("Riesgos asignados con exito.");
                    Listar listarTrabajadores = new Listar(this.hash, oTrabajador.empresaEntity.id);
                    listarTrabajadores.Show();
                    this.Close();
                }
                else
                {
                    string respuesta = trabajadorServicios.create(oTrabajador);
                    int id = default(int);
                    if (respuesta.Length > 0 && int.TryParse(respuesta, out id))
                    {

                        oTrabajador.id = id;
                        respuesta = trabajadorServicios.assignRisks(oTrabajador);
                        MessageBox.Show("Trabajador creado con exito.");
                        Listar listarTrabajadores = new Listar(this.hash, oTrabajador.empresaEntity.id);
                        listarTrabajadores.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear trabajador con los datos ingresados.");
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un problema al tratar de guardar el trabajador.");
            }
        }
    }
}
