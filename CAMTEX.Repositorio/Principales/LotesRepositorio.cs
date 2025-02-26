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
    public class LotesRepositorio : DDataAccess, IGeneralRepositorio<Lotes>
    {
        public IDictionary<string, object> Actualizar(Lotes entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(Lotes entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(Lotes entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(Lotes entidad)
        {
            oConn.AddParameter("@opcion", 1);
            oConn.AddParameter("@file", entidad.IdFile);
            oConn.AddParameter("@idOp", entidad.IdOPeraciones);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_ListarLotes]");
            return dt;
        }

        public DataTable ListarPaginado(Lotes entidad)
        {
            throw new NotImplementedException();
        }
    }
}
