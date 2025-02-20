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
    public class TipTransporteRepositorio : DDataAccess, IGeneralRepositorio<TipTransporte>
    {
        public IDictionary<string, object> Actualizar(TipTransporte entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(TipTransporte entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(TipTransporte entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(TipTransporte entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_TipoTransporte]");
            return dt;
        }

        public DataTable ListarPaginado(TipTransporte entidad)
        {
            throw new NotImplementedException();
        }
    }
}
