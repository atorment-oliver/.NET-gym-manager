using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CTipoPaquete
    {
        #region DMLS
        public static bool Insertar(TipoPaquete objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre del TipoPaquete");

            if (x.Cantidad > 0)
                throw x;

            DAOTipoPaquete daoProxy = new DAOTipoPaquete();
            return daoProxy.Insertar(objProxy.Nombre, objProxy.LimiteServicios, objProxy.Estado) > 0;
        }
        public static bool Actualizar(TipoPaquete objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre");

            if (x.Cantidad > 0)
                throw x;

            DAOTipoPaquete daoProxy = new DAOTipoPaquete();
            return daoProxy.Actualizar(objProxy.Id, objProxy.Nombre, objProxy.LimiteServicios, objProxy.Estado);
        }
        public static bool EliminarTipoPaquete(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOTipoPaquete daoProxy = new DAOTipoPaquete();
            return daoProxy.Eliminar(codigo);
        }
        #endregion
        #region Selects
        public static List<TipoPaquete> Traer()
        {
            DAOTipoPaquete daoProxy = new DAOTipoPaquete();
            DataSet dtsProxy = daoProxy.TraerTipoPaquetes();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<TipoPaquete> TraerXId(int codigo)
        {
            DAOTipoPaquete daoProxy = new DAOTipoPaquete();
            DataSet dtsProxy = daoProxy.TraerTipoPaqueteXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<TipoPaquete> TraerXCriterio(string nombre, string limiteServicios, string estado)
        {
            DAOTipoPaquete daoProxy = new DAOTipoPaquete();
            DataSet dtsProxy = daoProxy.TraerTipoPaqueteXCriterio(nombre, limiteServicios, estado);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXCriterioD(string nombre, string limiteServicios, string estado)
        {
            DAOTipoPaquete daoProxy = new DAOTipoPaquete();
            DataSet dtsProxy = daoProxy.TraerTipoPaqueteXCriterio(nombre, limiteServicios, estado);


            return dtsProxy.Tables[0];
        }
        public static bool EstaAsignado(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOTipoPaquete daoProxy = new DAOTipoPaquete();
            DataSet dtsProxy = daoProxy.EstaAsignado(codigo);


            if (dtsProxy.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }
        #endregion
        #region Metodos Privados
        private static List<TipoPaquete> CargarLista(DataTable tabla)
        {
            List<TipoPaquete> lstProxy = new List<TipoPaquete>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static TipoPaquete Cargar(DataRow fila)
        {
            TipoPaquete objProxy = new TipoPaquete();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Nombre = fila["nombre"].ToString();
            objProxy.LimiteServicios = (fila["limiteServicios"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            
            return objProxy;
        }
        #endregion
    }
}
