using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Camisas
{
    public class Camisa : Prenda
    {
        protected int CantCuelloComun;
        protected int CantCuelloComunPremium;
        protected int CantCuelloComunStandard;
        protected int CantCuelloMao;
        protected int CantCuelloMaoPremium;
        protected int CantCuelloMaoStandard;
        public Camisa()
        {
            Stock = 1000;
        }
    }
}
