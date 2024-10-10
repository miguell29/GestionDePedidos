using GestionDePedidos.Models;
using GestionDePedidos.Services;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        private Conexion data;
        private Cliente cliente;
        public EditClient(Cliente cliente)
        {
            this.cliente = cliente;
            this.DataContext = this.cliente;
            InitializeComponent();
            data = new Conexion();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data.UpdateClient(cliente))
                {
                    MessageBox.Show("Cliente Actualizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Actualizar los datos: " + ex.Message);
            }
            finally 
            { 
                this.Close() ;
            }
            
        }

    }
}
