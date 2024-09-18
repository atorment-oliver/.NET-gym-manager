using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.DAO
{
    public class DAOVersion
    {
        public int Insertar(string version, string comentario)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Direction = ParameterDirection.Output;
            lstParametros.Add(prmA);

            DbParameter prmBB = new SqlParameter();
            prmBB.DbType = DbType.String;
            prmBB.ParameterName = "@version";
            prmBB.Value = version;
            prmBB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBB);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.String;
            prmK.ParameterName = "@comentario";
            prmK.Value = comentario;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.Version_Insertar"))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public DataSet ObtenerUltimaVersion()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Version_ObtenerUltimaVersion");
        }
    }
}