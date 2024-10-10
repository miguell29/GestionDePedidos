
using GestionDePedidos.Models;
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
            InitializeComponent();
            MostrarClientes();
        }

        private void MostrarClientes()
        {
            var datatable = data.GetClientes();
            if (datatable != null)
            {
                gridClientes.SelectedValuePath = "Id";
                gridClientes.ItemsSource = datatable.DefaultView;
            }
            else
            {
                MessageBox.Show("Error al cargar los datos");
            }
        }

        private void gridClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridClientes.SelectedItem != null)
            {
                var datatable = data.GetPedidosCliente((int)gridClientes.SelectedValue);
                if (datatable != null)
                {
                    gridPedidos.SelectedValuePath = "Id";
                    gridPedidos.ItemsSource = datatable.DefaultView;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (gridPedidos.SelectedValue == null)
            {
                return;
            }
            if (data.DeletePedido((int)gridPedidos.SelectedValue))
            {
                if (gridClientes.SelectedItem != null)
                {
                    var datatable = data.GetPedidosCliente((int)gridClientes.SelectedValue);
                    if (datatable != null)
                    {
                        gridPedidos.SelectedValuePath = "Id";
                        gridPedidos.ItemsSource = datatable.DefaultView;
                    }
                }
            }
            else
            {
                MessageBox.Show("Error al eliminar pedido"); 
            }
        }

        private void gridClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (gridClientes.SelectedItem != null)
            {
                DataRowView rowView = (DataRowView)gridClientes.SelectedItem; // Obtén el DataRowView

                // Crea un nuevo objeto Cliente con los datos del DataRowView
                Cliente cliente = new Cliente(
                    (int)rowView["Id"],
                    (string)rowView["Nombre"],
                    (string)rowView["Direccion"],
                    (string)rowView["Poblacion"],
                    (string)rowView["Telefono"]
                );

                var editarCliente = new EditClient(cliente);
                editarCliente.ShowDialog();
                MostrarClientes();
            }
        }

        private void btnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            var crearCliente = new CreateClientWindow();
            crearCliente.ShowDialog();
            MostrarClientes();
        }
    }
}