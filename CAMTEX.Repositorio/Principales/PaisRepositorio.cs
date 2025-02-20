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
    public class PaisRepositorio : DDataAccess, IGeneralRepositorio<Pais>
    {
        public IDictionary<string, object> Actualizar(Pais entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(Pais entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(Pais entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(Pais entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_Pais]");
            return dt;
        }

        public DataTable ListarPaginado(Pais entidad)
        {
            throw new NotImplementedException();
        }
    }
}
