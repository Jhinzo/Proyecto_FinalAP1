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
    /// Interaction logic for ConsultaPlatillo.xaml
    /// </summary>
    public partial class ConsultaPlatillo : Window
    {
        public string[] combo { get; set; }
        public ConsultaPlatillo(Usuarios user)
        {
            if (user.NivelUsuario == "Administrador" || user.NivelUsuario == "Gerente")
            {
                InitializeComponent();
                combo = new string[] { "Todo", "Id", "Nombre", "Descripcion", "Precio" };
                FiltroComboBox.ItemsSource = combo;
            }
            else
            {
                MessageBox.Show("No posee el permiso necesario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }
       
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Platillos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = PlatillosBLL.GetList(e => true);
                        break;

                    case 1:
                        listado = PlatillosBLL.GetList(e => e.PlatilloId == Convert.ToInt32(CriterioTextBox.Text));
                        break;

                    case 2:
                        listado = PlatillosBLL.GetList(e => e.Nombre.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;

                    case 3:
                        listado = PlatillosBLL.GetList(e => e.Descripcion.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                    case 4:
                        listado = PlatillosBLL.GetList(e=>e.Precio == Convert.ToDouble(CriterioTextBox.Text));
                        break;

                    
                }
            }
            else
            {
                listado = PlatillosBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = PlatillosBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDatePicker.SelectedDate != null)
                listado = PlatillosBLL.GetList(c => c.Fecha.Date <= HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
