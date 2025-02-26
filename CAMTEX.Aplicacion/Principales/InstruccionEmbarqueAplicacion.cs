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
    public class InstruccionEmbarqueAplicacion : IGeneralAplicacion<InstruccionEmbarque>
    {
        private InstruccionEmbarqueRepositorio InstruccionEmbarqueRepositorio;

        public InstruccionEmbarqueAplicacion(InstruccionEmbarqueRepositorio instruccionEmbarqueRepositorio)
        {
            InstruccionEmbarqueRepositorio = instruccionEmbarqueRepositorio;
        }

        public Response Actualizar(Request<InstruccionEmbarque> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<InstruccionEmbarque> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<InstruccionEmbarque> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<InstruccionEmbarque>> Listar(Request<InstruccionEmbarque> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<InstruccionEmbarque>> ListarPaginado(Request<InstruccionEmbarque> entidad)
        {
            throw new NotImplementedException();
        }
        public Response<List<InstruccionEmbarque>> ListarInstruccionEmbarque()
        {
            Response<List<InstruccionEmbarque>> retorno = new Response<List<InstruccionEmbarque>>();

            try
            {
                DataTable dt = InstruccionEmbarqueRepositorio.ListarInstruccionEmbarque();
                List<InstruccionEmbarque> lista = new List<InstruccionEmbarque>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new InstruccionEmbarque()
                    {
                        RowNumber = Util.CapturaInt0(row, "RowNumber"),
                        IE_Anio = Util.CapturaInt0(row, "IE_Anio"),
                        IE_Nro = Util.CapturaInt0(row, "IE_Nro"),
                        Control_Comex = Util.CapturaString(row, "Control_Comex"),
                        Cliente = Util.CapturaString(row, "Cliente"),
                        TipoPrd = Util.CapturaString(row, "IEPSTPrd"),
                        CantPrendas = Util.CapturaDecimal(row, "CantPrendas"),
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
    }
}
