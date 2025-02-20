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
    public class IncotermAplicacion: IGeneralAplicacion<Incoterm>
    {
        private IncotermRepositorio IncotermRepositorio;

        public IncotermAplicacion (IncotermRepositorio incotermRepositorio)
        {
            IncotermRepositorio = incotermRepositorio;
        }

        public Response Actualizar(Request<Incoterm> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<Incoterm> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<Incoterm> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<Incoterm>> Listar(Request<Incoterm> entidad)
        {
            Response<List<Incoterm>> retorno = new Response<List<Incoterm>>();

            try
            {
                DataTable dt = IncotermRepositorio.Listar(entidad.entidad);
                List<Incoterm> lista = new List<Incoterm>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Incoterm()
                    {
                        IdIncoterm = Util.CapturaInt0(row, "IdIncoterm"),
                        U_DIN_INCO = Util.CapturaString(row, "U_DIN_INCO"),
                        Descripcion = Util.CapturaString(row, "Descripcion"),                       

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

        public Response<List<Incoterm>> ListarPaginado(Request<Incoterm> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
