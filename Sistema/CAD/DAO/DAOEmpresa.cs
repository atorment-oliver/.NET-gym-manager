using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.DAO
{
    public  class DAOEmpresa
    {
        /// <summary>
        /// Inserta un registro al origen de datos
        /// </summary>
        /// <param name="nombre">Nombre empleado</param>
        /// <returns>Id del empleado insertado</returns>
        public int Insertar(string nombre, string descripcion, string nombrePersonaContacto, string telefono, string correo, string direccion, DateTime fechaRegistro, string usuarioId, DateTime fecha, bool estado)
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
            prmC.DbType = DbType.String;
            prmC.ParameterName = "@descripcion";
            prmC.Value = descripcion;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@nombrePersonaContacto";
            prmD.Value = nombrePersonaContacto;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@telefono";
            prmE.Value = telefono;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.String;
            prmF.ParameterName = "@correo";
            prmF.Value = correo;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.String;
            prmG.ParameterName = "@direccion";
            prmG.Value = direccion;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmH = new SqlParameter();
            prmH.DbType = DbType.DateTime;
            prmH.ParameterName = "@fechaRegistro";
            prmH.Value = fechaRegistro;
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

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.Empresa_Insertar"))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public int Insertar(string nombre, string descripcion, string nombrePersonaContacto, string telefono, string correo, string direccion, DateTime fechaRegistro, string usuarioId, DateTime fecha, bool estado, SqlTransaction transaccion)
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
            prmC.DbType = DbType.String;
            prmC.ParameterName = "@descripcion";
            prmC.Value = descripcion;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@nombrePersonaContacto";
            prmD.Value = nombrePersonaContacto;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@telefono";
            prmE.Value = telefono;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.String;
            prmF.ParameterName = "@correo";
            prmF.Value = correo;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.String;
            prmG.ParameterName = "@direccion";
            prmG.Value = direccion;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmH = new SqlParameter();
            prmH.DbType = DbType.DateTime;
            prmH.ParameterName = "@fechaRegistro";
            prmH.Value = fechaRegistro;
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

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.Empresa_Insertar", transaccion))
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
        public bool Actualizar(int id, string nombre, string descripcion, string nombrePersonaContacto, string telefono, string correo, string direccion, DateTime fechaRegistro, string usuarioId, DateTime fecha, bool estado)
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
            prmC.DbType = DbType.String;
            prmC.ParameterName = "@descripcion";
            prmC.Value = descripcion;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@nombrePersonaContacto";
            prmD.Value = nombrePersonaContacto;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@telefono";
            prmE.Value = telefono;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.String;
            prmF.ParameterName = "@correo";
            prmF.Value = correo;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.String;
            prmG.ParameterName = "@direccion";
            prmG.Value = direccion;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmH = new SqlParameter();
            prmH.DbType = DbType.DateTime;
            prmH.ParameterName = "@fechaRegistro";
            prmH.Value = fechaRegistro;
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

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.Empresa_Actualizar");
        }
        public bool Actualizar(int id, string nombre, string descripcion, string nombrePersonaContacto, string telefono, string correo, string direccion, DateTime fechaRegistro, string usuarioId, DateTime fecha, bool estado, SqlTransaction transaccion)
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
            prmC.DbType = DbType.String;
            prmC.ParameterName = "@descripcion";
            prmC.Value = descripcion;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@nombrePersonaContacto";
            prmD.Value = nombrePersonaContacto;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@telefono";
            prmE.Value = telefono;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.String;
            prmF.ParameterName = "@correo";
            prmF.Value = correo;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.String;
            prmG.ParameterName = "@direccion";
            prmG.Value = direccion;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmH = new SqlParameter();
            prmH.DbType = DbType.DateTime;
            prmH.ParameterName = "@fechaRegistro";
            prmH.Value = fechaRegistro;
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

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.Empresa_Actualizar", transaccion);
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
            return conProxy.EjecutarDML(lstParametros, "vip.Empresa_Eliminar");
        }
        public DataSet TraerEmpresas()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta("select * from vip.empresa");
        }
        public DataSet TraerEmpresaXId(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Empresa_TraerXId");
        }
        public DataSet TraerEmpresaXCriterio(string nombre, string nombrePersonaContacto, string correo, string estado)
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
            return conProxy.EjecutarConsulta(lstParametros, "vip.Empresa_TraerXCriterio");
        }
        
    }
}
