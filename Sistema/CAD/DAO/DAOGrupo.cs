using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.DAO
{
    public class DAOGrupo
    {
        public int Insertar(string nombre, int horarioId, int servicioId, bool estado, string usuarioId, DateTime fecha)
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
            prmC.DbType = DbType.Int32;
            prmC.ParameterName = "@horarioId";
            prmC.Value = horarioId;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Int32;
            prmD.ParameterName = "@servicioId";
            prmD.Value = servicioId;
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
            if (conProxy.EjecutarDML(lstParametros, "vip.Grupo_Insertar"))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public int Insertar(string nombre, int horarioId, int servicioId, bool estado, string usuarioId, DateTime fecha, SqlTransaction transaccion)
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
            prmC.DbType = DbType.Int32;
            prmC.ParameterName = "@horarioId";
            prmC.Value = horarioId;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Int32;
            prmD.ParameterName = "@servicioId";
            prmD.Value = servicioId;
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
            if (conProxy.EjecutarDML(lstParametros, "vip.Grupo_Insertar", transaccion))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public bool Actualizar(int id, string nombre, int horarioId, int servicioId, bool estado, string usuarioId, DateTime fecha)
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
            prmC.DbType = DbType.Int32;
            prmC.ParameterName = "@horarioId";
            prmC.Value = horarioId;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Int32;
            prmD.ParameterName = "@servicioId";
            prmD.Value = servicioId;
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
            return conProxy.EjecutarDML(lstParametros, "vip.Grupo_Actualizar");
        }
        public bool Actualizar(int id, string nombre, int horarioId, int servicioId, bool estado, string usuarioId, DateTime fecha, SqlTransaction transaccion)
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
            prmC.DbType = DbType.Int32;
            prmC.ParameterName = "@horarioId";
            prmC.Value = horarioId;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Int32;
            prmD.ParameterName = "@servicioId";
            prmD.Value = servicioId;
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
            return conProxy.EjecutarDML(lstParametros, "vip.Grupo_Actualizar", transaccion);
        }
        public bool ActualizarHorarioId(int id, int horarioId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.Int32;
            prmB.ParameterName = "@horarioId";
            prmB.Value = horarioId;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.Grupo_ActualizarHorarioId");
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
            return conProxy.EjecutarDML(lstParametros, "vip.Grupo_Eliminar");
        }
        public DataSet Grupo_TraerXServicio(int servicioId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@servicioId";
            prmA.Value = servicioId;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Grupo_TraerXServicio");
        }
        public DataSet Grupo_TraerServicioHorario(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@grupoId";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Grupo_TraerServicioHorario");
        }
        public DataSet Grupo_TraerServicioHorarioCliente(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@clientePaqueteId";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Grupo_TraerServicioHorarioCliente");
        }
        public DataSet Grupo_TraerHorario(int id, int clientepaqueteid, DateTime fecha)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@grupoId";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.Int32;
            prmC.ParameterName = "@clientePaqueteId";
            prmC.Value = clientepaqueteid;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.DateTime;
            prmD.ParameterName = "@fecha";
            prmD.Value = fecha;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Grupo_TraerHorario");
        }
        public DataSet Grupo_TraerHorarioIn(int id, int clientepaqueteid, DateTime fecha)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@grupoId";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.Int32;
            prmC.ParameterName = "@clientePaqueteId";
            prmC.Value = clientepaqueteid;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.DateTime;
            prmD.ParameterName = "@fecha";
            prmD.Value = fecha;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Grupo_TraerHorarioIn");
        }
        public DataSet Grupo_TraerValidando(string salaId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.String;
            prmA.ParameterName = "@salaId";
            prmA.Value = salaId;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Horario_TraerXCriterioValidando");
        }
        public DataSet Grupo_TraerIdValidando(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Horario_TraerXIdValidando");
        }
        public DataSet Grupo_TraerValidandoCrucesHorario(int id, int id2)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);


            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.Int32;
            prmB.ParameterName = "@id2";
            prmB.Value = id2;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Grupo_TraerValidandoCrucesHorario");
        }
        public DataSet TraerGrupos()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Grupo_TraerTodos");
        }
        public DataSet TraerGrupoXId(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Grupo_TraerXId");
        }
        public DataSet TraerGrupoXCriterio(string nombre, string servicioId, string estado)
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
            prmC.ParameterName = "@servicioId";
            prmC.Value = servicioId;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@estado";
            prmE.Value = estado;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Grupo_TraerXCriterio");
        }
    }
}
