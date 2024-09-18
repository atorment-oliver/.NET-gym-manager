using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CLicencia
    {
        #region DMLS
        public static bool Insertar(Licencia objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.ClientePaqueteId < 0)
                x.AgregarError("Ingrese un cliente");

            if (x.Cantidad > 0)
                throw x;

            DAOLicencia daoProxy = new DAOLicencia();
            return daoProxy.Insertar(objProxy.Descripcion, objProxy.ClientePaqueteId, objProxy.FechaSolicitud, objProxy.FechaInicioLicencia, objProxy.FechaFinLicencia, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha) > 0;
        }
        public static bool Actualizar(Licencia objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOLicencia daoProxy = new DAOLicencia();
            return daoProxy.Actualizar(objProxy.Id, objProxy.Descripcion, objProxy.ClientePaqueteId, objProxy.FechaSolicitud, objProxy.FechaInicioLicencia, objProxy.FechaFinLicencia, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha);
        }

        public static bool EliminarLicencia(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOLicencia daoProxy = new DAOLicencia();
            return daoProxy.Eliminar(codigo);
        }
        #endregion
        #region Selects

        public static List<Licencia> TraerXId(int codigo)
        {
            DAOLicencia daoProxy = new DAOLicencia();
            DataSet dtsProxy = daoProxy.TraerLicenciaXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXIdImp(int codigo)
        {
            DAOLicencia daoProxy = new DAOLicencia();
            DataSet dtsProxy = daoProxy.TraerLicenciaXIdImp(codigo);


            return dtsProxy.Tables[0];
        }
        public static DataTable TraerXClientePaqueteId(int codigo)
        {
            DAOLicencia daoProxy = new DAOLicencia();
            DataSet dtsProxy = daoProxy.TraerXClientePaqueteId(codigo);

            return (dtsProxy.Tables[0]);
        }
        public static List<Licencia> TraerXClientePaqueteId2(int codigo)
        {
            DAOLicencia daoProxy = new DAOLicencia();
            DataSet dtsProxy = daoProxy.TraerXClientePaqueteId2(codigo);

            if (dtsProxy.Tables.Count > 0)
                return (CargarLista(dtsProxy.Tables[0]));

            return null;
        }
        public static List<Licencia> TraerXCriterio(string descripcion, int clientePaqueteId, string fechaInicio, string fechaFin, string estado)
        {
            DAOLicencia daoProxy = new DAOLicencia();
            DataSet dtsProxy = daoProxy.TraerLicenciaXCriterio(descripcion, clientePaqueteId, fechaInicio, fechaFin, estado);

            if (dtsProxy.Tables.Count > 0)
                return CargarLista(dtsProxy.Tables[0]);

            return null;
        }
        public static DataTable TraerXCriterioD(string descripcion, int clientePaqueteId,string fechaInicio, string fechaFin, string estado)
        {
            DAOLicencia daoProxy = new DAOLicencia();
            DataSet dtsProxy = daoProxy.TraerLicenciaXCriterio(descripcion, clientePaqueteId, fechaInicio, fechaFin, estado);


            return dtsProxy.Tables[0];
        }


        #endregion
        #region Metodos Privados
        private static List<Licencia> CargarLista(DataTable tabla)
        {
            List<Licencia> lstProxy = new List<Licencia>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Licencia Cargar(DataRow fila)
        {
            Licencia objProxy = new Licencia();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Descripcion = ((fila["descripcion"].ToString()));
            objProxy.ClientePaqueteId = Convert.ToInt32((fila["clientePaqueteId"].ToString()));
            objProxy.FechaSolicitud = Convert.ToDateTime(fila["fechaSolicitud"].ToString());
            objProxy.FechaInicioLicencia = Convert.ToDateTime(fila["fechaInicioLicencia"].ToString());
            objProxy.FechaFinLicencia = Convert.ToDateTime(fila["fechaFinLicencia"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());

            return objProxy;
        }
        #endregion
    }
}
