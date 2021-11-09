using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CapaSoporte.cache;
using System.Data;

namespace CapaAcessoDatos
{
    public class mantenedores : conexionMySQL
    {

        //USUARIOS
        public void ejecutarProcedimientoConOutput()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERTAR_USUARIO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //command.Parameters.Add("@idUsuario", MySqlDbType.Int32).Value = Usuario.idUsuario;
                    //command.Parameters.Add("@rut", MySqlDbType.VarChar).Value = Usuario.usuario;
                    //command.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = Usuario.password;
                    //command.Parameters.Add("@rut", MySqlDbType.VarChar).Value = Usuario.rut;
                    //command.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = Usuario.nombre;
                    //command.Parameters.Add("@apellido", MySqlDbType.VarChar).Value = Usuario.apellido;
                    //command.Parameters.Add("@correo", MySqlDbType.VarChar).Value = Usuario.correo;
                    //command.Parameters.Add("@rol", MySqlDbType.VarChar).Value = Usuario.rol;
                    //command.Parameters.Add("@jerarquia", MySqlDbType.VarChar).Value = Usuario.jerarquia;
                    //command.ExecuteNonQuery();
 
                }
            }
        }

        public void eliminarUsuario(String rut)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("ELIMINAR_USUARIO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@rut", MySqlDbType.VarChar).Value = Usuario.rut;
                    command.ExecuteNonQuery();

                }
            }
        }


        public DataSet listarUnidades()
        {
            
            using (var connection = GetConnection())
            {
                connection.Open();
                //using (var command = new MySqlCommand("LISTAR_USUARIOS", connection))
               // {
                 //   command.CommandType = System.Data.CommandType.StoredProcedure;               
                  //  command.ExecuteNonQuery();
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM unidadInterna;", connection);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                    
                //}
            }
        }

        public void actualizarUsuario(String rut)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("ACTUALIZAR_USUARIO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    
                    //command.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = Usuario.usuario;
                    //command.Parameters.Add("@password", MySqlDbType.VarChar).Value = Usuario.password;
                    //command.Parameters.Add("@rut", MySqlDbType.VarChar).Value = Usuario.rut;
                    //command.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = Usuario.nombre;
                    //command.Parameters.Add("@apellido", MySqlDbType.VarChar).Value = Usuario.apellido;
                    //command.Parameters.Add("@correo", MySqlDbType.VarChar).Value = Usuario.correo;
                    //command.Parameters.Add("@rol", MySqlDbType.VarChar).Value = Usuario.rol;
                    //command.Parameters.Add("@jerarquia", MySqlDbType.VarChar).Value = Usuario.jerarquia;
                    //command.ExecuteNonQuery();

                }
            }
        }

        //UNIDADES

        public void ingresarUnidad()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERTAR_UNIDAD", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@idUnidad", MySqlDbType.Int32).Value = unidadInterna.idUnidad;
                    command.Parameters.Add("@nombreUnidad", MySqlDbType.VarChar).Value = unidadInterna.nombreUnidad;
                    command.Parameters.Add("@fechaCre", MySqlDbType.VarChar).Value = unidadInterna.fechaCre;
                    command.Parameters.Add("@ultimaMod", MySqlDbType.VarChar).Value = unidadInterna.ultimaMod;
                    command.Parameters.Add("@numTareas", MySqlDbType.VarChar).Value = unidadInterna.numTareas;
                    command.Parameters.Add("@userCreador", MySqlDbType.VarChar).Value = unidadInterna.userCreador;
                    command.Parameters.Add("@area", MySqlDbType.VarChar).Value = unidadInterna.area;
                    command.ExecuteNonQuery();

                }
            }
        }

        public void eliminarUnidad(Int32 id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("ELIMINAR_UNIDAD", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@idUnidad", MySqlDbType.VarChar).Value = unidadInterna.idUnidad;
                    command.ExecuteNonQuery();

                }
            }
        }


        public DataSet listarUsuarios()
        {

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM unidadesInternas;", connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

                //}
            }
        }

        public void actualizarUnidad(Int32 id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("ACTUALIZAR_UNIDAD", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    command.Parameters.Add("@idUnidad", MySqlDbType.Int32).Value = unidadInterna.idUnidad;
                    command.Parameters.Add("@nombreUnidad", MySqlDbType.VarChar).Value = unidadInterna.nombreUnidad;
                    //command.Parameters.Add("@fechaCre", MySqlDbType.VarChar).Value = unidadInterna.fechaCre;
                    command.Parameters.Add("@ultimaMod", MySqlDbType.VarChar).Value = unidadInterna.ultimaMod;
                    command.Parameters.Add("@numTareas", MySqlDbType.VarChar).Value = unidadInterna.numTareas;
                    command.Parameters.Add("@userCreador", MySqlDbType.VarChar).Value = unidadInterna.userCreador;
                    command.Parameters.Add("@area", MySqlDbType.VarChar).Value = unidadInterna.area;
                    command.ExecuteNonQuery();

                }
            }
        }
    }
}
