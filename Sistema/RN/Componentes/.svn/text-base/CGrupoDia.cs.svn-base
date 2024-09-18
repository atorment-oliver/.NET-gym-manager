using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CGrupoDia
    {
        #region DMLS
        public static bool Insertar(GrupoDia objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.GrupoId < 0)
                x.AgregarError("Ingrese el  Grupo");

            if (x.Cantidad > 0)
                throw x;

            DAOGrupoDia daoProxy = new DAOGrupoDia();
            return daoProxy.Insertar(objProxy.GrupoId, objProxy.DiaId) > 0;
        }
        public static bool Actualizar(GrupoDia objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOGrupoDia daoProxy = new DAOGrupoDia();
            return daoProxy.Actualizar(objProxy.Id, objProxy.GrupoId, objProxy.DiaId);
        }
        public static bool EliminarGrupoDia(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOGrupoDia daoProxy = new DAOGrupoDia();
            return daoProxy.Eliminar(codigo);
        }
        public static bool EliminarXGrupoId(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOGrupoDia daoProxy = new DAOGrupoDia();
            return daoProxy.EliminarXGrupoId(codigo);
        }
        public static bool EliminarXGrupoIdDiaId(int grupoId, int diaId)
        {
            ValidationException x = new ValidationException();
            if (grupoId <= 0)
                x.AgregarError("Ingrese el código de grupo");
            if (diaId <= 0)
                x.AgregarError("Ingrese el código de dia");

            if (x.Cantidad > 0)
                throw x;

            DAOGrupoDia daoProxy = new DAOGrupoDia();
            return daoProxy.EliminarXGrupoIdDiaId(grupoId, diaId);
        }
        #endregion
        #region Selects
        public static List<GrupoDia> Traer()
        {
            DAOGrupoDia daoProxy = new DAOGrupoDia();
            DataSet dtsProxy = daoProxy.TraerGrupoDias();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<GrupoDia> TraerXId(int codigo)
        {
            DAOGrupoDia daoProxy = new DAOGrupoDia();
            DataSet dtsProxy = daoProxy.TraerGrupoDiaXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<GrupoDia> TraerXGrupoId(int grupoId)
        {
            DAOGrupoDia daoProxy = new DAOGrupoDia();
            DataSet dtsProxy = daoProxy.TraerGrupoDiaXId(grupoId);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<GrupoDia> TraerXCriterio(string id, string grupoid, string diaid)
        {
            DAOGrupoDia daoProxy = new DAOGrupoDia();
            DataSet dtsProxy = daoProxy.TraerGrupoDiaXCriterio(id, grupoid, diaid);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<GrupoDia> TraerXGrupoIdDiaId(int grupoid, int diaid, int horarioId)
        {
            DAOGrupoDia daoProxy = new DAOGrupoDia();
            DataSet dtsProxy = daoProxy.TraerXGrupoIdDiaId(grupoid, diaid, horarioId);

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXCriterioD(string id, string grupoid, string diaid)
        {
            DAOGrupoDia daoProxy = new DAOGrupoDia();
            DataSet dtsProxy = daoProxy.TraerGrupoDiaXCriterio(id, grupoid, diaid);

            return dtsProxy.Tables[0];
        }
       
        #endregion
        #region Metodos Privados
        private static List<GrupoDia> CargarLista(DataTable tabla)
        {
            List<GrupoDia> lstProxy = new List<GrupoDia>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static GrupoDia Cargar(DataRow fila)
        {
            GrupoDia objProxy = new GrupoDia();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.GrupoId = Convert.ToInt32(fila["grupoId"].ToString());
            objProxy.DiaId = Convert.ToInt32(fila["diaId"].ToString());
            return objProxy;
        }
        #endregion
    }
}
