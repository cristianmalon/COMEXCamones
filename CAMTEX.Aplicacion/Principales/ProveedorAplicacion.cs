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
    public class ProveedorAplicacion: IGeneralAplicacion<Proveedor>
    {
        private ProveedorRepositorio ProveedorRepositorio;

        public ProveedorAplicacion(ProveedorRepositorio proveedorRepositorio)
        {
            ProveedorRepositorio = proveedorRepositorio;
        }

        public Response Actualizar(Request<Proveedor> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Eliminar(Request<Proveedor> entidad)
        {
            throw new NotImplementedException();
        }

        public Response Insertar(Request<Proveedor> entidad)
        {
            throw new NotImplementedException();
        }

        public Response<List<Proveedor>> Listar(Request<Proveedor> entidad)
        {
            Response<List<Proveedor>> retorno = new Response<List<Proveedor>>();

            try
            {
                DataTable dt = ProveedorRepositorio.Listar(entidad.entidad);
                List<Proveedor> lista = new List<Proveedor>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Proveedor()
                    {
                        PrvCCod = Util.CapturaString(row, "PrvCCod"),     		
                        PrvDDes = Util.CapturaString(row, "PrvDDes"),          		
                        PrvDRuc = Util.CapturaString(row, "PrvDRuc"),      		
                        PrvDDir = Util.CapturaString(row, "PrvDDir"),       		
                        PrvDTel = Util.CapturaString(row, "PrvDTel"),       		
                        PrvSEst = Util.CapturaString(row, "PrvSEst"),          		
                        PrvCSap = Util.CapturaString(row, "PrvCSap"),        		
                        IdProveedor = Util.CapturaInt0(row, "IdProveedor")       

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

        public Response<List<Proveedor>> ListarPaginado(Request<Proveedor> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
