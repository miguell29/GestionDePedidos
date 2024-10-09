using GestionDePedidos.Models;
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
        public EditClient(Cliente cliente)
        {
            this.DataContext = cliente;
            InitializeComponent();
        }
    }
}
