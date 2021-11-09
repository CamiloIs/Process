using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAcessoDatos;
using System.Data;

namespace CapaNegocio
{
   public class modeloUnidad
    {

        public void insertUnidad()
        {
            mantenedores man = new mantenedores();
            man.ingresarUnidad();
        }

        public DataSet listarUnidades()
        {
            mantenedores man = new mantenedores();
            return man.listarUnidades();
        }

        public void eliminarUnidad(Int32 id)
        {
            mantenedores man = new mantenedores();
            man.eliminarUnidad(id);
        }

        public void updateUnidad(Int32 id)
        {
            mantenedores man = new mantenedores();
            man.actualizarUnidad(id);
        }
    }
}
