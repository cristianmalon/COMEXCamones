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
    public class OrdenesCompraAplicacion: IGeneralAplicacion<OrdenesCompra>
    {
        private OrdenesCompraRepositorio OrdenesCompraRepositorio;

        public OrdenesCompraAplicacion(OrdenesCompraRepositorio ordenesCompraRepositorio)
        {
            OrdenesCompraRepositorio = ordenesCompraRepositorio;
        }

        public Response Actualizar(Request<OrdenesCompra> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<OrdenesCompra> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<OrdenesCompra> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<OrdenesCompra>> Listar(Request<OrdenesCompra> entidad)
        {
            Response<List<OrdenesCompra>> retorno = new Response<List<OrdenesCompra>>();

            try
            {
                DataTable dt = OrdenesCompraRepositorio.Listar(entidad.entidad);
                List<OrdenesCompra> lista = new List<OrdenesCompra>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new OrdenesCompra()
                    {
                        id = Util.CapturaInt0(row, "OrdenID"),
                        NumeroOrden = Util.CapturaString(row, "NumeroOrdenC"),
                        PrvCCod = Util.CapturaString(row, "PrvCCod"),
                        PrvDDes = Util.CapturaString(row, "PrvDDes"),
                        
                        MaeCCod = Util.CapturaString(row, "MaeCCod"),
                        MaeDDes = Util.CapturaString(row, "MaeDDes"),


                        TarDNem = Util.CapturaString(row, "TarDNem"),
                        CNPDDes = Util.CapturaString(row, "CNPDDes"),
                        OrcDMon = Util.CapturaString(row, "OrcDMon"),
                        ItemOrdenCompra = Util.CapturaInt0(row, "ItemOrdenCompra"),
                        ItemNroEntregaOC = Util.CapturaInt0(row, "ItemNroEntregaOC"),
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

        public Response<List<OrdenesCompra>> ListarPaginado(Request<OrdenesCompra> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
