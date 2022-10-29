using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pantalones
{
    public class Pantalon : Prenda
    {
        private int cantComun;
        private int cantComunPremium;
        private int cantComunStandard;
        private int cantChupin;
        private int cantChupinPremium;
        private int cantChupinStandard;
        public Pantalon()
        {
            Stock = 2000;
        }

        public int CantComun { get => cantComun; set => cantComun = value; }
        public int CantComunPremium { get => cantComunPremium; set => cantComunPremium = value; }
        public int CantComunStandard { get => cantComunStandard; set => cantComunStandard = value; }
        public int CantChupin { get => cantChupin; set => cantChupin = value; }
        public int CantChupinPremium { get => cantChupinPremium; set => cantChupinPremium = value; }
        public int CantChupinStandard { get => cantChupinStandard; set => cantChupinStandard = value; }
    }
}
