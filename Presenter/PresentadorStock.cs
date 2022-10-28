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
                //si se seleccionado Standard
                if (bool.Parse(arr[4].ToString()))
                {
                    //si se seleccionan ambas se muestra la cantidad de manga corta con cuello mao y standard
                    if (bool.Parse(arr[1].ToString()) && bool.Parse(arr[2].ToString()))
                    {
                        MangaCorta mangaC = new MangaCorta();
                        view.DisplayStock(mangaC.CantCuelloMaoStandard.ToString());
                    }
                    //si se seleccionan manga corta se muestra la cantidad de cuello comun y standard
                    if (bool.Parse(arr[1].ToString()))
                    {
                        MangaCorta mangaC = new MangaCorta();
                        view.DisplayStock(mangaC.CantCuelloComunStandard.ToString());
                    }
                    //si se seleccionan cuello mao se muestra la cantidad de manga larga y standard
                    if (bool.Parse(arr[2].ToString()))
                    {
                        MangaLarga mangaL = new MangaLarga();
                        view.DisplayStock(mangaL.CantCuelloMaoStandard.ToString());
                    }
                }
                //sino la prenda es premium
                else
                {
                    //si se seleccionan ambas se muestra la cantidad de manga corta con cuello mao y premium
                    if (bool.Parse(arr[1].ToString()) && bool.Parse(arr[2].ToString()))
                    {
                        MangaCorta mangaC = new MangaCorta();
                        view.DisplayStock(mangaC.CantCuelloMaoPremium.ToString());
                    }
                    //si se seleccionan manga corta se muestra la cantidad de cuello comun y premium
                    if (bool.Parse(arr[1].ToString()))
                    {
                        MangaCorta mangaC = new MangaCorta();
                        view.DisplayStock(mangaC.CantCuelloComunPremium.ToString());
                    }
                    //si se seleccionan cuello mao se muestra la cantidad de manga larga y premium
                    if (bool.Parse(arr[2].ToString()))
                    {
                        MangaLarga mangaL = new MangaLarga();
                        view.DisplayStock(mangaL.CantCuelloMaoPremium.ToString());
                    }
                }
                

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
