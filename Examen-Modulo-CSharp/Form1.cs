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
        DatosTiendaYVendedor datosTiendaYVendedor;
        public Form1()
        {
            InitializeComponent();
            checkChupin.Enabled = false;
            datosTiendaYVendedor = new DatosTiendaYVendedor(this);
        }

        public void DisplayResult(string result, bool error, string quePaso)
        {
            if (error)
                MessageBox.Show(quePaso, result);
            else
                txtPrecioCalculado.Text = result;
        }

        public ArrayList GetInputValues()
        {
            ArrayList datosIngresador = new ArrayList();
            datosIngresador.Add(rbCamisa.Checked);          //1
            datosIngresador.Add(rbPantalon.Checked);        //2
            datosIngresador.Add(checkMangaCorta.Checked);   //3
            datosIngresador.Add(checkCuelloMao.Checked);    //4
            datosIngresador.Add(checkChupin.Checked);       //5
            datosIngresador.Add(rbCamisa.Checked);          //6
            datosIngresador.Add(rbCamisa.Checked);          //7

            return datosIngresador;
        }

        public void DisplayData(ArrayList datos)
        {
            lbNombreTienda.Text = datos[0].ToString();
            lbDireccionTienda.Text = datos[1].ToString();
            lbNombreYApellidoVendedor.Text = datos[2] + " " + datos[3];
            lbCodigoVendedor.Text = datos[4].ToString();
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

        private void rbPantalon_CheckedChanged(object sender, EventArgs e)
        {
            checkChupin.Enabled = true;
            checkMangaCorta.Checked = false;
            checkMangaCorta.Enabled = false;
            checkCuelloMao.Checked = false;
            checkCuelloMao.Enabled = false;
        }

        private void rbCamisa_CheckedChanged(object sender, EventArgs e)
        {
            checkChupin.Enabled = false;
            checkChupin.Checked = false;
            checkMangaCorta.Enabled = true;
            checkCuelloMao.Enabled = true;
        }
    }
}
