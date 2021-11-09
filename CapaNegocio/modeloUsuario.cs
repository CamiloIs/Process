using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAcessoDatos;

namespace CapaNegocio
{
    public class modeloUsuario
    {
       
        
        public bool LoginUsuario(string user, string pass)
        {
            usuarioDao userDao = new usuarioDao();
            return userDao.Login(user, pass);

        }

        public void insert()
        {
            mantenedores man = new mantenedores();
            man.ejecutarProcedimientoConOutput();
        }

        public DataSet listarUsuarios()
        {
            mantenedores man = new mantenedores();
            return man.listarUsuarios();
        }

        public void eliminarUser(String rut)
        {
            mantenedores man = new mantenedores();
            man.eliminarUsuario(rut);
        }

        public void updateUser(String rut)
        {
            mantenedores man = new mantenedores();
            man.actualizarUsuario(rut);
        }
    }
}
