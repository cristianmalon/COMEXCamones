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
    public class TipoImportacionController : Controller
    {
        // GET: TipoImportacion
        public ActionResult Index()
        {
            return View();
        }





        [HttpGet]
        [AllowAnonymous]
        public JsonResult ListarTIpoImportacion()
        {
            var datos = new Request<TipoImportacion>();
            //datos.entidad = entidad;
            datos.entidad = new TipoImportacion();
            ////datos.entidad.IdSede = VariablesWeb.Usuario.IdSede;
            var lista = new TipoImportacionAplicacion(new TipoImportacionRepositorio()).Listar(datos);
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


    }
}
