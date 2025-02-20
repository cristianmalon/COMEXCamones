using CAMTEX.Aplicacion.Base;
using CAMTEX.Aplicacion.Entidades;
using CAMTEX.Entidades;
using CAMTEX.Repositorio;
using CAMTEX.UtilGeneral;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CAMTEX.Aplicacion
{
    public class CondPagoAplicacion: IGeneralAplicacion<CondPago>
    {
        private CondPagoRepositorio CondPagoRepositorio;

        public CondPagoAplicacion(CondPagoRepositorio condPagoRepositorio)
        {
            CondPagoRepositorio = condPagoRepositorio;
        }

        public Response Actualizar(Request<CondPago> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<CondPago> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<CondPago> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<CondPago>> Listar(Request<CondPago> entidad)
        {
            Response<List<CondPago>> retorno = new Response<List<CondPago>>();

            try
            {
                DataTable dt = CondPagoRepositorio.Listar(entidad.entidad);
                List<CondPago> lista = new List<CondPago>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new CondPago()
                    {
                        CNPCCod = Util.CapturaString(row, "CNPCCod"),
                        CNPDDes = Util.CapturaString(row, "CNPDDes"),
                        CNPSEst = Util.CapturaString(row, "CNPSEst"),
                        CNPDObs = Util.CapturaString(row, "CNPDObs")                  
                                               
                    });
                }

                retorno.error = false;
                retorno.response = lista;
            }
            catch (Exception ex)
            {
                retorno.error = true;
                retorno.mensaje = ex.Message;
            }
            return retorno;
        }

        public Response<List<CondPago>> ListarPaginado(Request<CondPago> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
