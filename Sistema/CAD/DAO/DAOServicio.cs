using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.DAO
{
    public class DAOServicio
    {
        public int Insertar(string nombre, bool restriccionHorario, int cupo, bool estado, string usuarioId, DateTime fecha)
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

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.Boolean;
            prmC.ParameterName = "@restriccionHorario";
            prmC.Value = restriccionHorario;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Int32;
            prmD.ParameterName = "@cupo";
            prmD.Value = cupo;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.Boolean;
            prmI.ParameterName = "@estado";
            prmI.Value = estado;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.String;
            prmJ.ParameterName = "@usuarioId";
            prmJ.Value = usuarioId;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.DateTime;
            prmK.ParameterName = "@fecha";
            prmK.Value = fecha;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.Servicio_Insertar"))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public int Insertar(string nombre, bool restriccionHorario, int cupo, bool estado, string usuarioId, DateTime fecha, SqlTransaction transaccion)
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

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.Boolean;
            prmC.ParameterName = "@restriccionHorario";
            prmC.Value = restriccionHorario;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Int32;
            prmD.ParameterName = "@cupo";
            prmD.Value = cupo;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.Boolean;
            prmI.ParameterName = "@estado";
            prmI.Value = estado;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.String;
            prmJ.ParameterName = "@usuarioId";
            prmJ.Value = usuarioId;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.DateTime;
            prmK.ParameterName = "@fecha";
            prmK.Value = fecha;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.Servicio_Insertar", transaccion))
                return Convert.ToInt32(prmA.Value);
            return -1;
        }
        public bool Actualizar(int id, string nombre, bool restriccionHorario, int cupo, bool estado, string usuarioId, DateTime fecha)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.String;
            prmB.ParameterName = "@nombre";
            prmB.Value = nombre;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.Boolean;
            prmC.ParameterName = "@restriccionHorario";
            prmC.Value = restriccionHorario;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Int32;
            prmD.ParameterName = "@cupo";
            prmD.Value = cupo;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.Boolean;
            prmI.ParameterName = "@estado";
            prmI.Value = estado;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.String;
            prmJ.ParameterName = "@usuarioId";
            prmJ.Value = usuarioId;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.DateTime;
            prmK.ParameterName = "@fecha";
            prmK.Value = fecha;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.Servicio_Actualizar");
        }
        public bool Actualizar(int id, string nombre, bool restriccionHorario, int cupo, bool estado, string usuarioId, DateTime fecha, SqlTransaction transaccion)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.String;
            prmB.ParameterName = "@nombre";
            prmB.Value = nombre;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.Boolean;
            prmC.ParameterName = "@restriccionHorario";
            prmC.Value = restriccionHorario;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Int32;
            prmD.ParameterName = "@cupo";
            prmD.Value = cupo;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.Boolean;
            prmI.ParameterName = "@estado";
            prmI.Value = estado;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.String;
            prmJ.ParameterName = "@usuarioId";
            prmJ.Value = usuarioId;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.DateTime;
            prmK.ParameterName = "@fecha";
            prmK.Value = fecha;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.Servicio_Actualizar", transaccion);
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
            return conProxy.EjecutarDML(lstParametros, "vip.Servicio_Eliminar");
        }
        public DataSet EstaAsignado(int codigo)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@Id";
            prmA.Value = codigo;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Servicio_AsignadoACliente");
        }
        public DataSet TraerServicios()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Servicio_TraerTodos");
        }
        public DataSet TraerServicioXId(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Servicio_TraerXId");
        }
        public DataSet TraerServicioXCriterio(string nombre, string restriccionHorario, string estado)
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
            prmC.ParameterName = "@restriccionHorario";
            prmC.Value = restriccionHorario;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@estado";
            prmE.Value = estado;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Servicio_TraerXCriterio");
        }

    }
}
