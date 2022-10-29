using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public interface IView
    {
        //para la vista
        void DisplayData(ArrayList datos);
        void DisplayResult(string result, bool error, string quePaso);
        void DisplayStock(string data);
        void DisplayStockPremium(string data);

        //para el modelo
        ArrayList GetInputValues();
    }
}
