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
    public class AgentesAplicacion: IGeneralAplicacion<Agentes>
    {
        private AgentesRepositorio AgentesRepositorio;

        public AgentesAplicacion(AgentesRepositorio agentesRepositorio)
        {
            AgentesRepositorio = agentesRepositorio;
        }

        public Response Actualizar(Request<Agentes> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<Agentes> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<Agentes> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<Agentes>> Listar(Request<Agentes> entidad)
        {
            Response<List<Agentes>> retorno = new Response<List<Agentes>>();

            try
            {
                DataTable dt = AgentesRepositorio.Listar(entidad.entidad);
                List<Agentes> lista = new List<Agentes>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Agentes()
                    {
                        idAgentes = Util.CapturaInt0(row, "idAgente"),
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

        public Response<List<Agentes>> ListarPaginado(Request<Agentes> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
