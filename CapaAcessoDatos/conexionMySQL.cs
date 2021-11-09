using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CapaAcessoDatos
{
    public class conexionMySQL
    {
        private readonly string connectionString;
        public conexionMySQL()
        {
            connectionString = "Server=localhost; Database=process; User=root; port=3306; password=1994; SSL Mode=0;";
        }
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
