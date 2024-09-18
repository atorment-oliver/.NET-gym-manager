using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CEmpresaPaquete
    {
        #region DMLS
        public static bool Insertar(EmpresaPaquete objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.EmpresaId < 0)
                x.AgregarError("Ingrese la empresa");

            if (objProxy.PaqueteId < 0)
                x.AgregarError("Ingrese el paquete");

            if (x.Cantidad > 0)
                throw x;

            DAOEmpresaPaquete daoProxy = new DAOEmpresaPaquete();
            return daoProxy.Insertar(objProxy.EmpresaId, objProxy.PaqueteId) > 0;
        }
        public static bool Actualizar(EmpresaPaquete objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Costo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOEmpresaPaquete daoProxy = new DAOEmpresaPaquete();
            return daoProxy.Actualizar(objProxy.EmpresaId, objProxy.PaqueteId, objProxy.Costo);
        }
        public static bool EliminarEmpresaPaquete(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOEmpresaPaquete daoProxy = new DAOEmpresaPaquete();
            return daoProxy.Eliminar(codigo);
        }
        public static bool EliminarXGrupoId(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOEmpresaPaquete daoProxy = new DAOEmpresaPaquete();
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

            DAOEmpresaPaquete daoProxy = new DAOEmpresaPaquete();
            return daoProxy.EliminarXGrupoIdDiaId(grupoId, diaId);
        }
        #endregion
        #region Selects
        public static List<EmpresaPaquete> Traer()
        {
            DAOEmpresaPaquete daoProxy = new DAOEmpresaPaquete();
            DataSet dtsProxy = daoProxy.TraerEmpresaPaquetes();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<EmpresaPaquete> TraerXId(int codigo)
        {
            DAOEmpresaPaquete daoProxy = new DAOEmpresaPaquete();
            DataSet dtsProxy = daoProxy.TraerEmpresaPaqueteXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<EmpresaPaquete> TraerXGrupoId(int grupoId)
        {
            DAOEmpresaPaquete daoProxy = new DAOEmpresaPaquete();
            DataSet dtsProxy = daoProxy.TraerEmpresaPaqueteXId(grupoId);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<EmpresaPaquete> TraerXCriterio(string id, string grupoid, string diaid)
        {
            DAOEmpresaPaquete daoProxy = new DAOEmpresaPaquete();
            DataSet dtsProxy = daoProxy.TraerEmpresaPaqueteXCriterio(id, grupoid, diaid);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<EmpresaPaquete> TraerXGrupoIdDiaId(int grupoid, int diaid, int horarioId)
        {
            DAOEmpresaPaquete daoProxy = new DAOEmpresaPaquete();
            DataSet dtsProxy = daoProxy.TraerXGrupoIdDiaId(grupoid, diaid, horarioId);

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXCriterioD(string id, string grupoid, string diaid)
        {
            DAOEmpresaPaquete daoProxy = new DAOEmpresaPaquete();
            DataSet dtsProxy = daoProxy.TraerEmpresaPaqueteXCriterio(id, grupoid, diaid);

            return dtsProxy.Tables[0];
        }
        public static DataTable TraerXEmpresaId(string id)
        {
            DAOEmpresaPaquete daoProxy = new DAOEmpresaPaquete();
            DataSet dtsProxy = daoProxy.TraerXEmpresaId(id);

            return dtsProxy.Tables[0];
        }
        #endregion
        #region Metodos Privados
        private static List<EmpresaPaquete> CargarLista(DataTable tabla)
        {
            List<EmpresaPaquete> lstProxy = new List<EmpresaPaquete>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static EmpresaPaquete Cargar(DataRow fila)
        {
            EmpresaPaquete objProxy = new EmpresaPaquete();
            objProxy.Costo = Convert.ToDecimal(fila["costo"].ToString());
            objProxy.EmpresaId = Convert.ToInt32(fila["EmpresaId"].ToString());
            objProxy.PaqueteId = Convert.ToInt32(fila["PaqueteId"].ToString());
            return objProxy;
        }
        #endregion
    }
}
