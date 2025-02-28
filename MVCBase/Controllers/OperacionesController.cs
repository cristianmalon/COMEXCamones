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
    public class OperacionesController : Controller
    {
        // GET: Operaciones
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexE()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Registrar()
        {
            Files entidad = new Files()
            {
                UsuarioCreacion = VariablesWeb.Usuario.SUsrId,
                Estacion = VariablesWeb.HostName(),
                FechaCreacion = DateTime.Now
            };            
            return PartialView("_Registrar", entidad);

        }
        [AllowAnonymous]
        public ActionResult RegistrarE()
        {
            Files entidad = new Files()
            {
                UsuarioCreacion = VariablesWeb.Usuario.SUsrId,
                Estacion = VariablesWeb.HostName(),
                FechaCreacion = DateTime.Now
            };
            return PartialView("_RegistrarE", entidad);

        }
        [AllowAnonymous]
        public ActionResult VROrdenCompra(string id , OrdenesCompra orderData,int FileID)
        {
            ViewBag.Id = id;
            //traemos los demas campos
            var datos = new Request<Producto>();
            //datos.entidad = entidad;
            datos.entidad = new Producto();
            datos.entidad.OrdenID = orderData.id;
            datos.entidad.FileID = FileID;
            var lista = new ProductoAplicacion(new ProductoRepositorio()).ListarPaginado(datos);
            orderData.ListaProducto = lista.response;
            return PartialView("_BuscarOrdC", orderData);
        }


        [AllowAnonymous]
        public ActionResult VRFactura(string id, Factura FacturaData)
        {
            ViewBag.Id = id;
            return PartialView("_BuscarF", FacturaData);
        }

        [AllowAnonymous]
        public ActionResult VRIE(string id)
        {
            ViewBag.Id = id;
            return PartialView("_BuscarIE");
        }

        [AllowAnonymous]
        public ActionResult BuscarOcGrid()
        {
            return PartialView("_OCGrid");
        }



        [AllowAnonymous]
        public ActionResult BuscarF()
        {
            return PartialView("_FGrid");
        }




        [HttpPost]
        [AllowAnonymous]
        public JsonResult InsertFiles(string fileName, string observacion)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Response response = new Response();
                    Files entidad = new Files();
                    entidad.CodFile = fileName ;
                    entidad.Detalle = observacion;
                    //entidad.IdSede = VariablesWeb.ENUsuario.IdSede;
                    entidad.Estacion = VariablesWeb.HostName();
                    entidad.UsuarioCreacion = VariablesWeb.Usuario.SUsrId;
                    

                    var datos = new Request<Files>();
                    datos.entidad = entidad;
                    response = new FilesAplicacion(new FilesRepositorio()).Insertar(datos);

                    return Json(new
                    {
                        rpta = response.Success,
                        errores = Utiles.GetErrorsFromModelState(this.ModelState),
                        NuevoFileID = response.output,
                        url = Url.Action("Index"),
                        result = response.Success ? Utiles.MessageSaveSuccess() : response.mensaje,
                        id = 0,
                        nuevoFileID = response.Success ? Convert.ToInt32(response.output) : 0 // Nuevo campo con el ID generado
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




        [HttpPost]
        [AllowAnonymous]
        public JsonResult InsertFilesE(string fileName, string observacion)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Response response = new Response();
                    Files entidad = new Files();
                    entidad.CodFile = fileName;
                    entidad.Detalle = observacion;
                    //entidad.IdSede = VariablesWeb.ENUsuario.IdSede;
                    entidad.Estacion = VariablesWeb.HostName();
                    entidad.UsuarioCreacion = VariablesWeb.Usuario.SUsrId;


                    var datos = new Request<Files>();
                    datos.entidad = entidad;
                    response = new FilesAplicacion(new FilesRepositorio()).InsertarE(datos);

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

        [HttpPost]
        [AllowAnonymous]
        public JsonResult ActualizarOperaciones(Operaciones entidad)
        {

            try
            {
                Response response = new Response();
                var datos = new Request<Operaciones>();
                entidad.USUARIO_REG = VariablesWeb.Usuario.SUsrId;
                datos.entidad = entidad;
                response = new OperacionesAplicacion(new OperacionesRepositorio()).Actualizar(datos);
                return Json(new
                {
                    result = response.Success,
                    errores = Utiles.GetErrorsFromModelState(this.ModelState),
                    url = Url.Action("Index"),
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
                    id = 0
                }, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        [AllowAnonymous]
        public JsonResult RegistrarOC(string nuevoFileID, string idOcList , string formDatoImp)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Response response = new Response();
                    Operaciones entidad = new Operaciones();
                    entidad.NuevoFileID = nuevoFileID;
                    entidad.CadIdOc = idOcList;
                    entidad.CadformDatoI = formDatoImp;
                    //entidad.IdSede = VariablesWeb.ENUsuario.IdSede;
                    //entidad.Estacion = VariablesWeb.HostName();
                    //entidad.UsuarioCreacion = VariablesWeb.Usuario.SUsrId;


                    var datos = new Request<Operaciones>();
                    datos.entidad = entidad;
                    response = new OperacionesAplicacion(new OperacionesRepositorio()).Insertar(datos);

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


















        [HttpGet]
        [AllowAnonymous]
        public JsonResult ListarFilesI()
        {
            var datos = new Request<Files>();
            //datos.entidad = entidad;
            datos.entidad = new Files();
            ////datos.entidad.IdSede = VariablesWeb.Usuario.IdSede;
            var lista = new FilesAplicacion(new FilesRepositorio()).ListarI(datos);
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

        [HttpGet]
        [AllowAnonymous]
        public JsonResult ListarFilesE()
        {
            var datos = new Request<Files>();
            //datos.entidad = entidad;
            datos.entidad = new Files();
            ////datos.entidad.IdSede = VariablesWeb.Usuario.IdSede;
            var lista = new FilesAplicacion(new FilesRepositorio()).ListarE(datos);
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






        [HttpGet]
        [AllowAnonymous]
        public JsonResult ListarOcGrid()
        {
            var datos = new Request<OrdenesCompra>();
            //datos.entidad = entidad;
            datos.entidad = new OrdenesCompra();
            ////datos.entidad.IdSede = VariablesWeb.Usuario.IdSede;
            var lista = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).Listar(datos);
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
        [HttpGet]
        [AllowAnonymous]
        public JsonResult ListarProductos(int OcId, string maeCCodList)
        {
            var datos = new Request<Producto>();
            //datos.entidad = entidad;
            datos.entidad = new Producto();
            datos.entidad.OcId = OcId;
            datos.entidad.cadenaCodigo = maeCCodList;
            ////datos.entidad.IdSede = VariablesWeb.Usuario.IdSede;
            var lista = new ProductoAplicacion(new ProductoRepositorio()).Listar(datos);
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



        [HttpGet]
        [AllowAnonymous]
        public JsonResult ListarLotes(int OcId, int file)
        {
            var datos = new Request<Lotes>();
            //datos.entidad = entidad;
            datos.entidad = new Lotes();
            datos.entidad.IdOPeraciones = OcId;
            datos.entidad.IdFile = file;
            ////datos.entidad.IdSede = VariablesWeb.Usuario.IdSede;
            var lista = new LotesAplicacion(new LotesRepositorio()).Listar(datos);
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







        /*FACTURA*/






        [HttpGet]
        [AllowAnonymous]
        public JsonResult ListarFacturas()
        {
            var datos = new Request<Factura>();
            //datos.entidad = entidad;
            datos.entidad = new Factura();
            ////datos.entidad.IdSede = VariablesWeb.Usuario.IdSede;
            var lista = new FacturasAplicacion(new FacturasRepositorio()).Listar(datos);
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



        [HttpGet]
        [AllowAnonymous]
        public JsonResult ListarIE()
        {
            ////datos.entidad.IdSede = VariablesWeb.Usuario.IdSede;
            var lista = new InstruccionEmbarqueAplicacion(new InstruccionEmbarqueRepositorio()).ListarInstruccionEmbarque();
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
