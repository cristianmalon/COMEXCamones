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
    public class ControlDespachoOSController : Controller
    {
        // GET: ControlDespachoOS
        public ActionResult Index()
        {
            E_CDSD01 entidad = new E_CDSD01();
           

            return View( entidad );
        }

        public JsonResult ListarPaginado( E_CDSD01 entidad ) {

            var datos = new Request<E_CDSD01>();
            datos.entidad = entidad;
            datos.token = VariablesWeb.Usuario.AUTHKEY;
            IRestResponse response = CApi.ServicePost( "ControlDespachoOS/ListarPaginado", datos );
            Response<List<E_CDSD01>> lista = JsonConvert.DeserializeObject<Response<List<E_CDSD01>>>( response.Content );
            if ( lista.response == null ) {
                return Json( new { lista = lista.response, pageSize = 0 } );
            }
            else {
                return Json( new { lista = lista, pageSize = lista.response.Count > 0 ? lista.response.First().TotalPage : 0 } );
            }


        }

        [HttpGet]
        public ActionResult Registro( string key, string pag ) {
            E_CDSD01 entidad = new E_CDSD01();
            entidad.CdsFFechaReg = DateTime.Now;
            //entidad.USUARIO_REG = VariablesWeb.Usuario.SUsrId;
            entidad.USUARIO_REG = VariablesWeb.Usuario.SUsrDsc;

            Session.RemoveAll();
            Response.Cache.SetCacheability( HttpCacheability.NoCache );
            entidad.IP =  VariablesWeb.IP();
            //Response response = new Response();
            //var datos = new Request<E_CDSD01>();
            //datos.entidad = entidad;
            //IRestResponse rpta = CApi.ServicePost( "ControlDespachoOS/ListarPlaca", datos );
            //response = JsonConvert.DeserializeObject<Response>( rpta.Content );
            //entidad.Placa = response.output;

            if ( key != null ) {
                var _key = CShrapEncryption.DecryptString( key, VariablesWeb.Usuario.AUTHKEY );
                var ArrKey = _key.Split( '#' );
                entidad.SerialKey = key;
                //entidad.IdPedido = Convert.ToInt32( ArrKey[0] );

                //var datos = new Request<E_PEDIDO>();
                //datos.entidad = entidad;
                //datos.token = VariablesWeb.Usuario.AUTHKEY;
                //IRestResponse response = CApi.ServicePost( "Pedido/Listar", datos );
                //Response<List<E_PEDIDO>> lista = JsonConvert.DeserializeObject<Response<List<E_PEDIDO>>>( response.Content );

                //if ( lista.error == true ) {
                //    Response.Write( @"<script language='javascript'>alert('Message: \n" + "Error!" + " .');</script>" );
                //}
                //else {
                //    entidad = lista.response.Count > 0 ? lista.response.First() : entidad;
                //    if ( entidad.FechaEntrega == null ) {
                //        entidad.FechaEntrega = DateTime.Now;
                //    }
                //}
            }
            
           
            return View( entidad );
        }

        [HttpGet]
        public ActionResult Destino( string key, string pag ) {
            E_CDSD01 entidad = new E_CDSD01();
            entidad.CdsFFechaReg = DateTime.Now;
            //entidad.USUARIO_REG = VariablesWeb.Usuario.SUsrId;
            entidad.USUARIO_REG = VariablesWeb.Usuario.SUsrDsc;

            Session.RemoveAll();
            Response.Cache.SetCacheability( HttpCacheability.NoCache );
            entidad.IP = VariablesWeb.IP();
            //Response response = new Response();
            //var datos = new Request<E_CDSD01>();
            //datos.entidad = entidad;
            //IRestResponse rpta = CApi.ServicePost( "ControlDespachoOS/ListarPlaca", datos );
            //response = JsonConvert.DeserializeObject<Response>( rpta.Content );
            //entidad.Placa = response.output;

            return View( entidad );
        }


        public JsonResult BuscarGuia( E_CDSD01 entidad ) {

            var datos = new Request<E_CDSD01>();
            datos.entidad = entidad;
            datos.token = VariablesWeb.Usuario.AUTHKEY;
            IRestResponse response = CApi.ServicePost( "ControlDespachoOS/BuscarGuiaCab", datos );
            Response<List<E_CDSD01>> lista = JsonConvert.DeserializeObject<Response<List<E_CDSD01>>>( response.Content );
            return Json( new { lista = lista.response } );
        }

        public JsonResult BuscarGuiaCabDestino( E_CDSD01 entidad ) {

            var datos = new Request<E_CDSD01>();
            datos.entidad = entidad;
            datos.token = VariablesWeb.Usuario.AUTHKEY;
            IRestResponse response = CApi.ServicePost( "ControlDespachoOS/BuscarGuiaCabDestino", datos );
            Response<List<E_CDSD01>> lista = JsonConvert.DeserializeObject<Response<List<E_CDSD01>>>( response.Content );
            return Json( new { lista = lista.response } );
        }


        public JsonResult ListarGuiadetalle( E_CDSD01 entidad ) {

            var datos = new Request<E_CDSD01>();
            datos.entidad = entidad;
            datos.token = VariablesWeb.Usuario.AUTHKEY;
            IRestResponse response = CApi.ServicePost( "ControlDespachoOS/BuscarGuiaDet", datos );
            Response<List<E_CDSD02>> lista = JsonConvert.DeserializeObject<Response<List<E_CDSD02>>>( response.Content );
            return Json( new { lista = lista.response, pageSize = 0 } );
        }

        public JsonResult ListarDetalleDestino( E_CDSD01 entidad ) {

            var datos = new Request<E_CDSD01>();
            datos.entidad = entidad;
            datos.token = VariablesWeb.Usuario.AUTHKEY;
            IRestResponse response = CApi.ServicePost( "ControlDespachoOS/ListarDetalleDestino", datos );
            Response<List<E_CDSD02>> lista = JsonConvert.DeserializeObject<Response<List<E_CDSD02>>>( response.Content );
            return Json( new { lista = lista.response, pageSize = 0 } );
        }

        [HttpPost]
        public JsonResult RegistrarGuia( E_CDSD01 entidad ) {
            Dictionary<string, object> result = new Dictionary<string, object>();
            Dictionary<string, object> lista = new Dictionary<string, object>();
            String msj = String.Empty;
            Boolean resp = false;
            entidad.USUARIO_REG = VariablesWeb.Usuario.SUsrId;
            entidad.HOST_REG = VariablesWeb.HostName();
            
            Response response = new Response();
            try {
                var datos = new Request<E_CDSD01>();
                datos.entidad = entidad;
                IRestResponse rpta = CApi.ServicePost( "ControlDespachoOS/Insertar", datos );
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

        [HttpPost]
        public JsonResult Generar_Despacho_Placa( E_CDSD01 entidad ) {
            Dictionary<string, object> result = new Dictionary<string, object>();
            Dictionary<string, object> lista = new Dictionary<string, object>();
            String msj = String.Empty;
            Boolean resp = false;


            Response response = new Response();
            try {
                var datos = new Request<E_CDSD01>();
                datos.entidad = entidad;
                IRestResponse rpta = CApi.ServicePost( "ControlDespachoOS/Generar_Despacho_Placa", datos );
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


        [HttpPost]
        public JsonResult Registrar_Destino( E_CDSD01 entidad ) {
            Dictionary<string, object> result = new Dictionary<string, object>();
            Dictionary<string, object> lista = new Dictionary<string, object>();
            String msj = String.Empty;
            Boolean resp = false;
            entidad.USUARIO_REG = VariablesWeb.Usuario.SUsrId;
            entidad.HOST_REG = VariablesWeb.HostName();

            Response response = new Response();
            try {
                var datos = new Request<E_CDSD01>();
                datos.entidad = entidad;
                IRestResponse rpta = CApi.ServicePost( "ControlDespachoOS/InsertarDestino", datos );
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


        public ActionResult BuscarGuias( string key ) {
            E_CDSD01 entidad = new E_CDSD01();
            entidad.Placa = key;
            //Registramos el 
            return PartialView( "_BuscarGuias", entidad );

        }

        public JsonResult ListarGuiaPlaca( E_CDSD01 entidad ) {

            var datos = new Request<E_CDSD01>();
            datos.entidad = entidad;
            datos.token = VariablesWeb.Usuario.AUTHKEY;
            IRestResponse response = CApi.ServicePost( "ControlDespachoOS/BuscarGuiasPlaca", datos );
            Response<List<E_CDSD01>> lista = JsonConvert.DeserializeObject<Response<List<E_CDSD01>>>( response.Content );
            if ( lista.response == null ) {
                return Json( new { lista = lista.response, pageSize = 0 } );
            }
            else {
                return Json( new { lista = lista.response, pageSize = lista.response.Count > 0 ? lista.response.First().TotalPage : 0 } );
            }


        }

        public JsonResult ListarGuiaPlacaDestino( E_CDSD01 entidad ) {

            var datos = new Request<E_CDSD01>();
            datos.entidad = entidad;
            datos.token = VariablesWeb.Usuario.AUTHKEY;
            IRestResponse response = CApi.ServicePost( "ControlDespachoOS/BuscarGuiasPlacaDestino", datos );
            Response<List<E_CDSD01>> lista = JsonConvert.DeserializeObject<Response<List<E_CDSD01>>>( response.Content );
            if ( lista.response == null ) {
                return Json( new { lista = lista.response, pageSize = 0 } );
            }
            else {
                return Json( new { lista = lista.response, pageSize = lista.response.Count > 0 ? lista.response.First().TotalPage : 0 } );
            }


        }

        public ActionResult BuscarGuiasDestino( string key ) {
            E_CDSD01 entidad = new E_CDSD01();
            entidad.Placa = key;
            return PartialView( "_BuscarGuiasDestino", entidad );

        }

        public ActionResult ReporteControlDespacho() {
            E_CDSD01 entidad = new E_CDSD01();
            return View( entidad );
        }

        public JsonResult Listar_Reporte_Despacho( E_CDSD01 entidad ) {

            var datos = new Request<E_CDSD01>();
            datos.entidad = entidad;
            datos.token = VariablesWeb.Usuario.AUTHKEY;
            IRestResponse response = CApi.ServicePost( "ControlDespachoOS/Listar_Reporte_Despacho", datos );
            Response<List<E_CDSD01>> lista = JsonConvert.DeserializeObject<Response<List<E_CDSD01>>>( response.Content );
            return Json( new { lista = lista.response, pageSize = 0 } );
        }
    }

}