using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pantalones
{
    public class Pantalon : Prenda
    {
        protected int CantComun;
        protected int CantComunPremium;
        protected int CantComunStandard;
        protected int CantChupin;
        protected int CantChupinPremium;
        protected int CantChupinStandard;
        public Pantalon()
        {
            Stock = 2000;
        }
    }
}
