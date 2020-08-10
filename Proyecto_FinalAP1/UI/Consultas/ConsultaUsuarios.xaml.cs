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
    /// Interaction logic for ConsultaUsuarios.xaml
    /// </summary>
    public partial class ConsultaUsuarios : Window
    {
        public string[] combo = new string[] { "Todo", "Id", "Nombre", "Apellido", "UserName","NivelUsuario" };

        public ConsultaUsuarios(Usuarios user)
        {
            if (user.NivelUsuario == "Administrador" || user.NivelUsuario == "Gerente")
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
            var listado = new List<Usuarios>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: 
                        listado = UsuariosBLL.GetList(e =>true);
                        break;

                    case 1: 
                        listado = UsuariosBLL.GetList(e => e.UsuarioId == Convert.ToInt32(CriterioTextBox.Text));
                        break;

                    case 2:                       
                        listado = UsuariosBLL.GetList(e => e.Nombre.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;

                    case 3:                  
                        listado = UsuariosBLL.GetList(e => e.Apellido.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                    case 4:               
                        listado = UsuariosBLL.GetList(e => e.UserName.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;

                    case 5:               
                        listado = UsuariosBLL.GetList(e => e.NivelUsuario.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                }
            }
            else
            {
                listado = UsuariosBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = UsuariosBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDatePicker.SelectedDate != null)
                listado = UsuariosBLL.GetList(c => c.Fecha.Date <= HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
