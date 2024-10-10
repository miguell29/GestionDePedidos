using GestionDePedidos.Models;
using GestionDePedidos.Services;
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
using System.Windows.Shapes;

namespace GestionDePedidos
{
    /// <summary>
    /// Lógica de interacción para CreateClientWindow.xaml
    /// </summary>
    public partial class CreateClientWindow : Window
    {
        private Conexion data;
        private Cliente cliente;
        public CreateClientWindow()
        {
            cliente = new Cliente();
            this.DataContext = this.cliente;
            InitializeComponent();
            data = new Conexion();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data.CreateClient(cliente))
                {
                    MessageBox.Show("Cliente Creado Correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Crear el Cliente: " + ex.Message);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
