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
    public class TipArticuloRepositorio : DDataAccess, IGeneralRepositorio<TipArticulo>
    {
        public IDictionary<string, object> Actualizar(TipArticulo entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(TipArticulo entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(TipArticulo entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(TipArticulo entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_TipoArticulo]");
            return dt;
        }

        public DataTable ListarPaginado(TipArticulo entidad)
        {
            throw new NotImplementedException();
        }
    }
}
