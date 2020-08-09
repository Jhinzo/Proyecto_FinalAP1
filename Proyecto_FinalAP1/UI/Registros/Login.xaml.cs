using Proyecto_FinalAP1.BLL;
using Proyecto_FinalAP1.DAL;
using Proyecto_FinalAP1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_FinalAP1.UI.Registros
{
    /// <summary>
    /// Interaction logic for Usuarios.xaml
    /// </summary>
    public partial class Login: Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserNameTextBox.Text.Length == 0 || ContraseñaPasswordBox.Password.Length == 0 )
            {
                MessageBox.Show("No puede dejar campos vacios.", "Llenar campos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                bool usuario = UsuariosBLL.Validar(UserNameTextBox.Text, ContraseñaPasswordBox.Password);
                if (usuario == true)
                {
                    MainWindow main = new MainWindow(getUsuario());
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El nombre de usuario o la contraseña es incorrecta.", "No se pudo conectar", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
        }

        private Usuarios getUsuario()
        {
            Contexto db = new Contexto();
            Usuarios usuario;

            usuario = db.Usuarios.Where(p => p.UserName == UserNameTextBox.Text).SingleOrDefault();
            return usuario;
        }
    }
    
}
