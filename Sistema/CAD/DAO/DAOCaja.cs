using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.DAO
{
    public class DAOCaja
    {
        public int Insertar(string cajeroId, DateTime fechaCreacion, bool estado, int numero)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Direction = ParameterDirection.Output;
            lstParametros.Add(prmA);

            DbParameter prmBC = new SqlParameter();
            prmBC.DbType = DbType.String;
            prmBC.ParameterName = "@cajeroId";
            prmBC.Value = cajeroId;
            prmBC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBC);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.DateTime;
            prmB.ParameterName = "@fechaCreacion";
            prmB.Value = fechaCreacion;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);
            
            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Int32;
            prmD.ParameterName = "@numero";
            prmD.Value = numero;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.Boolean;
            prmK.ParameterName = "@estado";
            prmK.Value = estado;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.Caja_Insertar"))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public int Insertar(string nombre, SqlTransaction transaccion)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@codigo";
            prmA.Direction = ParameterDirection.Output;
            lstParametros.Add(prmA);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.String;
            prmB.ParameterName = "@nombre";
            prmB.Value = nombre;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "dbo.InsertCaja", transaccion))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public bool Actualizar(int id, string cajeroId, DateTime fechaCreacion, bool estado, int numero)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmBC = new SqlParameter();
            prmBC.DbType = DbType.String;
            prmBC.ParameterName = "@cajeroId";
            prmBC.Value = cajeroId;
            prmBC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBC);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.DateTime;
            prmB.ParameterName = "@fechaCreacion";
            prmB.Value = fechaCreacion;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.Boolean;
            prmK.ParameterName = "@estado";
            prmK.Value = estado;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            DbParameter prmL = new SqlParameter();
            prmL.DbType = DbType.Int32;
            prmL.ParameterName = "@numero";
            prmL.Value = numero;
            prmL.Direction = ParameterDirection.Input;
            lstParametros.Add(prmL);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.Caja_Actualizar");
        }
        public bool Actualizar(int id, bool estado)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.Boolean;
            prmK.ParameterName = "@estado";
            prmK.Value = estado;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.Caja_Cerrar");
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
            return conProxy.EjecutarDML(lstParametros, "vip.Caja_Eliminar");
        }
        public DataSet TraerUltimoId()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Caja_TraerUltimoID");
        }
        public DataSet TraerCajas()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Caja_TraerTodos");
        }
        public DataSet TraerCajaXId(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Caja_TraerXId");
        }
        public DataSet TraerCajaXCriterio(string numero, string cajeroId, string estado)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.String;
            prmA.ParameterName = "@numero";
            prmA.Value = numero;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.String;
            prmC.ParameterName = "@cajeroId";
            prmC.Value = cajeroId;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@estado";
            prmE.Value = estado;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Caja_TraerXCriterio");
        }
        public DataSet EstaAbierto(string cajeroId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.String;
            prmA.ParameterName = "@cajeroId";
            prmA.Value = cajeroId;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Caja_EstaAbierto");
        }
        public DataSet UltimaCaja(string cajeroId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.String;
            prmA.ParameterName = "@cajeroId";
            prmA.Value = cajeroId;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Caja_UltimaCaja");
        }
        public DataSet EstaAsignada(string cajeroId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.String;
            prmA.ParameterName = "@cajeroId";
            prmA.Value = cajeroId;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Caja_EstaAsignada");
        }
    }
}
