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
    public class RutasController : Controller
    {
        [UserSystemAttribute]
        public ActionResult Index()
        {
            //ConnectServiceClient<ISeguridad> seguridad = new ConnectServiceClient<ISeguridad>();
            RUTAS entidad = new RUTAS();

            entidad.ListaEstado = GenericoEstado.GeneralEstado();
            IRestResponse response = CApi.ServicePost("Seguridad/ListarSistemas", new Request<SISTEMAS>() { entidad = new SISTEMAS { ESTADO = "A" }, token = VariablesWeb.Usuario.AUTHKEY });
            var listasistemas = JsonConvert.DeserializeObject<Response<List<SISTEMAS>>>(response.Content);
            //var listasistemas = seguridad.ProccessClient.ListarSistemas(new Request<SISTEMAS>() { entidad = new SISTEMAS { ESTADO = "A" }, token = VariablesWeb.Usuario.AUTHKEY });
            response = CApi.ServicePost("Seguridad/ListarRutas_Tipo", new Request<RUTAS_TIPO>() { entidad = new RUTAS_TIPO { ESTADO = "A" }, token = VariablesWeb.Usuario.AUTHKEY });
            var listatipos = JsonConvert.DeserializeObject<Response<List<RUTAS_TIPO>>>(response.Content);
            //var listatipos = seguridad.ProccessClient.ListarRutas_Tipo(new Request<RUTAS_TIPO>() { entidad = new RUTAS_TIPO { ESTADO = "A" }, token = VariablesWeb.Usuario.AUTHKEY });
            if (listasistemas.error.Equals(false) && listatipos.error.Equals(false))
            {
                entidad.ListaSistemas = listasistemas.response;
                entidad.ListaRutasTipo = listatipos.response;
            }
           // seguridad.CloseService();
            return View(entidad);
        }


        [HttpPost]
        [UserSystemAttribute]
        public JsonResult ListarPaginado(RUTAS entidad)
        {
            IRestResponse response = CApi.ServicePost("Seguridad/ListarRutasPaginado", new Request<RUTAS>() { entidad = entidad, token = VariablesWeb.Usuario.AUTHKEY });
            var lista = JsonConvert.DeserializeObject<Response<List<RUTAS>>>(response.Content);

            return Json(new { lista = lista.response, pageSize = lista.response.Count > 0 ? lista.response.First().TotalPage : 0 });
        }

        [HttpGet]
        [UserSystemAttribute]
        public ActionResult Editar(String Index)
        {
            //ConnectServiceClient<ISeguridad> seguridad = new ConnectServiceClient<ISeguridad>();
            RUTAS entidadrutas = new RUTAS();

            if (!Index.Equals(string.Empty))
            {
                entidadrutas.SerialKey = Index;
                IRestResponse response = CApi.ServicePost("Seguridad/ListarRutas", new Request<RUTAS>() { entidad = entidadrutas, token = VariablesWeb.Usuario.AUTHKEY });
                var lista = JsonConvert.DeserializeObject<Response<List<RUTAS>>>(response.Content);
                entidadrutas = lista.response.Count > 0 ? lista.response.First() : null;
            }
            IRestResponse response_ = CApi.ServicePost("Seguridad/ListarSistemas", new Request<SISTEMAS>() { entidad = new SISTEMAS { ESTADO = "A" }, token = VariablesWeb.Usuario.AUTHKEY });
            var listasistemas = JsonConvert.DeserializeObject<Response<List<SISTEMAS>>>(response_.Content);

            response_ = CApi.ServicePost("Seguridad/ListarRutas_Tipo", new Request<RUTAS_TIPO>() { entidad = new RUTAS_TIPO { ESTADO = "A" }, token = VariablesWeb.Usuario.AUTHKEY });
            var listatipos = JsonConvert.DeserializeObject<Response<List<RUTAS_TIPO>>>(response_.Content);

            response_ = CApi.ServicePost("Seguridad/Listar_RutaPadreSistema", new Request<RUTAS>() { entidad = new RUTAS { ESTADO = "A",SISTEMAKey=entidadrutas.SISTEMAKey }, token = VariablesWeb.Usuario.AUTHKEY });

            var listarutaspadre = JsonConvert.DeserializeObject<Response<List<RUTAS>>>(response_.Content);

            if (listasistemas.error.Equals(false) && listatipos.error.Equals(false) && listarutaspadre.error.Equals(false))
            {
                entidadrutas.ListaSistemas = listasistemas.response;
                entidadrutas.ListaRutasTipo = listatipos.response;
                entidadrutas.ListaRutasPadre = listarutaspadre.response;
                entidadrutas.ListaEstado = GenericoEstado.GeneralEstado();
            }
           

            return PartialView("_Editar", entidadrutas);
        }

        [HttpGet]
        [UserSystemAttribute]
        public ActionResult Registrar(String Index)
        {
            //ConnectServiceClient<ISeguridad> seguridad = new ConnectServiceClient<ISeguridad>();
            RUTAS entidad = new RUTAS();

            IRestResponse response_ = CApi.ServicePost("Seguridad/ListarSistemas", new Request<SISTEMAS>() { entidad = new SISTEMAS { ESTADO = "A" }, token = VariablesWeb.Usuario.AUTHKEY });
            var listasistemas = JsonConvert.DeserializeObject<Response<List<SISTEMAS>>>(response_.Content);

            response_ = CApi.ServicePost("Seguridad/ListarRutas_Tipo", new Request<RUTAS_TIPO>() { entidad = new RUTAS_TIPO { ESTADO = "A" }, token = VariablesWeb.Usuario.AUTHKEY });
            var listatipos = JsonConvert.DeserializeObject<Response<List<RUTAS_TIPO>>>(response_.Content);

            response_ = CApi.ServicePost("Seguridad/Listar_RutaPadreSistema", new Request<RUTAS>() { entidad = new RUTAS { ESTADO = "A",SISTEMA_ID=0 }, token = VariablesWeb.Usuario.AUTHKEY });

            var listarutaspadre = JsonConvert.DeserializeObject<Response<List<RUTAS>>>(response_.Content);
            if (listasistemas.error.Equals(false) && listatipos.error.Equals(false))
            {
                entidad.ListaRutasPadre = listarutaspadre.response;
                entidad.ListaSistemas = listasistemas.response;
                entidad.ListaRutasTipo = listatipos.response;
                entidad.ListaEstado = GenericoEstado.GeneralEstado();
            }
            //seguridad.CloseService();
            return PartialView("_Registrar", entidad);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult ListRutaPadre(RUTAS model)
        {

            
            var listaResponse = new Response<List<RUTAS>>();
            try
            {
                IRestResponse response_ = CApi.ServicePost("Seguridad/Listar_RutaPadreSistema", new Request<RUTAS>() { entidad = new RUTAS { ESTADO = "A", SISTEMAKey = model.SISTEMAKey }, token = VariablesWeb.Usuario.AUTHKEY });

                 listaResponse = JsonConvert.DeserializeObject<Response<List<RUTAS>>>(response_.Content);


            }
            catch (Exception ex)
            {
                listaResponse.Success = false;
                listaResponse.error = true;
                listaResponse.mensaje = ex.Message;
            }
            finally {  }

            return Json(listaResponse);
        }

        [HttpPost]
        [UserSystemAttribute]
        public JsonResult Actualizar(RUTAS entidad)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            Dictionary<string, object> lista = new Dictionary<string, object>();
            String msj = String.Empty;

            if (ModelState.IsValid)
            {
               // ConnectServiceClient<ISeguridad> seguridad = new ConnectServiceClient<ISeguridad>();
                Response response = new Response();
                try
                {
                    if (entidad.CONTROLADOR != null && entidad.ACCION != null)
                    {
                        entidad.RUTA = "../../" + entidad.CONTROLADOR + "/" + entidad.ACCION;
                    }

                    entidad.FECHA_ACT = DateTime.Now;
                    entidad.USUARIO_ACT = VariablesWeb.Usuario.SUsrId;
                    entidad.HOST_ACT = VariablesWeb.HostName();

                    if (entidad.SerialKey == null || entidad.SerialKey.Trim().Equals(string.Empty))
                    {
                        entidad.FECHA_REG = DateTime.Now;
                        entidad.USUARIO_REG = VariablesWeb.Usuario.SUsrId;
                        entidad.HOST_REG = VariablesWeb.HostName();

                        IRestResponse rpta = CApi.ServicePost("Seguridad/InsertarRuta", new Request<RUTAS>() { entidad = entidad, token = VariablesWeb.Usuario.AUTHKEY });
                        response = JsonConvert.DeserializeObject<Response>(rpta.Content);

                        //response = seguridad.ProccessClient.InsertarRuta(new Request<RUTAS>() { entidad = entidad, token = VariablesWeb.Usuario.AUTHKEY });
                        msj = Utiles.MessageSaveSuccess();
                    }
                    else
                    {
                        IRestResponse rpta = CApi.ServicePost("Seguridad/ActualizarRuta", new Request<RUTAS>() { entidad = entidad, token = VariablesWeb.Usuario.AUTHKEY });
                        response = JsonConvert.DeserializeObject<Response>(rpta.Content);

                        //response = seguridad.ProccessClient.ActualizarRuta(new Request<RUTAS>() { entidad = entidad, token = VariablesWeb.Usuario.AUTHKEY });
                        msj = Utiles.MessageUpdateSuccess();
                    }
                }
                catch (Exception ex)
                {
                    lista.Add("*", ex.Message);
                    return Json(new
                    {
                        rpta = false,
                        errores = lista,
                        result = Utiles.MessageServerError()
                    }, JsonRequestBehavior.AllowGet);
                }
                finally
                {
                   // seguridad.CloseService();
                }

                return Json(new
                {
                    rpta = true,
                    errores = Utiles.GetErrorsFromModelState(this.ModelState),
                    url = Url.Action("Index"),
                    result = msj
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    rpta = false,
                    errores = Utiles.GetErrorsFromModelState(this.ModelState),
                    url = Url.Action("Index"),
                    result = Utiles.MessageModelStateInvalid()
                }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}