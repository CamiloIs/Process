using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaSoporte.cache;
using CapaNegocio;
using CapaAcessoDatos;
using MySql.Data.MySqlClient;


namespace CapaVisual
{
    public partial class panelAdmin : Form
    {
        public panelAdmin()
        {
            InitializeComponent();
            LoadUserData();
        }

        private bool Editar = false;
        private string rut = null;

        MySqlConnection conectar = new MySqlConnection("Server=localhost; Database=process; User=root; port=3306; password=; SSL Mode=0;");
        DataSet ds;

        DataSet resultado = new DataSet();
        DataView miFiltro;

        private void MostrarTabla()
        {
            conectar.Open();
            MySqlCommand comm = new MySqlCommand("SELECT * FROM usuario", conectar);

            MySqlDataAdapter con = new MySqlDataAdapter(comm);
            ds = new DataSet();
            con.Fill(ds);
            dtUsuarios.DataSource = ds.Tables[0];
            conectar.Close();

            //CapaAcessoDatos.conexionMySQL con = new conexionMySQL();
            //con.Open();
            //modeloUsuario man = new modeloUsuario();
            ////dtUsuarios.DataSource = man.listarUsuarios();
            ////dtUsuarios.Tables[0];
            ////dtUsuarios.DataMember = "usuario";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to log out?", "Warning",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Dispose();
        }

        private void LoadUserData()
        {
            lblUser.Text = cacheUsuario.nombre;
            lblRol.Text = cuenta.rol;
            lblCorreo.Text = cacheUsuario.correo;
        }

        private void panelAdmin_Load(object sender, EventArgs e)
        {
            this.leerDatos("SELECT * FROM usuario", ref resultado, "usuario");
            this.miFiltro = ((DataTable)resultado.Tables["usuario"]).DefaultView;
            this.dtUsuarios.DataSource = miFiltro;
            // MostrarTabla();
            //this.leerDatos("SELECT * FROM Usuarios", ref resultado, "Usuarios");
            //this.miFiltro = ((DataTable)resultado.Tables["Usuarios"]).DefaultView;
            //this.dtUsuarios.DataSource = miFiltro;
        }

        
    
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                modeloUsuario man = new modeloUsuario();

                //Usuario.usuario = this.txtUser.Text;
                //Usuario.password = this.txtPass.Text;
                //Usuario.rut = this.txtRut.Text;
                //Usuario.nombre = this.txtNombre.Text;
                //Usuario.apellido = this.txtApellido.Text;
                //Usuario.correo = this.txtCorreo.Text;
                //Usuario.rol = this.txtRol.Text;
                //Usuario.jerarquia = this.txtJer.Text;

                man.insert();
                MostrarTabla();
                Limpiar();
                MessageBox.Show("Usuario Creado Exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario no Creado" + ex.Message, "Mensaje de Sistema");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtUsuarios.SelectedRows.Count == 1)
                {
                    mantenedores man = new mantenedores();
                    Usuario.rut = dtUsuarios.CurrentRow.Cells["rut"].Value.ToString();
                    man.eliminarUsuario(rut);
                    MostrarTabla();
                    Limpiar();

                    //ServiceClient.WebServiceClientSoapClient auxServiceCliente = new ServiceClient.WebServiceClientSoapClient();

                    //ServiceClient.Usuarios auxUsuario = new ServiceClient.Usuarios();

                    //auxServiceCliente.eliminarUsuarioService(Rut);
                    MessageBox.Show("Eliminado correctamente", "Mensaje de Sistema");
                    
                }
                else
                    MessageBox.Show("Seleccione una fila por favor", "Mensaje de Sistema");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        //private void leerDatos(/*string query, ref DataSet dtsprincipal, string tabla*/)
        //{
        //    try
        //    {
        //        modeloUsuario man = new modeloUsuario();
        //        man.insert();

        //        //string cadena = "Data Source=DESKTOP-SVH5M1U;Initial Catalog=evaGames;Integrated Security=True";
        //        //MySqlConnection cn = new SqlConnection(cadena);
        //        //SqlCommand cmd = new SqlCommand(query, cn);
        //        //cn.Open();
        //        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        //da.Fill(dtsprincipal, tabla);
        //        //da.Dispose();
        //        //cn.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }


        //}

        private void leerDatos(string query, ref DataSet dtsprincipal, string tabla)
        {
            try
            {
                string cadena = "Server = localhost; Database = process; User = root; port = 3306; password =; SSL Mode = 0; ";
                MySqlConnection cn = new MySqlConnection(cadena);
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dtsprincipal, tabla);
                da.Dispose();
                cn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string salidaDatos = string.Empty;
            string[] palabras_busqueda = this.txtBuscar.Text.Split(' ');

            foreach (string palabra in palabras_busqueda)
            {
                if(salidaDatos.Length == 0)
                {
                    salidaDatos = "(nombre LIKE '%" + palabra + "%' OR apellido LIKE '%" + palabra + "%' OR rut LIKE '%" + palabra
                                + "%' OR usuario LIKE '%" + palabra + "%' OR correo LIKE '%" + palabra + "%' OR rol LIKE '%" + palabra + "%')";
                }
                else
                {
                    salidaDatos += " AND (nombre LIKE '%" + palabra + "%' OR apellido LIKE '%" + palabra + "%' OR rut LIKE '%" + palabra
                                + "%' OR usuario LIKE '%" + palabra + "%' OR correo LIKE '%" + palabra + "%' OR rol LIKE '%" + palabra + "%')";
                }
            }

            this.miFiltro.RowFilter = salidaDatos;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtUsuarios.SelectedRows.Count == 1)
            {
                Editar = true;
                txtUser.Text = dtUsuarios.CurrentRow.Cells["usuario"].Value.ToString();
                txtPass.Text = dtUsuarios.CurrentRow.Cells["password"].Value.ToString();
                txtRut.Text = dtUsuarios.CurrentRow.Cells["rut"].Value.ToString();
                txtNombre.Text = dtUsuarios.CurrentRow.Cells["nombre"].Value.ToString();
                txtApellido.Text = dtUsuarios.CurrentRow.Cells["apellido"].Value.ToString();                              
                txtCorreo.Text = dtUsuarios.CurrentRow.Cells["correo"].Value.ToString();
                txtRol.Text = dtUsuarios.CurrentRow.Cells["rol"].Value.ToString();
                txtJer.Text = dtUsuarios.CurrentRow.Cells["jerarquia"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor", "Mensaje de Sistema");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                modeloUsuario man = new modeloUsuario();

                //Usuario.usuario = this.txtUser.Text;
                //Usuario.password = this.txtPass.Text;
                //Usuario.rut = this.txtRut.Text;
                //Usuario.nombre = this.txtNombre.Text;
                //Usuario.apellido = this.txtApellido.Text;
                //Usuario.correo = this.txtCorreo.Text;
                //Usuario.rol = this.txtRol.Text;
                //Usuario.jerarquia = this.txtJer.Text;

                man.updateUser(rut);
                MostrarTabla();
                Limpiar();
                MessageBox.Show("Usuario Actualizado Exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario no Actualizado" + ex.Message, "Mensaje de Sistema");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtRut.Clear();
            txtUser.Clear();
            txtCorreo.Clear();
            txtRol.Clear();
            txtPass.Clear();
            txtJer.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
