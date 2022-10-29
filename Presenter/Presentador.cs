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
    public class Presentador
    {
        private IView view;

        public Presentador(IView view)
        {
            this.view = view;
            ArrayList arr = this.view.GetInputValues();
            int valorPrecio;
            float precioDescuento;
            float precioAumento;

            //cantidad ingresada
            if (!ValidacionEntero(arr[5])) //arr[5] --> cantidad
            {
                view.DisplayResult("Error", true, "Ingrese una cantidad valida.");
                return;
            }
            //precio ingresada
            if (!ValidacionEntero(arr[6])) //arr[6] --> precio
            {
                view.DisplayResult("Error", true, "Ingrese un precio valido.");
                return;
            }
            //si se chequeo Camisa
            if (bool.Parse(arr[0].ToString())) //arr[0] --> camisa
            {
                MangaLarga mangaL = new MangaLarga();
                MangaCorta mangaC = new MangaCorta();
                //multiplico Cantidad x Precio unitario
                valorPrecio = int.Parse(arr[6].ToString()) * int.Parse(arr[5].ToString());

                #region Logica Camisa
                //si no se marco nada
                if (!bool.Parse(arr[2].ToString()) && !bool.Parse(arr[1].ToString()))
                {
                    //si se marco standard
                    if (bool.Parse(arr[4].ToString())) //arr[4] --> standard
                    {
                        //lo paso a la vista para que se encargue de mostrarlo
                        this.view.DisplayResult(valorPrecio.ToString(), false, "no paso nada jeje");
                    }
                    else
                        view.DisplayStockPremium(mangaL.CantCuelloComunPremium.ToString());
                    view.DisplayStock(mangaL.CantCuelloComun.ToString());
                }
                //si se marco Manga corta unicamente
                if (bool.Parse(arr[1].ToString()) && !bool.Parse(arr[2].ToString()))
                {
                    //si se marco standard
                    if (bool.Parse(arr[4].ToString())) // arr[4] --> standard
                    {
                        //aplico descuento
                        precioDescuento = valorPrecio - (valorPrecio * 0.1f); // --> descuento del 10%
                        //lo paso a la vista para que se encargue de mostrarlo
                        this.view.DisplayResult(precioDescuento.ToString(), false, "no paso nada jeje");
                    }
                    else
                        view.DisplayStockPremium(mangaC.CantCuelloComunPremium.ToString());
                    view.DisplayStock(mangaC.CantCuelloComun.ToString());
                }
                //si se marco Cuello Mao unicamente
                if (bool.Parse(arr[2].ToString()) && !bool.Parse(arr[1].ToString()))
                {
                    //si se marco standard
                    if (bool.Parse(arr[4].ToString())) // arr[4] --> standard
                    {
                        //aplico aumento
                        precioAumento = valorPrecio + (valorPrecio * 0.03f); // --> aumento del 3%
                        //lo paso a la vista para que se encargue de mostrarlo
                        this.view.DisplayResult(precioAumento.ToString(), false, "no paso nada jeje");
                    }
                    else
                        view.DisplayStockPremium(mangaL.CantCuelloMaoPremium.ToString());
                    view.DisplayStock(mangaL.CantCuelloMao.ToString());
                }
                //si se marco Manga corta && Cuello Mao
                if (bool.Parse(arr[1].ToString()) && bool.Parse(arr[2].ToString()))
                {
                    //si es standard muestra
                    if (bool.Parse(arr[4].ToString()))
                    {
                        //aplico descuento
                        precioDescuento = valorPrecio - (valorPrecio * 0.1f); // --> descuento del 10%
                        //aplico aumento
                        precioAumento = precioDescuento + (precioDescuento * 0.03f); // --> aumento del 3%
                        //lo paso a la vista para que se encargue de mostrarlo
                        this.view.DisplayResult(precioAumento.ToString(), false, "no paso nada jeje");
                    }
                    else
                        view.DisplayStockPremium(mangaC.CantCuelloMaoPremium.ToString());
                    view.DisplayStock(mangaC.CantCuelloMao.ToString());
                }
                #endregion
            }
            //sino, se chequeo el pantalon
            else
            {
                Chupin chupin = new Chupin();
                Comun pantalonComun = new Comun();

                #region Logica Pantalon
                //si se marco chupin
                if (bool.Parse(arr[3].ToString()))
                {
                    //si es entandard
                    if (bool.Parse(arr[4].ToString()))
                        view.DisplayStockPremium(chupin.CantChupinStandard.ToString());
                    else
                        view.DisplayStockPremium(chupin.CantChupinPremium.ToString());
                    //muestra stock
                    view.DisplayStock(chupin.CantChupin.ToString());
                }
                else
                {
                    //si es entandard
                    if (bool.Parse(arr[4].ToString()))
                        view.DisplayStockPremium(pantalonComun.CantComunStandard.ToString());
                    else
                        view.DisplayStockPremium(pantalonComun.CantComunPremium.ToString());
                    //muestra stock
                    view.DisplayStock(pantalonComun.CantComun.ToString());
                }
                #endregion
            }
        }
        private static bool ValidacionEntero(object dato)
        {
            return int.TryParse(dato.ToString(), out _);
        }
    }
}
