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
    public class ContenedorAplicacion: IGeneralAplicacion<Contenedores>
    {
        private ContenedorRepositorio ContenedorRepositorio;

        public ContenedorAplicacion (ContenedorRepositorio contenedorRepositorio)
        {
            ContenedorRepositorio = contenedorRepositorio;
        }

        public Response Actualizar(Request<Contenedores> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<Contenedores> entidad)
        {
            Response retorno = new Response();
            try
            {
                var resultado = ContenedorRepositorio.Eliminar(entidad.entidad);
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

        public Response Insertar(Request<Contenedores> entidad)
        {
            Response retorno = new Response();
            try
            {
                var resultado = ContenedorRepositorio.Insertar(entidad.entidad);
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

        public Response<List<Contenedores>> Listar(Request<Contenedores> entidad)
        {
            Response<List<Contenedores>> retorno = new Response<List<Contenedores>>();

            try
            {
                DataTable dt = ContenedorRepositorio.Listar(entidad.entidad);
                List<Contenedores> lista = new List<Contenedores>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Contenedores()
                    {
                        IdFile = Util.CapturaInt0(row, "FileID"),
                        IdOPeraciones = Util.CapturaInt0(row, "IdOperaciones"),
                        IdContenedor = Util.CapturaInt0(row, "IdLote"),
                        Contenedor = Util.CapturaString(row, "CodigoLote")                
                        
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

        public Response<List<Contenedores>> ListarPaginado(Request<Contenedores> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
