using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        private readonly IConfiguration _configuration;
        public MainWindow()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            var connectionString = _configuration.GetConnectionString("MyDatabaseConnection");
            InitializeComponent();
            MostrarDatos(connectionString);
        }

        private void MostrarDatos(string? connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT * FROM Cliente";
                    using (var adapter = new SqlDataAdapter(query,connection))
                    {
                       var dataTable = new DataTable();
                       adapter.Fill(dataTable);
                       info.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de SQL server: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message);
            }
        }
    }
}