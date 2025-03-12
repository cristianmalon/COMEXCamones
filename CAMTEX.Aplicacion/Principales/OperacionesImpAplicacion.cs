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
    public class OperacionesImpAplicacion: IGeneralAplicacion<OperacionesImp>
    {
        private OperacionesImpRepositorio OperacionesImpRepositorio;


        public OperacionesImpAplicacion(OperacionesImpRepositorio operacionesImpRepositorio)
        {
            OperacionesImpRepositorio = operacionesImpRepositorio;
        }

        public Response Actualizar(Request<OperacionesImp> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<OperacionesImp> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<OperacionesImp> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<OperacionesImp>> Listar(Request<OperacionesImp> entidad)
        {
            Response<List<OperacionesImp>> retorno = new Response<List<OperacionesImp>>();

            try
            {
                DataTable dt = OperacionesImpRepositorio.Listar(entidad.entidad);
                List<OperacionesImp> lista = new List<OperacionesImp>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new OperacionesImp()
                    {
                        FileID = Util.CapturaInt0(row, "FileID"),
                        IdOperaciones = Util.CapturaInt0(row, "IdOperaciones"),
                        IdDatoGeneral = Util.CapturaInt0(row, "IdDatoGeneral"),
                        CodigoLote = Util.CapturaString(row, "CodigoLote"),
                        Lote = Util.CapturaString(row, "Lote"),
                        U_DIN_AADU = Util.CapturaString(row, "U_DIN_AADU"),
                        U_DIN_ACAR = Util.CapturaString(row, "U_DIN_ACAR"),
                        Cantidad = Util.CapturaDecimal(row, "CantidadTotal"),

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

        public Response<List<OperacionesImp>> ListarPaginado(Request<OperacionesImp> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
