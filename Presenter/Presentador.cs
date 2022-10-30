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
            float valorprecio = 0;
            MangaLarga mangaL;
            MangaCorta mangaC;
            Chupin chupin;
            Comun pantalonComun;

            #region Validacion datos ingresados
            //cantidad ingresada
            if (!ValidacionEntero(arr[5])) //arr[5] --> cantidad
            {
                EmitirError("Ingrese una cantidad valida.", this.view);
                return;
            }
            //precio ingresada
            if (!ValidacionFloat(arr[6])) //arr[6] --> precio
            {
                EmitirError("Ingrese un precio valido.", this.view);
                return;
            }
            #endregion
            
            //si se chequeo Camisa
            if (bool.Parse(arr[0].ToString())) //arr[0] --> camisa
            {
                mangaL = new MangaLarga();
                mangaC = new MangaCorta();

                //almacenos los datos en Prenda Para luego poder hacer al logica de negocio
                //es indistinto pasar por parametro la prenda que sea
                AlamacenarDatosPrenda(mangaL, arr);
                AlamacenarDatosPrenda(mangaC, arr);

                #region Logica Camisa
                //si no se marco nada
                if (!bool.Parse(arr[2].ToString()) && !bool.Parse(arr[1].ToString()))
                {
                    if (bool.Parse(arr[4].ToString()))
                    {
                        //si la cantidad ingresado es mayor a la cantidad de cuello comun standard, se emite un error
                        if (int.Parse(arr[5].ToString()) > int.Parse(mangaL.CantCuelloComunStandard.ToString()))
                            EmitirError("La cantidad es mayor a la disponible", this.view);
                        if (int.Parse(arr[5].ToString()) <= 0)
                            EmitirError("La cantidad tiene que ser mayor que 0", this.view);
                        else
                            //manda a la vista el precio unitario por la cantidad
                            valorprecio = mangaL.CalcularPrecioUnitarioXCantidad();
                            this.view.DisplayResult(valorprecio.ToString(), false, "no paso nada jeje");
                    }
                    else 
                    {
                        //si la cantidad ingresado es mayor a la cantidad de cuello comun premium, se emite un error
                        if (int.Parse(arr[5].ToString()) > int.Parse(mangaL.CantCuelloComunPremium.ToString()))
                            EmitirError("La cantidad es mayor a la disponible", this.view);
                        if (int.Parse(arr[5].ToString()) <= 0)
                            EmitirError("La cantidad tiene que ser mayor que 0", this.view);
                        else
                        {
                            //aplico aumento por ser premium del 30% y manda a la vista
                            this.view.DisplayResult(mangaL.CalcularAumentoPremium().ToString(), false, "no paso nada jeje");
                        }
                    }
                }
                //si se marco Manga corta unicamente
                if (bool.Parse(arr[1].ToString()) && !bool.Parse(arr[2].ToString()))
                {
                    //si se marco standard
                    if (bool.Parse(arr[4].ToString()))
                    {
                        if (int.Parse(arr[5].ToString()) > int.Parse(mangaC.CantCuelloComunStandard.ToString()))
                            EmitirError("La cantidad es mayor a la disponible", this.view);
                        if (int.Parse(arr[5].ToString()) <= 0)
                            EmitirError("La cantidad tiene que ser mayor que 0", this.view);
                        else
                            //aplico descuento del 10% y manda a la vista
                            this.view.DisplayResult(mangaC.CalcularDescuentoMangaCorta().ToString(), false, "no paso nada jeje");
                    }
                    else
                    {
                        if (int.Parse(arr[5].ToString()) > int.Parse(mangaC.CantCuelloComunPremium.ToString()))
                            EmitirError("La cantidad es mayor a la disponible", this.view);
                        if (int.Parse(arr[5].ToString()) <= 0)
                            EmitirError("La cantidad tiene que ser mayor que 0", this.view);
                        else
                        {
                            //aplico aumento por ser premium del 30% y manda a la vista
                            this.view.DisplayResult(mangaC.CalcularDescuentoMangaCortaMasPremium().ToString(), false, "no paso nada jeje");
                        }
                    }
                }
                //si se marco Cuello Mao unicamente
                if (bool.Parse(arr[2].ToString()) && !bool.Parse(arr[1].ToString()))
                {
                    //si se marco standard
                    if (bool.Parse(arr[4].ToString()))
                    {
                        if (int.Parse(arr[5].ToString()) > int.Parse(mangaL.CantCuelloMaoStandard.ToString()))
                            EmitirError("La cantidad es mayor a la disponible", this.view);
                        if (int.Parse(arr[5].ToString()) <= 0)
                            EmitirError("La cantidad tiene que ser mayor que 0", this.view);
                        else
                            //aplico aumento del 3% y manda a la vista
                            this.view.DisplayResult(mangaL.CalcularAumentoCuelloMao().ToString(), false, "no paso nada jeje");
                    }
                    else
                    {
                        if (int.Parse(arr[5].ToString()) > int.Parse(mangaL.CantCuelloMaoPremium.ToString()))
                            EmitirError("La cantidad es mayor a la disponible", this.view);
                        if (int.Parse(arr[5].ToString()) <= 0)
                            EmitirError("La cantidad tiene que ser mayor que 0", this.view);
                        else
                        {
                            //aplico aumento por ser premium del 30% y manda a la vista
                            this.view.DisplayResult(mangaL.CalcularAumentoCuelloMaoMasPremium().ToString(), false, "no paso nada jeje");
                        }
                    }
                }
                //si se marco Manga corta && Cuello Mao
                if (bool.Parse(arr[1].ToString()) && bool.Parse(arr[2].ToString()))
                {
                    //si es standard muestra
                    if (bool.Parse(arr[4].ToString()))
                    {
                        if (int.Parse(arr[5].ToString()) > int.Parse(mangaC.CantCuelloMaoStandard.ToString()))
                        {
                            EmitirError("La cantidad es mayor a la disponible", this.view);
                            return;
                        }
                        if (int.Parse(arr[5].ToString()) <= 0)
                        {
                            EmitirError("La cantidad tiene que ser mayor que 0", this.view);
                            return;
                        }
                            
                        else
                            //aplico descuento del 10% + aumento del 3% y mando a la vista
                            this.view.DisplayResult(mangaC.CalcularDescuentoMangaCortaYCuelloMao().ToString(), false, "no paso nada jeje");
                    }
                    else
                    {
                        if (int.Parse(arr[5].ToString()) > int.Parse(mangaC.CantCuelloMaoStandard.ToString()))
                            EmitirError("La cantidad es mayor a la disponible", this.view);
                        if (int.Parse(arr[5].ToString()) <= 0)
                            EmitirError("La cantidad tiene que ser mayor que 0", this.view);
                        else
                        {
                            //aplico aumento por ser premium del 30% y manda a la vista
                            this.view.DisplayResult(mangaC.CalcularDescuentoMangaCortaYCuelloMaoPremium().ToString(), false, "no paso nada jeje");
                        }
                    }
                }
                #endregion
            }
            //sino, se chequeo el pantalon
            else
            {
                chupin = new Chupin();
                pantalonComun = new Comun();

                //almacenos los datos en Prenda Para luego poder hacer al logica de negocio
                //es indistinto pasar por parametro la prenda que sea
                AlamacenarDatosPrenda(pantalonComun, arr);
                AlamacenarDatosPrenda(chupin, arr);

                #region Logica Pantalon
                //si se marco chupin
                if (bool.Parse(arr[3].ToString()))
                {
                    //si es entandard
                    if (bool.Parse(arr[4].ToString()))
                    {
                        if (int.Parse(arr[5].ToString()) > int.Parse(chupin.CantChupinStandard.ToString()))
                            EmitirError("La cantidad es mayor a la disponible", this.view);
                        if (int.Parse(arr[5].ToString()) <= 0)
                            EmitirError("La cantidad tiene que ser mayor que 0", this.view);
                        else
                            //aplico descuento del 12% y mando a la vista
                            this.view.DisplayResult(chupin.CalcularDescuentoChupin().ToString(), false, "no paso nada jeje");
                    }
                    else
                    {
                        if (int.Parse(arr[5].ToString()) > int.Parse(chupin.CantChupinPremium.ToString()))
                            EmitirError("La cantidad es mayor a la disponible", this.view);
                        if (int.Parse(arr[5].ToString()) <= 0)
                            EmitirError("La cantidad tiene que ser mayor que 0", this.view);
                        else
                        {
                            //aplico aumento del 30% por ser premium
                            this.view.DisplayResult(chupin.CalcularDescuentoChupinMasPremium().ToString(), false, "no paso nada jeje");
                        }
                    }
                }
                //sino, es un pantalon comun
                else
                {
                    //si es entandard
                    if (bool.Parse(arr[4].ToString()))
                    {
                        if (int.Parse(arr[5].ToString()) > int.Parse(pantalonComun.CantComunStandard.ToString()))
                            EmitirError("La cantidad es mayor a la disponible", this.view);
                        if (int.Parse(arr[5].ToString()) <= 0)
                            EmitirError("La cantidad tiene que ser mayor que 0", this.view);
                        else
                            this.view.DisplayResult(pantalonComun.CalcularPrecioUnitarioXCantidad().ToString(), false, "no paso nada jeje");
                    }
                    else
                    {
                        if (int.Parse(arr[5].ToString()) > int.Parse(pantalonComun.CantComunPremium.ToString()))
                            EmitirError("La cantidad es mayor a la disponible", this.view);
                        if (int.Parse(arr[5].ToString()) <= 0)
                            EmitirError("La cantidad tiene que ser mayor que 0", this.view);
                        else
                        {
                            //aplico aumento del 30% por ser premium
                            this.view.DisplayResult(pantalonComun.CalcularAumentoPremium().ToString(), false, "no paso nada jeje");
                        }
                    }
                }
                #endregion
            }
        }
        #region Metodos
        private static bool ValidacionEntero(object dato)
        {
            return int.TryParse(dato.ToString(), out _);
        }
        private static bool ValidacionFloat(object dato)
        {
            return float.TryParse(dato.ToString(), out _);
        }
        private static void EmitirError(string mj, IView view)
        {
            view.DisplayResult("Error", true, mj);
        }
        private static void AlamacenarDatosPrenda(Prenda obj, ArrayList arr)
        {
            obj.Stock = int.Parse(arr[5].ToString());
            obj.PrecioUnitario = int.Parse(arr[6].ToString());
        }
        #endregion
    }
}
