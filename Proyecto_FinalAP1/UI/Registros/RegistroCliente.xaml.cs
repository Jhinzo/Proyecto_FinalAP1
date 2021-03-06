﻿using Proyecto_FinalAP1.BLL;
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
    /// Interaction logic for RegistroCliente.xaml
    /// </summary>
    public partial class RegistroCliente : Window
    {
        Clientes Cliente = new Clientes();
        public RegistroCliente(Usuarios user)
        {
            if (user.NivelUsuario =="Cocinero")
            {
                MessageBox.Show("Este Usuario no tiene acceso a esta ventana", "Fallo",
                   MessageBoxButton.OK, MessageBoxImage.Warning);
                new MainWindow(user).Show();
                this.Close();
            }
            else
            {
                InitializeComponent();
                this.Cliente = new Clientes();

            }
            
        }

        private void Limpiar()
        {
            this.Cliente = new Clientes();
            this.DataContext = Cliente;
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

            if (ApellidosTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var cliente = ClientesBLL.Buscar(Convert.ToInt32(ClienteIdTextBox.Text));

            if (cliente != null)
            {
                MessageBox.Show("Cliente encontrado", "Exito",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                this.Cliente = cliente;
                
            }
                
            else
            {
                MessageBox.Show("Transaccion Fallida", "Fallo",
                   MessageBoxButton.OK, MessageBoxImage.Warning);

            }
                

            this.DataContext = this.Cliente;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = ClientesBLL.Guardar(Cliente);

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
            if (ClientesBLL.Eliminar(Convert.ToInt32(ClienteIdTextBox.Text)))
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
