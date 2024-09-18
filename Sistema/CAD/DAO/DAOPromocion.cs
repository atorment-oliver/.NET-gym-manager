using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.DAO
{
    public class DAOPromocion
    {
        public int Insertar(string nombre, DateTime fechaInicio, DateTime fechaFin, decimal montoDescuento, bool estado, string usuarioId, DateTime fecha, bool mensual)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Direction = ParameterDirection.Output;
            lstParametros.Add(prmA);

            DbParameter prmBB = new SqlParameter();
            prmBB.DbType = DbType.String;
            prmBB.ParameterName = "@nombre";
            prmBB.Value = nombre;
            prmBB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBB);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.DateTime;
            prmB.ParameterName = "@fechaInicio";
            prmB.Value = fechaInicio;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.DateTime;
            prmC.ParameterName = "@fechaFin";
            prmC.Value = fechaFin;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Decimal;
            prmD.ParameterName = "@montoDescuento";
            prmD.Value = montoDescuento;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

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

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.Boolean;
            prmI.ParameterName = "@mensual";
            prmI.Value = mensual;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.Promocion_Insertar"))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public bool Actualizar(int id, string nombre, DateTime fechaInicio, DateTime fechaFin, decimal montoDescuento, bool estado, string usuarioId, DateTime fecha, bool mensual)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmBB = new SqlParameter();
            prmBB.DbType = DbType.String;
            prmBB.ParameterName = "@nombre";
            prmBB.Value = nombre;
            prmBB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmBB);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.DateTime;
            prmB.ParameterName = "@fechaInicio";
            prmB.Value = fechaInicio;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.DateTime;
            prmC.ParameterName = "@fechaFin";
            prmC.Value = fechaFin;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Decimal;
            prmD.ParameterName = "@montoDescuento";
            prmD.Value = montoDescuento;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

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

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.Boolean;
            prmI.ParameterName = "@mensual";
            prmI.Value = mensual;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.Promocion_Actualizar");
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
            return conProxy.EjecutarDML(lstParametros, "vip.Promocion_Eliminar");
        }
        public DataSet TraerPromocionXId(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Promocion_TraerXId");
        }
        public DataSet TraerPromocionXSala(int salaId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@salaId";
            prmA.Value = salaId;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Promocion_TraerXSala");
        }
        public DataSet TraerPromocionXCriterio(string fechaInicio, string fechaFin, string nombre, string estado)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.String;
            prmB.ParameterName = "@fechaInicio";
            prmB.Value = fechaInicio;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.String;
            prmC.ParameterName = "@fechaFin";
            prmC.Value = fechaFin;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@nombre";
            prmD.Value = nombre;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@estado";
            prmE.Value = estado;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Promocion_TraerXCriterio");
        }
        public DataSet TraerPromocionXCriterioHabilita()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Promocion_TraerHabilita");
        }
        public DataSet TraerPromocionXCriterioCruce(string horaInicio, string horaFin, bool finDeSemana, int salaId, bool estado)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.Int32;
            prmB.ParameterName = "@salaId";
            prmB.Value = salaId;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.String;
            prmC.ParameterName = "@horaInicio";
            prmC.Value = horaInicio;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@horaFin";
            prmD.Value = horaFin;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.Boolean;
            prmE.ParameterName = "@finDeSemana";
            prmE.Value = finDeSemana;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.Boolean;
            prmK.ParameterName = "@estado";
            prmK.Value = estado;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Promocion_TraerXCriterioCruce");
        }
        public DataSet TraerDatosTodos(DateTime fecha)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.DateTime;
            prmA.ParameterName = "@fecha";
            prmA.Value = fecha;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Promocion_TraerDatosTodos");
        }
    }
}
