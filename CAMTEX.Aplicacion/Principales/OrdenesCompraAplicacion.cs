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
        public Response ActualizarDatosImportacion(Request<OrdenesCompra> entidad)
        {
            Response retorno = new Response();
            try
            {
                var resultado = OrdenesCompraRepositorio.ActualizarDatosImportacion(entidad.entidad);
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
                        OrdenCompraSAP = Util.CapturaString(row, "NumeroOrdenC"),
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

        public Response<List<Situacion>> ListarSituacion()
        {
            Response<List<Situacion>> retorno = new Response<List<Situacion>>();

            try
            {
                DataTable dt = OrdenesCompraRepositorio.ListarSituacion();
                List<Situacion> lista = new List<Situacion>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Situacion()
                    {
                        Idsituacion = Util.CapturaInt0(row, "idsituacion"),
                        DesSituacion = Util.CapturaString(row, "situacion"),
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
        public Response<List<ViaTransporte>> ListarViaTransporte()
        {
            Response<List<ViaTransporte>> retorno = new Response<List<ViaTransporte>>();

            try
            {
                DataTable dt = OrdenesCompraRepositorio.ListarViaTransporte();
                List<ViaTransporte> lista = new List<ViaTransporte>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new ViaTransporte()
                    {
                        IdVia = Util.CapturaInt0(row, "idVia"),
                        DesViaTransporte = Util.CapturaString(row, "ViaTransporte"),
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
        public Response<List<LineaNaviera>> ListarLineaNaviera()
        {
            Response<List<LineaNaviera>> retorno = new Response<List<LineaNaviera>>();

            try
            {
                DataTable dt = OrdenesCompraRepositorio.ListarLineaNaviera();
                List<LineaNaviera> lista = new List<LineaNaviera>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new LineaNaviera()
                    {
                        IdLineaNaviera = Util.CapturaInt0(row, "IdLineaNaviera"),
                        DesLineaNaviera = Util.CapturaString(row, "LineaNaviera"),
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
        public Response<List<OrdenesCompra>> DatoImportacion_listar(OrdenesCompra entidad)
        {
            Response<List<OrdenesCompra>> retorno = new Response<List<OrdenesCompra>>();

            try
            {
                DataTable dt = OrdenesCompraRepositorio.DatoImportacion_listar(entidad);
                List<OrdenesCompra> lista = new List<OrdenesCompra>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new OrdenesCompra()
                    {
                        IdOperaciones = Util.CapturaInt0(row, "IdOperaciones"),
                        IdDatoGeneral = Util.CapturaInt0(row, "IdDatoGeneral"),
                        NumeroOperacion = Util.CapturaString(row, "NumeroOperacion"),
                        IdVia = Util.CapturaInt0(row, "IdVia"),
                        BL = Util.CapturaInt0(row, "BL"),
                        IdDeposito = Util.CapturaInt0(row, "IdDeposito"),
                        NumFactura = Util.CapturaString(row, "NumFactura"),
                        FechaIngreso = Util.CapturaDatetime(row, "FechaIngreso"),
                        FechaEmbarque = Util.CapturaDatetime(row, "FechaEmbarque"),
                        Garantia = Util.CapturaInt0(row, "Garantia"),
                        IdSituacion = Util.CapturaInt0(row, "IdSituacion"),
                        IdLineaNaviera = Util.CapturaInt0(row, "IdLineaNaviera"),
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
    }
}
