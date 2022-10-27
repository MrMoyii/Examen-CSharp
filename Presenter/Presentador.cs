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
        Vendedor vendedor;
        Tienda tienda;
        private IView view;
        public Presentador(IView view)
        {
            tienda = new Tienda();
            vendedor = new Vendedor();
            ArrayList arrData = new ArrayList();
            AlamcenarDatos(arrData, tienda, vendedor);
            view.DisplayData(arrData);
        }
        static void AlamcenarDatos(ArrayList arrData, Tienda tienda, Vendedor vendedor)
        {
            arrData.Add(tienda.Nombre);
            arrData.Add(tienda.Direccion);
            arrData.Add(vendedor.Nombre);
            arrData.Add(vendedor.Apellido);
            arrData.Add(vendedor.CodigoVendedor);
        }
    }
}
