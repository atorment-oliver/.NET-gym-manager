using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CClientePaquete
    {
        #region DMLS
        public static bool Insertar(ClientePaquete objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.ClienteId < 0)
                x.AgregarError("Ingrese el Cliente");

            if (x.Cantidad > 0)
                throw x;

            DAOClientePaquete daoProxy = new DAOClientePaquete();
            return daoProxy.Insertar(objProxy.ClienteId, objProxy.PaqueteId, objProxy.FechaRegistro, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha) > 0;
        }
        public static int InsertarCodigo(ClientePaquete objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.ClienteId < 0)
                x.AgregarError("Ingrese el Cliente");

            if (x.Cantidad > 0)
                throw x;

            DAOClientePaquete daoProxy = new DAOClientePaquete();
            return daoProxy.Insertar(objProxy.ClienteId, objProxy.PaqueteId, objProxy.FechaRegistro, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha);
        }
        public static bool Actualizar(ClientePaquete objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (objProxy.ClienteId < 0)
                x.AgregarError("Ingrese el Cliente");

            if (x.Cantidad > 0)
                throw x;

            DAOClientePaquete daoProxy = new DAOClientePaquete();
            return daoProxy.Actualizar(objProxy.Id, objProxy.ClienteId, objProxy.PaqueteId, objProxy.FechaRegistro, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha);
        }
        public static bool EliminarClientePaquete(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOClientePaquete daoProxy = new DAOClientePaquete();
            return daoProxy.Eliminar(codigo);
        }

        #endregion
        #region Selects
        public static List<ClientePaquete> Traer()
        {
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TraerClientePaquetes();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<ClientePaquete> TraerXId(int codigo)
        {
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TraerClientePaqueteXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXIdPrecioReal(int codigo)
        {
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TraerClientePaqueteXIdPrecioReal(codigo);


            return (dtsProxy.Tables[0]);
        }
        public static DataTable TraerXIdPrecioRealPaquete(int codigo, int paqueteid)
        {
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TraerClientePaqueteXIdPrecioRealPaquete(codigo, paqueteid);


            return (dtsProxy.Tables[0]);
        }
        public static List<ClientePaquete> TraerXCriterio(string nombre, string tipoClientePaqueteId, string estado)
        {
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TraerClientePaqueteXCriterio(nombre, tipoClientePaqueteId, estado);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXCriterioD(string nombre, string tipoClientePaqueteId, string estado)
        {
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TraerClientePaqueteXCriterio(nombre, tipoClientePaqueteId, estado);
            return dtsProxy.Tables[0];
        }
        public static DataTable TraerHistorial(int clienteId)
        {
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TraerHistorial(clienteId);
            return dtsProxy.Tables[0];
        }
        public static DataTable TraerHistorialAdicional(int clienteId)
        {
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TraerHistorialAdiciona(clienteId);
            return dtsProxy.Tables[0];
        }
        public static DataTable TraerTiempoPaquete(int clienteId)
        {
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TraerClientePaqueteTiempoPaquete(clienteId);


            return dtsProxy.Tables[0];
        }
        public static DataTable TraerPaquetesAdeudados(int clienteId)
        {
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TraerPaquetesAdeudados(clienteId);


            return dtsProxy.Tables[0];
        }
        public static DataTable TraerPaquetesAdeudadosEmpresa(int clienteId, int Mes, int ano)
        {
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TraerPaquetesAdeudadosEmpresa(clienteId, Mes, ano);


            return dtsProxy.Tables[0];
        }
        public static bool EstaAsignado(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.EstaAsignado(codigo);
            if (dtsProxy.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }
        public static bool TieneAdicional(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TieneAdicional(codigo);
            if (dtsProxy.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }
        public static List<ClientePaquete> DatosTieneAdicional(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TieneAdicional(codigo);
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static bool TieneAdicionalPadre(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TieneAdicionalPadre(codigo);
            if (dtsProxy.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }
        public static List<ClientePaquete> TraerXCIdCliente(int id)
        {
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TraerXCIdCliente(id);


            return CargarLista(dtsProxy.Tables[0]);
        }

        public static List<ClientePaquete> TraerXCIdClienteHabilitado(int id, bool estado)
        {
            DAOClientePaquete daoProxy = new DAOClientePaquete();
            DataSet dtsProxy = daoProxy.TraerXCIdClienteHabilitado(id, estado);

            return CargarLista(dtsProxy.Tables[0]);
        }
        #endregion
        #region Metodos Privados
        private static List<ClientePaquete> CargarLista(DataTable tabla)
        {
            List<ClientePaquete> lstProxy = new List<ClientePaquete>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static ClientePaquete Cargar(DataRow fila)
        {
            ClientePaquete objProxy = new ClientePaquete();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.PaqueteId = Convert.ToInt32(fila["paqueteId"].ToString());
            objProxy.ClienteId = Convert.ToInt32(fila["clienteId"].ToString());
            objProxy.FechaRegistro = Convert.ToDateTime(fila["fechaRegistro"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());

            return objProxy;
        }
        #endregion
    }
}
