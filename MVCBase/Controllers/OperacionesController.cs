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
        public ActionResult Editar(string estado)
        {
            Files entidad = new Files()
            {
                UsuarioCreacion = VariablesWeb.Usuario.SUsrId,
                Estacion = VariablesWeb.HostName(),
                FechaCreacion = DateTime.Now,
                ESTADO = estado
            };
            return PartialView("_Editar", entidad);

        }

        [AllowAnonymous]
        public ActionResult EditarExp(int FileId, string estado)
        {
            Files entidad = new Files()
            {
                UsuarioCreacion = VariablesWeb.Usuario.SUsrId,
                Estacion = VariablesWeb.HostName(),
                FechaCreacion = DateTime.Now,
                FileId= FileId,
                ESTADO = estado
            };
            return PartialView("_RegistrarE", entidad);

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
        public ActionResult VROrdenCompra(string id , OrdenesCompra orderData,int FileID, string ViewID)
        {
            ViewBag.Id = id;
            ViewBag.ViewID = ViewID;
            //traemos los demas campos
            var datos = new Request<Producto>();
            //datos.entidad = entidad;
            datos.entidad = new Producto();
            datos.entidad.OrdenID = orderData.id;
            datos.entidad.OrccnSap = orderData.OrdenCompraSAP;
            datos.entidad.FileID = FileID;
            var lista = new ProductoAplicacion(new ProductoRepositorio()).ListarPaginado(datos);
            orderData.ListaProducto = lista.response;
            var listaSituacion = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ListarSituacion();
            orderData.ListaSituacion = listaSituacion.response;
            var ListarViaTransporte = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ListarViaTransporte();
            orderData.ListaViatransporte= ListarViaTransporte.response;
            var ListarLineaNaviera = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ListarLineaNaviera();
            orderData.ListaLineaNaviera = ListarLineaNaviera.response;

            var ListarAgenteCarga = new AgenteCargaAplicacion(new AgenteCargaRepositorio()).Listar(new Request<AgenteCarga>());
            orderData.ListaAgenteCarga = ListarAgenteCarga.response;
            var ListarAgentes = new AgentesAplicacion(new AgentesRepositorio()).Listar(new Request<Agentes>());
            orderData.ListaAgentes = ListarAgentes.response;
            var ListarDeposito = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ListarDeposito();
            orderData.ListaDeposito = ListarDeposito.response;
            var ListarArancel = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ListarArancel();
            orderData.ListaArancel = ListarArancel.response;
            var ListaPuertoEmbarque = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ListarPuertoEmbarque();
            orderData.ListaPuertoEmbarque = ListaPuertoEmbarque.response;
            var ListaAlmacen = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ListarAlmacen();
            orderData.ListaAlmacen = ListaAlmacen.response;
            var ListarIncoter = new IncotermAplicacion(new IncotermRepositorio()).Listar(new Request<Incoterm>());
            orderData.ListaIncoterm = ListarIncoter.response;
            var listaDatoImportacion = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).DatoImportacion_listar(orderData);
            if (listaDatoImportacion.response != null && listaDatoImportacion.response.Count>0)
            {
                orderData.IdDatoGeneral = listaDatoImportacion.response[0].IdDatoGeneral;
                orderData.NumeroOperacion = listaDatoImportacion.response[0].NumeroOperacion;
                orderData.IdVia = listaDatoImportacion.response[0].IdVia;
                orderData.BL = listaDatoImportacion.response[0].BL;
                orderData.IdDeposito = listaDatoImportacion.response[0].IdDeposito;
                orderData.NumFactura = listaDatoImportacion.response[0].NumFactura;
                orderData.FechaFactura = listaDatoImportacion.response[0].FechaFactura;
                orderData.FechaIngreso = listaDatoImportacion.response[0].FechaIngreso;
                orderData.FechaEmbarque = listaDatoImportacion.response[0].FechaEmbarque;
                orderData.Garantia = listaDatoImportacion.response[0].Garantia;
                orderData.IdSituacion = listaDatoImportacion.response[0].IdSituacion;
                orderData.IdLineaNaviera = listaDatoImportacion.response[0].IdLineaNaviera;
                orderData.IdAgente = listaDatoImportacion.response[0].IdAgente;
                orderData.IdAgenteCarga = listaDatoImportacion.response[0].IdAgenteCarga;
                orderData.EtaCallao = listaDatoImportacion.response[0].EtaCallao;
                orderData.VctSobreEst = listaDatoImportacion.response[0].VctSobreEst;
                orderData.IdArancel = listaDatoImportacion.response[0].IdArancel;
                orderData.IdPuerEm = listaDatoImportacion.response[0].IdPuerEm;
                orderData.IdAlmacen = listaDatoImportacion.response[0].IdAlmacen;
                orderData.FechaDeposito = listaDatoImportacion.response[0].FechaDeposito;
                orderData.NroDua = listaDatoImportacion.response[0].NroDua;
                orderData.IdIncoterm = listaDatoImportacion.response[0].IdIncoterm;
            }
            

            return PartialView("_BuscarOrdC", orderData);
        }



        [HttpGet]
        [AllowAnonymous]
        public JsonResult ListarAgenteC()
        {
            var datos = new Request<AgenteCarga>();
            //datos.entidad = entidad;
            datos.entidad = new AgenteCarga();
            ////datos.entidad.IdSede = VariablesWeb.Usuario.IdSede;
            var lista = new AgenteCargaAplicacion(new AgenteCargaRepositorio()).Listar(datos);
            //return Json(new { data = lista.response });
            var data = lista.response.Select(AgenteC => new { idAgenteCarga = AgenteC.idAgenteCarga, Nombre = AgenteC.Nombre.Trim() }).ToArray();


            return Json(data, JsonRequestBehavior.AllowGet);
        }

       


        [HttpPost]
        [AllowAnonymous]
        public JsonResult ActualizarDatosImportacion(OrdenesCompra entidad)
        {

            try
            {
                Response response = new Response();
                var datos = new Request<OrdenesCompra>();
                entidad.Usuario = VariablesWeb.Usuario.SUsrId;
                datos.entidad = entidad;
                response = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ActualizarDatosImportacion(datos);
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

        [AllowAnonymous]
        public ActionResult VRFactura(string id, InstruccionEmbarque FacturaData, int FileID)
        {
            ViewBag.Id = id;
            ViewBag.ViewID = "R";
            var datos = new Request<Producto>();
            datos.entidad = new Producto();
            datos.entidad.FileID = FileID;
            datos.entidad.IE_Anio = FacturaData.IE_Anio;
            datos.entidad.IE_Nro = FacturaData.IE_Nro;
            var lista = new ProductoAplicacion(new ProductoRepositorio()).ListarPaginadoExpo(datos);
            FacturaData.ListaProducto = lista.response;
            var listaSituacion = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ListarSituacion();
            FacturaData.ListaSituacion = listaSituacion.response;
            var ListarViaTransporte = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ListarViaTransporte();
            FacturaData.ListaViatransporte = ListarViaTransporte.response;
            var ListarLineaNaviera = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ListarLineaNaviera();
            FacturaData.ListaLineaNaviera = ListarLineaNaviera.response;

            var ListarAgenteCarga = new AgenteCargaAplicacion(new AgenteCargaRepositorio()).Listar(new Request<AgenteCarga>());
            FacturaData.ListaAgenteCarga = ListarAgenteCarga.response;
            var ListarAgentes = new AgentesAplicacion(new AgentesRepositorio()).Listar(new Request<Agentes>());
            FacturaData.ListaAgentes = ListarAgentes.response;
            var ListarDeposito = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ListarDeposito();
            FacturaData.ListaDeposito = ListarDeposito.response;
            var ListarArancel = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ListarArancel();
            FacturaData.ListaArancel = ListarArancel.response;
            var ListaPuertoEmbarque = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ListarPuertoEmbarque();
            FacturaData.ListaPuertoEmbarque = ListaPuertoEmbarque.response;
            var ListaAlmacen = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ListarAlmacen();
            FacturaData.ListaAlmacen = ListaAlmacen.response;
            var ListarIncoter = new IncotermAplicacion(new IncotermRepositorio()).Listar(new Request<Incoterm>());
            FacturaData.ListaIncoterm = ListarIncoter.response;
            OrdenesCompra orderData = new OrdenesCompra();
            orderData.FileID = FileID;
            orderData.IE_Anio = FacturaData.IE_Anio;
            orderData.IE_Nro = FacturaData.IE_Nro;
            var ListaOperacionAlmacen = new InstruccionEmbarqueAplicacion(new InstruccionEmbarqueRepositorio()).OperacionAlmacen_listar(orderData);
            FacturaData.ListaOpeAlmacen = ListaOperacionAlmacen.response;
            var ListarFacTurasRelacionadas_IE = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).ListarFacTurasRelacionadas_IE(orderData);
            FacturaData.ListaFactura = ListarFacTurasRelacionadas_IE.response;

            var listaDatoImportacion = new OrdenesCompraAplicacion(new OrdenesCompraRepositorio()).DatoImportacion_listar(orderData);
            
            if (listaDatoImportacion.response != null && listaDatoImportacion.response.Count > 0)
            {
                FacturaData.IdDatoGeneral = listaDatoImportacion.response[0].IdDatoGeneral;
                FacturaData.NumeroOperacion = listaDatoImportacion.response[0].NumeroOperacion;
                FacturaData.IdVia = listaDatoImportacion.response[0].IdVia;
                FacturaData.BL = listaDatoImportacion.response[0].BL;
                FacturaData.IdDeposito = listaDatoImportacion.response[0].IdDeposito;
                FacturaData.NumFactura = listaDatoImportacion.response[0].NumFactura;
                FacturaData.FechaFactura = listaDatoImportacion.response[0].FechaFactura;
                FacturaData.FechaIngreso = listaDatoImportacion.response[0].FechaIngreso;
                FacturaData.FechaEmbarque = listaDatoImportacion.response[0].FechaEmbarque;
                FacturaData.Garantia = listaDatoImportacion.response[0].Garantia;
                FacturaData.IdSituacion = listaDatoImportacion.response[0].IdSituacion;
                FacturaData.IdLineaNaviera = listaDatoImportacion.response[0].IdLineaNaviera;
                FacturaData.IdAgente = listaDatoImportacion.response[0].IdAgente;
                FacturaData.IdAgenteCarga = listaDatoImportacion.response[0].IdAgenteCarga;
                FacturaData.EtaCallao = listaDatoImportacion.response[0].EtaCallao;
                FacturaData.VctSobreEst = listaDatoImportacion.response[0].VctSobreEst;
                FacturaData.IdArancel = listaDatoImportacion.response[0].IdArancel;
                FacturaData.IdPuerEm = listaDatoImportacion.response[0].IdPuerEm;
                FacturaData.IdAlmacen = listaDatoImportacion.response[0].IdAlmacen;
                FacturaData.FechaDeposito = listaDatoImportacion.response[0].FechaDeposito;
                FacturaData.NroDua = listaDatoImportacion.response[0].NroDua;
                FacturaData.IdIncoterm = listaDatoImportacion.response[0].IdIncoterm;
            }
            return PartialView("_BuscarF", FacturaData);
        }

        [AllowAnonymous]
        public ActionResult VRIE(string id)
        {
            ViewBag.Id = id;
            return PartialView("_BuscarIE");
        }

        [AllowAnonymous]
        public ActionResult BuscarOcGrid(string proveedor)
        {
            ViewBag.Proveedor = proveedor;  // lo mandas a la vista parcial
            return PartialView("_OCGrid");
        }



        [AllowAnonymous]
        public ActionResult BuscarF()
        {
            return PartialView("_FGrid");
        }




        [HttpPost]
        [AllowAnonymous]
        public JsonResult InsertFiles(string fileName, string Proveedor)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Response response = new Response();
                    Files entidad = new Files();
                    entidad.CodFile = fileName ;
                    entidad.CodProv = Proveedor;
                    //entidad.Detalle = observacion;
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
                        FileName = response.output2,
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
                        NuevoFileID = response.output,
                        FileName = response.output2,
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
                    status = response.status,
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
        public JsonResult ActualizarOperacionesExpo(Operaciones entidad)
        {

            try
            {
                Response response = new Response();
                var datos = new Request<Operaciones>();
                entidad.USUARIO_REG = VariablesWeb.Usuario.SUsrId;
                datos.entidad = entidad;
                response = new OperacionesAplicacion(new OperacionesRepositorio()).Actualizar_Exportacion(datos);
                return Json(new
                {
                    result = response.Success,
                    errores = Utiles.GetErrorsFromModelState(this.ModelState),
                    status = response.status,
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
        public JsonResult RegistrarOC(string nuevoFileID, string idOcList, string cadLote, string formDatoImp)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Response response = new Response();
                    Operaciones entidad = new Operaciones();
                    entidad.NuevoFileID = nuevoFileID;
                    entidad.CadIdOc = idOcList;
                    entidad.CadLote = cadLote;
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


        [HttpPost]
        [AllowAnonymous]
        public JsonResult ActualizarEstadoOrdenxFile(int fileID, int ordenId, string nuevoEstado)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    Response response = new Response();
                    Operaciones entidad = new Operaciones();
                    entidad.NroFile = fileID;
                    entidad.OrdenID = ordenId;                    
                    //entidad.IdSede = VariablesWeb.ENUsuario.IdSede;
                    //entidad.Estacion = VariablesWeb.HostName();
                    //entidad.UsuarioCreacion = VariablesWeb.Usuario.SUsrId;


                    var datos = new Request<Operaciones>();
                    datos.entidad = entidad;
                    response = new OperacionesAplicacion(new OperacionesRepositorio()).Eliminar(datos);

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
        public JsonResult ActualizarEstadoOrdenxFileE(int fileID, int ordenId, string nuevoEstado)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    Response response = new Response();
                    Operaciones entidad = new Operaciones();
                    entidad.NroFile = fileID;
                    entidad.OrdenID = ordenId;
                    //entidad.IdSede = VariablesWeb.ENUsuario.IdSede;
                    //entidad.Estacion = VariablesWeb.HostName();
                    //entidad.UsuarioCreacion = VariablesWeb.Usuario.SUsrId;


                    var datos = new Request<Operaciones>();
                    datos.entidad = entidad;
                    response = new OperacionesAplicacion(new OperacionesRepositorio()).Eliminar(datos);

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
        public JsonResult ListarFilesI(string anio)
        {
            var datos = new Request<Files>();
            //datos.entidad = entidad;
            datos.entidad = new Files();
            if (anio != "")
            {
                datos.entidad.anio = Convert.ToInt32(anio);
            }
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



        [HttpPost]
        [AllowAnonymous]
        public JsonResult ActualizarEstadoFile(Files entidad)
        {


            if (ModelState.IsValid)
            {
                try
                {

                    Response response = new Response();
                    var datos = new Request<Files>();
                    datos.entidad = entidad;
                    response = new FilesAplicacion(new FilesRepositorio()).ActualizarEstado(datos);

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
        public JsonResult ListarFilesE(string anio)
        {
            var datos = new Request<Files>();
            //datos.entidad = entidad;
            datos.entidad = new Files();
            if (anio != "")
            {
                datos.entidad.anio = Convert.ToInt32(anio);
            }
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


        /*LOTES*/
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



        [HttpPost]
        [AllowAnonymous]
        public JsonResult InsertarLote(Lotes entidad)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Response response = new Response();
                    
                    //entidad.IdSede = VariablesWeb.ENUsuario.IdSede;
                    entidad.HOST_REG = VariablesWeb.HostName();
                    entidad.USUARIO_REG = VariablesWeb.Usuario.SUsrId;


                    var datos = new Request<Lotes>();
                    datos.entidad = entidad;
                    response = new LotesAplicacion(new LotesRepositorio()).Insertar(datos);

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


        [HttpDelete]
        [AllowAnonymous]
        public JsonResult EliminarLote(Lotes entidad)
        {
           
            if (ModelState.IsValid)
            {
                try
                {

                    Response response = new Response();
                    var datos = new Request<Lotes>();
                    datos.entidad = entidad;
                    response = new LotesAplicacion(new LotesRepositorio()).Eliminar(datos);

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



        [HttpPut]
        [AllowAnonymous]
        public JsonResult ActualizarLote(Lotes entidad)
        {


            if (ModelState.IsValid)
            {
                try
                {

                    Response response = new Response();
                    var datos = new Request<Lotes>();
                    datos.entidad = entidad;
                    response = new LotesAplicacion(new LotesRepositorio()).Actualizar(datos);

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


        /*FIN LOTES*/

        /*CONTENEDOR*/

        [HttpGet]
        [AllowAnonymous]
        public JsonResult ListarContenedores(int OcId, int file)
        {
            var datos = new Request<Contenedores>();
            //datos.entidad = entidad;
            datos.entidad = new Contenedores();
            datos.entidad.IdOPeraciones = OcId;
            datos.entidad.IdFile = file;
            ////datos.entidad.IdSede = VariablesWeb.Usuario.IdSede;
            var lista = new ContenedorAplicacion(new ContenedorRepositorio()).Listar(datos);
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
        public JsonResult InsertarContenedor(Contenedores entidad)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Response response = new Response();

                    //entidad.IdSede = VariablesWeb.ENUsuario.IdSede;
                    entidad.HOST_REG = VariablesWeb.HostName();
                    entidad.USUARIO_REG = VariablesWeb.Usuario.SUsrId;


                    var datos = new Request<Contenedores>();
                    datos.entidad = entidad;
                    response = new ContenedorAplicacion(new ContenedorRepositorio()).Insertar(datos);

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



        [HttpDelete]
        [AllowAnonymous]
        public JsonResult EliminarContenedor(Contenedores entidad)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    Response response = new Response();
                    var datos = new Request<Contenedores>();
                    datos.entidad = entidad;
                    response = new ContenedorAplicacion(new ContenedorRepositorio()).Eliminar(datos);

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

        
        [HttpPut]
        [AllowAnonymous]
        public JsonResult ActualizarContenedor(Contenedores entidad)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    Response response = new Response();

                    entidad.HOST_ACT = VariablesWeb.HostName();
                    entidad.USUARIO_ACT = VariablesWeb.Usuario.SUsrId;



                    var datos = new Request<Contenedores>();
                    datos.entidad = entidad;
                    response = new ContenedorAplicacion(new ContenedorRepositorio()).Actualizar(datos);

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

        /*FIN CONTENEDOR*/





        /*INICIO OPERACIONES*/

        [HttpGet]
        [AllowAnonymous]
        public JsonResult ListarOperacionesO(int OcId, int file)
        {
            var datos = new Request<Operativa>();
            //datos.entidad = entidad;
            datos.entidad = new Operativa();
            datos.entidad.IdOPeraciones = OcId;
            datos.entidad.IdFile = file;
            ////datos.entidad.IdSede = VariablesWeb.Usuario.IdSede;
            var lista = new OperativaAplicacion(new OperativaRepositorio()).Listar(datos);
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



        [HttpPut]
        [AllowAnonymous]
        public JsonResult ActualizarOperacionImp(Operativa entidad)
        {
            

            if (ModelState.IsValid)
            {
                try
                {

                    Response response = new Response();
                    var datos = new Request<Operativa>();
                    datos.entidad = entidad;
                    response = new OperativaAplicacion(new OperativaRepositorio()).Actualizar(datos);

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
        public JsonResult InsertarOperacionesImp(Operativa entidad)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Response response = new Response();

                    

                    var datos = new Request<Operativa>();
                    datos.entidad = entidad;
                    response = new OperativaAplicacion(new OperativaRepositorio()).Insertar(datos);

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



        [HttpDelete]
        [AllowAnonymous]
        public JsonResult EliminarOperacionesImp(Operativa entidad)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    Response response = new Response();
                    var datos = new Request<Operativa>();
                    datos.entidad = entidad;
                    response = new OperativaAplicacion(new OperativaRepositorio()).Eliminar(datos);

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


        /*FIN OPERACIONES*/






























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
