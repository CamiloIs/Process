using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using CapaNegocio;
using CapaSoporte.cache;
using MySql.Data.MySqlClient;

namespace CapaVisual
{
    public partial class Login : Form
    {
        //MySqlConnection conexion =  new MySqlConnection("Server=localhost; Database=process; User=root; port=3306; password=1994; SSL Mode=0;");
        public Login()
        {
            InitializeComponent();
            txtPass.UseSystemPasswordChar = true;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {  
            if (txtUser.Text != "Username" && txtUser.TextLength > 2)
            {
                if (txtPass.Text != "Password")
                {
                    modeloUsuario user = new modeloUsuario();
                    var validLogin = user.LoginUsuario(txtUser.Text, txtPass.Text);
                    if (validLogin == true)
                    {
                        if (cuenta.rol == "Administrador")
                        {

                            Base mainMenu = new Base();
                            MessageBox.Show("Bienvenido " + cuenta.usuario);
                            mainMenu.Show();
                            mainMenu.FormClosed += Logout;
                            this.Hide();
                        }
                        else 
                        {
                            MessageBox.Show("Usuario no es Administrador");
                        
                        }
                        
                    }
                    else
                    {
                        msgError("Incorrect username or password entered. \n   Please try again.");
                        txtPass.Text = "Password";
                        
                        txtUser.Focus();
                    }
                }
                else msgError("Please enter password.");
            }
            else msgError("Please enter username.");
            

            

        }
        private void msgError(string msg)
        {
            lblError.Text = "    " + msg;
            lblError.Visible = true;
        }
        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtPass.Text = "";
            txtPass.UseSystemPasswordChar = true;
            txtUser.Text = "";
            lblError.Visible = false;
            this.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //conexion.Open();
            //MessageBox.Show("holiiii");
            //conexion.Close();
        }
    }
}
