using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace CAD.DAO
{
    public class DAODistribucionPago
    {
        public int Insertar(int clienteId, int porcentaje, bool estado, string usuarioId, DateTime fecha)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Direction = ParameterDirection.Output;
            lstParametros.Add(prmA);

            DbParameter prmBC = new SqlParameter();
            prmBC.DbType = DbType.Int32;
            prmBC.ParameterName = "@clienteId";
            prmBC.Value = clienteId;
            prmBC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBC);

            DbParameter prmBB = new SqlParameter();
            prmBB.DbType = DbType.Int32;
            prmBB.ParameterName = "@porcentaje";
            prmBB.Value = porcentaje;
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
            if (conProxy.EjecutarDML(lstParametros, "vip.DistribucionPago_Insertar"))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public int Insertar(int clienteId, int porcentaje, bool estado, string usuarioId, DateTime fecha, SqlTransaction transaccion)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Direction = ParameterDirection.Output;
            lstParametros.Add(prmA);

            DbParameter prmBC = new SqlParameter();
            prmBC.DbType = DbType.Int32;
            prmBC.ParameterName = "@clienteId";
            prmBC.Value = clienteId;
            prmBC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBC);

            DbParameter prmBB = new SqlParameter();
            prmBB.DbType = DbType.Int32;
            prmBB.ParameterName = "@porcentaje";
            prmBB.Value = porcentaje;
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
            if (conProxy.EjecutarDML(lstParametros, "vip.DistribucionPago_Insertar", transaccion))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public bool Actualizar(int id, int clienteId, int porcentaje, bool estado, string usuarioId, DateTime fecha)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmBC = new SqlParameter();
            prmBC.DbType = DbType.Int32;
            prmBC.ParameterName = "@clienteId";
            prmBC.Value = clienteId;
            prmBC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBC);

            DbParameter prmBB = new SqlParameter();
            prmBB.DbType = DbType.Int32;
            prmBB.ParameterName = "@porcentaje";
            prmBB.Value = porcentaje;
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
            return conProxy.EjecutarDML(lstParametros, "vip.DistribucionPago_Actualizar");
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
            return conProxy.EjecutarDML(lstParametros, "vip.DistribucionPago_Eliminar");
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
            return conProxy.EjecutarDML(lstParametros, "vip.DistribucionPago_Eliminar", transaccion);
        }
        public DataSet TraerDistribucionPagos()
        {
            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta("vip.DistribucionPago_Traer");
        }
        public DataSet TraerDistribucionPagoXId(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.DistribucionPago_TraerXId");
        }
        public DataSet TraerDistribucionPagoXIdCliente(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.DistribucionPago_TraerXIdCliente");
        }
        public DataSet TraerDistribucionPagoXCriterio(int porcentajeInicio, int porcentajeFin, string cliente, string empresaId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            
            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@porcentajeInicio";
            prmD.Value = porcentajeInicio;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.String;
            prmA.ParameterName = "@porcentajeFin";
            prmA.Value = porcentajeFin;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@cliente";
            prmE.Value = cliente;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.String;
            prmF.ParameterName = "@empresaId";
            prmF.Value = empresaId;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);
            
            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.DistribucionPago_TraerXCriterio");
        }
        public DataSet TraerDistribucionPagoXPendientes(string clienteId, string empresaId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            
            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@clienteId";
            prmE.Value = clienteId;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.String;
            prmF.ParameterName = "@empresaId";
            prmF.Value = empresaId;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.DistribucionPago_TraerXPendientes");
        }
        public DataSet TraerDistribucionPagoXCriterioPago(int porcentajeInicio, int porcentajeFin, string clienteId, string empresaId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@porcentajeInicio";
            prmD.Value = porcentajeInicio;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.String;
            prmA.ParameterName = "@porcentajeFin";
            prmA.Value = porcentajeFin;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@clienteId";
            prmE.Value = clienteId;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.String;
            prmF.ParameterName = "@empresaId";
            prmF.Value = empresaId;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.DistribucionPago_TraerXCriterioPago");
        }
    }
}
