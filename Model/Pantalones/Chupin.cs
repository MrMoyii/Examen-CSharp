using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pantalones
{
    public class Chupin : Pantalon
    {
        public Chupin()
        {
            CantChupin = 1500;
            CantChupinPremium = 750;
            CantChupinStandard = 750;
        }
        public float CalcularDescuentoChupin()
        {
            float precioBase = CalcularPrecioUnitarioXCantidad();
            return precioBase - (precioBase * 0.12f); // --> descuento del 12%
        }
        public float CalcularDescuentoChupinMasPremium()
        {
            float precioBase = CalcularDescuentoChupin();               // --> descuento del 12%
            precioBase += CalcularAumentoPremium_Parametro(precioBase); // --> aumento del 30%
            return precioBase; // --> descuento del 12% + aumento del 30%
        }
    }
}
