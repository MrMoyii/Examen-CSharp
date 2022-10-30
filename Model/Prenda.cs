using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Prenda
    {
        private bool esPremium;
        private int stock;
        private int precioUnitario;
        public bool EsPremium { get => esPremium; set => esPremium = value; }
        public int PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public int Stock { get => stock; set => stock = value; }

        public float CalcularPrecioUnitarioXCantidad()
        {
            return precioUnitario * stock;
        }
        public float CalcularAumentoPremium()
        {
            float precioBase = CalcularPrecioUnitarioXCantidad();
            return precioBase + (precioBase * 0.3f); // --> aumento del 30%
        }
        public float CalcularAumentoPremium_Parametro(float precioBase)
        {
            return precioBase * 0.3f; // --> aumento del 30%
        }

    }
}
