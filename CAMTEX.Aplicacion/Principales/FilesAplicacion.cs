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

                        FileId = Util.CapturaInt0(row, "FileId"),
                        CodFile = Util.CapturaString(row, "CodFile"),
                        FechaOp = Util.CapturaDatetime(row, "FechaOp"),

                        NroOp = Util.CapturaString(row, "NroOp"),
                        Proveedor = Util.CapturaString(row, "Proveedor"),
                        OrdC = Util.CapturaString(row, "OrdC"),

                        DesArt = Util.CapturaString(row, "DesArt"),
                        Situacion = Util.CapturaString(row, "Situacion"),

                        FechaEmbarque = Util.CapturaDatetime(row, "Fechaembarque"),
                        ViaTransporte = Util.CapturaString(row, "ViaTransporte"),


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
                        FechaOp = Util.CapturaDatetime(row, "FechaOp"),

                        NroOp = Util.CapturaString(row, "NroOp"),
                        Proveedor = Util.CapturaString(row, "Proveedor"),
                        OrdC = Util.CapturaString(row, "OrdC"),

                        Producto = Util.CapturaString(row, "Producto"),
                        DesArt = Util.CapturaString(row, "DesArt"),
                        Solicitado = Util.CapturaInt0(row, "Solicitado"),

                        DUA = Util.CapturaString(row, "DUA"),
                        Deposito = Util.CapturaInt0(row, "Deposito"),
                        Situacion = Util.CapturaString(row, "Situacion"),

                        FechaIngreso = Util.CapturaDatetime(row, "FechaIngreso"),
                        FechaEmbarque = Util.CapturaDatetime(row, "FechaEmbarque"),
                       
                        NumFactura = Util.CapturaInt0(row, "NumFactura"),
                        LineaNaviera = Util.CapturaString(row, "LineaNaviera"),

                        Contenedor = Util.CapturaInt0(row, "Contenedor"),
                        AgenteAduana = Util.CapturaString(row, "AgenteAduana"),

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
    }
}
