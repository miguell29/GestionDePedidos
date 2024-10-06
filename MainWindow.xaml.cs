
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
        private Conexion data;
        public MainWindow()
        {
            data = new Conexion();
            var datatable = data.GetClientes();
            InitializeComponent();
            if (datatable != null)
            {
                gridClientes.ItemsSource = datatable.DefaultView;   
            }
            else
            {
                MessageBox.Show("Error al cargar los datos");
            }
        }

        private void gridClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var datatable = data.GetPedidosCliente(gridClientes.SelectedIndex);
            if (datatable != null)
            {
                gridPedidos.ItemsSource = datatable.DefaultView;
            }
        }
    }
}