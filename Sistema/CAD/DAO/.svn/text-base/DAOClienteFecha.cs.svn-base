using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace CAD.DAO
{
    public class DAOClienteFecha
    {
        public bool Insertar(int clienteId, DateTime fechaInicio, bool estado, string usuarioId, DateTime fecha)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmBC = new SqlParameter();
            prmBC.DbType = DbType.Int32;
            prmBC.ParameterName = "@clienteId";
            prmBC.Value = clienteId;
            prmBC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBC);

            DbParameter prmBB = new SqlParameter();
            prmBB.DbType = DbType.DateTime;
            prmBB.ParameterName = "@fechaInicio";
            prmBB.Value = fechaInicio;
            prmBB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBB);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@usuarioId";
            prmE.Value = usuarioId;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.Boolean;
            prmK.ParameterName = "@estado";
            prmK.Value = estado;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            DbParameter prmL = new SqlParameter();
            prmL.DbType = DbType.DateTime;
            prmL.ParameterName = "@fecha";
            prmL.Value = fecha;
            prmL.Direction = ParameterDirection.Input;
            lstParametros.Add(prmL);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.ClienteFecha_Insertar"))
                return true;
            else
                return false;

        }
        public bool Insertar(int clienteId, DateTime fechaInicio, bool estado, string usuarioId, DateTime fecha, SqlTransaction transaccion)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmBC = new SqlParameter();
            prmBC.DbType = DbType.Int32;
            prmBC.ParameterName = "@clienteId";
            prmBC.Value = clienteId;
            prmBC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBC);

            DbParameter prmBB = new SqlParameter();
            prmBB.DbType = DbType.DateTime;
            prmBB.ParameterName = "@fechaInicio";
            prmBB.Value = fechaInicio;
            prmBB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBB);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@usuarioId";
            prmE.Value = usuarioId;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.Boolean;
            prmK.ParameterName = "@estado";
            prmK.Value = estado;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            DbParameter prmL = new SqlParameter();
            prmL.DbType = DbType.DateTime;
            prmL.ParameterName = "@fecha";
            prmL.Value = fecha;
            prmL.Direction = ParameterDirection.Input;
            lstParametros.Add(prmL);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.ClienteFecha_Insertar", transaccion))
                return true;
            else
                return false;

        }
        public bool Actualizar(int clienteId, DateTime fechaInicio, bool estado, string usuarioId, DateTime fecha)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmBC = new SqlParameter();
            prmBC.DbType = DbType.Int32;
            prmBC.ParameterName = "@clienteId";
            prmBC.Value = clienteId;
            prmBC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBC);

            DbParameter prmBB = new SqlParameter();
            prmBB.DbType = DbType.DateTime;
            prmBB.ParameterName = "@fechaInicio";
            prmBB.Value = fechaInicio;
            prmBB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBB);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@usuarioId";
            prmE.Value = usuarioId;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.Boolean;
            prmK.ParameterName = "@estado";
            prmK.Value = estado;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            DbParameter prmL = new SqlParameter();
            prmL.DbType = DbType.DateTime;
            prmL.ParameterName = "@fecha";
            prmL.Value = fecha;
            prmL.Direction = ParameterDirection.Input;
            lstParametros.Add(prmL);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.ClienteFecha_Actualizar");
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
            return conProxy.EjecutarDML(lstParametros, "vip.ClienteFecha_Eliminar");
        }
        public bool Eliminar(int codigo, SqlTransaction transaccion)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@Id";
            prmA.Value = codigo;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.ClienteFecha_Eliminar", transaccion);
        }
        public DataSet TraerClienteFechas()
        {
            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta("vip.ClienteFecha_Traer");
        }
        public DataSet TraerClienteFechaXId(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.ClienteFecha_TraerXId");
        }
        public DataSet TraerClienteFechaXIdCliente(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.ClienteFecha_TraerXIdCliente");
        }
    }
}
