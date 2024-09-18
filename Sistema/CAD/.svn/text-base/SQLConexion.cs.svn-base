using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD
{
    public class SQLConexion : IConexion
    {
        #region Atributos
        private string strConexion;
        #endregion 
        #region Metodos
        #region Constructor
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public SQLConexion()
        {
            string strDB = ConfigurationManager.AppSettings["DB"];
            strConexion = ConfigurationManager.ConnectionStrings[strDB].ConnectionString;
        }
        public SQLConexion(string ConnStrConfig)
        {
            strConexion = ConnStrConfig;
        }
        #endregion
        #region Getters
        public DataSet EjecutarConsulta(string sql)
        {
            DataSet dtsProxy = new DataSet();
            using (SqlConnection conProxy = new SqlConnection(strConexion))
            {
                using (SqlDataAdapter adaProxy = new SqlDataAdapter(sql, conProxy))
                {
                    conProxy.Open();
                    adaProxy.Fill(dtsProxy);
                    return dtsProxy;
                }                    
            }
        }
        public DataSet EjecutarConsulta(List<DbParameter> parametros, string sql)
        {
            DataSet dtsProxy = new DataSet();
            using (SqlConnection conProxy = new SqlConnection(strConexion))
            {
                using (SqlDataAdapter adaProxy = new SqlDataAdapter())
                {
                    adaProxy.SelectCommand = CrearCommando(parametros, conProxy, sql);
                    conProxy.Open();
                    adaProxy.Fill(dtsProxy);
                    return dtsProxy;
                }
            }            
        }        
        #endregion
        #region DML
        /// <summary>
        /// Creación de una transacción y apertura de la conexión.
        /// </summary>
        /// <returns>Transacción activa</returns>
        public SqlTransaction IniciarTransaccion()
        {
            SqlConnection conProxy = new SqlConnection(strConexion);
            try
            {
                conProxy.Open();
                SqlTransaction trnProxy = conProxy.BeginTransaction();
                return trnProxy;
            }
            catch (Exception x)
            {
                throw x;
            }            
        }
        public bool EjecutarDML(string sql)
        {
            using (SqlConnection conProxy = new SqlConnection(strConexion))
            {
                using (SqlCommand cmdProxy = new SqlCommand(sql, conProxy))
                {
                    conProxy.Open();
                    return cmdProxy.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool EjecutarDML(List<DbParameter> parametros, string sql)
        {
            using (SqlConnection conProxy = new SqlConnection(strConexion))
            {
                conProxy.Open();
                return CrearCommando(parametros, conProxy, sql).ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// Ejecutar DML transaccional
        /// </summary>
        /// <param name="parametros">Lisat de parametros para el SP</param>
        /// <param name="sql">Nombre del SP a ejecutar</param>
        /// <param name="transaccion">Transaccion</param>
        /// <returns>Resultado de la operación DML</returns>
        public bool EjecutarDML(List<DbParameter> parametros, string sql, SqlTransaction transaccion)
        {
            return CrearCommando(parametros, sql, transaccion).ExecuteNonQuery() > 0;
        }
        #endregion
        #region Metodos Colaboracion
        private SqlCommand CrearCommando(List<DbParameter> parametros, SqlConnection conProxy, string sql)
        {
            SqlCommand cmdProxy = conProxy.CreateCommand();
            cmdProxy.CommandType = CommandType.StoredProcedure;
            cmdProxy.CommandText = sql;

            foreach (DbParameter parametro in parametros)
            {
                cmdProxy.Parameters.Add((SqlParameter)parametro);
            }
            return cmdProxy;
        }
        /// <summary>
        /// Crear comando transaccional
        /// </summary>
        /// <param name="parametros">Lista de parametros para el SP</param>
        /// <param name="sql">Nombre del SP a ejecutar</param>
        /// <param name="transaccion">Transacción</param>
        /// <returns>Comando</returns>
        private SqlCommand CrearCommando(List<DbParameter> parametros, string sql, SqlTransaction transaccion)
        {
            SqlCommand cmdProxy = transaccion.Connection.CreateCommand();
            cmdProxy.CommandType = CommandType.StoredProcedure;
            cmdProxy.Transaction = transaccion;
            cmdProxy.CommandText = sql;

            foreach (DbParameter parametro in parametros)
            {
                cmdProxy.Parameters.Add((SqlParameter)parametro);
            }
            return cmdProxy;
        }
        #endregion
        #endregion
    }
}
