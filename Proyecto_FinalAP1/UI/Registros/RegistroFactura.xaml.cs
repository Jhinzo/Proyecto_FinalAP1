using Proyecto_FinalAP1.BLL;
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
    /// Interaction logic for RegistroFactura.xaml
    /// </summary>
    public partial class RegistroFactura : Window
    {
        public RegistroFactura()
        {
            InitializeComponent();
        }

        private readonly Usuarios Usuario = new Usuarios();
        private Compras Compra = new Compras();
        public RegistroCompras(Usuarios user)
        {
            InitializeComponent();
            DataContext = Compra;
            ClienteComboBox.ItemsSource = ClientesBLL.GetList();
            ClienteComboBox.SelectedValuePath = "ClientesId";
            ClienteComboBox.DisplayMemberPath = "Nombre";
            PlatilloComboBox.ItemsSource = PlatillosBLL.GetList();
            PlatilloComboBox.SelectedValuePath = "PlatilloId";
            PlatilloComboBox.DisplayMemberPath = "Descripcion";
            Usuario = user;
        }



    }
}
