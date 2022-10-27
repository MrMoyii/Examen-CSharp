using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Camisas
{
    class MangaCorta : Camisa
    {
        public MangaCorta()
        {
            Stock = 500;

            CantCuelloComun = 350;
            CantCuelloComunPremium = 175;
            CantCuelloComunStandard = 175;

            CantCuelloMao = 150;
            CantCuelloMaoPremium = 75;
            CantCuelloMaoStandard = 75;
        }
    }
}
