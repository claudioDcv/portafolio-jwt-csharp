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

namespace SafeAdmin.Mantenedores.Sistema.Empresa
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

        public Crear(string hash, int id)
        {
            InitializeComponent();
            this.hash = hash;
            try
            {
                EmpresaServices oEmpresaServicios = new EmpresaServices(this.hash);
                DTO.Modelo.Empresa oEmpresa = oEmpresaServicios.getOne(id);
                if (oEmpresa.id > 0)
                {
                    txtID.Text = oEmpresa.id.ToString();
                    txtNombre.Text = oEmpresa.nombre;
                    txtDireccion.Text = oEmpresa.direccion;
                    txtTelefono.Text = oEmpresa.telefono;
                    txtEmail.Text = oEmpresa.email;
                    lblTitulo.Text = "Editar Empresa";

                    btnInstalacion.Visibility = Visibility.Visible;
                    btnTrabajador.Visibility = Visibility.Visible;
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
                DTO.Modelo.Empresa oEmpresa = new DTO.Modelo.Empresa();
                EmpresaServices oEmpresaServicios = new EmpresaServices(this.hash);
                oEmpresa.id = Convert.ToInt32(txtID.Text);
                oEmpresa.nombre = txtNombre.Text;
                oEmpresa.direccion = txtDireccion.Text;
                oEmpresa.telefono = txtTelefono.Text;
                oEmpresa.email = txtEmail.Text;
                string respuesta = string.Empty;
                int id = default(int);
                if (oEmpresa.id > 0)
                {
                    respuesta = oEmpresaServicios.update(oEmpresa);
                    if (respuesta.Length > 0 && int.TryParse(respuesta, out id))
                    {
                        if(id > 0)
                        {
                            MessageBox.Show("Empresa actualizada con exito.");
                            Listar listar = new Listar(this.hash);
                            listar.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar la empresa con los datos ingresados.");
                    }
                }
                else
                {
                    respuesta = oEmpresaServicios.create(oEmpresa);
                    if (respuesta.Length > 0 && int.TryParse(respuesta, out id))
                    {
                        MessageBox.Show("Empresa creada con exito.");
                        Listar listar = new Listar(this.hash);
                        listar.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar la empresa con los datos ingresados.");
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnTrabajador_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtID.Text);
                Personal.Listar listar = new Personal.Listar(this.hash, id);
                listar.Show();
                this.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnInstalacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtID.Text);
                Instalacion.Listar listar = new Instalacion.Listar(this.hash, id);
                listar.Show();
                this.Close();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
