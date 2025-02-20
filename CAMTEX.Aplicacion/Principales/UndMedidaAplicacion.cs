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
    public class UndMedidaAplicacion: IGeneralAplicacion<UndMedida>
    {
        private UndMedidaRepositorio UndMedidaRepositorio;

        public UndMedidaAplicacion(UndMedidaRepositorio undMedidaRepositorio)
        {
            UndMedidaRepositorio = undMedidaRepositorio;
        }

        public Response Actualizar(Request<UndMedida> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<UndMedida> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<UndMedida> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<UndMedida>> Listar(Request<UndMedida> entidad)
        {
            Response<List<UndMedida>> retorno = new Response<List<UndMedida>>();

            try
            {
                DataTable dt = UndMedidaRepositorio.Listar(entidad.entidad);
                List<UndMedida> lista = new List<UndMedida>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new UndMedida()
                    {
                        UniCCod = Util.CapturaString(row, "UniCCod"),
                        UniDDes = Util.CapturaString(row, "UniDDes"),
                        UnisEst = Util.CapturaString(row, "UnisEst"),
                        UndCcodSunat = Util.CapturaString(row, "UndCcodSunat"),
                       

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

        public Response<List<UndMedida>> ListarPaginado(Request<UndMedida> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
