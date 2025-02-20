using CAMTEX.Entidades;
using CAMTEX.UtilData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMTEX.Repositorio
{
    public class ArticuloRepositorio : DDataAccess, IGeneralRepositorio<Articulo>
    {
        public IDictionary<string, object> Actualizar(Articulo entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(Articulo entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(Articulo entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(Articulo entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Articulo]");
            return dt;
        }

        public DataTable ListarPaginado(Articulo entidad)
        {
            throw new NotImplementedException();
        }
    }
}
