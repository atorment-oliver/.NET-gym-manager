using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CPaquete
    {
        #region DMLS
        public static bool Insertar(Paquete objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre del Paquete");

            if (x.Cantidad > 0)
                throw x;

            DAOPaquete daoProxy = new DAOPaquete();
            return daoProxy.Insertar(objProxy.Nombre, objProxy.UnidadId, objProxy.Tiempo, objProxy.TipoPaqueteId, objProxy.Precio, objProxy.DiasValidez, objProxy.FechaRegistro, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha) > 0;
        }
        public static bool Actualizar(Paquete objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre");

            if (x.Cantidad > 0)
                throw x;

            DAOPaquete daoProxy = new DAOPaquete();
            return daoProxy.Actualizar(objProxy.Id, objProxy.Nombre, objProxy.UnidadId, objProxy.Tiempo, objProxy.TipoPaqueteId, objProxy.Precio, objProxy.DiasValidez, objProxy.FechaRegistro, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha);
        }
        public static bool EliminarPaquete(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOPaquete daoProxy = new DAOPaquete();
            return daoProxy.Eliminar(codigo);
        }
        
        #endregion
        #region Selects
        public static List<Paquete> Traer()
        {
            DAOPaquete daoProxy = new DAOPaquete();
            DataSet dtsProxy = daoProxy.TraerPaquetes();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Paquete> TraerXId(int codigo)
        {
            DAOPaquete daoProxy = new DAOPaquete();
            DataSet dtsProxy = daoProxy.TraerPaqueteXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Paquete> TraerXCriterio(string nombre, string tipoPaqueteId, string estado)
        {
            DAOPaquete daoProxy = new DAOPaquete();
            DataSet dtsProxy = daoProxy.TraerPaqueteXCriterio(nombre, tipoPaqueteId, estado);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXCriterioD(string nombre, string tipoPaqueteId, string estado)
        {
            DAOPaquete daoProxy = new DAOPaquete();
            DataSet dtsProxy = daoProxy.TraerPaqueteXCriterio(nombre, tipoPaqueteId, estado);


            return dtsProxy.Tables[0];
        }
        public static DataTable TraerSinAdicional(string id)
        {
            DAOPaquete daoProxy = new DAOPaquete();
            DataSet dtsProxy = daoProxy.TraerSinAdicional(id);


            return dtsProxy.Tables[0];
        }
        public static DataTable TraerSinAdicional2(string id)
        {
            DAOPaquete daoProxy = new DAOPaquete();
            DataSet dtsProxy = daoProxy.TraerSinAdicional2(id);


            return dtsProxy.Tables[0];
        }
        public static DataTable TraerPaqueteAdicional(string id)
        {
            DAOPaquete daoProxy = new DAOPaquete();
            DataSet dtsProxy = daoProxy.TraerPaqueteAdicional(id);


            return dtsProxy.Tables[0];
        }
        public static DataTable TraerPaqueteAdicionalPadre(string id)
        {
            DAOPaquete daoProxy = new DAOPaquete();
            DataSet dtsProxy = daoProxy.TraerPaqueteAdicionalPadre(id);


            return dtsProxy.Tables[0];
        }
        public static bool EstaAsignado(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");
            DAOPaquete daoProxy = new DAOPaquete();
            DataSet dtsProxy = daoProxy.EstaAsignado(codigo);
            if (dtsProxy.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }
        #endregion
        #region Metodos Privados
        private static List<Paquete> CargarLista(DataTable tabla)
        {
            List<Paquete> lstProxy = new List<Paquete>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Paquete Cargar(DataRow fila)
        {
            Paquete objProxy = new Paquete();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Nombre = fila["nombre"].ToString();
            objProxy.UnidadId = Convert.ToInt32(fila["unidadId"].ToString());
            objProxy.Tiempo = Convert.ToInt32(fila["tiempo"].ToString());
            objProxy.TipoPaqueteId = Convert.ToInt32(fila["tipoPaqueteId"].ToString());
            objProxy.Precio = Convert.ToDouble(fila["precio"].ToString());
            objProxy.DiasValidez = fila["diasValidez"].ToString();
            objProxy.FechaRegistro = Convert.ToDateTime(fila["fechaRegistro"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());

            return objProxy;
        }
        #endregion
    }
}
