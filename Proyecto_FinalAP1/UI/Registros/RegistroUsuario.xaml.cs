using Proyecto_FinalAP1.BLL;
using Proyecto_FinalAP1.Entidades;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for RegistroUsuario.xaml
    /// </summary>
    public partial class RegistroUsuario : Window
    {
        Usuarios usuarios = new Usuarios();
        public string[] Niveles{get; set; }
        private Entidades.Usuarios usuario = new Entidades.Usuarios();

        public RegistroUsuario()
        {
            InitializeComponent();
            this.DataContext = usuario;
            Niveles = new string[] { "Administrador", "Almacenero", "Vendedor", "Tesorero", "Gerente" };
            NivelUsuarioComboBox.ItemsSource = Niveles;
        }

        private void Limpiar()
        {
            this.usuario = new Entidades.Usuarios();
            ContraseñaPasswordBox.Password = string.Empty;
            ConfirmarContraseñaPasswordBox.Password = string.Empty;
            this.DataContext = usuario;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Nombres está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ApellidosTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Apellidos está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ApellidosTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (UserNameTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Nombre usuario está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                UserNameTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ContraseñaPasswordBox.Password.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Contraseña está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ContraseñaPasswordBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ConfirmarContraseñaPasswordBox.Password.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Confirmar contraseña está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ConfirmarContraseñaPasswordBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ConfirmarContraseñaPasswordBox.Password != ContraseñaPasswordBox.Password)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("La contraseña no coiciden", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ConfirmarContraseñaPasswordBox.Focus();
                GuardarButton.IsEnabled = true;
            }


            return esValido;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            usuario.Contraseña = ContraseñaPasswordBox.Password;

            var paso = UsuariosBLL.Guardar(usuario);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Convert.ToInt32(UsuarioIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var estudiante = UsuariosBLL.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));

            if (usuario != null)
            {
                this.usuario = estudiante;
                MessageBox.Show("Usuario encontrado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
                
            else
            {
                MessageBox.Show("Usuario no encontrado", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Limpiar();
            }
               

            this.DataContext = this.usuario;
        }
    }
}
