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
    public class SituacionEstadoAplicacion: IGeneralAplicacion<SituacionEstado>
    {
        private SituacionEstadoRepositorio SituacionEstadoRepositorio;

        public SituacionEstadoAplicacion(SituacionEstadoRepositorio situacionEstadoRepositorio)
        {
            SituacionEstadoRepositorio = situacionEstadoRepositorio;
        }

        public Response Actualizar(Request<SituacionEstado> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<SituacionEstado> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<SituacionEstado> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<SituacionEstado>> Listar(Request<SituacionEstado> entidad)
        {
            Response<List<SituacionEstado>> retorno = new Response<List<SituacionEstado>>();

            try
            {
                DataTable dt = SituacionEstadoRepositorio.Listar(entidad.entidad);
                List<SituacionEstado> lista = new List<SituacionEstado>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new SituacionEstado()
                    {
                        Nombre = Util.CapturaString(row, "Nombre"),
                        Estado = Util.CapturaString(row, "Estado"),
                        

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

        public Response<List<SituacionEstado>> ListarPaginado(Request<SituacionEstado> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
