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
    public class FacturasAplicacion: IGeneralAplicacion<Factura>
    {
        private FacturasRepositorio FacturasRepositorio;

        public FacturasAplicacion(FacturasRepositorio facturasRepositorio)
        {
            FacturasRepositorio = facturasRepositorio;
        }

        public Response Actualizar(Request<Factura> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<Factura> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<Factura> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<Factura>> Listar(Request<Factura> entidad)
        {
            Response<List<Factura>> retorno = new Response<List<Factura>>();

            try
            {
                DataTable dt = FacturasRepositorio.Listar(entidad.entidad);
                List<Factura> lista = new List<Factura>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Factura()
                    {
                        U_DIN_NFACT = Util.CapturaString(row, "U_DIN_NFACT"),
                        U_DIN_PROV = Util.CapturaString(row, "U_DIN_PROV"),
                        U_DIN_FFACT = Util.CapturaDatetime(row, "U_DIN_FFACT"),
                        U_DIN_MON = Util.CapturaString(row, "U_DIN_MON"),
                        /*
                        U_DIN_FCSOL = Util.CapturaInt0(row, "U_DIN_FCSOL"),
                        U_DIN_COND = Util.CapturaString(row, "U_DIN_COND"),
                        U_DIN_BL = Util.CapturaString(row, "U_DIN_BL"),
                        U_DIN_VIA = Util.CapturaString(row, "U_DIN_VIA"),
                        U_DIN_AADU = Util.CapturaString(row, "U_DIN_AADU"),
                        U_DIN_ACAR = Util.CapturaString(row, "U_DIN_ACAR"),
                        U_DIN_DEPO = Util.CapturaString(row, "U_DIN_DEPO"),
                        
                        */
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

        public Response<List<Factura>> ListarPaginado(Request<Factura> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
