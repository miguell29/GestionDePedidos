using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePedidos.Models
{
    public class Cliente
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Poblacion { get; set; }
        public string? Telefono { get; set; }
        public Cliente(int id, string nombre, string direccion, string poblacion, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Poblacion = poblacion;
            Telefono = telefono;
        }
        Cliente() { }
    }
}
