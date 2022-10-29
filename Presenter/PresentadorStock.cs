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
                MangaLarga mangaL = new MangaLarga();
                MangaCorta mangaC = new MangaCorta();

                #region Logica Camisa
                //si no se marco nada
                if (!bool.Parse(arr[2].ToString()) && !bool.Parse(arr[1].ToString()))
                {
                    if (bool.Parse(arr[4].ToString()))
                        view.DisplayStockPremium(mangaL.CantCuelloComunStandard.ToString());
                    else
                        view.DisplayStockPremium(mangaL.CantCuelloComunPremium.ToString());
                    view.DisplayStock(mangaL.CantCuelloComun.ToString());
                }
                //si se marco Cuello Mao unicamente--> muestro manga larga con cuello mao
                if (bool.Parse(arr[2].ToString()) && !bool.Parse(arr[1].ToString()))
                {
                    if (bool.Parse(arr[4].ToString()))
                        view.DisplayStockPremium(mangaL.CantCuelloMaoStandard.ToString());
                    else
                        view.DisplayStockPremium(mangaL.CantCuelloMaoPremium.ToString());
                    view.DisplayStock(mangaL.CantCuelloMao.ToString());
                }
                //si se marco Manga corta && Cuello Mao
                if (bool.Parse(arr[1].ToString()) && bool.Parse(arr[2].ToString()))
                {
                    //si es standar muestra en la vista
                    if (bool.Parse(arr[4].ToString()))
                        view.DisplayStockPremium(mangaC.CantCuelloMaoStandard.ToString());
                    else
                        view.DisplayStockPremium(mangaC.CantCuelloMaoPremium.ToString());
                    view.DisplayStock(mangaC.CantCuelloMao.ToString());
                }
                //si se marco Manga corta unicamente--> muestro manga corta con cuello comun
                if (bool.Parse(arr[1].ToString()) && !bool.Parse(arr[2].ToString()))
                {
                    if (bool.Parse(arr[4].ToString()))
                        view.DisplayStockPremium(mangaC.CantCuelloComunStandard.ToString());
                    else
                        view.DisplayStockPremium(mangaC.CantCuelloComunPremium.ToString());
                    view.DisplayStock(mangaC.CantCuelloComun.ToString());
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
    }
}
