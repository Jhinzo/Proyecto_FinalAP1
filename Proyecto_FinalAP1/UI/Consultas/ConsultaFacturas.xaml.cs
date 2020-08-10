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
    /// Interaction logic for ConsultaFacturas.xaml
    /// </summary>
    public partial class ConsultaFacturas : Window
    {
        public string[] combo { get; set; }
        public ConsultaFacturas(Usuarios user)
        {
            if(user.NivelUsuario == "Administrador" || user.NivelUsuario == "Gerente")
            {
                InitializeComponent();
                combo = new string[] { "Todo", "Id" };
                FiltroComboBox.ItemsSource = combo;
            }
            else
                {
                MessageBox.Show("No posee el permiso necesario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

                
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Facturas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = FacturasBLL.GetList(e => true);
                        break;

                    case 1:
                        listado = FacturasBLL.GetList(e => e.FacturaId == Convert.ToInt32(CriterioTextBox.Text));
                        break;

                    


                }
            }
            else
            {
                listado = FacturasBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = FacturasBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDatePicker.SelectedDate != null)
                listado = FacturasBLL.GetList(c => c.Fecha.Date <= HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
