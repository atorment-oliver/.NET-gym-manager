using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.DAO
{
    public class DAOCliente
    {
        public int Insertar(string nombre, string apellidos, string direccion, string telefono, string celular, string celular2, string ci, string correo, string ocupacion, string lugarTrabajo, string telefonoTrabajo, string correoTrabajo, DateTime fechaNacimiento, string genero, string estadoCivil, bool tieneHijos, int numeroHijos, DateTime fechaIngreso, int numeroCliente, bool recibirNotificaciones, int empresaId, string usuarioId, DateTime fecha, string estado)
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
            prmC.ParameterName = "@apellidos";
            prmC.Value = apellidos;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@direccion";
            prmD.Value = direccion;
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
            prmF.ParameterName = "@celular";
            prmF.Value = celular;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            DbParameter prmFF = new SqlParameter();
            prmFF.DbType = DbType.String;
            prmFF.ParameterName = "@celular2";
            prmFF.Value = celular2;
            prmFF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmFF);

            DbParameter prmFD = new SqlParameter();
            prmFD.DbType = DbType.String;
            prmFD.ParameterName = "@ci";
            prmFD.Value = ci;
            prmFD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmFD);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.String;
            prmG.ParameterName = "@correo";
            prmG.Value = correo;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmH = new SqlParameter();
            prmH.DbType = DbType.String;
            prmH.ParameterName = "@ocupacion";
            prmH.Value = ocupacion;
            prmH.Direction = ParameterDirection.Input;
            lstParametros.Add(prmH);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.String;
            prmI.ParameterName = "@lugarTrabajo";
            prmI.Value = lugarTrabajo;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.String;
            prmJ.ParameterName = "@telefonoTrabajo";
            prmJ.Value = telefonoTrabajo;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.String;
            prmK.ParameterName = "@correoTrabajo";
            prmK.Value = correoTrabajo;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            DbParameter prmL = new SqlParameter();
            prmL.DbType = DbType.DateTime;
            prmL.ParameterName = "@fechaNacimiento";

            if (fechaNacimiento.Year == 1900 && fechaNacimiento.Month == 1 && fechaNacimiento.Day == 1)
                prmL.Value = null;
            else
                prmL.Value = fechaNacimiento;
            prmL.Direction = ParameterDirection.Input;
            lstParametros.Add(prmL);

            DbParameter prmM = new SqlParameter();
            prmM.DbType = DbType.String;
            prmM.ParameterName = "@genero";
            prmM.Value = genero;
            prmM.Direction = ParameterDirection.Input;
            lstParametros.Add(prmM);

            DbParameter prmN = new SqlParameter();
            prmN.DbType = DbType.String;
            prmN.ParameterName = "@estadoCivil";
            prmN.Value = estadoCivil;
            prmN.Direction = ParameterDirection.Input;
            lstParametros.Add(prmN);

            DbParameter prmO = new SqlParameter();
            prmO.DbType = DbType.Boolean;
            prmO.ParameterName = "@tieneHijos";
            prmO.Value = tieneHijos;
            prmO.Direction = ParameterDirection.Input;
            lstParametros.Add(prmO);

            DbParameter prmP = new SqlParameter();
            prmP.DbType = DbType.Int32;
            prmP.ParameterName = "@numeroHijos";
            prmP.Value = numeroHijos;
            prmP.Direction = ParameterDirection.Input;
            lstParametros.Add(prmP);

            DbParameter prmQ = new SqlParameter();
            prmQ.DbType = DbType.DateTime;
            prmQ.ParameterName = "@fechaIngreso";
            prmQ.Value = fechaIngreso;
            prmQ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmQ);

            DbParameter prmR = new SqlParameter();
            prmR.DbType = DbType.Int32;
            prmR.ParameterName = "@numeroCliente";
            prmR.Value = numeroCliente;
            prmR.Direction = ParameterDirection.Input;
            lstParametros.Add(prmR);

            DbParameter prmS = new SqlParameter();
            prmS.DbType = DbType.Boolean;
            prmS.ParameterName = "@recibirNotificaciones";
            prmS.Value = recibirNotificaciones;
            prmS.Direction = ParameterDirection.Input;
            lstParametros.Add(prmS);

            DbParameter prmUU = new SqlParameter();
            prmUU.DbType = DbType.String;
            prmUU.ParameterName = "@empresaId";
            prmUU.Value = empresaId;
            prmUU.Direction = ParameterDirection.Input;
            lstParametros.Add(prmUU);

            DbParameter prmU = new SqlParameter();
            prmU.DbType = DbType.String;
            prmU.ParameterName = "@usuarioId";
            prmU.Value = usuarioId;
            prmU.Direction = ParameterDirection.Input;
            lstParametros.Add(prmU);

            DbParameter prmV = new SqlParameter();
            prmV.DbType = DbType.DateTime;
            prmV.ParameterName = "@fecha";
            prmV.Value = fecha;
            prmV.Direction = ParameterDirection.Input;
            lstParametros.Add(prmV);

            DbParameter prmW = new SqlParameter();
            prmW.DbType = DbType.String;
            prmW.ParameterName = "@estado";
            prmW.Value = estado;
            prmW.Direction = ParameterDirection.Input;
            lstParametros.Add(prmW);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.Cliente_Insertar"))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public int Insertar(string nombre, string apellidos, string direccion, string telefono, string celular, string celular2, string ci, string correo, string ocupacion, string lugarTrabajo, string telefonoTrabajo, string correoTrabajo, DateTime fechaNacimiento, string genero, string estadoCivil, bool tieneHijos, int numeroHijos, DateTime fechaIngreso, int numeroCliente, bool recibirNotificaciones, int empresaId, string usuarioId, DateTime fecha, string estado, SqlTransaction transaccion)
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
            prmC.ParameterName = "@apellidos";
            prmC.Value = apellidos;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@direccion";
            prmD.Value = direccion;
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
            prmF.ParameterName = "@celular";
            prmF.Value = celular;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            DbParameter prmFF = new SqlParameter();
            prmFF.DbType = DbType.String;
            prmFF.ParameterName = "@celular2";
            prmFF.Value = celular2;
            prmFF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmFF);

            DbParameter prmFD = new SqlParameter();
            prmFD.DbType = DbType.String;
            prmFD.ParameterName = "@ci";
            prmFD.Value = ci;
            prmFD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmFD);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.String;
            prmG.ParameterName = "@correo";
            prmG.Value = correo;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmH = new SqlParameter();
            prmH.DbType = DbType.String;
            prmH.ParameterName = "@ocupacion";
            prmH.Value = ocupacion;
            prmH.Direction = ParameterDirection.Input;
            lstParametros.Add(prmH);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.String;
            prmI.ParameterName = "@lugarTrabajo";
            prmI.Value = lugarTrabajo;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.String;
            prmJ.ParameterName = "@telefonoTrabajo";
            prmJ.Value = telefonoTrabajo;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.String;
            prmK.ParameterName = "@correoTrabajo";
            prmK.Value = correoTrabajo;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            DbParameter prmL = new SqlParameter();
            prmL.DbType = DbType.DateTime;
            prmL.ParameterName = "@fechaNacimiento";

            if (fechaNacimiento.Year == 1900 && fechaNacimiento.Month == 1 && fechaNacimiento.Day == 1)
                prmL.Value = null;
            else
                prmL.Value = fechaNacimiento;
            prmL.Direction = ParameterDirection.Input;
            lstParametros.Add(prmL);

            DbParameter prmM = new SqlParameter();
            prmM.DbType = DbType.String;
            prmM.ParameterName = "@genero";
            prmM.Value = genero;
            prmM.Direction = ParameterDirection.Input;
            lstParametros.Add(prmM);

            DbParameter prmN = new SqlParameter();
            prmN.DbType = DbType.String;
            prmN.ParameterName = "@estadoCivil";
            prmN.Value = estadoCivil;
            prmN.Direction = ParameterDirection.Input;
            lstParametros.Add(prmN);

            DbParameter prmO = new SqlParameter();
            prmO.DbType = DbType.Boolean;
            prmO.ParameterName = "@tieneHijos";
            prmO.Value = tieneHijos;
            prmO.Direction = ParameterDirection.Input;
            lstParametros.Add(prmO);

            DbParameter prmP = new SqlParameter();
            prmP.DbType = DbType.Int32;
            prmP.ParameterName = "@numeroHijos";
            prmP.Value = numeroHijos;
            prmP.Direction = ParameterDirection.Input;
            lstParametros.Add(prmP);

            DbParameter prmQ = new SqlParameter();
            prmQ.DbType = DbType.DateTime;
            prmQ.ParameterName = "@fechaIngreso";
            prmQ.Value = fechaIngreso;
            prmQ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmQ);

            DbParameter prmR = new SqlParameter();
            prmR.DbType = DbType.Int32;
            prmR.ParameterName = "@numeroCliente";
            prmR.Value = numeroCliente;
            prmR.Direction = ParameterDirection.Input;
            lstParametros.Add(prmR);

            DbParameter prmS = new SqlParameter();
            prmS.DbType = DbType.Boolean;
            prmS.ParameterName = "@recibirNotificaciones";
            prmS.Value = recibirNotificaciones;
            prmS.Direction = ParameterDirection.Input;
            lstParametros.Add(prmS);

            DbParameter prmUU = new SqlParameter();
            prmUU.DbType = DbType.String;
            prmUU.ParameterName = "@empresaId";
            prmUU.Value = empresaId;
            prmUU.Direction = ParameterDirection.Input;
            lstParametros.Add(prmUU);

            DbParameter prmU = new SqlParameter();
            prmU.DbType = DbType.String;
            prmU.ParameterName = "@usuarioId";
            prmU.Value = usuarioId;
            prmU.Direction = ParameterDirection.Input;
            lstParametros.Add(prmU);

            DbParameter prmV = new SqlParameter();
            prmV.DbType = DbType.DateTime;
            prmV.ParameterName = "@fecha";
            prmV.Value = fecha;
            prmV.Direction = ParameterDirection.Input;
            lstParametros.Add(prmV);

            DbParameter prmW = new SqlParameter();
            prmW.DbType = DbType.String;
            prmW.ParameterName = "@estado";
            prmW.Value = estado;
            prmW.Direction = ParameterDirection.Input;
            lstParametros.Add(prmW);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.Cliente_Insertar", transaccion))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
  
        public bool Actualizar(int id, string nombre, string apellidos, string direccion, string telefono, string celular, string celular2, string ci, string correo, string ocupacion, string lugarTrabajo, string telefonoTrabajo, string correoTrabajo, DateTime fechaNacimiento, string genero, string estadoCivil, bool tieneHijos, int numeroHijos, DateTime fechaIngreso, int numeroCliente, bool recibirNotificaciones, int empresaId, string usuarioId, DateTime fecha, string estado)
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
            prmC.ParameterName = "@apellidos";
            prmC.Value = apellidos;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@direccion";
            prmD.Value = direccion;
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
            prmF.ParameterName = "@celular";
            prmF.Value = celular;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            DbParameter prmFF = new SqlParameter();
            prmFF.DbType = DbType.String;
            prmFF.ParameterName = "@celular2";
            prmFF.Value = celular2;
            prmFF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmFF);

            DbParameter prmFD = new SqlParameter();
            prmFD.DbType = DbType.String;
            prmFD.ParameterName = "@ci";
            prmFD.Value = ci;
            prmFD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmFD);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.String;
            prmG.ParameterName = "@correo";
            prmG.Value = correo;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmH = new SqlParameter();
            prmH.DbType = DbType.String;
            prmH.ParameterName = "@ocupacion";
            prmH.Value = ocupacion;
            prmH.Direction = ParameterDirection.Input;
            lstParametros.Add(prmH);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.String;
            prmI.ParameterName = "@lugarTrabajo";
            prmI.Value = lugarTrabajo;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.String;
            prmJ.ParameterName = "@telefonoTrabajo";
            prmJ.Value = telefonoTrabajo;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.String;
            prmK.ParameterName = "@correoTrabajo";
            prmK.Value = correoTrabajo;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            DbParameter prmL = new SqlParameter();
            prmL.DbType = DbType.DateTime;
            prmL.ParameterName = "@fechaNacimiento";
            if (fechaNacimiento.Year == 1900 && fechaNacimiento.Month == 1 && fechaNacimiento.Day == 1)
                prmL.Value = null;
            else
                prmL.Value = fechaNacimiento;
            prmL.Direction = ParameterDirection.Input;
            lstParametros.Add(prmL);

            DbParameter prmM = new SqlParameter();
            prmM.DbType = DbType.String;
            prmM.ParameterName = "@genero";
            prmM.Value = genero;
            prmM.Direction = ParameterDirection.Input;
            lstParametros.Add(prmM);

            DbParameter prmN = new SqlParameter();
            prmN.DbType = DbType.String;
            prmN.ParameterName = "@estadoCivil";
            prmN.Value = estadoCivil;
            prmN.Direction = ParameterDirection.Input;
            lstParametros.Add(prmN);

            DbParameter prmO = new SqlParameter();
            prmO.DbType = DbType.Boolean;
            prmO.ParameterName = "@tieneHijos";
            prmO.Value = tieneHijos;
            prmO.Direction = ParameterDirection.Input;
            lstParametros.Add(prmO);

            DbParameter prmP = new SqlParameter();
            prmP.DbType = DbType.Int32;
            prmP.ParameterName = "@numeroHijos";
            prmP.Value = numeroHijos;
            prmP.Direction = ParameterDirection.Input;
            lstParametros.Add(prmP);

            DbParameter prmQ = new SqlParameter();
            prmQ.DbType = DbType.DateTime;
            prmQ.ParameterName = "@fechaIngreso";
            prmQ.Value = fechaIngreso;
            prmQ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmQ);

            DbParameter prmR = new SqlParameter();
            prmR.DbType = DbType.Int32;
            prmR.ParameterName = "@numeroCliente";
            prmR.Value = numeroCliente;
            prmR.Direction = ParameterDirection.Input;
            lstParametros.Add(prmR);

            DbParameter prmS = new SqlParameter();
            prmS.DbType = DbType.Boolean;
            prmS.ParameterName = "@recibirNotificaciones";
            prmS.Value = recibirNotificaciones;
            prmS.Direction = ParameterDirection.Input;
            lstParametros.Add(prmS);

            DbParameter prmUU = new SqlParameter();
            prmUU.DbType = DbType.String;
            prmUU.ParameterName = "@empresaId";
            prmUU.Value = empresaId;
            prmUU.Direction = ParameterDirection.Input;
            lstParametros.Add(prmUU);

            DbParameter prmU = new SqlParameter();
            prmU.DbType = DbType.String;
            prmU.ParameterName = "@usuarioId";
            prmU.Value = usuarioId;
            prmU.Direction = ParameterDirection.Input;
            lstParametros.Add(prmU);

            DbParameter prmV = new SqlParameter();
            prmV.DbType = DbType.DateTime;
            prmV.ParameterName = "@fecha";
            prmV.Value = fecha;
            prmV.Direction = ParameterDirection.Input;
            lstParametros.Add(prmV);

            DbParameter prmW = new SqlParameter();
            prmW.DbType = DbType.String;
            prmW.ParameterName = "@estado";
            prmW.Value = estado;
            prmW.Direction = ParameterDirection.Input;
            lstParametros.Add(prmW);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.Cliente_Actualizar");
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
            return conProxy.EjecutarDML(lstParametros, "vip.Cliente_Eliminar");
        }
        public DataSet TraerMaximoNumero()
        {
            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta("vip.Cliente_TraerMaximoNumero");
        }
        public DataSet ExisteCi()
        {
            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta("vip.Cliente_ExisteCi");
        }
        public DataSet TraerClientes()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta("select * from vip.Cliente");
        }
        public DataSet TraerSinCi()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta("vip.Cliente_TraerSinCi");
        }
        public DataSet TraerClienteXId(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Cliente_TraerXId");
        }
        public DataSet TraerClienteXCriterio(string nombre, string correo, string ci, string estado)
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
            prmC.ParameterName = "@correo";
            prmC.Value = correo;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@ci";
            prmD.Value = ci;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@estado";
            prmE.Value = estado;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Cliente_TraerXCriterio");
        }
        public DataSet ValidarDatos(string nombre, string apellidos, string ci)
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
            prmC.ParameterName = "@apellidos";
            prmC.Value = apellidos;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@ci";
            prmD.Value = ci;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Cliente_ValidarDatos");
        }
        public DataSet TraerClienteXCriterioSinEmpresa(string nombre, string correo, string ci, string estado)
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
            prmC.ParameterName = "@correo";
            prmC.Value = correo;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@ci";
            prmD.Value = ci;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@estado";
            prmE.Value = estado;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Cliente_TraerXCriterioSinEmpresa");
        }
        public DataSet TraerXOrCriterioPaquetes(string nombre, string correo, string ci, string estado, string clientePaqueteId)
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
            prmC.ParameterName = "@correo";
            prmC.Value = correo;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@ci";
            prmD.Value = ci;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@estado";
            prmE.Value = estado;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.String;
            prmF.ParameterName = "@clientePaqueteId";
            prmF.Value = clientePaqueteId;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Cliente_TraerXOrCriterioPaquetes");
        }
        public DataSet TraerXOrCriterioPaquetesReporte(string nombre, string correo, string ci, string estado, string clientePaqueteId)
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
            prmC.ParameterName = "@correo";
            prmC.Value = correo;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@ci";
            prmD.Value = ci;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@estado";
            prmE.Value = estado;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.String;
            prmF.ParameterName = "@clientePaqueteId";
            prmF.Value = clientePaqueteId;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Cliente_TraerXOrCriterioPaquetesReporte");
        }
        public DataSet TraerXFiltro(string clienteId, DateTime fechaPagoInicio, DateTime fechaPagoFin, string empresaId, string grupoId, string formaPago, string paqueteId, string servicioId, string promocionId, string estado, string estadonr, string estadopago)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmAA = new SqlParameter();
            prmAA.DbType = DbType.String;
            prmAA.ParameterName = "@clienteId";
            prmAA.Value = clienteId;
            prmAA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmAA);

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.DateTime;
            prmA.ParameterName = "@fechaPagoInicio";
            prmA.Value = fechaPagoInicio;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.DateTime;
            prmC.ParameterName = "@fechaPagoFin";
            prmC.Value = fechaPagoFin;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@empresaId";
            prmD.Value = empresaId;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@grupoId";
            prmE.Value = grupoId;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.String;
            prmF.ParameterName = "@formaPago";
            prmF.Value = formaPago;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.String;
            prmG.ParameterName = "@paqueteId";
            prmG.Value = paqueteId;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmH = new SqlParameter();
            prmH.DbType = DbType.String;
            prmH.ParameterName = "@servicioId";
            prmH.Value = servicioId;
            prmH.Direction = ParameterDirection.Input;
            lstParametros.Add(prmH);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.String;
            prmI.ParameterName = "@promocionId";
            prmI.Value = promocionId;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.String;
            prmJ.ParameterName = "@estado";
            prmJ.Value = estado;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.String;
            prmK.ParameterName = "@estadonr";
            prmK.Value = estadonr;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            DbParameter prmL = new SqlParameter();
            prmL.DbType = DbType.String;
            prmL.ParameterName = "@estadopago";
            prmL.Value = estadopago;
            prmL.Direction = ParameterDirection.Input;
            lstParametros.Add(prmL);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Clientes_Activos");
        }
        public DataSet TraerXFiltro2(string clienteId, DateTime fechaPagoInicio, DateTime fechaPagoFin, string empresaId, string grupoId, string formaPago, string paqueteId, string servicioId, string promocionId, string estado, string estadonr, string estadopago)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmAA = new SqlParameter();
            prmAA.DbType = DbType.String;
            prmAA.ParameterName = "@clienteId";
            prmAA.Value = clienteId;
            prmAA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmAA);

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.DateTime;
            prmA.ParameterName = "@fechaPagoInicio";
            prmA.Value = fechaPagoInicio;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.DateTime;
            prmC.ParameterName = "@fechaPagoFin";
            prmC.Value = fechaPagoFin;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@empresaId";
            prmD.Value = empresaId;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@grupoId";
            prmE.Value = grupoId;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.String;
            prmF.ParameterName = "@formaPago";
            prmF.Value = formaPago;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.String;
            prmG.ParameterName = "@paqueteId";
            prmG.Value = paqueteId;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmH = new SqlParameter();
            prmH.DbType = DbType.String;
            prmH.ParameterName = "@servicioId";
            prmH.Value = servicioId;
            prmH.Direction = ParameterDirection.Input;
            lstParametros.Add(prmH);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.String;
            prmI.ParameterName = "@promocionId";
            prmI.Value = promocionId;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.String;
            prmJ.ParameterName = "@estado";
            prmJ.Value = estado;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.String;
            prmK.ParameterName = "@estadonr";
            prmK.Value = estadonr;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            DbParameter prmL = new SqlParameter();
            prmL.DbType = DbType.String;
            prmL.ParameterName = "@estadopago";
            prmL.Value = estadopago;
            prmL.Direction = ParameterDirection.Input;
            lstParametros.Add(prmL);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Clientes_Activos2");
        }
        public DataSet TraerXFiltro3(string clienteId, DateTime fechaPagoInicio, DateTime fechaPagoFin, string empresaId, string grupoId, string formaPago, string paqueteId, string servicioId, string promocionId, string estado, string estadonr, string estadopago)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmAA = new SqlParameter();
            prmAA.DbType = DbType.String;
            prmAA.ParameterName = "@clienteId";
            prmAA.Value = clienteId;
            prmAA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmAA);

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.DateTime;
            prmA.ParameterName = "@fechaPagoInicio";
            prmA.Value = fechaPagoInicio;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.DateTime;
            prmC.ParameterName = "@fechaPagoFin";
            prmC.Value = fechaPagoFin;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@empresaId";
            prmD.Value = empresaId;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@grupoId";
            prmE.Value = grupoId;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.String;
            prmF.ParameterName = "@formaPago";
            prmF.Value = formaPago;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.String;
            prmG.ParameterName = "@paqueteId";
            prmG.Value = paqueteId;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmH = new SqlParameter();
            prmH.DbType = DbType.String;
            prmH.ParameterName = "@servicioId";
            prmH.Value = servicioId;
            prmH.Direction = ParameterDirection.Input;
            lstParametros.Add(prmH);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.String;
            prmI.ParameterName = "@promocionId";
            prmI.Value = promocionId;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.String;
            prmJ.ParameterName = "@estado";
            prmJ.Value = estado;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.String;
            prmK.ParameterName = "@estadonr";
            prmK.Value = estadonr;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            DbParameter prmL = new SqlParameter();
            prmL.DbType = DbType.String;
            prmL.ParameterName = "@estadopago";
            prmL.Value = estadopago;
            prmL.Direction = ParameterDirection.Input;
            lstParametros.Add(prmL);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Clientes_Activos3");
        }
        public DataSet TraerDatos(string estado)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.String;
            prmJ.ParameterName = "@estado";
            prmJ.Value = estado;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Clientes_Datos");
        }
        public DataSet TraerClienteXOrCriterio(string nombre, string correo, string ci, string estado)
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
            prmC.ParameterName = "@correo";
            prmC.Value = correo;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@ci";
            prmD.Value = ci;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@estado";
            prmE.Value = estado;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Cliente_TraerXOrCriterio");
        }
        public DataSet TraerClienteConEmpresa(string nombre)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.String;
            prmA.ParameterName = "@cliente";
            prmA.Value = nombre;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Cliente_TraerConEmpresa");
        }
    }
}
