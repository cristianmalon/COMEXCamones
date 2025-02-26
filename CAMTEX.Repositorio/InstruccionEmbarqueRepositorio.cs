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
    public class InstruccionEmbarqueRepositorio : DDataAccess, IGeneralRepositorio<InstruccionEmbarque>
    {
        public IDictionary<string, object> Actualizar(InstruccionEmbarque entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Eliminar(InstruccionEmbarque entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(InstruccionEmbarque entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(InstruccionEmbarque entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable ListarPaginado(InstruccionEmbarque entidad)
        {
            throw new NotImplementedException();
        }
        public DataTable ListarInstruccionEmbarque()
        {
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_InstruccionEmbarque_Lista]");
            return dt;
        }
    }
}
