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
    public class FilesAplicacion: IGeneralAplicacion<Files>
    {
        private FilesRepositorio FilesRepositorio;

        public FilesAplicacion(FilesRepositorio filesRepositorio)
        {
            FilesRepositorio = filesRepositorio;
        }

        public Response Actualizar(Request<Files> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<Files> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<Files> entidad)
        {
            Response retorno = new Response();
            try
            {
                var resultado = FilesRepositorio.Insertar(entidad.entidad);
                retorno.Success = true;
                retorno.error = false;
                retorno.output = resultado["NuevoFileID"].ToString();


            }
            catch (Exception ex)
            {
                retorno.error = true;
                retorno.mensaje = ex.Message;
            }
            return retorno;
        }
        public Response InsertarE(Request<Files> entidad)
        {
            Response retorno = new Response();
            try
            {
                var resultado = FilesRepositorio.InsertarE(entidad.entidad);
                retorno.Success = true;
                retorno.error = false;
                retorno.output = resultado["NuevoFileID"].ToString();

            }
            catch (Exception ex)
            {
                retorno.error = true;
                retorno.mensaje = ex.Message;
            }
            return retorno;
        }


        public Response<List<Files>> ListarI(Request<Files> entidad)
        {
            Response<List<Files>> retorno = new Response<List<Files>>();

            try
            {
                DataTable dt = FilesRepositorio.ListarI(entidad.entidad);
                List<Files> lista = new List<Files>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Files()
                    {
                        NombreF = Util.CapturaString(row, "NombreF"),
                        CodProv = Util.CapturaString(row, "CodProv"),
                        FileId = Util.CapturaInt0(row, "FileId"),
                        CodFile = Util.CapturaString(row, "CodFile"),
                        FechaOp = Util.CapturaDatetime(row, "FechaOp"),
                        OrdenID = Util.CapturaString(row, "OrdenID"),
                        NroOp = Util.CapturaString(row, "NroOp"),
                        Proveedor = Util.CapturaString(row, "Proveedor"),
                        OrdC = Util.CapturaString(row, "OrdC"),
                        NumeroOperacion = Util.CapturaString(row, "NumeroOperacion"),
                        DesArt = Util.CapturaString(row, "DesArt"),
                        Situacion = Util.CapturaString(row, "Situacion"),

                        FechaEmbarque = Util.CapturaDatetime(row, "Fechaembarque"),
                        ViaTransporte = Util.CapturaString(row, "ViaTransporte"),
                        UsuarioCreacion = Util.CapturaString(row, "OperacionUsuarioLogCrea"),
                        TarCCod = Util.CapturaString(row, "TarCCod"),



                        TarDNem = Util.CapturaString(row, "TarDNem"),
                        CNPDDes = Util.CapturaString(row, "CNPDDes"),
                        OrcDMon = Util.CapturaString(row, "OrcDMon"),


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


        public Response<List<Files>> ListarE(Request<Files> entidad)
        {
            Response<List<Files>> retorno = new Response<List<Files>>();

            try
            {
                DataTable dt = FilesRepositorio.ListarE(entidad.entidad);
                List<Files> lista = new List<Files>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Files()
                    {
                        FileId = Util.CapturaInt0(row, "CodFile"),
                        CodFile = Util.CapturaString(row, "FileName"),
                        Detalle = Util.CapturaString(row, "Detalle"),
                        FechaOp = Util.CapturaDatetime(row, "FechaOp"),
                        NroOp = Util.CapturaString(row, "NroOp"),
                        NumeroOperacion = Util.CapturaString(row, "NumeroOperacion"),
                        Proveedor = Util.CapturaString(row, "Proveedor"),
                        IE_Anio = Util.CapturaString(row, "IE_Anio"),
                        IE_Nro = Util.CapturaString(row, "IE_Nro"),
                        CantPrendas = Util.CapturaDecimal(row, "CantPrendas"),
                        Control_Comex = Util.CapturaString(row, "Control_Comex")
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
        public Response<List<Files>> ListarPaginado(Request<Files> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<Files>> Listar(Request<Files> entidad)
        {
            throw new NotImplementedException();
        }

        public Response ListarReporteImportacion()
        {
            Response retorno = new Response();
            try
            {
                var dt = FilesRepositorio.ListarReporteImportacion();
                retorno.Success = true;
                retorno.error = false;
                retorno.tabla = dt;

            }
            catch (Exception ex)
            {
                retorno.error = true;
                retorno.mensaje = ex.Message;
            }
            return retorno;
        }
    }
}
