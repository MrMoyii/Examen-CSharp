using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pantalones
{
    public class Comun : Pantalon
    {
        public Comun()
        {
            CantComun = 500;
            CantComunPremium = 250;
            CantComunStandard = 250;
        }
    }
}
