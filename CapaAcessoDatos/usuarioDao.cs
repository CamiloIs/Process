using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using CapaSoporte.cache;

namespace CapaAcessoDatos
{
    public class usuarioDao : conexionMySQL
    {
        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM cuenta where (usuario=@user and password=@pass)";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())//Obtenemos los datos de la columna y asignamos a los campos de la Cache de Usuario
                        {
                            cuenta.idCuenta = reader.GetInt32(0);
                            cuenta.usuario = reader.GetString(1);
                            cuenta.password = reader.GetString(2);
                            cuenta.rol = reader.GetString(3);
                            
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
    }
}
