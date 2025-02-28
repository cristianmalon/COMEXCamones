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
    public class OperacionesAplicacion: IGeneralAplicacion<Operaciones>
    {
        private OperacionesRepositorio OperacionesRepositorio;


        public OperacionesAplicacion(OperacionesRepositorio operacionesRepositorio)
        {
            OperacionesRepositorio = operacionesRepositorio;
        }

        public Response Actualizar(Request<Operaciones> entidad)
        {
            Response retorno = new Response();
            try
            {
                var resultado = OperacionesRepositorio.Actualizar(entidad.entidad);
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

        public Response Eliminar(Request<Operaciones> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<Operaciones> entidad)
        {
            Response retorno = new Response();
            try
            {
                var resultado = OperacionesRepositorio.Insertar(entidad.entidad);
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

        public Response<List<Operaciones>> Listar(Request<Operaciones> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<Operaciones>> ListarPaginado(Request<Operaciones> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
