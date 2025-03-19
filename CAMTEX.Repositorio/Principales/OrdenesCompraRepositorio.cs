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
    public class OrdenesCompraRepositorio : DDataAccess, IGeneralRepositorio<OrdenesCompra>
    {
        public IDictionary<string, object> Actualizar(OrdenesCompra entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> ActualizarDatosImportacion(OrdenesCompra entidad)
        {
            Dictionary<string, object> retorno = new Dictionary<string, object>();
            try
            {
                oConn.AddParameter("@FileID", entidad.FileID);
                oConn.AddParameter("@OrdenCompraSAP", entidad.OrdenCompraSAP);
                oConn.AddParameter("@NumeroOperacion", entidad.NumeroOperacion);
                oConn.AddParameter("@IdVia", entidad.IdVia);
                oConn.AddParameter("@BL", entidad.BL);
                oConn.AddParameter("@IdDeposito", entidad.IdDeposito);
                oConn.AddParameter("@SerieFactura", entidad.SerieFactura);
                oConn.AddParameter("@NumFactura", entidad.NumFactura);
                oConn.AddParameter("@FechaIngreso", entidad.FechaIngreso);
                oConn.AddParameter("@FechaEmbarque", entidad.FechaEmbarque);
                oConn.AddParameter("@Garantia", entidad.Garantia);
                oConn.AddParameter("@IdSituacion", entidad.IdSituacion);
                oConn.AddParameter("@IdLineaNaviera", entidad.IdLineaNaviera);
                oConn.AddParameter("@IdAgente", entidad.IdAgente);
                oConn.AddParameter("@IdAgenteCarga", entidad.IdAgenteCarga);
                oConn.AddParameter("@Usuario", entidad.Usuario);
                oConn.AddParameter("@Host", entidad.Host);
                DataTable dt = oConn.ExecuteDataTable("USP_DatoImportacion");
                retorno.Add("resultado", true);
                retorno.Add("mensaje", "OK");
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IDictionary<string, object> Eliminar(OrdenesCompra entidad)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> Insertar(OrdenesCompra entidad)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar(OrdenesCompra entidad)
        {
            oConn.AddParameter("@opcion", 1);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[Usp_OrdenesCompa]");
            return dt;
        }

        public DataTable ListarPaginado(OrdenesCompra entidad)
        {
            throw new NotImplementedException();
        }
        public DataTable ListarSituacion()
        {
            DataTable dt = oConn.ExecuteDataTable("[DBO].[USP_Situacion_listar]");
            return dt;
        }
        public DataTable ListarViaTransporte()
        {
            DataTable dt = oConn.ExecuteDataTable("[DBO].[USP_ViaTransporte_listar]");
            return dt;
        }
        public DataTable ListarLineaNaviera()
        {
            DataTable dt = oConn.ExecuteDataTable("[DBO].[USP_LineaNaviera_listar]");
            return dt;
        }
        public DataTable ListarDeposito()
        {
            DataTable dt = oConn.ExecuteDataTable("[DBO].[USP_Deposito_listar]");
            return dt;
        }

        public DataTable DatoImportacion_listar(OrdenesCompra entidad)
        {
            oConn.AddParameter("@FileID", entidad.FileID);
            oConn.AddParameter("@OrdenCompraSAP", entidad.NumeroOrden);
            DataTable dt = oConn.ExecuteDataTable("[DBO].[USP_DatoImportacion_listar]");
            return dt;
        }
    }
}
