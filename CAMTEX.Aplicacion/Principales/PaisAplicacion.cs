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
    public class PaisAplicacion: IGeneralAplicacion<Pais>
    {
        private PaisRepositorio PaisRepositorio;

        public PaisAplicacion(PaisRepositorio paisRepositorio)
        {
            PaisRepositorio = paisRepositorio;
        }

        public Response Actualizar(Request<Pais> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<Pais> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<Pais> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<Pais>> Listar(Request<Pais> entidad)
        {
            Response<List<Pais>> retorno = new Response<List<Pais>>();

            try
            {
                DataTable dt = PaisRepositorio.Listar(entidad.entidad);
                List<Pais> lista = new List<Pais>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Pais()
                    {
                        IdPais = Util.CapturaInt0(row, "IdPais"),
                        Nombre = Util.CapturaString(row, "Nombre"),
                        

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

        public Response<List<Pais>> ListarPaginado(Request<Pais> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
