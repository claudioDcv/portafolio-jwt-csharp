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
                Usuario oUsuario = oUsuarioServicios.getOne(id);
                IList<Perfil> oPerfiles = oPerfilServicios.getAll();
                lstPerfiles.ItemsSource = oPerfiles;
                txtID.Text = oUsuario.id.ToString();
                txtEmail.Text = oUsuario.email;
                txtNombre.Text = oUsuario.name;
                txtApellido.Text = oUsuario.surname;
                lblPassword.Visibility = Visibility.Collapsed;
                txtPassword.Visibility = Visibility.Collapsed;
                foreach (var tmp in lstPerfiles.Items)
                {
                    if(oUsuario.profiles.Any(x => x.id == ((Perfil)tmp).id))
                    {
                        int indice = lstPerfiles.Items.IndexOf(tmp);
                        lstPerfiles.SelectedItems.Add(tmp);
                        //lstPerfiles.SelectedIndex += indice;
                    }
                }
                lstPerfiles.SelectedItems.Add(oUsuario.profiles);
                lblTitulo.Content = "Editar Usuario";
                btnBloquear.Visibility = Visibility.Visible;
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
                foreach(var tmp in lstPerfiles.SelectedItems)
                {
                    oUsuario.profiles.Add((Perfil)tmp);
                }
                int respuesta = default(int);
                if (oUsuario.id > 0)
                {
                    respuesta = usuarioServices.update(oUsuario);
                    if(respuesta == 0)
                    {
                        MessageBox.Show("El usuario no se puede actualizar con los datos ingresados.");
                        return;
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
                    if (respuesta > 0)
                    {
                        oUsuario.id = respuesta;
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
                int respuesta = usuarioServices.asignProfiles(oUsuario);

                if (respuesta > 0)
                {
                    MessageBox.Show("Usuario bloqueado con éxito.");
                    Listar listar = new Listar(hash);
                    listar.Show();
                    this.Close();
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

    }
}
