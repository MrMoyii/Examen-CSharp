using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Presenter
{
    public class DatosTiendaYVendedor
    {
        Vendedor vendedor;
        Tienda tienda;
        private IView view;
        public DatosTiendaYVendedor(IView view)
        {
            tienda = new Tienda();
            vendedor = new Vendedor();
            ArrayList arrData = new ArrayList();
            AlamcenarDatosTiendaYVendedor(arrData, tienda, vendedor);

            view.DisplayData(arrData);
        }

        //tomo los datos del modelo y los almaceno en un ArrayList
        static void AlamcenarDatosTiendaYVendedor(ArrayList arrData, Tienda tienda, Vendedor vendedor)
        {
            arrData.Add(tienda.Nombre);
            arrData.Add(tienda.Direccion);
            arrData.Add(vendedor.Nombre);
            arrData.Add(vendedor.Apellido);
            arrData.Add(vendedor.CodigoVendedor);
        }
    }
}
