using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CSala
    {
        #region DMLS
        public static bool Insertar(Sala objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre de la Sala");

            if (x.Cantidad > 0)
                throw x;

            DAOSala daoProxy = new DAOSala();
            return daoProxy.Insertar(objProxy.Nombre, objProxy.Estado) > 0;
        }
        public static bool Actualizar(Sala objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre");

            if (x.Cantidad > 0)
                throw x;

            DAOSala daoProxy = new DAOSala();
            return daoProxy.Actualizar(objProxy.Id, objProxy.Nombre, objProxy.Estado);
        }
        public static bool Eliminar(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOSala daoProxy = new DAOSala();
            return daoProxy.Eliminar(codigo);
        }
        #endregion
        #region Selects
        public static Sala TraerXId(int codigo)
        {
            DAOSala daoProxy = new DAOSala();
            DataSet dtsProxy = daoProxy.TraerTipoPaqueteXId(codigo);
            
            if (dtsProxy.Tables.Count > 0 && dtsProxy.Tables[0].Rows.Count > 0)
                return Cargar(dtsProxy.Tables[0].Rows[0]);
            return null;
        }
        public static DataTable TraerXCriterio(string nombre)
        {
            DAOSala daoProxy = new DAOSala();
            DataSet dtsProxy = daoProxy.TraerTipoPaqueteXCriterio(nombre);
            
            return dtsProxy.Tables[0];
        }
        public static DataTable TraerXEstado(string nombre)
        {
            DAOSala daoProxy = new DAOSala();
            DataSet dtsProxy = daoProxy.TraerXEstado(nombre);

            return dtsProxy.Tables[0];
        }
        #endregion
        #region Metodos Privados
        private static List<Sala> CargarLista(DataTable tabla)
        {
            List<Sala> lstProxy = new List<Sala>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Sala Cargar(DataRow fila)
        {
            Sala objProxy = new Sala();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Nombre = fila["nombre"].ToString();
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            
            return objProxy;
        }
        #endregion
    }
}
