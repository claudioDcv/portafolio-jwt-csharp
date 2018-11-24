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
using Services = DTO.Servicios;
using DTO.Modelo;

namespace SafeAdmin
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string pass = txtContrasena.Password;

                Services.LoginServices loginServicio = new Services.LoginServices();
                DTO.Modelo.Login oLogin = loginServicio.Autenticar(email, pass);

                bool respuesta = oLogin.code == 200;

                if (respuesta)
                {
                    Services.UsuarioServices usuarioServicio = new Services.UsuarioServices(oLogin.token);
                    Usuario oUsuario = usuarioServicio.validateProfile();
                    if(oUsuario.profiles.Any(x => x.naturalKey == "ADMIN_SAFE"))
                    {
                        //string hash = "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJhZG1pbl9zYWZlLnRlY25pY29Ac2FmZS5jbCIsImlhdCI6MTU0MTYzNTIxNSwiZXhwIjoxNTQxNzIxNjE1fQ.EQ8sfTrKEkR8WehBXBBj07cmDeaR9Oys_eQvOOnlC8U";
                        string hash = oLogin.token;
                        MainWindow ventanaPrincipal = new MainWindow(hash);
                        ventanaPrincipal.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No cuenta con el perfil necesario para acceder.");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario no válido");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Usuario/Contraseña no válidos.");
            }
        }
    }
}
