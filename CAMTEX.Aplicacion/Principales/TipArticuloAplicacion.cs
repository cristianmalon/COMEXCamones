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
    public class TipArticuloAplicacion: IGeneralAplicacion<TipArticulo>
    {
        private TipArticuloRepositorio TipArticuloRepositorio;

        public TipArticuloAplicacion(TipArticuloRepositorio tipArticuloRepositorio)
        {
            TipArticuloRepositorio = tipArticuloRepositorio;
        }

        public Response Actualizar(Request<TipArticulo> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<TipArticulo> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<TipArticulo> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<TipArticulo>> Listar(Request<TipArticulo> entidad)
        {
            Response<List<TipArticulo>> retorno = new Response<List<TipArticulo>>();

            try
            {
                DataTable dt = TipArticuloRepositorio.Listar(entidad.entidad);
                List<TipArticulo> lista = new List<TipArticulo>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new TipArticulo()
                    {
                        TarCCod = Util.CapturaString(row, "TarCCod"),
                        TarDDes = Util.CapturaString(row, "TarDDes"),
                        TarSEst = Util.CapturaString(row, "TarSEst"),
                        TarDNem = Util.CapturaString(row, "TarDNem")                                  
                        
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

        public Response<List<TipArticulo>> ListarPaginado(Request<TipArticulo> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
