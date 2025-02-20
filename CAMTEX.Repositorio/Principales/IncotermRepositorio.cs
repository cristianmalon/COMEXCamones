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
    public class IncotermRepositorio : DDataAccess, IGeneralRepositorio<Incoterm>
    {
        public IDictionary<string, object> Actualizar(Incoterm entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(Incoterm entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(Incoterm entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(Incoterm entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Incoterm]");
            return dt;
        }

        public DataTable ListarPaginado(Incoterm entidad)
        {
            throw new NotImplementedException();
        }
    }
}
