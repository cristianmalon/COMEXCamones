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
    public class ArticuloAplicacion: IGeneralAplicacion<Articulo>
    {
        private ArticuloRepositorio ArticuloRepositorio;

        public ArticuloAplicacion(ArticuloRepositorio articuloRepositorio)
        {
            ArticuloRepositorio = articuloRepositorio;
        }

        public Response Actualizar(Request<Articulo> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<Articulo> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<Articulo> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<Articulo>> Listar(Request<Articulo> entidad)
        {
            Response<List<Articulo>> retorno = new Response<List<Articulo>>();

            try
            {
                DataTable dt = ArticuloRepositorio.Listar(entidad.entidad);
                List<Articulo> lista = new List<Articulo>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Articulo()
                    {
                        MaeDDes = Util.CapturaString(row, "MaeDDes"),
                        UniCCod = Util.CapturaString(row, "UniCCod")                      

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

        public Response<List<Articulo>> ListarPaginado(Request<Articulo> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
