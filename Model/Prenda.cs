using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    abstract class Prenda
    {
        public bool EsPremium { get => EsPremium; set => EsPremium = value; }
        public int PrecioUnitario { get => PrecioUnitario; set => PrecioUnitario = value; }
        public int Stock { get => Stock; set => Stock = value; }
    }
}
