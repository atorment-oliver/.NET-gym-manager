using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.OleDb;
using System.Collections.Generic;

namespace CAD
{
    public class ExcelConexion : IConexion
    {
        #region Atributos
        private string strConexion;
        #endregion 
        #region Metodos
        #region Constructor
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ExcelConexion()
        {
            string strDB = ConfigurationManager.AppSettings["DB"];
            strConexion = ConfigurationManager.ConnectionStrings["ExcelConnection"].ConnectionString;
        }
        #endregion
        #region Getters
        public DataSet EjecutarConsulta(string sql)
        {
            DataSet dtsProxy = new DataSet();
            using (OleDbConnection conProxy = new OleDbConnection(strConexion))
            {
                using (OleDbDataAdapter adaProxy = new OleDbDataAdapter(sql, conProxy))
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
            using (OleDbConnection conProxy = new OleDbConnection(strConexion))
            {
                using (OleDbDataAdapter adaProxy = new OleDbDataAdapter(sql, conProxy))
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
        public bool EjecutarDML(string sql)
        {
            using (OleDbConnection conProxy = new OleDbConnection(strConexion))
            {
                using (OleDbCommand cmdProxy = new OleDbCommand(sql, conProxy))
                {
                    conProxy.Open();
                    return cmdProxy.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool EjecutarDML(List<DbParameter> parametros, string sql)
        {
            using (OleDbConnection conProxy = new OleDbConnection(strConexion))
            {
                conProxy.Open();
                return CrearCommando(parametros, conProxy, sql).ExecuteNonQuery() > 0;
            }           
        }
        #endregion
        #region Metodos Colaboracion
        private OleDbCommand CrearCommando(List<DbParameter> parametros, OleDbConnection conProxy, string sql)
        {
            OleDbCommand cmdProxy = conProxy.CreateCommand();
            cmdProxy.CommandType = CommandType.StoredProcedure;
            cmdProxy.CommandText = sql;

            foreach (DbParameter parametro in parametros)
            {
                cmdProxy.Parameters.Add((OleDbParameter)parametro);
            }
            return cmdProxy;
        }
        #endregion
        #endregion
    }
}
