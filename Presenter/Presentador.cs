using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Presenter
{
    public class Presentador
    {
        private IView view;
        public Presentador(IView view)
        {
            this.view = view;
            ArrayList arr = new ArrayList();
            arr = this.view.GetInputValues();

            if (!Validacion(arr[0], "string"))
            {
                view.DisplayResult("Error", true, "Ingrese una direccion.");
                return;
            }
            if (!Validacion(arr[1], "int"))
            {
                view.DisplayResult("Error", true, "Ingrese un número de m2 valido.");
                return;
            }
            if (!Validacion(arr[2], "int"))
            {
                view.DisplayResult("Error", true, "Ingrese un precio base valido.");
                return;
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
