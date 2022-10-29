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
        public double calcularPrecio()
        {

            return 1.2;
        }
    }
}
