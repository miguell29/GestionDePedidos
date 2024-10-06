
using GestionDePedidos.Services;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionDePedidos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            var data = new Conexion();
            var datatable = data.GetClientes();
            InitializeComponent();
            if (datatable != null)
            {
                info.ItemsSource = datatable.DefaultView;   
            }
        }

        
    }
}