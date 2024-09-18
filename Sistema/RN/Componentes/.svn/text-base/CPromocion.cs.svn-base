using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CPromocion
    {
        #region DMLS
        public static bool Insertar(Promocion objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.MontoDescuento < 0)
                x.AgregarError("Ingrese un monto");

            if (x.Cantidad > 0)
                throw x;

            DAOPromocion daoProxy = new DAOPromocion();
            return daoProxy.Insertar(objProxy.Nombre, objProxy.FechaInicio, objProxy.FechaFin, objProxy.MontoDescuento, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha, objProxy.Mensual) > 0;
        }
        public static bool Actualizar(Promocion objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOPromocion daoProxy = new DAOPromocion();
            return daoProxy.Actualizar(objProxy.Id, objProxy.Nombre, objProxy.FechaInicio, objProxy.FechaFin, objProxy.MontoDescuento, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha, objProxy.Mensual);
        }
       
        public static bool EliminarPromocion(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOPromocion daoProxy = new DAOPromocion();
            return daoProxy.Eliminar(codigo);
        }
        #endregion
        #region Selects
        
        public static List<Promocion> TraerXId(int codigo)
        {
            DAOPromocion daoProxy = new DAOPromocion();
            DataSet dtsProxy = daoProxy.TraerPromocionXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Promocion> TraerXCriterio(string fechaInicio, string fechaFin, string usuarioId, string estado)
        {
            DAOPromocion daoProxy = new DAOPromocion();
            DataSet dtsProxy = daoProxy.TraerPromocionXCriterio(fechaInicio, fechaFin, usuarioId, estado);

            if (dtsProxy.Tables.Count > 0)
                return CargarLista(dtsProxy.Tables[0]);

            return null;
        }
        public static DataTable TraerXCriterioD(string fechaInicio, string fechaFin, string usuarioId, string estado)
        {
            DAOPromocion daoProxy = new DAOPromocion();
            DataSet dtsProxy = daoProxy.TraerPromocionXCriterio(fechaInicio, fechaFin, usuarioId, estado);


            return dtsProxy.Tables[0];
        }
	public static DataTable TraerDatosTodos(DateTime fecha)
        {
            DAOPromocion daoProxy = new DAOPromocion();
            DataSet dtsProxy = daoProxy.TraerDatosTodos(fecha);
            return dtsProxy.Tables[0];
        }
        public static DataTable TraerHabiles()
        {
            DAOPromocion daoProxy = new DAOPromocion();
            DataSet dtsProxy = daoProxy.TraerPromocionXCriterioHabilita();


            return dtsProxy.Tables[0];
        }
       
        #endregion
        #region Metodos Privados
        private static List<Promocion> CargarLista(DataTable tabla)
        {
            List<Promocion> lstProxy = new List<Promocion>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Promocion Cargar(DataRow fila)
        {
            Promocion objProxy = new Promocion();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Nombre = (fila["nombre"].ToString());
            objProxy.FechaInicio = Convert.ToDateTime(fila["fechaInicio"].ToString());
            objProxy.FechaInicio = Convert.ToDateTime(fila["fechaInicio"].ToString());
            objProxy.FechaFin = Convert.ToDateTime(fila["fechaFin"].ToString());
            objProxy.MontoDescuento = Convert.ToDecimal(fila["montoDescuento"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.Mensual = Convert.ToBoolean(fila["mensual"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());

            return objProxy;
        }
        #endregion
    }
}
