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

namespace Proyecto_FinalAP1.UI.Consultas
{
    /// <summary>
    /// Interaction logic for ConsultaClientes.xaml
    /// </summary>
    public partial class ConsultaClientes : Window
    {
        public string[] combo = new string[] { "Todo", "Id", "Nombres", "Apellidos", "Mesa" };


        public ConsultaClientes( Usuarios user)
        {
            if(user.NivelUsuario=="Administrador"|| user.NivelUsuario == "Gerente")
            {
                InitializeComponent();
                                FiltroComboBox.ItemsSource = combo;
            }
            else
            {
                MessageBox.Show("No posee el permiso necesario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Clientes>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ClientesBLL.GetList(e => true);
                        break;

                    case 1:
                        listado = ClientesBLL.GetList(e => e.ClienteId == Convert.ToInt32(CriterioTextBox.Text));
                        break;

                    case 2:
                        listado = ClientesBLL.GetList(e => e.Nombres.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;

                    case 3:
                        listado = ClientesBLL.GetList(e => e.Apellidos.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                    case 4:
                        listado = ClientesBLL.GetList(e => e.Mesa == Convert.ToDouble(CriterioTextBox.Text));
                        break;


                }
            }
            else
            {
                listado = ClientesBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = ClientesBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDatePicker.SelectedDate != null)
                listado = ClientesBLL.GetList(c => c.Fecha.Date <= HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
            
        }

    }
}
