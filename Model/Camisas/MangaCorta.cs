using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Camisas
{
    public class MangaCorta : Camisa
    {
        public MangaCorta()
        {
            Stock = 500;

            CantCuelloComun = 300;
            CantCuelloComunPremium = 150;
            CantCuelloComunStandard = 150;

            CantCuelloMao = 200;
            CantCuelloMaoPremium = 100;
            CantCuelloMaoStandard = 100;
        }
        public float CalcularDescuentoMangaCorta()
        {
            float precioBase = CalcularPrecioUnitarioXCantidad();
            return precioBase - (precioBase * 0.1f); // --> descuento del 10%
        }
        public float CalcularDescuentoMangaCortaMasPremium()
        {
            float precioBase = CalcularDescuentoMangaCorta();           // --> descuento del 10%
            precioBase += CalcularAumentoPremium_Parametro(precioBase); // --> aumento del 30%
            return precioBase; // --> descuento del 10% + aumento del 30%
        }
        public float CalcularDescuentoMangaCortaYCuelloMao()
        {
            float precioBase = CalcularDescuentoMangaCorta();           // --> descuento del 10%
            precioBase += CalcularAumentoCuelloMao_Parametro(precioBase);// --> aumento del 3%
            return precioBase; // --> descuento del 10% + aumento del 3%
        }
        public float CalcularDescuentoMangaCortaYCuelloMaoPremium()
        {
            float precioBase = CalcularDescuentoMangaCortaYCuelloMao(); // --> descuento del 10% + aumento del 3%
            precioBase += CalcularAumentoPremium_Parametro(precioBase);  // --> aumento del 30%
            return precioBase; // --> descuento del 10% + aumento del 3% + aumento del 30%
        }
    }
}
