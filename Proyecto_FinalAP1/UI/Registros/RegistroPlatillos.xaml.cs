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
    /// Interaction logic for RegistroPlatillos.xaml
    /// </summary>
    public partial class RegistroPlatillos : Window
    {
        Platillos Platillo = new Platillos();
        public RegistroPlatillos()
        {
            InitializeComponent();
            this.Platillo = new Platillos();
        }

        private void Limpiar()
        {
            this.Platillo = new Platillos();
            this.DataContext =Platillo;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var Platillo = PlatillosBLL.Buscar(Convert.ToInt32(PlatilloIdTextBox.Text));

            if (Platillo != null)
                this.Platillo = Platillo;
            else
                this.Platillo = new Platillos();

            this.DataContext = this.Platillo;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = PlatillosBLL.Guardar(Platillo);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccione exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlatillosBLL.Eliminar(Convert.ToInt32(PlatilloIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
