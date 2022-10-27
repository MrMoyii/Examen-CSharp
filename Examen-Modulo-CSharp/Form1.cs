using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Presenter;
using System.Collections;

namespace Examen_Modulo_CSharp
{
    public partial class Form1 : Form, IView
    {
        Presentador presentador;
        public Form1()
        {
            InitializeComponent();
            presentador = new Presentador(this);
        }

        #region Diseño y control del form
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion


        public void DisplayResult(string result, bool error, string quePaso)
        {
            throw new NotImplementedException();
        }

        public ArrayList GetInputValues()
        {
            throw new NotImplementedException();
        }

        public void DisplayData(ArrayList datos)
        {
            lbNombreTienda.Text = datos[0].ToString();
            lbDireccionTienda.Text = datos[1].ToString();
            lbNombreYApellidoVendedor.Text = datos[2] + " " + datos[3];
            lbCodigoVendedor.Text = datos[4].ToString();
        }
    }
}
