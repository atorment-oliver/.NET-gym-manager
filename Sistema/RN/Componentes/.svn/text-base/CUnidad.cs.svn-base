using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CUnidad
    {
        #region DMLS
        public static bool Insertar(Unidad objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre del Unidad");

            if (x.Cantidad > 0)
                throw x;

            DAOUnidad daoProxy = new DAOUnidad();
            return daoProxy.Insertar(objProxy.Nombre, objProxy.Estado) > 0;
        }
        public static bool Actualizar(Unidad objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre");

            if (x.Cantidad > 0)
                throw x;

            DAOUnidad daoProxy = new DAOUnidad();
            return daoProxy.Actualizar(objProxy.Id, objProxy.Nombre, objProxy.Estado);
        }
        public static bool EliminarUnidad(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOUnidad daoProxy = new DAOUnidad();
            return daoProxy.Eliminar(codigo);
        }
        #endregion
        #region Selects
        public static List<Unidad> Traer()
        {
            DAOUnidad daoProxy = new DAOUnidad();
            DataSet dtsProxy = daoProxy.TraerUnidads();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Unidad> TraerXId(int codigo)
        {
            DAOUnidad daoProxy = new DAOUnidad();
            DataSet dtsProxy = daoProxy.TraerUnidadXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Unidad> TraerXCriterio(string nombre, string estado)
        {
            DAOUnidad daoProxy = new DAOUnidad();
            DataSet dtsProxy = daoProxy.TraerUnidadXCriterio(nombre, estado);


            return CargarLista(dtsProxy.Tables[0]);
        }
        #endregion
        #region Metodos Privados
        private static List<Unidad> CargarLista(DataTable tabla)
        {
            List<Unidad> lstProxy = new List<Unidad>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Unidad Cargar(DataRow fila)
        {
            Unidad objProxy = new Unidad();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Nombre = fila["nombre"].ToString();
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());

            return objProxy;
        }
        #endregion
    }
}
