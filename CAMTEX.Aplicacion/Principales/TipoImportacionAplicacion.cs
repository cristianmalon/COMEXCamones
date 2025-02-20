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
    public class TipoImportacionAplicacion: IGeneralAplicacion<TipoImportacion>
    {
        private TipoImportacionRepositorio TipoImportacionRepositorio;

        public TipoImportacionAplicacion(TipoImportacionRepositorio tipoImportacionRepositorio)
        {
            TipoImportacionRepositorio = tipoImportacionRepositorio;
        }

        public Response Actualizar(Request<TipoImportacion> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<TipoImportacion> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<TipoImportacion> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<TipoImportacion>> Listar(Request<TipoImportacion> entidad)
        {
            Response<List<TipoImportacion>> retorno = new Response<List<TipoImportacion>>();

            try
            {
                DataTable dt = TipoImportacionRepositorio.Listar(entidad.entidad);
                List<TipoImportacion> lista = new List<TipoImportacion>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new TipoImportacion()
                    {
                        IdTipoFile = Util.CapturaInt0(row, "IdTipoFile"),
                        DetalleFile = Util.CapturaString(row, "DetalleFile"),
                        EstadoFile = Util.CapturaString(row, "EstadoFile"),
                        
                        
                        

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

        public Response<List<TipoImportacion>> ListarPaginado(Request<TipoImportacion> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
