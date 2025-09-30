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
    public class LotesAplicacion: IGeneralAplicacion<Lotes>
    {
        private LotesRepositorio LotesRepositorio;

        public LotesAplicacion (LotesRepositorio lotesRepositorio)
        {
            LotesRepositorio = lotesRepositorio;
        }

        public Response Actualizar(Request<Lotes> entidad)
        {
            Response retorno = new Response();
            try
            {
                var resultado = LotesRepositorio.Actualizar(entidad.entidad);
                retorno.Success = true;
                retorno.error = false;

            }
            catch (Exception ex)
            {
                retorno.error = true;
                retorno.mensaje = ex.Message;
            }
            return retorno;
        }

        public Response Eliminar(Request<Lotes> entidad)
        {
            Response retorno = new Response();
            try
            {
                var resultado = LotesRepositorio.Eliminar(entidad.entidad);
                retorno.Success = true;
                retorno.error = false;

            }
            catch (Exception ex)
            {
                retorno.error = true;
                retorno.mensaje = ex.Message;
            }
            return retorno;
        }

        public Response Insertar(Request<Lotes> entidad)
        {
            Response retorno = new Response();
            try
            {
                var resultado = LotesRepositorio.Insertar(entidad.entidad);
                retorno.Success = true;
                retorno.error = false;

            }
            catch (Exception ex)
            {
                retorno.error = true;
                retorno.mensaje = ex.Message;
            }
            return retorno;
        }

        public Response<List<Lotes>> Listar(Request<Lotes> entidad)
        {
            Response<List<Lotes>> retorno = new Response<List<Lotes>>();

            try
            {
                DataTable dt = LotesRepositorio.Listar(entidad.entidad);
                List<Lotes> lista = new List<Lotes>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Lotes()
                    {
                        IdFile = Util.CapturaInt0(row, "FileID"),
                        IdOPeraciones = Util.CapturaInt0(row, "IdOperaciones"),
                        IdLote = Util.CapturaInt0(row, "IdLote"),
                        Codigo = Util.CapturaString(row, "CodigoLote"),
                        NroLotes = Util.CapturaString(row, "Lote"),
                        Evaluacion = Util.CapturaDatetime(row, "Evaluacion"),

                        EstadoLote = Util.CapturaString(row, "EstadoCad"),
                        Resultado = Util.CapturaString(row, "ResultadoCad"),
                        Destino = Util.CapturaString(row, "DestinoCad"),
                        DepositoCad = Util.CapturaString(row, "DepositoCad"),

                        ESTADO = Util.CapturaString(row, "Estado")

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

        public Response<List<Lotes>> ListarPaginado(Request<Lotes> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
