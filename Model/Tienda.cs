using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Tienda
    {
        private string nombre = "Distrito Moda";
        private string direccion = "Av. Garibaldi 1320";
        private string listadoPrendas = "Camisas y Pantalones";

        public string Nombre { get => nombre; }
        public string Direccion { get => direccion; }
        public string ListadoPrendas { get => listadoPrendas; }
    }
}
