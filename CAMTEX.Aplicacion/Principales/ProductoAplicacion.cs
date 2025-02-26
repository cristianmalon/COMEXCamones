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
    public class ProductoAplicacion : IGeneralAplicacion<Producto>
    {
        private ProductoRepositorio ProductoRepositorio;

        public ProductoAplicacion(ProductoRepositorio productoRepositorio)
        {
            ProductoRepositorio = productoRepositorio;
        }

        public Response Actualizar(Request<Producto> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<Producto> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<Producto> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<Producto>> Listar(Request<Producto> entidad)
        {
            Response<List<Producto>> retorno = new Response<List<Producto>>();

            try
            {
                DataTable dt = ProductoRepositorio.Listar(entidad.entidad);
                List<Producto> lista = new List<Producto>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Producto()
                    {
                        Codigo = Util.CapturaString(row, "MaeCCod"),
                        OrcCItem = Util.CapturaInt0(row, "OrcCItem"),
                        OrdenID = Util.CapturaInt0(row, "OrdenID"),
                        OrccnSap = Util.CapturaString(row, "OrccnSap"),
                        Descripcion = Util.CapturaString(row, "MaeDDes"),
                        PU = Util.CapturaDecimal(row, "OrcNPrec"),
                        Qty = Util.CapturaDecimal(row, "OrcQCan"),
                        Valor = Util.CapturaDecimal(row, "OrcNImp"),
                        Moneda = Util.CapturaString(row, "OrcDMon")
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

        public Response<List<Producto>> ListarPaginado(Request<Producto> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
