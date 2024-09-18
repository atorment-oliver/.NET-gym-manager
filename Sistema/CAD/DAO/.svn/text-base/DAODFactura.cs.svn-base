using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.DAO
{
    public class DAODFactura
    {
        public int Insertar(int factura_id, int producto_id, int cantidad, SqlTransaction transaccion)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@codigo";
            prmA.Direction = ParameterDirection.Output;
            lstParametros.Add(prmA);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.Int32;
            prmB.ParameterName = "@factura_id";
            prmB.Value = factura_id;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.Int32;
            prmC.ParameterName = "@producto_id";
            prmC.Value = producto_id;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Int32;
            prmD.ParameterName = "@cantidad";
            prmD.Value = cantidad;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "dbo.InsertDFactura", transaccion))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        //public DataSet TraerDFacturaXIdFactura(int codigo)
        //{
        //    List<DbParameter> lstParametros = new List<DbParameter>();

        //    DbParameter prmA = new SqlParameter();
        //    prmA.DbType = DbType.Int32;
        //    prmA.ParameterName = "@codigo";
        //    prmA.Value = codigo;
        //    prmA.Direction = ParameterDirection.Input;
        //    lstParametros.Add(prmA);

        //    SQLConexion conProxy = new SQLConexion();
        //    return conProxy.EjecutarConsulta(lstParametros, "dbo.TraerDFacturaXIdFactura");
        //}        
    }
}
