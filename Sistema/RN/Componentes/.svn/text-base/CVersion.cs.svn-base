using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CVersion
    {
        #region DMLS
        public static bool Insertar(RN.Entidades.Version objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.Numero))
                x.AgregarError("Ingrese el número de la versión");

            if (x.Cantidad > 0)
                throw x;

            DAOVersion daoProxy = new DAOVersion();
            return daoProxy.Insertar(objProxy.Numero, objProxy.Comentario) > 0;
        }
        #endregion
        #region Selects
        public static RN.Entidades.Version ObtenerUltimaVersion()
        {
            DAOVersion daoProxy = new DAOVersion();
            DataSet dtsProxy = daoProxy.ObtenerUltimaVersion();
            
            if (dtsProxy.Tables.Count > 0 && dtsProxy.Tables[0].Rows.Count > 0)
                return Cargar(dtsProxy.Tables[0].Rows[0]);
            return null;
        }
        #endregion
        #region Metodos Privados
        private static List<RN.Entidades.Version> CargarLista(DataTable tabla)
        {
            List<RN.Entidades.Version> lstProxy = new List<RN.Entidades.Version>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static RN.Entidades.Version Cargar(DataRow fila)
        {
            RN.Entidades.Version objProxy = new RN.Entidades.Version();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Numero = fila["version"].ToString();
            objProxy.Comentario = fila["comentario"].ToString();
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"]);
            
            return objProxy;
        }
        #endregion
    }
}
