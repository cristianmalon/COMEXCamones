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
    public class ProductoRepositorio : DDataAccess, IGeneralRepositorio<Producto>
    {
        public IDictionary<string, object> Actualizar(Producto entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(Producto entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(Producto entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(Producto entidad)
        {
            entidad.cadenaCodigo = string.Join(",", entidad.cadenaCodigo.Split(',').Select(x => $"'{x}'"));
            oConn.AddParameter("@opcion", 1);
            oConn.AddParameter("@OcId", entidad.OcId);
            oConn.AddParameter("@CadMae", entidad.cadenaCodigo);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[sp_ListarProductos]");
            return dt;
        }

        public DataTable ListarPaginado(Producto entidad)
        {
            oConn.AddParameter("@opcion", 1);
            oConn.AddParameter("@FileID", entidad.FileID);
            oConn.AddParameter("@OrdenID", entidad.OrdenID);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[USP_FileOperacionesProductos_listar]");
            return dt;
        }
    }
}
