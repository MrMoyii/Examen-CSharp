using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Vendedor
    {
        private string nombre = "Pedro";
        private string apellido = "Alfonso";
        private string codigoVendedor = "123789";

        public string Nombre { get => nombre; }
        public string Apellido { get => apellido; }
        public string CodigoVendedor { get => codigoVendedor; }
    }
}
