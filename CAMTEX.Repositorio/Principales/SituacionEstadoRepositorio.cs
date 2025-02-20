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
    public class SituacionEstadoRepositorio : DDataAccess, IGeneralRepositorio<SituacionEstado>
    {
        public IDictionary<string, object> Actualizar(SituacionEstado entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(SituacionEstado entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(SituacionEstado entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(SituacionEstado entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_SituacionEstado]");
            return dt;
        }

        public DataTable ListarPaginado(SituacionEstado entidad)
        {
            throw new NotImplementedException();
        }
    }
}
