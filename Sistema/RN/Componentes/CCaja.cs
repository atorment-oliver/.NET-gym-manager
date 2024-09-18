using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CCaja
    {
        #region DMLS
        public static bool Insertar(Caja objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.CajeroId))
                x.AgregarError("Ingrese el codigo del cajero");

            if (x.Cantidad > 0)
                throw x;

            DAOCaja daoProxy = new DAOCaja();
            return daoProxy.Insertar(objProxy.CajeroId, objProxy.FechaCreacion, objProxy.Estado, objProxy.Numero) > 0;
        }
        public static bool Actualizar(Caja objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOCaja daoProxy = new DAOCaja();
            return daoProxy.Actualizar(objProxy.Id, objProxy.CajeroId,objProxy.FechaCreacion, objProxy.Estado, objProxy.Numero);
        }
        public static bool Cerrar(Caja objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOCaja daoProxy = new DAOCaja();
            return daoProxy.Actualizar(objProxy.Id, objProxy.Estado);
        }
        public static bool EliminarCaja(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOCaja daoProxy = new DAOCaja();
            return daoProxy.Eliminar(codigo);
        }
        #endregion
        #region Selects
        public static List<Caja> Traer()
        {
            DAOCaja daoProxy = new DAOCaja();
            DataSet dtsProxy = daoProxy.TraerCajas();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static int TraerUltimoId()
        {
            DAOCaja daoProxy = new DAOCaja();
            DataSet dtsProxy = daoProxy.TraerUltimoId();
            if (dtsProxy != null && dtsProxy.Tables.Count > 0 && dtsProxy.Tables[0].Rows.Count > 0 && !string.IsNullOrEmpty(dtsProxy.Tables[0].Rows[0][0].ToString()))
                return Convert.ToInt32(dtsProxy.Tables[0].Rows[0][0]);
            return 1;
        }
        public static List<Caja> TraerXId(int codigo)
        {
            DAOCaja daoProxy = new DAOCaja();
            DataSet dtsProxy = daoProxy.TraerCajaXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Caja> TraerXCriterio(string numero, string cajeroId, string estado)
        {
            DAOCaja daoProxy = new DAOCaja();
            DataSet dtsProxy = daoProxy.TraerCajaXCriterio(numero, cajeroId, estado);

            if (dtsProxy.Tables.Count > 0)
                return CargarLista(dtsProxy.Tables[0]);

            return null;
        }
        public static DataTable TraerXCriterioD(string numero, string cajeroId, string estado)
        {
            DAOCaja daoProxy = new DAOCaja();
            DataSet dtsProxy = daoProxy.TraerCajaXCriterio(numero, cajeroId, estado);


            return dtsProxy.Tables[0];
        }
        public static List<Caja> EstaAbierto(string codigo)
        {
            ValidationException x = new ValidationException();

            if (x.Cantidad > 0)
                throw x;

            DAOCaja daoProxy = new DAOCaja();
            DataSet dtsProxy = daoProxy.EstaAbierto(codigo);
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Caja> UltimaCaja(string codigo)
        {
            ValidationException x = new ValidationException();

            if (x.Cantidad > 0)
                throw x;

            DAOCaja daoProxy = new DAOCaja();
            DataSet dtsProxy = daoProxy.UltimaCaja(codigo);
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Caja> EstaAsignada(string codigo)
        {
            ValidationException x = new ValidationException();

            if (x.Cantidad > 0)
                throw x;

            DAOCaja daoProxy = new DAOCaja();
            DataSet dtsProxy = daoProxy.EstaAsignada(codigo);
            return CargarLista(dtsProxy.Tables[0]);
        }
        #endregion
        #region Metodos Privados
        private static List<Caja> CargarLista(DataTable tabla)
        {
            List<Caja> lstProxy = new List<Caja>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Caja Cargar(DataRow fila)
        {
            Caja objProxy = new Caja();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Numero = Convert.ToInt32(fila["numero"].ToString());
            objProxy.CajeroId = (fila["cajeroId"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());

            return objProxy;
        }
        #endregion
    }
}
