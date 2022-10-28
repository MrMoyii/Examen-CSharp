using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Camisas;
using Model.Pantalones;

namespace Presenter
{
    public class PresentadorStock
    {
        private IView view;
        public PresentadorStock(IView view)
        {
            this.view = view;
            ArrayList arr = new ArrayList();
            arr = this.view.GetInputValues();

            //si se chequeo Camisa
            if (bool.Parse(arr[0].ToString()))
            {
                Camisa camisa = new Camisa();
                int stockCamisa = camisa.Stock;
                view.DisplayStock(stockCamisa.ToString());
            }
            //sino toma el pantalon
            else
            {
                Pantalon pantalon = new Pantalon();
                int stockPantalon = pantalon.Stock;
                view.DisplayStock(stockPantalon.ToString());
            }
        }
        private static bool Validacion(object dato, string tipoDato)
        {
            switch (tipoDato)
            {
                case "int":
                    return int.TryParse(dato.ToString(), out _);

                case "string":

                    if (string.IsNullOrEmpty(dato.ToString().Trim()))
                        return false;
                    else
                        return true;

                default:
                    return false;
            }
        }
    }
}
