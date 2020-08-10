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
    /// Interaction logic for RegistroFactura.xaml
    /// </summary>
    public partial class RegistroFactura : Window
    {
        
        public Facturas Factura = new Facturas();
        private readonly Usuarios Usuario = new Usuarios();

        public RegistroFactura(Usuarios user)
        {

            if(user.NivelUsuario=="Cocinero")
            {
                MessageBox.Show("usuario no permitido!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                new MainWindow(user).Show();
                this.Close();
            }
            else
            {
                
                InitializeComponent();
                this.DataContext = Factura;
                ClienteComboBox.ItemsSource = ClientesBLL.GetList();
                ClienteComboBox.SelectedValuePath = "ClienteId";
                ClienteComboBox.DisplayMemberPath= "Nombres";
                PlatilloComboBox.ItemsSource = PlatillosBLL.GetList();
                PlatilloComboBox.SelectedValuePath = "PlatilloId";
                PlatilloComboBox.DisplayMemberPath = "Nombre";
                

                Usuario = user;
            }
           
        }
        
        
        private void Limpiar()
        {
            Factura = new Facturas();
            CantidadTextBox.Text = string.Empty;
            PlatilloComboBox.Text = string.Empty;
            ClienteComboBox.Text = string.Empty;
            SubTotalTextBox.Text = string.Empty;
            TotalItbisTextBox.Text = string.Empty;
            DataContext = Factura;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Facturas Unit = FacturasBLL.Buscar(Convert.ToInt32(FacturaIdTextBox.Text));

            if (Unit != null) { Factura = Unit; Cargar(); }
            else { Limpiar(); }
        }

        private void Calcular()
        {
            Contexto c = new Contexto();
            double totalITBIS = 0;
            double subtotal = 0;
            double total = 0;
            if (Factura.OrdenDetalle.Count> 0)
            {
                totalITBIS = Factura.OrdenDetalle.Sum(e =>e.Itbis);
                subtotal = Factura.OrdenDetalle.Sum(e => e.Importe);
                total = totalITBIS + subtotal;
            }
            TotalItbisTextBox.Text = totalITBIS.ToString();
            SubTotalTextBox.Text = subtotal.ToString();
            TotalTextBox.Text = total.ToString();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Factura;
            
            Calcular();
        }

        private void EliminarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (FacturaDataGrid.Items.Count >= 1 && FacturaDataGrid.SelectedIndex <= FacturaDataGrid.Items.Count - 1)
            {
                try
                {
                    Factura.OrdenDetalle.RemoveAt(FacturaDataGrid.SelectedIndex);
                    Cargar();
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Por favor selecione una fila para eliminar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private bool Validar()
        {
            bool esValido = true;

            if (Factura.OrdenDetalle == null)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Factura está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CantidadTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }
            return esValido;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar()) { return; }
            Factura.ItbisTotal = int.Parse(TotalItbisTextBox.Text);
            Factura.SubTotal = int.Parse(SubTotalTextBox.Text);
            Factura.Total = int.Parse(TotalTextBox.Text);
            bool factura = FacturasBLL.Guardar(Factura);

            if (factura)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else { MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (FacturasBLL.Eliminar(Convert.ToInt32(FacturaIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Factura eliminada!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AñadirFilaButton_Click(object sender, RoutedEventArgs e)
        {
            Platillos prod = PlatillosBLL.Buscar(PlatilloComboBox.SelectedIndex);
            Clientes cl = ClientesBLL.Buscar(ClienteComboBox.SelectedIndex);
            
            if (prod != null)
            {
                prod.Cantidad -= int.Parse(CantidadTextBox.Text); PlatillosBLL.Modificar(prod);
                double importe = int.Parse(CantidadTextBox.Text) * prod.Precio;
                Factura.OrdenDetalle.Add(new Ordenes(Factura.FacturaId, PlatilloComboBox.Text, int.Parse(CantidadTextBox.Text), prod.Precio, importe, importe * 0.18));
                Cargar();
            }
            else
            {
                MessageBox.Show("Por favor llenar los campos correctamente y intentelo de nuevo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        

       

        private void PlatilloComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Platillos pl = PlatillosBLL.Buscar(PlatilloComboBox.SelectedIndex);

        }
    }
}
