using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVisual
{
    public partial class Base : Form
    {
        public Base()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(childForm);
            panelContenedor.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void bntRegistrar_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new panelAdmin());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            const string message = "Si Cierra la Aplicion se Cerrara su Sesion \n Seguro Desea Salir?";
            const string caption = "Mensaje de sistema";
            var result = MessageBox.Show(this, message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);


            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new UnidadesInternas());
        }
    }
}
