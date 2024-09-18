using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.DAO
{
    public class DAOMovimientoCaja
    {
        public int Insertar(int cajaId, DateTime fechaHoraApertura, decimal montoAperturaBob, decimal montoAperturaSus, 
            decimal tipoCambio, string usuarioId, DateTime fecha, bool estado)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Direction = ParameterDirection.Output;
            lstParametros.Add(prmA);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.DateTime;
            prmB.ParameterName = "@fechaHoraApertura";
            prmB.Value = fechaHoraApertura;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.Decimal;
            prmC.ParameterName = "@montoAperturaBob";
            prmC.Value = montoAperturaBob;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Decimal;
            prmD.ParameterName = "@montoAperturaSus";
            prmD.Value = montoAperturaSus;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.Int32;
            prmG.ParameterName = "@cajaId";
            prmG.Value = cajaId;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.String;
            prmI.ParameterName = "@usuarioId";
            prmI.Value = usuarioId;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.DateTime;
            prmJ.ParameterName = "@fecha";
            prmJ.Value = fecha;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.Boolean;
            prmK.ParameterName = "@estado";
            prmK.Value = estado;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);
            
            DbParameter prmL = new SqlParameter();
            prmL.DbType = DbType.Decimal;
            prmL.ParameterName = "@tipoCambio";
            prmL.Value = tipoCambio;
            prmL.Direction = ParameterDirection.Input;
            lstParametros.Add(prmL);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.MovimientoCaja_Insertar"))
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
            if (conProxy.EjecutarDML(lstParametros, "dbo.InsertEmpleado", transaccion))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public bool Actualizar(int id, decimal montoCorregido, decimal montoCorregidoSus, bool observado, string observacionAdm, int cajaId, DateTime? fechaHoraCierre, string observacion, decimal montoCierreBob, decimal montoCierreSus, decimal montoAdministracionBob, decimal montoAdministracionSus, string usuarioId, DateTime fecha, bool estado)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.Decimal;
            prmB.ParameterName = "@montoCierreSus";
            prmB.Value = montoCierreSus;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.Decimal;
            prmC.ParameterName = "@montoAdministracionSus";
            prmC.Value = montoAdministracionSus;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.DateTime;
            prmD.ParameterName = "@fechaHoraCierre";
            prmD.Value = fechaHoraCierre;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.Decimal;
            prmE.ParameterName = "@montoCierreBob";
            prmE.Value = montoCierreBob;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.Decimal;
            prmF.ParameterName = "@montoAdministracionBob";
            prmF.Value = montoAdministracionBob;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.Int32;
            prmG.ParameterName = "@cajaId";
            prmG.Value = cajaId;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmH = new SqlParameter();
            prmH.DbType = DbType.String;
            prmH.ParameterName = "@observacion";
            prmH.Value = observacion;
            prmH.Direction = ParameterDirection.Input;
            lstParametros.Add(prmH);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.String;
            prmI.ParameterName = "@usuarioId";
            prmI.Value = usuarioId;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.DateTime;
            prmJ.ParameterName = "@fecha";
            prmJ.Value = fecha;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.Boolean;
            prmK.ParameterName = "@estado";
            prmK.Value = estado;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            DbParameter prmL = new SqlParameter();
            prmL.DbType = DbType.Boolean;
            prmL.ParameterName = "@observado";
            prmL.Value = observado;
            prmL.Direction = ParameterDirection.Input;
            lstParametros.Add(prmL);

            DbParameter prmM = new SqlParameter();
            prmM.DbType = DbType.Decimal;
            prmM.ParameterName = "@montoCorregido";
            prmM.Value = montoCorregido;
            prmM.Direction = ParameterDirection.Input;
            lstParametros.Add(prmM);

            DbParameter prmN = new SqlParameter();
            prmN.DbType = DbType.String;
            prmN.ParameterName = "@observacionAdm";
            prmN.Value = observacionAdm;
            prmN.Direction = ParameterDirection.Input;
            lstParametros.Add(prmN);

            DbParameter prmO = new SqlParameter();
            prmO.DbType = DbType.Decimal;
            prmO.ParameterName = "@montoCorregidoSus";
            prmO.Value = montoCorregidoSus;
            prmO.Direction = ParameterDirection.Input;
            lstParametros.Add(prmO);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.MovimientoCaja_Actualizar");
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
            return conProxy.EjecutarDML(lstParametros, "vip.MovimientoCaja_Eliminar");
        }
        public DataSet TraerMovimientoCajas()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta("select * from vip.MovimientoCaja");
        }
        public DataSet TraerMovimientoCajaXId(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.MovimientoCaja_TraerXId");
        }
        public DataSet TraerMovimientoCajaXCriterio(string nombre, string nombrePersonaContacto, string correo, string estado)
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
            prmC.ParameterName = "@nombrePersonaContacto";
            prmC.Value = nombrePersonaContacto;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@correo";
            prmD.Value = correo;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@estado";
            prmE.Value = estado;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.MovimientoCaja_TraerXCriterio");
        }
        public DataSet TraerMovimientoCajaXObservacion(DateTime fechaDesdeCierre, DateTime fechaHastaCierre, Guid cajeroId, char tipo)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.DateTime;
            prmA.ParameterName = "@fechaDesde";
            prmA.Value = fechaDesdeCierre;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.DateTime;
            prmB.ParameterName = "@fechaHasta";
            prmB.Value = fechaHastaCierre.AddHours(23.90);
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.Guid;
            prmC.ParameterName = "@cajeroId";
            if (cajeroId.ToString() == "00000000-0000-0000-0000-000000000000")
                prmC.Value = null;
            else
                prmC.Value = cajeroId;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@tipo";
            prmD.Value = tipo;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.MovimientoCaja_TraerXObservacion");
        }
        public DataSet EstaAbierto(string cajeroId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.String;
            prmA.ParameterName = "@cajaId";
            prmA.Value = cajeroId;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.MovimientoCaja_EstaAbierto");
        }
        public DataSet UltimoCierre(string cajeroId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.String;
            prmA.ParameterName = "@cajaId";
            prmA.Value = cajeroId;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.MovimientoCaja_UltimoCierre");
        }
        public DataSet UltimaApertura(string cajeroId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.String;
            prmA.ParameterName = "@cajaId";
            prmA.Value = cajeroId;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.MovimientoCaja_UltimaApertura");
        }
    }
}
