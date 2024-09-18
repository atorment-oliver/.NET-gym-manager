using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CIntercambio
    {
        #region DMLS
        public static bool Insertar(Intercambio objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el codigo del cajero");

            if (x.Cantidad > 0)
                throw x;

            DAOIntercambio daoProxy = new DAOIntercambio();
            return daoProxy.Insertar(objProxy.Nombre) > 0;
        }
        public static bool Actualizar(Intercambio objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOIntercambio daoProxy = new DAOIntercambio();
            return daoProxy.Actualizar(objProxy.Id, objProxy.Nombre);
        }
        
        public static bool EliminarIntercambio(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOIntercambio daoProxy = new DAOIntercambio();
            return daoProxy.Eliminar(codigo);
        }
        #endregion
        #region Selects
        public static List<Intercambio> Traer()
        {
            DAOIntercambio daoProxy = new DAOIntercambio();
            DataSet dtsProxy = daoProxy.TraerIntercambios();

            return CargarLista(dtsProxy.Tables[0]);
        }
       
        public static List<Intercambio> TraerXId(int codigo)
        {
            DAOIntercambio daoProxy = new DAOIntercambio();
            DataSet dtsProxy = daoProxy.TraerIntercambioXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
     
        #endregion
        #region Metodos Privados
        private static List<Intercambio> CargarLista(DataTable tabla)
        {
            List<Intercambio> lstProxy = new List<Intercambio>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Intercambio Cargar(DataRow fila)
        {
            Intercambio objProxy = new Intercambio();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Nombre = (fila["nombre"].ToString());
            return objProxy;
        }
        #endregion
    }
}
