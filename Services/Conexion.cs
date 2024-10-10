using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using GestionDePedidos.Models;
using System.Windows;

namespace GestionDePedidos.Services
{
    internal class Conexion
    {
        private readonly IConfiguration _configuration;
        private string? connectionString;

        public Conexion()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            connectionString = _configuration.GetConnectionString("MyDatabaseConnection");
        }

        public DataTable? GetClientes()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM Cliente";
                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                       // info.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de SQL server: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
                return null;
            }
        }


        public DataTable? GetPedidosCliente(int id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM Pedido P INNER JOIN Cliente C ON C.Id = P.CCliente WHERE C.Id = @ClienteId";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ClienteId", id);

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
                return null;
                
            }
        }

        public bool DeletePedido(int id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var query = "DELETE FROM PEDIDO WHERE Id = @Id";
                    var command = new SqlCommand(query,connection);
                    connection.Open();
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
  
        public bool UpdateClient(Cliente cliente)
        {
            try
            {                    using (var connection = new SqlConnection(connectionString))
                    {
                        var query = "UPDATE Cliente SET " +
                            "Nombre = @nombre, " +
                            "Direccion = @direccion," +
                            "Poblacion = @poblacion," +
                            "Telefono = @telefono " +
                            "WHERE Id = @id";
                        var command = new SqlCommand(query,connection);
                        connection.Open();
                        command.Parameters.AddWithValue("@nombre", cliente.Nombre);
                        command.Parameters.AddWithValue("@direccion", cliente.Direccion);
                        command.Parameters.AddWithValue("@poblacion",cliente.Poblacion);
                        command.Parameters.AddWithValue("@telefono",cliente.Telefono);
                        command.Parameters.AddWithValue("@id", cliente.Id);
                        command.ExecuteNonQuery();
                        return true;
                    }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CreateClient(Cliente cliente)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var query = "INSERT INTO Cliente (Nombre, Direccion, Poblacion, Telefono) " +
                        "VALUES (@nombre, @direccion, @poblacion, @telefono)";
                    var command = new SqlCommand(query, connection);
                    connection.Open();
                    command.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    command.Parameters.AddWithValue("@poblacion", cliente.Poblacion);
                    command.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }


}
