using Proyecto_FinalAP1.Entidades;
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
        Usuarios user = new Usuarios();
        Login ventana = new Login();

        public MainWindow()
        {
            InitializeComponent();
            ventana.Show();
            this.Close();
        }

        public MainWindow(Usuarios user)
        {
            
        }

        

        


    }
}
