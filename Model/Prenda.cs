using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Prenda
    {
        public bool EsPremium { get => EsPremium; set => EsPremium = value; }
        public int PrecioUnitario { get => PrecioUnitario; set => PrecioUnitario = value; }

        private int stock;
        public int Stock { get => stock; set => stock = value; }
    }
}
