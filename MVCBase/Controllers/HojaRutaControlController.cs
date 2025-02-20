using CAMTEX.Aplicacion.Entidades;
using CAMTEX.Entidades;
using MVCBase.Util;
//using CAMTEX.Servicios.Seguridad;
using CAMTEX.UtilGeneral;
using CAMTEX.Web.Security;
//using CAMTEX.Web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using Newtonsoft.Json;


namespace MVCBase.Controllers
{
    public class HojaRutaControlController : Controller
    {
        // GET: HojaRutaControl
        public ActionResult Index()
        {
            E_HojaRutacontrol mHoja = new E_HojaRutacontrol();
            //mHoja.HRCID = 0;
            return View();
        }
        public JsonResult Listar_Hojaruta( E_HojaRutacontrol entidad ) {

            var datos = new Request<E_HojaRutacontrol>();
            datos.entidad = entidad;
            datos.token = VariablesWeb.Usuario.AUTHKEY;
            IRestResponse response = CApi.ServicePost( "Hojaruta/Listar_Hojaruta", datos );
            Response<List<E_HojaRutacontrol>> lista = JsonConvert.DeserializeObject<Response<List<E_HojaRutacontrol>>>( response.Content );
            return Json( new { lista = lista.response } );
        }

        public ActionResult BuscarTransportista() {
            E_HojaRutacontrol mCliente = new E_HojaRutacontrol();
            mCliente.HRCTransportista = "TEXTILES CAMONES";
            return PartialView( "_BuscarTransportista", mCliente );
        }



        public JsonResult ListarTransportista( E_HojaRutacontrol entidad ) {

            var datos = new Request<E_HojaRutacontrol>();
            datos.entidad = entidad;
            datos.token = VariablesWeb.Usuario.AUTHKEY;
            IRestResponse response = CApi.ServicePost( "Hojaruta/ListarTransportista", datos );
            Response<List<E_Transportista>> lista = JsonConvert.DeserializeObject<Response<List<E_Transportista>>>( response.Content );
            if ( lista.response == null ) {
                return Json( new { lista = lista.response, pageSize = 0 } );
            }
            else {
                return Json( new { lista = lista.response, pageSize = lista.response.Count > 0 ? lista.response.First().TotalPage : 0 } );
            }
        }

        public JsonResult Listar_HojaRutaControlDetalle( E_HojaRutacontrol entidad ) {

            var datos = new Request<E_HojaRutacontrol>();
            datos.entidad = entidad;
            datos.token = VariablesWeb.Usuario.AUTHKEY;
            IRestResponse response = CApi.ServicePost( "Hojaruta/Listar_HojaRutaControlDetalle", datos );
            Response<List<E_HojaRutaControlDetalle>> lista = JsonConvert.DeserializeObject<Response<List<E_HojaRutaControlDetalle>>>( response.Content );
            return Json( new { lista = lista.response, pageSize = 0 } );

            //if ( lista.response == null ) {
            //    return Json( new { lista = lista.response, pageSize = 0 } );
            //}
            //else {
            //    return Json( new { lista = lista.response, pageSize =  0 } );
            //}
        }

        [HttpPost]
        public JsonResult Registrar_HojaRutaControl( E_HojaRutacontrol entidad ) {
            Dictionary<string, object> result = new Dictionary<string, object>();
            Dictionary<string, object> lista = new Dictionary<string, object>();
            String msj = String.Empty;
            Boolean resp = false;
            entidad.USUARIO_REG = VariablesWeb.Usuario.SUsrId;
            entidad.HOST_REG = VariablesWeb.HostName();

            Response response = new Response();
            try {
                var datos = new Request<E_HojaRutacontrol>();
                datos.entidad = entidad;
                IRestResponse rpta = CApi.ServicePost( "Hojaruta/Insertar", datos );
                response = JsonConvert.DeserializeObject<Response>( rpta.Content );
                resp = !response.error;
                msj = response.error != true ? Utiles.MessageUpdateSuccess() : response.mensaje;

            }
            catch ( Exception ex ) {
                lista.Add( "*", ex.Message );
                return Json( new {
                    rpta = false,
                    errores = lista,
                    result = Utiles.MessageServerError() + " " + ex.Message
                }, JsonRequestBehavior.AllowGet );
            }

            return Json( new {
                rpta = response.Success,
                errores = "",
                url = Url.Action( "Index" ),
                result = msj,
                id = response.output
            }, JsonRequestBehavior.AllowGet );

        }
    }
}