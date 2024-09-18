using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CDistribucionPago
    {
        #region DMLS
        public static bool Insertar(DistribucionPago objProxy)
        {
            ValidationException x = new ValidationException();
            if ((objProxy.ClienteId) <= 0)
                x.AgregarError("Ingrese el cliente");

            if (x.Cantidad > 0)
                throw x;

            DAODistribucionPago daoProxy = new DAODistribucionPago();
            return daoProxy.Insertar(objProxy.ClienteId, objProxy.Porcentaje, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha) > 0;
        }
        public static bool Actualizar(DistribucionPago objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if ((objProxy.ClienteId) <=0)
                x.AgregarError("Ingrese el cliente");

            if (x.Cantidad > 0)
                throw x;

            DAODistribucionPago daoProxy = new DAODistribucionPago();
            return daoProxy.Actualizar(objProxy.Id, objProxy.ClienteId, objProxy.Porcentaje, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha);
        }
        public static bool EliminarDistribucionPago(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAODistribucionPago daoProxy = new DAODistribucionPago();
            return daoProxy.Eliminar(codigo);
        }

        #endregion
        #region Selects
        public static List<DistribucionPago> Traer()
        {
            DAODistribucionPago daoProxy = new DAODistribucionPago();
            DataSet dtsProxy = daoProxy.TraerDistribucionPagos();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<DistribucionPago> TraerXId(int codigo)
        {
            DAODistribucionPago daoProxy = new DAODistribucionPago();
            DataSet dtsProxy = daoProxy.TraerDistribucionPagoXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<DistribucionPago> TraerXIdCliente(int codigo)
        {
            DAODistribucionPago daoProxy = new DAODistribucionPago();
            DataSet dtsProxy = daoProxy.TraerDistribucionPagoXIdCliente(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<DistribucionPago> TraerXCriterio(int porcentajeInicio, int porcentajeFin, string cliente, string empresaId)
        {
            DAODistribucionPago daoProxy = new DAODistribucionPago();
            DataSet dtsProxy = daoProxy.TraerDistribucionPagoXCriterio(porcentajeInicio, porcentajeFin, cliente, empresaId);
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXCriterioD(int porcentajeInicio, int porcentajeFin, string cliente, string empresaId)
        {
            DAODistribucionPago daoProxy = new DAODistribucionPago();
            DataSet dtsProxy = daoProxy.TraerDistribucionPagoXCriterio(porcentajeInicio, porcentajeFin, cliente, empresaId);
            return dtsProxy.Tables[0];
        }
        public static DataTable TraerXPendientes(string clienteId, string empresaId)
        {
            DAODistribucionPago daoProxy = new DAODistribucionPago();
            DataSet dtsProxy = daoProxy.TraerDistribucionPagoXPendientes(clienteId, empresaId);
            return dtsProxy.Tables[0];
        }
        public static DataTable TraerXCriterioPago(int porcentajeInicio, int porcentajeFin, string clienteId, string empresaId)
        {
            DAODistribucionPago daoProxy = new DAODistribucionPago();
            DataSet dtsProxy = daoProxy.TraerDistribucionPagoXCriterioPago(porcentajeInicio, porcentajeFin, clienteId, empresaId);
            return dtsProxy.Tables[0];
        }
       
        #endregion
        #region Metodos Privados
        private static List<DistribucionPago> CargarLista(DataTable tabla)
        {
            List<DistribucionPago> lstProxy = new List<DistribucionPago>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static DistribucionPago Cargar(DataRow fila)
        {
            DistribucionPago objProxy = new DistribucionPago();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.ClienteId = Convert.ToInt32(fila["clienteId"].ToString());
            objProxy.Porcentaje = Convert.ToInt32(fila["porcentaje"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());

            return objProxy;
        }
        #endregion
    }
}
