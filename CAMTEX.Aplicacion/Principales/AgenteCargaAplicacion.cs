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
    public class AgenteCargaAplicacion: IGeneralAplicacion<AgenteCarga>
    {
        private AgenteCargaRepositorio AgenteCargaRepositorio;

        public AgenteCargaAplicacion(AgenteCargaRepositorio agenteCargaRepositorio)
        {
            AgenteCargaRepositorio = agenteCargaRepositorio;
        }

        public Response Actualizar(Request<AgenteCarga> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<AgenteCarga> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<AgenteCarga> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<AgenteCarga>> Listar(Request<AgenteCarga> entidad)
        {
            Response<List<AgenteCarga>> retorno = new Response<List<AgenteCarga>>();

            try
            {
                DataTable dt = AgenteCargaRepositorio.Listar(entidad.entidad);
                List<AgenteCarga> lista = new List<AgenteCarga>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new AgenteCarga()
                    {
                        idAgenteCarga = Util.CapturaInt0(row, "idAgenteCarga"),
                        Nombre = Util.CapturaString(row, "Nombre"),
                        U_DIN_AADU = Util.CapturaString(row, "U_DIN_AADU"),
                        U_DIN_ACAR = Util.CapturaString(row, "U_DIN_ACAR"),
                        
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

        public Response<List<AgenteCarga>> ListarPaginado(Request<AgenteCarga> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
