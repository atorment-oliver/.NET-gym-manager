using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RN.Entidades;
using CAD.DAO;
using System.Data;

namespace RN.Componentes
{
    public class CParametro
    {
        #region DMLS
        public static bool Insertar(Parametro objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre");

            if (string.IsNullOrEmpty(objProxy.Valor))
                x.AgregarError("Ingrese el valor");

            if (x.Cantidad > 0)
                throw x;

            DAOParametro daoProxy = new DAOParametro();
            return daoProxy.Insertar(objProxy.Nombre, objProxy.Valor, objProxy.Visible, objProxy.Usuario, objProxy.Fecha, objProxy.Estado) > 0;
        }
        public static bool Actualizar(Parametro objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.Id))
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOParametro daoProxy = new DAOParametro();
            return daoProxy.Actualizar(objProxy.Id, objProxy.Nombre, objProxy.Valor, objProxy.Visible, objProxy.Usuario, objProxy.Fecha, objProxy.Estado);
        }
        public static bool EliminarParametro(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOParametro daoProxy = new DAOParametro();
            return daoProxy.Eliminar(codigo);
        }
        #endregion
        #region Selects
        public static List<Parametro> Traer()
        {
            DAOParametro daoProxy = new DAOParametro();
            DataSet dtsProxy = daoProxy.TraerParametro();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Parametro> TraerXId(string codigo)
        {
            DAOParametro daoProxy = new DAOParametro();
            DataSet dtsProxy = daoProxy.TraerParametroXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Parametro> TraerXCriterio(string numero, string cajeroId, string estado)
        {
            DAOParametro daoProxy = new DAOParametro();
            DataSet dtsProxy = daoProxy.TraerParametroXCriterio(numero, cajeroId, estado);

            if (dtsProxy.Tables.Count > 0)
                return CargarLista(dtsProxy.Tables[0]);

            return null;
        }
        public static DataTable TraerXCriterioD(string numero, string cajeroId, string estado)
        {
            DAOParametro daoProxy = new DAOParametro();
            DataSet dtsProxy = daoProxy.TraerParametroXCriterio(numero, cajeroId, estado);


            return dtsProxy.Tables[0];
        }
        
        #endregion
        #region Metodos Privados
        private static List<Parametro> CargarLista(DataTable tabla)
        {
            List<Parametro> lstProxy = new List<Parametro>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Parametro Cargar(DataRow fila)
        {
            Parametro objProxy = new Parametro();
            objProxy.Id = (fila["id"]).ToString();
            objProxy.Nombre = (fila["nombre"].ToString());
            objProxy.Valor = (fila["valor"].ToString());
            objProxy.Visible = Convert.ToBoolean(fila["visible"].ToString());
            objProxy.Usuario = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());

            return objProxy;
        }
        #endregion
    }
}
