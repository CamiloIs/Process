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
    public partial class UnidadesInternas : Form
    {
        public UnidadesInternas()
        {
            InitializeComponent();
            txtfechaC.Text = DateTime.Now.ToString();
            txtulmod.Text = DateTime.Now.ToString();
        }

        private bool Editar = false;
        private Int32 id = 0;

        MySqlConnection conectar = new MySqlConnection("Server=localhost; Database=process; User=root; port=3306; password=; SSL Mode=0;");
        DataSet ds;

        DataSet resultado = new DataSet();
        DataView miFiltro;

        private void MostrarTabla()
        {
            conectar.Open();
            MySqlCommand comm = new MySqlCommand("SELECT * FROM unidadInterna", conectar);

            MySqlDataAdapter con = new MySqlDataAdapter(comm);
            ds = new DataSet();
            con.Fill(ds);
            dtUnidad.DataSource = ds.Tables[0];
            conectar.Close();

            //CapaAcessoDatos.conexionMySQL con = new conexionMySQL();
            //con.Open();
            //modeloUsuario man = new modeloUsuario();
            ////dtUsuarios.DataSource = man.listarUsuarios();
            ////dtUsuarios.Tables[0];
            ////dtUsuarios.DataMember = "usuario";
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                modeloUnidad man = new modeloUnidad();

                unidadInterna.nombreUnidad = this.txtnom.Text;
                unidadInterna.fechaCre = this.txtfechaC.Text;
                unidadInterna.ultimaMod = this.txtulmod.Text;
                unidadInterna.numTareas = this.txtNunt.Text;
                unidadInterna.userCreador = this.txtusercre.Text;
                unidadInterna.area = this.txtarea.Text;

                man.insertUnidad();
                MostrarTabla();
                Limpiar();
                MessageBox.Show("Unidad Creado Exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unidad no Creado" + ex.Message, "Mensaje de Sistema");
            }
        }

        private void Limpiar()
        {
            txtId.Clear();
            txtnom.Clear();
            txtfechaC.Clear();
            txtulmod.Clear();
            txtNunt.Clear();
            txtusercre.Clear();
            txtarea.Clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                modeloUnidad man = new modeloUnidad();
                unidadInterna.idUnidad = Convert.ToInt32(this.txtId.Text);
                unidadInterna.nombreUnidad = this.txtnom.Text;
                unidadInterna.fechaCre = this.txtfechaC.Text;
                unidadInterna.ultimaMod = this.txtulmod.Text;
                unidadInterna.numTareas = this.txtNunt.Text;
                unidadInterna.userCreador = this.txtusercre.Text;
                unidadInterna.area = this.txtarea.Text;

                man.updateUnidad(id);
                MostrarTabla();
                Limpiar();
                MessageBox.Show("Unidad Actualizado Exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unidad no Actualizado" + ex.Message, "Mensaje de Sistema");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtUnidad.SelectedRows.Count == 1)
                {
                    modeloUnidad man = new modeloUnidad();
                    unidadInterna.idUnidad = Convert.ToInt32(dtUnidad.CurrentRow.Cells["idUnidad"].Value);
                    man.eliminarUnidad(id);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtUnidad.SelectedRows.Count == 1)
            {
                Editar = true;
                txtId.Text = dtUnidad.CurrentRow.Cells["idUnidad"].Value.ToString();
                txtnom.Text = dtUnidad.CurrentRow.Cells["nombreUnidad"].Value.ToString();
                txtfechaC.Text = dtUnidad.CurrentRow.Cells["fechaCre"].Value.ToString();
                txtulmod.Text = dtUnidad.CurrentRow.Cells["ultimaMod"].Value.ToString();
                txtNunt.Text = dtUnidad.CurrentRow.Cells["numTareas"].Value.ToString();
                txtusercre.Text = dtUnidad.CurrentRow.Cells["userCreador"].Value.ToString();
                txtarea.Text = dtUnidad.CurrentRow.Cells["area"].Value.ToString();
                

            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor", "Mensaje de Sistema");
            }
        }

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

        private void UnidadesInternas_Load(object sender, EventArgs e)
        {
            this.leerDatos("SELECT * FROM unidadInterna", ref resultado, "nombreUnidad");
            this.miFiltro = ((DataTable)resultado.Tables["nombreUnidad"]).DefaultView;
            this.dtUnidad.DataSource = miFiltro;
        }
    }
}
