using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CServicio
    {
        #region DMLS
        public static bool Insertar(Servicio objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre del Servicio");

            if (x.Cantidad > 0)
                throw x;

            DAOServicio daoProxy = new DAOServicio();
            return daoProxy.Insertar(objProxy.Nombre, objProxy.RestriccionHorario, objProxy.Cupo, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha) > 0;
        }
        public static int InsertarCodigo(Servicio objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre del Servicio");

            if (x.Cantidad > 0)
                throw x;

            DAOServicio daoProxy = new DAOServicio();
            return daoProxy.Insertar(objProxy.Nombre, objProxy.RestriccionHorario, objProxy.Cupo, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha);
        }
        public static bool Actualizar(Servicio objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre");

            if (x.Cantidad > 0)
                throw x;

            DAOServicio daoProxy = new DAOServicio();
            return daoProxy.Actualizar(objProxy.Id, objProxy.Nombre, objProxy.RestriccionHorario, objProxy.Cupo, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha);
        }
        public static bool EliminarServicio(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOServicio daoProxy = new DAOServicio();
            return daoProxy.Eliminar(codigo);
        }

        #endregion
        #region Selects
        public static List<Servicio> Traer()
        {
            DAOServicio daoProxy = new DAOServicio();
            DataSet dtsProxy = daoProxy.TraerServicios();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Servicio> TraerXId(int codigo)
        {
            DAOServicio daoProxy = new DAOServicio();
            DataSet dtsProxy = daoProxy.TraerServicioXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Servicio> TraerXCriterio(string nombre, string restriccionHorario, string estado)
        {
            DAOServicio daoProxy = new DAOServicio();
            DataSet dtsProxy = daoProxy.TraerServicioXCriterio(nombre, restriccionHorario, estado);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXCriterioD(string nombre, string restriccionHorario, string estado)
        {
            DAOServicio daoProxy = new DAOServicio();
            DataSet dtsProxy = daoProxy.TraerServicioXCriterio(nombre, restriccionHorario, estado);


            return dtsProxy.Tables[0];
        }
        public static bool EstaAsignado(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");
            DAOServicio daoProxy = new DAOServicio();
            DataSet dtsProxy = daoProxy.EstaAsignado(codigo);
            if (dtsProxy.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }
        #endregion
        #region Metodos Privados
        private static List<Servicio> CargarLista(DataTable tabla)
        {
            List<Servicio> lstProxy = new List<Servicio>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Servicio Cargar(DataRow fila)
        {
            Servicio objProxy = new Servicio();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Nombre = fila["nombre"].ToString();
            objProxy.RestriccionHorario = Convert.ToBoolean(fila["restriccionHorario"].ToString());
            if(fila["cupo"].ToString()== "")
                objProxy.Cupo = 0;
            else
                objProxy.Cupo = Convert.ToInt32(fila["cupo"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());

            return objProxy;
        }
        #endregion
    }
}
