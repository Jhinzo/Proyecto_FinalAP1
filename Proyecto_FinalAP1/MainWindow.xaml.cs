using Proyecto_FinalAP1.Entidades;
using Proyecto_FinalAP1.UI.Consultas;
using Proyecto_FinalAP1.UI.Registros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_FinalAP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Usuarios usuario = new Usuarios();
        Login ventana = new Login();

        public MainWindow()
        {
            InitializeComponent();
            ventana.Show();
            this.Close();
        }

        public MainWindow(Usuarios user)
        {
            InitializeComponent();
            usuario = user;
        }

        private void RPlatillosItem_Click(object sender, RoutedEventArgs e)
        {
            RegistroPlatillos rp = new RegistroPlatillos(usuario);
            rp.Show();
            

        }
        private void RUsuariosItem_Click(object sender, RoutedEventArgs e)
        {
            RegistroUsuario ru = new RegistroUsuario(usuario);
            ru.Show();
            

        }
        private void RClienteItem_Click(object sender, RoutedEventArgs e)
        {
            RegistroCliente ru = new RegistroCliente(usuario);
            ru.Show();
           

        }

        private void RFacturasItem_Click(object sender, RoutedEventArgs e)
        {
            RegistroFactura ru = new RegistroFactura(usuario);
            ru.Show();
            

        }

        private void CPlatillosItem_Click(object sender, RoutedEventArgs e)
        {
            ConsultaPlatillo rp = new ConsultaPlatillo(usuario);
            rp.Show();


        }
        private void CUsuariosItem_Click(object sender, RoutedEventArgs e)
        {
            ConsultaUsuarios ru = new ConsultaUsuarios(usuario);
            ru.Show();


        }
        private void CClienteItem_Click(object sender, RoutedEventArgs e)
        {
            ConsultaClientes ru = new ConsultaClientes(usuario);
            ru.Show();


        }

        private void CFacturasItem_Click(object sender, RoutedEventArgs e)
        {
            ConsultaFacturas ru = new ConsultaFacturas(usuario);
            ru.Show();


        }

    }
}
