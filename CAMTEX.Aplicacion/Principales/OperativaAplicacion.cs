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
    public class OperativaAplicacion: IGeneralAplicacion<Operativa>
    {
        private OperativaRepositorio OperativaRepositorio;


        public OperativaAplicacion (OperativaRepositorio operativaRepositorio)
        {
            OperativaRepositorio = operativaRepositorio;
        }

        public Response Actualizar(Request<Operativa> entidad)
        {
            Response retorno = new Response();
            try
            {
                var resultado = OperativaRepositorio.Actualizar(entidad.entidad);
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

        public Response Eliminar(Request<Operativa> entidad)
        {
            Response retorno = new Response();
            try
            {
                var resultado = OperativaRepositorio.Eliminar(entidad.entidad);
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

        public Response Insertar(Request<Operativa> entidad)
        {
            Response retorno = new Response();
            try
            {
                var resultado = OperativaRepositorio.Insertar(entidad.entidad);
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

        public Response<List<Operativa>> Listar(Request<Operativa> entidad)
        {
            Response<List<Operativa>> retorno = new Response<List<Operativa>>();

            try
            {
                DataTable dt = OperativaRepositorio.Listar(entidad.entidad);
                List<Operativa> lista = new List<Operativa>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Operativa()
                    {
                        IdFile = Util.CapturaInt0(row, "FileID"),
                        IdOperativa = Util.CapturaInt0(row, "IdOperativa"),
                        IdOPeraciones = Util.CapturaInt0(row, "IdOperaciones"),
                        IdLote = Util.CapturaInt0(row, "IdLote"),
                        NroOperacion = Util.CapturaString(row, "NroOperacion"),
                        FechaOperacion = Util.CapturaDatetime(row, "FechaOperacion"),
                        IdAgentes = Util.CapturaInt0(row, "IdAgente"),
                        IdAgenteCarga = Util.CapturaInt0(row, "IdAgenteCarga"),
                        Cantidad = Util.CapturaDecimal(row, "Cantidad"),                        

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

        public Response<List<Operativa>> ListarPaginado(Request<Operativa> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
