using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAMTEX.Aplicacion.Entidades;
using CAMTEX.Entidades;
using MVCBase.Util;
using VariablesWeb = MVCBase.Util.VariablesWeb;
using Newtonsoft.Json;
using CAMTEX.Aplicacion;
using CAMTEX.Repositorio;

namespace MVCBase.Controllers
{
    public class AgenteCargaController : Controller
    {
        // GET: AgenteCarga
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult ListarAgenteCarga()
        {
            var datos = new Request<AgenteCarga>();
            //datos.entidad = entidad;
            datos.entidad = new AgenteCarga();
            ////datos.entidad.IdSede = VariablesWeb.Usuario.IdSede;
            var lista = new AgenteCargaAplicacion(new AgenteCargaRepositorio()).Listar(datos);
            //return Json(new { data = lista.response });
            var rpta = Json(new
            {
                //data = lista.response
                result = !lista.error,
                IsError = lista.error,
                Datos = JsonConvert.SerializeObject(lista.response),
                msg = lista.mensaje
            }, JsonRequestBehavior.AllowGet);
            rpta.MaxJsonLength = int.MaxValue;

            return rpta;
        }






        [HttpPost]
        [AllowAnonymous]
        public JsonResult InsertarAgenteCarga(AgenteCarga entidad)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Response response = new Response();
                    //entidad.IdSede = VariablesWeb.ENUsuario.IdSede;

                    var datos = new Request<AgenteCarga>();
                    datos.entidad = entidad;
                    response = new AgenteCargaAplicacion(new AgenteCargaRepositorio()).Insertar(datos);

                    return Json(new
                    {
                        rpta = response.Success,
                        errores = Utiles.GetErrorsFromModelState(this.ModelState),
                        url = Url.Action("Index"),
                        result = response.Success ? Utiles.MessageSaveSuccess() : response.mensaje,
                        id = 0
                    }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        rpta = false,
                        errores = Utiles.GetErrorsFromModelState(this.ModelState),
                        url = Url.Action("Index"),
                        result = Utiles.MessageServerError() + " - " + ex.Message.ToString(),
                        //combo = 0
                        id = 0
                    }, JsonRequestBehavior.AllowGet);
                }
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



        [HttpDelete]
        [AllowAnonymous]
        public JsonResult DeleteAgenteCarga(AgenteCarga entidad)
        {
            //entidad.IdSede = VariablesWeb.Usuario.IdSede;
            //entidad.IdSede = VariablesWeb.ENUsuario.IdSede;

            //string nombre = Request.QueryString["values"].ToString();
            var dato5 = Request.Form["values"];
            if (ModelState.IsValid)
            {
                try
                {

                    Response response = new Response();
                    var datos = new Request<AgenteCarga>();
                    datos.entidad = entidad;
                    response = new AgenteCargaAplicacion(new AgenteCargaRepositorio()).Eliminar(datos);

                    return Json(new
                    {
                        rpta = response.Success,
                        errores = Utiles.GetErrorsFromModelState(this.ModelState),
                        url = Url.Action("Index"),
                        result = response.Success ? Utiles.MessageSaveSuccess() : response.mensaje,
                        id = 0
                    }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        rpta = false,
                        errores = Utiles.GetErrorsFromModelState(this.ModelState),
                        url = Url.Action("Index"),
                        result = Utiles.MessageServerError() + " - " + ex.Message.ToString(),
                        //combo = 0
                        id = 0
                    }, JsonRequestBehavior.AllowGet);
                }
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
