using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO;

namespace SafeAdmin
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string hash;
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string hash)
        {
            InitializeComponent();
            this.hash = hash;
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.ReadToken(hash) as JwtSecurityToken;
            lblHash.Content = token.Subject;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void itmUsuarios_Click(object sender, RoutedEventArgs e)
        {
            var usuarios = new Mantenedores.Sistema.Usuarios.Listar(hash);
            usuarios.Show();
        }

        private void itmTipoRiesgos_Click(object sender, RoutedEventArgs e)
        {
            var tipoRiesgos = new Mantenedores.Sistema.Riesgos.Listar(this.hash);
            tipoRiesgos.Show();
        }

        private void itmEmpresas_Click(object sender, RoutedEventArgs e)
        {
            var empresas = new Mantenedores.Sistema.Empresa.Listar(this.hash);
            empresas.Show();
        }

        private void itmExamenes_Click(object sender, RoutedEventArgs e)
        {
            var examenes = new Mantenedores.Sistema.Examenes.Listar(this.hash);
            examenes.Show();
        }

        private void itmSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
