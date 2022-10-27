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


        }
        
    }
}
