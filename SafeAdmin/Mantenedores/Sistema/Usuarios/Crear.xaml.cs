using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Services = DTO.Servicios;

namespace SafeAdmin.Mantenedores.Sistema.Usuarios
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
            try
            {
                Services.PerfilServices oPerfilServicios = new Services.PerfilServices(hash);
                IList<Perfil> oPerfiles = oPerfilServicios.getAll();
                lstPerfiles.ItemsSource = oPerfiles;
                lblTitulo.Content = "Crear Usuario";
            }
            catch (Exception)
            {

            }
        }

        public Crear(string hash, int id)
        {
            InitializeComponent();
            this.hash = hash;
            try
            {
                Services.UsuarioServices oUsuarioServicios = new Services.UsuarioServices(hash);
                Services.PerfilServices oPerfilServicios = new Services.PerfilServices(hash);
                Services.EmpresaServices oEmpresaServicios = new Services.EmpresaServices(hash);
                Usuario oUsuario = oUsuarioServicios.getOne(id);
                IList<Perfil> oPerfiles = oPerfilServicios.getAll();
                lstPerfiles.ItemsSource = oPerfiles;
                txtID.Text = oUsuario.id.ToString();
                txtEmail.Text = oUsuario.email;
                txtNombre.Text = oUsuario.name;
                txtApellido.Text = oUsuario.surname;
                if(oUsuario.empresaFk > 0)
                {
                    lblEmpresa.Text = "Empresa Asignada: " + oEmpresaServicios.getOne(oUsuario.empresaFk).nombre;
                }
                lblPassword.Visibility = Visibility.Collapsed;
                txtPassword.Visibility = Visibility.Collapsed;
                //foreach (var tmp in lstPerfiles.Items)
                //{
                //    if(oUsuario.profiles.Any(x => x.id == ((Perfil)tmp).id))
                //    {
                //        int indice = lstPerfiles.Items.IndexOf(tmp);
                //        lstPerfiles.SelectedItems.Add(tmp);
                //    }
                //}
                lstPerfiles.SelectedItems.Add(oUsuario.profiles);
                lblTitulo.Content = "Editar Usuario";
                btnBloquear.Visibility = Visibility.Visible;
                txtEmpresaID.Text = oUsuario.empresaFk.ToString();
            }
            catch(Exception ex)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Services.UsuarioServices usuarioServices = new Services.UsuarioServices(this.hash);
                Usuario oUsuario = new Usuario();
                oUsuario.id = txtID.Text != "" ? Convert.ToInt32(txtID.Text) : 0;
                oUsuario.name = txtNombre.Text;
                oUsuario.surname = txtApellido.Text;
                oUsuario.email = txtEmail.Text;
                oUsuario.hash = txtPassword.Password;
                oUsuario.empresaFk = Convert.ToInt32(txtEmpresaID.Text);
                foreach(var tmp in lstPerfiles.SelectedItems)
                {
                    oUsuario.profiles.Add((Perfil)tmp);
                }
                string respuesta = string.Empty;
                int id = default(int);
                if (oUsuario.id > 0)
                {
                    respuesta = usuarioServices.update(oUsuario);
                    if(int.TryParse(respuesta, out id))
                    {
                        if (id == 0)
                        {
                            MessageBox.Show("El usuario no se puede actualizar con los datos ingresados.");
                            return;
                        }
                    }
                }
                else
                {
                    respuesta = usuarioServices.create(oUsuario);
                }
                

                if(oUsuario.id > 0)
                {
                    respuesta = usuarioServices.asignProfiles(oUsuario);
                    MessageBox.Show("Usuario actualizado con éxito.");
                    Listar listar = new Listar(hash);
                    listar.Show();
                    this.Close();
                }
                else
                {
                    if (respuesta.Length > 0 && int.TryParse(respuesta, out id))
                    {
                        if(id > 0)
                        {
                            oUsuario.id = id;
                            respuesta = usuarioServices.asignProfiles(oUsuario);
                            MessageBox.Show("Usuario guardado con éxito.");
                            Listar listar = new Listar(hash);
                            listar.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Usuario no se pudo guardar.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario no se pudo guardar.");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hubo un problema con el guardado de Usuario. Intente nuevamente");
            }
        }

        private void btnBloquear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Services.UsuarioServices usuarioServices = new Services.UsuarioServices(hash);
                Usuario oUsuario = new Usuario();
                oUsuario.id = txtID.Text != "" ? Convert.ToInt32(txtID.Text) : 0;
                oUsuario.profiles = new List<Perfil>();
                string respuesta = usuarioServices.asignProfiles(oUsuario);
                int id = default(int);
                if (respuesta.Length > 0 && int.TryParse(respuesta, out id))
                {
                    if(id > 0)
                    {
                        MessageBox.Show("Usuario bloqueado con éxito.");
                        Listar listar = new Listar(hash);
                        listar.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnValidar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validar validar = new Validar(this.hash, this);
                btnGuardar.IsEnabled = false;
                validar.Show();
            }
            catch (Exception ex)
            {
            }
        }


        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                bool valido = ValidarMail(email);
                if (valido)
                {
                    btnGuardar.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Formato de correo inválido.");
                    btnGuardar.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private bool ValidarMail(string email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void lstPerfiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                IList<Perfil> oPerfiles = new List<Perfil>();
                foreach (var tmp in lstPerfiles.SelectedItems)
                {
                    oPerfiles.Add((Perfil)tmp);
                }
                if(oPerfiles.Any(x => x.naturalKey == "ADMIN_EMPRESA"))
                {
                    if (txtEmpresaID.Text == "0")
                    {
                        SeleccionarEmpresa seleccionarEmpresa = new SeleccionarEmpresa(this.hash, ref this.txtEmpresaID);
                        seleccionarEmpresa.Show();
                    }
                }
                else
                {
                    txtEmpresaID.Text = "0";
                    lblEmpresa.Text = "Empresa Asignada: Sin Asignar";
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void txtEmpresaID_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string id = txtEmpresaID.Text;
                Services.EmpresaServices oEmpresaServicios = new Services.EmpresaServices(this.hash);
                if (id == "0")
                {
                    lblEmpresa.Text = "Empresa Asignada: Sin Asignar";
                }
                else
                {
                    lblEmpresa.Text = "Empresa Asignada: " + oEmpresaServicios.getOne(Convert.ToInt32(id)).nombre;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
