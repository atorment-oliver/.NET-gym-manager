using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.DAO
{
    public class DAOIntercambio
    {
        public int Insertar(string nombre)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Direction = ParameterDirection.Output;
            lstParametros.Add(prmA);

            DbParameter prmBC = new SqlParameter();
            prmBC.DbType = DbType.String;
            prmBC.ParameterName = "@nombre";
            prmBC.Value = nombre;
            prmBC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBC);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.Intercambio_Insertar"))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public int Insertar(string nombre, SqlTransaction transaccion)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Direction = ParameterDirection.Output;
            lstParametros.Add(prmA);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.String;
            prmB.ParameterName = "@nombre";
            prmB.Value = nombre;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.Intercambio_Insertar", transaccion))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public bool Actualizar(int id, string nombre)
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
            prmBC.ParameterName = "@nombre";
            prmBC.Value = nombre;
            prmBC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBC);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.Intercambio_Actualizar");
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
            return conProxy.EjecutarDML(lstParametros, "vip.Intercambio_Eliminar");
        }
        
        public DataSet TraerIntercambios()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Intercambio_TraerTodos");
        }
        public DataSet TraerIntercambioXId(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Intercambio_TraerXId");
        }
    
    }
}
