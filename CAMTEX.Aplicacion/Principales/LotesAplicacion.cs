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
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<Lotes> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<Lotes> entidad)
        {
            throw new NotImplementedException();
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
                        Codigo = Util.CapturaString(row, "Codigo"),
                        NroLotes = Util.CapturaString(row, "NroLotes"),
                        Evaluacion = Util.CapturaDatetime(row, "Evaluacion"),
                        Estado = Util.CapturaString(row, "Estado"),
                        Resultado = Util.CapturaString(row, "Resultado"),
                        Deposito = Util.CapturaString(row, "Deposito"),
                        Destino = Util.CapturaString(row, "Destino")

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
