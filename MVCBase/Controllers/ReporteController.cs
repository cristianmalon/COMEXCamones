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
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult ListarReporteImportacion()
        {
           
            var lista = new FilesAplicacion(new FilesRepositorio()).ListarReporteImportacion();
            var rpta = Json(new
            {
                //data = lista.response
                result = !lista.error,
                IsError = lista.error,
                Datos = JsonConvert.SerializeObject(lista.tabla),
                msg = lista.mensaje
            }, JsonRequestBehavior.AllowGet);
            rpta.MaxJsonLength = int.MaxValue;

            return rpta;
        }
    }
}