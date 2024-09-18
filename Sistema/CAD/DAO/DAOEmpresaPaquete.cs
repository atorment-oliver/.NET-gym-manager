using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.DAO
{
    public class DAOEmpresaPaquete
    {
        public int Insertar(int empresaId, int paqueteId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Direction = ParameterDirection.Output;
            lstParametros.Add(prmA);

            DbParameter prmBB = new SqlParameter();
            prmBB.DbType = DbType.Int32;
            prmBB.ParameterName = "@empresaId";
            prmBB.Value = empresaId;
            prmBB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBB);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.Int32;
            prmB.ParameterName = "@paqueteId";
            prmB.Value = paqueteId;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.EmpresaPaquete_Insertar"))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public bool Insertar(int empresaId, int paqueteId, decimal costo, SqlTransaction transaccion)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmBB = new SqlParameter();
            prmBB.DbType = DbType.Int32;
            prmBB.ParameterName = "@empresaId";
            prmBB.Value = empresaId;
            prmBB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBB);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.Int32;
            prmB.ParameterName = "@paqueteId";
            prmB.Value = paqueteId;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.Decimal;
            prmC.ParameterName = "@costo";
            prmC.Value = costo;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.EmpresaPaquete_Insertar", transaccion))
                return true;
            return false;

        }
        public bool Actualizar(int empresaId, int paqueteId, decimal costo)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmBB = new SqlParameter();
            prmBB.DbType = DbType.Int32;
            prmBB.ParameterName = "@empresaId";
            prmBB.Value = empresaId;
            prmBB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBB);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.Int32;
            prmB.ParameterName = "@paqueteId";
            prmB.Value = paqueteId;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.Decimal;
            prmC.ParameterName = "@costo";
            prmC.Value = costo;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.EmpresaPaquete_Actualizar");
        }
        public bool Actualizar(int empresaId, int paqueteId, decimal costo, SqlTransaction transaccion)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmBB = new SqlParameter();
            prmBB.DbType = DbType.Int32;
            prmBB.ParameterName = "@empresaId";
            prmBB.Value = empresaId;
            prmBB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBB);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.Int32;
            prmB.ParameterName = "@paqueteId";
            prmB.Value = paqueteId;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.Decimal;
            prmC.ParameterName = "@costo";
            prmC.Value = costo;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.EmpresaPaquete_Actualizar", transaccion);
        }
        public bool Eliminar(int codigo)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@Id";
            prmA.Value = codigo;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.EmpresaPaquete_Eliminar");
        }
        public bool EliminarXGrupoId(int codigo)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@Id";
            prmA.Value = codigo;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.EmpresaPaquete_EliminarGrupoId");
        }
        public bool EliminarXGrupoId(int codigo, SqlTransaction transaccion)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@Id";
            prmA.Value = codigo;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.EmpresaPaquete_EliminarGrupoId", transaccion);
        }
        public bool EliminarXGrupoIdDiaId(int grupoId, int diaId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmBB = new SqlParameter();
            prmBB.DbType = DbType.Int32;
            prmBB.ParameterName = "@grupoId";
            prmBB.Value = grupoId;
            prmBB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBB);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.Int32;
            prmB.ParameterName = "@diaId";
            prmB.Value = diaId;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.EmpresaPaquete_EliminarXGrupoIdDiaId");
        }
        public DataSet TraerEmpresaPaquetes()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.EmpresaPaquete_TraerTodos");
        }
        public DataSet TraerEmpresaPaqueteXId(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@grupoId";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.EmpresaPaquete_TraerXGrupoId");
        }
        public DataSet TraerEmpresaPaqueteXGrupoId(int grupoId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@grupoId";
            prmA.Value = grupoId;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.EmpresaPaquete_TraerXGrupoId");
        }
        public DataSet TraerEmpresaPaqueteXCriterio(string nombre, string grupoId, string diaId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.String;
            prmA.ParameterName = "@nombre";
            prmA.Value = nombre;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.String;
            prmC.ParameterName = "@grupoId";
            prmC.Value = grupoId;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@diaId";
            prmE.Value = diaId;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.EmpresaPaquete_TraerXCriterio");
        }
        public DataSet TraerXEmpresaId(string id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.String;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.EmpresaPaquete_TraerXEmpresaId");
        }
        public DataSet TraerXGrupoIdDiaId(int grupoid, int diaid, int horarioId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@grupoId";
            prmA.Value = grupoid;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.Int32;
            prmC.ParameterName = "@diaId";
            prmC.Value = diaid;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.Int32;
            prmE.ParameterName = "@horarioId";
            prmE.Value = horarioId;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.EmpresaPaquete_TraerXGrupoIdDiaId");
        }

    }
}
