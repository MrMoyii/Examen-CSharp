using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Camisas
{
    public class Camisa : Prenda
    {
        private int cantCuelloComun;
        private int cantCuelloComunPremium;
        private int cantCuelloComunStandard;
        private int cantCuelloMao;
        private int cantCuelloMaoPremium;
        private int cantCuelloMaoStandard;

        public Camisa()
        {
            Stock = 1000;
        }

        public int CantCuelloComun { get => cantCuelloComun; set => cantCuelloComun = value; }
        public int CantCuelloComunPremium { get => cantCuelloComunPremium; set => cantCuelloComunPremium = value; }
        public int CantCuelloComunStandard { get => cantCuelloComunStandard; set => cantCuelloComunStandard = value; }
        public int CantCuelloMao { get => cantCuelloMao; set => cantCuelloMao = value; }
        public int CantCuelloMaoPremium { get => cantCuelloMaoPremium; set => cantCuelloMaoPremium = value; }
        public int CantCuelloMaoStandard { get => cantCuelloMaoStandard; set => cantCuelloMaoStandard = value; }

        public float CalcularAumentoCuelloMao()
        {
            float precioBase = CalcularPrecioUnitarioXCantidad();
            return precioBase + (precioBase * 0.03f); // --> aumento del 3%
        }
        public float CalcularAumentoCuelloMao_Parametro(float precioBase)
        {
            return precioBase * 0.03f; // --> aumento del 3%
        }
        public float CalcularAumentoCuelloMaoMasPremium()
        {
            float precioBase = CalcularAumentoCuelloMao(); // --> aumento del 3%
            precioBase += CalcularAumentoPremium_Parametro(precioBase); // --> aumento del 30%
            return precioBase; 
        }
    }
}
