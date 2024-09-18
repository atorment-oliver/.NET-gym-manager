using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CPromocionCliente
    {
        #region DMLS
        public static bool Insertar(PromocionCliente objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.ClientePaqueteId < 0)
                x.AgregarError("Ingrese un monto");

            if (x.Cantidad > 0)
                throw x;

            DAOPromocionCliente daoProxy = new DAOPromocionCliente();
            return daoProxy.Insertar(objProxy.ClientePaqueteId, objProxy.PromocionId, objProxy.FechaAsignacion, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha) > 0;
        }
        public static bool Actualizar(PromocionCliente objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOPromocionCliente daoProxy = new DAOPromocionCliente();
            return daoProxy.Actualizar(objProxy.Id, objProxy.ClientePaqueteId, objProxy.PromocionId, objProxy.FechaAsignacion, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha);
        }

        public static bool EliminarPromocionCliente(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOPromocionCliente daoProxy = new DAOPromocionCliente();
            return daoProxy.Eliminar(codigo);
        }
        #endregion
        #region Selects

        public static List<PromocionCliente> TraerXId(int codigo)
        {
            DAOPromocionCliente daoProxy = new DAOPromocionCliente();
            DataSet dtsProxy = daoProxy.TraerPromocionXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<PromocionCliente> TraerXIdCliente(int codigo)
        {
            DAOPromocionCliente daoProxy = new DAOPromocionCliente();
            DataSet dtsProxy = daoProxy.TraerXIdCliente(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<PromocionCliente> TraerXIdPaqueteCliente(int codigo)
        {
            DAOPromocionCliente daoProxy = new DAOPromocionCliente();
            DataSet dtsProxy = daoProxy.TraerXIdPaqueteCliente(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<PromocionCliente> TraerXIdClienteMensual(int codigo)
        {
            DAOPromocionCliente daoProxy = new DAOPromocionCliente();
            DataSet dtsProxy = daoProxy.TraerXIdClienteMensual(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<PromocionCliente> TraerXIdClienteNoMensual(int codigo)
        {
            DAOPromocionCliente daoProxy = new DAOPromocionCliente();
            DataSet dtsProxy = daoProxy.TraerXIdClienteNoMensual(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<PromocionCliente> TraerXIdClienteValidando(int codigo)
        {
            DAOPromocionCliente daoProxy = new DAOPromocionCliente();
            DataSet dtsProxy = daoProxy.TraerXIdClienteValidando(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<PromocionCliente> TraerXIdClientePago(int codigo)
        {
            DAOPromocionCliente daoProxy = new DAOPromocionCliente();
            DataSet dtsProxy = daoProxy.TraerXIdClientePago(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<PromocionCliente> TraerXCriterio(string fechaInicio, string fechaFin, string usuarioId, string estado)
        {
            DAOPromocionCliente daoProxy = new DAOPromocionCliente();
            DataSet dtsProxy = daoProxy.TraerPromocionXCriterio(fechaInicio, fechaFin, usuarioId, estado);

            if (dtsProxy.Tables.Count > 0)
                return CargarLista(dtsProxy.Tables[0]);

            return null;
        }
        public static DataTable TraerXCriterioD(string fechaInicio, string fechaFin, string usuarioId, string estado)
        {
            DAOPromocionCliente daoProxy = new DAOPromocionCliente();
            DataSet dtsProxy = daoProxy.TraerPromocionXCriterio(fechaInicio, fechaFin, usuarioId, estado);


            return dtsProxy.Tables[0];
        }


        #endregion
        #region Metodos Privados
        private static List<PromocionCliente> CargarLista(DataTable tabla)
        {
            List<PromocionCliente> lstProxy = new List<PromocionCliente>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static PromocionCliente Cargar(DataRow fila)
        {
            PromocionCliente objProxy = new PromocionCliente();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.ClientePaqueteId = Convert.ToInt32(fila["ClientePaqueteId"].ToString());
            objProxy.PromocionId = Convert.ToInt32(fila["PromocionId"].ToString());
            objProxy.FechaAsignacion = Convert.ToDateTime(fila["FechaAsignacion"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());

            return objProxy;
        }
        #endregion
    }
}
