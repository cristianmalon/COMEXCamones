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
    public class TipTransporteAplicacion: IGeneralAplicacion<TipTransporte>
    {
        private TipTransporteRepositorio TipTransporteRepositorio;


        public TipTransporteAplicacion(TipTransporteRepositorio tipTransporteRepositorio)
        {
            TipTransporteRepositorio = tipTransporteRepositorio;
        }

        public Response Actualizar(Request<TipTransporte> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<TipTransporte> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<TipTransporte> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<TipTransporte>> Listar(Request<TipTransporte> entidad)
        {
            Response<List<TipTransporte>> retorno = new Response<List<TipTransporte>>();

            try
            {
                DataTable dt = TipTransporteRepositorio.Listar(entidad.entidad);
                List<TipTransporte> lista = new List<TipTransporte>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new TipTransporte()
                    {
                        idTransporte = Util.CapturaInt0(row, "Id_TipTrans"),
                        Nombre = Util.CapturaString(row, "Nombre"),
                        U_DIN_NAVE = Util.CapturaString(row, "U_DIN_NAVE"),
                        U_DIN_ETA = Util.CapturaDatetime(row, "U_DIN_ETA"),
                        Des_Trans = Util.CapturaString(row, "Des_Trans"),
                        ESTADO = Util.CapturaString(row, "Estado"),
                        FECHA_REG = Util.CapturaDatetime(row, "Fec_Crea")

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

        public Response<List<TipTransporte>> ListarPaginado(Request<TipTransporte> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
