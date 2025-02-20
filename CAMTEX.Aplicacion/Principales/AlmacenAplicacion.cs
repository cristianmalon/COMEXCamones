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
    public class AlmacenAplicacion: IGeneralAplicacion<Almacen>
    {
        private AlmacenRepositorio AlmacenRepositorio;

        public AlmacenAplicacion(AlmacenRepositorio almacenRepositorio)
        {
            AlmacenRepositorio = almacenRepositorio;
        }

        public Response Actualizar(Request<Almacen> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<Almacen> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<Almacen> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<Almacen>> Listar(Request<Almacen> entidad)
        {
            Response<List<Almacen>> retorno = new Response<List<Almacen>>();

            try
            {
                DataTable dt = AlmacenRepositorio.Listar(entidad.entidad);
                List<Almacen> lista = new List<Almacen>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Almacen()
                    {
                        AlmCCod = Util.CapturaString(row, "AlmCCod"),
                        TarCCod = Util.CapturaString(row, "TarCCod"),
                        CCOCCod = Util.CapturaString(row, "CCOCCod"),
                        TipoAlmSunat = Util.CapturaString(row, "TipoAlmSunat")                       
                        
                        

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

        public Response<List<Almacen>> ListarPaginado(Request<Almacen> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
