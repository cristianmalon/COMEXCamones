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
    public class IncotermController : Controller
    {
        // GET: Incoterm
        public ActionResult Index()
        {
            return View();
        }




        [HttpGet]
        [AllowAnonymous]
        public JsonResult ListarIncoterm()
        {
            var datos = new Request<Incoterm>();
            //datos.entidad = entidad;
            datos.entidad = new Incoterm();
            ////datos.entidad.IdSede = VariablesWeb.Usuario.IdSede;
            var lista = new IncotermAplicacion(new IncotermRepositorio()).Listar(datos);
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
        public JsonResult InsertIncoter(Incoterm entidad)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Response response = new Response();
                    var datos = new Request<Incoterm>();
                    entidad.USUARIO_REG = VariablesWeb.Usuario.SUsrId;
                    entidad.HOST_REG = VariablesWeb.IP();
                    datos.entidad = entidad;
                    response = new IncotermAplicacion(new IncotermRepositorio()).Insertar(datos);

                    return Json(new
                    {
                        errores = Utiles.GetErrorsFromModelState(this.ModelState),
                        url = Url.Action("Index"),
                        result = response.Success,
                        msg = response.Success ? Utiles.MessageSaveSuccess() : response.mensaje,
                    }, JsonRequestBehavior.AllowGet); ;
                }
                catch (Exception ex)
                {
                    return Json(new
                    {

                        url = Url.Action("Index"),
                        result = false,
                        msg = Utiles.MessageServerError() + " - " + ex.Message.ToString(),
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
                    result = false,
                    msg = Utiles.MessageModelStateInvalid()
                }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPut]
        [AllowAnonymous]
        public JsonResult UpdateIncoterm(Incoterm entidad)
        {
            //string nombre = Request.QueryString["values"].ToString();

            if (ModelState.IsValid)
            {
                try
                {

                    Response response = new Response();
                    var datos = new Request<Incoterm>();
                    entidad.USUARIO_REG = VariablesWeb.Usuario.SUsrId;
                    entidad.HOST_REG = VariablesWeb.IP();
                    datos.entidad = entidad;

                    response = new IncotermAplicacion(new IncotermRepositorio()).Actualizar(datos);

                    return Json(new
                    {
                        errores = Utiles.GetErrorsFromModelState(this.ModelState),
                        url = Url.Action("Index"),
                        result = response.Success,
                        msg = response.Success ? Utiles.MessageSaveSuccess() : response.mensaje,
                    }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        result = false,
                        errores = Utiles.GetErrorsFromModelState(this.ModelState),
                        url = Url.Action("Index"),
                        msg = Utiles.MessageServerError() + " - " + ex.Message.ToString(),
                        //combo = 0
                        id = 0
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new
                {
                    result = false,
                    errores = Utiles.GetErrorsFromModelState(this.ModelState),
                    url = Url.Action("Index"),
                    msg = Utiles.MessageModelStateInvalid()
                }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpDelete]
        [AllowAnonymous]
        public JsonResult DeleteTablet(Incoterm entidad)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    Response response = new Response();
                    entidad.USUARIO_REG = VariablesWeb.Usuario.SUsrId;
                    entidad.HOST_REG = VariablesWeb.IP();
                    var datos = new Request<Incoterm>();
                    datos.entidad = entidad;
                    response = new IncotermAplicacion(new IncotermRepositorio()).Eliminar(datos);

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
