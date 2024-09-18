using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.DAO
{
    public class DAOConsulta
    {
        public int Insertar(int clienteId, DateTime fechaConsulta, double peso, double talla, double imc, double pa, double fr, double fc, double pulso,
            string cabeza, string cardioPulmonar, string abdomen, string genitoUrinario, string extremidades, string antPatologicos, string enfermedadesActuales,
            bool tabaco, string alcohol, string medicamentos, string estiloActividad, string descripcionActividad, string tipoActividad, string conclusion,
            bool estado, string usuarioId, DateTime fecha)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Direction = ParameterDirection.Output;
            lstParametros.Add(prmA);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.Int32;
            prmB.ParameterName = "@clienteId";
            prmB.Value = clienteId;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.DateTime;
            prmC.ParameterName = "@fechaConsulta";
            prmC.Value = fechaConsulta;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Double;
            prmD.ParameterName = "@peso";
            prmD.Value = peso;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.Double;
            prmE.ParameterName = "@talla";
            prmE.Value = talla;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.Double;
            prmF.ParameterName = "@imc";
            prmF.Value = imc;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            DbParameter prmFF = new SqlParameter();
            prmFF.DbType = DbType.Double;
            prmFF.ParameterName = "@pa";
            prmFF.Value = pa;
            prmFF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmFF);

            DbParameter prmFD = new SqlParameter();
            prmFD.DbType = DbType.Double;
            prmFD.ParameterName = "@fr";
            prmFD.Value = fr;
            prmFD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmFD);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.Double;
            prmG.ParameterName = "@fc";
            prmG.Value = fc;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmH = new SqlParameter();
            prmH.DbType = DbType.Double;
            prmH.ParameterName = "@pulso";
            prmH.Value = pulso;
            prmH.Direction = ParameterDirection.Input;
            lstParametros.Add(prmH);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.String;
            prmI.ParameterName = "@cabeza";
            prmI.Value = cabeza;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.String;
            prmJ.ParameterName = "@cardioPulmonar";
            prmJ.Value = cardioPulmonar;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.String;
            prmK.ParameterName = "@abdomen";
            prmK.Value = abdomen;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            DbParameter prmM = new SqlParameter();
            prmM.DbType = DbType.String;
            prmM.ParameterName = "@genitoUrinario";
            prmM.Value = genitoUrinario;
            prmM.Direction = ParameterDirection.Input;
            lstParametros.Add(prmM);

            DbParameter prmN = new SqlParameter();
            prmN.DbType = DbType.String;
            prmN.ParameterName = "@extremidades";
            prmN.Value = extremidades;
            prmN.Direction = ParameterDirection.Input;
            lstParametros.Add(prmN);

            DbParameter prmO = new SqlParameter();
            prmO.DbType = DbType.String;
            prmO.ParameterName = "@antPatologicos";
            prmO.Value = antPatologicos;
            prmO.Direction = ParameterDirection.Input;
            lstParametros.Add(prmO);

            DbParameter prmP = new SqlParameter();
            prmP.DbType = DbType.String;
            prmP.ParameterName = "@enfermedadesActuales";
            prmP.Value = enfermedadesActuales;
            prmP.Direction = ParameterDirection.Input;
            lstParametros.Add(prmP);

            DbParameter prmQ = new SqlParameter();
            prmQ.DbType = DbType.Boolean;
            prmQ.ParameterName = "@tabaco";
            prmQ.Value = tabaco;
            prmQ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmQ);

            DbParameter prmR = new SqlParameter();
            prmR.DbType = DbType.String;
            prmR.ParameterName = "@alcohol";
            prmR.Value = alcohol;
            prmR.Direction = ParameterDirection.Input;
            lstParametros.Add(prmR);

            DbParameter prmS = new SqlParameter();
            prmS.DbType = DbType.String;
            prmS.ParameterName = "@medicamentos";
            prmS.Value = medicamentos;
            prmS.Direction = ParameterDirection.Input;
            lstParametros.Add(prmS);

            DbParameter prmUU = new SqlParameter();
            prmUU.DbType = DbType.String;
            prmUU.ParameterName = "@estiloActividad";
            prmUU.Value = estiloActividad;
            prmUU.Direction = ParameterDirection.Input;
            lstParametros.Add(prmUU);

            DbParameter prmU = new SqlParameter();
            prmU.DbType = DbType.String;
            prmU.ParameterName = "@descripcionActividad";
            prmU.Value = descripcionActividad;
            prmU.Direction = ParameterDirection.Input;
            lstParametros.Add(prmU);

            DbParameter prmV = new SqlParameter();
            prmV.DbType = DbType.String;
            prmV.ParameterName = "@tipoActividad";
            prmV.Value = tipoActividad;
            prmV.Direction = ParameterDirection.Input;
            lstParametros.Add(prmV);

            DbParameter prmVv = new SqlParameter();
            prmVv.DbType = DbType.String;
            prmVv.ParameterName = "@conclusion";
            prmVv.Value = conclusion;
            prmVv.Direction = ParameterDirection.Input;
            lstParametros.Add(prmVv);

            DbParameter prmW = new SqlParameter();
            prmW.DbType = DbType.Boolean;
            prmW.ParameterName = "@estado";
            prmW.Value = estado;
            prmW.Direction = ParameterDirection.Input;
            lstParametros.Add(prmW);

            DbParameter prmX = new SqlParameter();
            prmX.DbType = DbType.String;
            prmX.ParameterName = "@usuarioId";
            prmX.Value = usuarioId;
            prmX.Direction = ParameterDirection.Input;
            lstParametros.Add(prmX);

            DbParameter prmY = new SqlParameter();
            prmY.DbType = DbType.DateTime;
            prmY.ParameterName = "@fecha";
            prmY.Value = fecha;
            prmY.Direction = ParameterDirection.Input;
            lstParametros.Add(prmY);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.Consulta_Insertar"))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public int Insertar(string nombre, string apellidos, string direccion, string telefono, string celular, string celular2, string ci, string correo, string ocupacion, string lugarTrabajo, string telefonoTrabajo, string correoTrabajo, DateTime fechaNacimiento, string genero, string estadoCivil, bool tieneHijos, int numeroHijos, DateTime fechaIngreso, int numeroConsulta, bool recibirNotificaciones, int empresaId, string usuarioId, DateTime fecha, string estado, SqlTransaction transaccion)
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
            prmR.ParameterName = "@numeroConsulta";
            prmR.Value = numeroConsulta;
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
            if (conProxy.EjecutarDML(lstParametros, "vip.Consulta_Insertar", transaccion))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }

        public bool Actualizar(int id, int clienteId, DateTime fechaConsulta, double peso, double talla, double imc, double pa, double fr, double fc, double pulso,
            string cabeza, string cardioPulmonar, string abdomen, string genitoUrinario, string extremidades, string antPatologicos, string enfermedadesActuales,
            bool tabaco, string alcohol, string medicamentos, string estiloActividad, string descripcionActividad, string tipoActividad, string conclusion,
            bool estado, string usuarioId, DateTime fecha)
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
            prmB.ParameterName = "@clienteId";
            prmB.Value = clienteId;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.DateTime;
            prmC.ParameterName = "@fechaConsulta";
            prmC.Value = fechaConsulta;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Double;
            prmD.ParameterName = "@peso";
            prmD.Value = peso;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.Double;
            prmE.ParameterName = "@talla";
            prmE.Value = talla;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.Double;
            prmF.ParameterName = "@imc";
            prmF.Value = imc;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            DbParameter prmFF = new SqlParameter();
            prmFF.DbType = DbType.Double;
            prmFF.ParameterName = "@pa";
            prmFF.Value = pa;
            prmFF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmFF);

            DbParameter prmFD = new SqlParameter();
            prmFD.DbType = DbType.Double;
            prmFD.ParameterName = "@fr";
            prmFD.Value = fr;
            prmFD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmFD);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.Double;
            prmG.ParameterName = "@fc";
            prmG.Value = fc;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmH = new SqlParameter();
            prmH.DbType = DbType.Double;
            prmH.ParameterName = "@pulso";
            prmH.Value = pulso;
            prmH.Direction = ParameterDirection.Input;
            lstParametros.Add(prmH);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.String;
            prmI.ParameterName = "@cabeza";
            prmI.Value = cabeza;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.String;
            prmJ.ParameterName = "@cardioPulmonar";
            prmJ.Value = cardioPulmonar;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.String;
            prmK.ParameterName = "@abdomen";
            prmK.Value = abdomen;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            DbParameter prmM = new SqlParameter();
            prmM.DbType = DbType.String;
            prmM.ParameterName = "@genitoUrinario";
            prmM.Value = genitoUrinario;
            prmM.Direction = ParameterDirection.Input;
            lstParametros.Add(prmM);

            DbParameter prmN = new SqlParameter();
            prmN.DbType = DbType.String;
            prmN.ParameterName = "@extremidades";
            prmN.Value = extremidades;
            prmN.Direction = ParameterDirection.Input;
            lstParametros.Add(prmN);

            DbParameter prmO = new SqlParameter();
            prmO.DbType = DbType.String;
            prmO.ParameterName = "@antPatologicos";
            prmO.Value = antPatologicos;
            prmO.Direction = ParameterDirection.Input;
            lstParametros.Add(prmO);

            DbParameter prmP = new SqlParameter();
            prmP.DbType = DbType.String;
            prmP.ParameterName = "@enfermedadesActuales";
            prmP.Value = enfermedadesActuales;
            prmP.Direction = ParameterDirection.Input;
            lstParametros.Add(prmP);

            DbParameter prmQ = new SqlParameter();
            prmQ.DbType = DbType.Boolean;
            prmQ.ParameterName = "@tabaco";
            prmQ.Value = tabaco;
            prmQ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmQ);

            DbParameter prmR = new SqlParameter();
            prmR.DbType = DbType.String;
            prmR.ParameterName = "@alcohol";
            prmR.Value = alcohol;
            prmR.Direction = ParameterDirection.Input;
            lstParametros.Add(prmR);

            DbParameter prmS = new SqlParameter();
            prmS.DbType = DbType.String;
            prmS.ParameterName = "@medicamentos";
            prmS.Value = medicamentos;
            prmS.Direction = ParameterDirection.Input;
            lstParametros.Add(prmS);

            DbParameter prmUU = new SqlParameter();
            prmUU.DbType = DbType.String;
            prmUU.ParameterName = "@estiloActividad";
            prmUU.Value = estiloActividad;
            prmUU.Direction = ParameterDirection.Input;
            lstParametros.Add(prmUU);

            DbParameter prmU = new SqlParameter();
            prmU.DbType = DbType.String;
            prmU.ParameterName = "@descripcionActividad";
            prmU.Value = descripcionActividad;
            prmU.Direction = ParameterDirection.Input;
            lstParametros.Add(prmU);

            DbParameter prmV = new SqlParameter();
            prmV.DbType = DbType.String;
            prmV.ParameterName = "@tipoActividad";
            prmV.Value = tipoActividad;
            prmV.Direction = ParameterDirection.Input;
            lstParametros.Add(prmV);

            DbParameter prmVv = new SqlParameter();
            prmVv.DbType = DbType.String;
            prmVv.ParameterName = "@conclusion";
            prmVv.Value = conclusion;
            prmVv.Direction = ParameterDirection.Input;
            lstParametros.Add(prmVv);

            DbParameter prmW = new SqlParameter();
            prmW.DbType = DbType.Boolean;
            prmW.ParameterName = "@estado";
            prmW.Value = estado;
            prmW.Direction = ParameterDirection.Input;
            lstParametros.Add(prmW);

            DbParameter prmX = new SqlParameter();
            prmX.DbType = DbType.String;
            prmX.ParameterName = "@usuarioId";
            prmX.Value = usuarioId;
            prmX.Direction = ParameterDirection.Input;
            lstParametros.Add(prmX);

            DbParameter prmY = new SqlParameter();
            prmY.DbType = DbType.DateTime;
            prmY.ParameterName = "@fecha";
            prmY.Value = fecha;
            prmY.Direction = ParameterDirection.Input;
            lstParametros.Add(prmY);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.Consulta_Actualizar");
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
            return conProxy.EjecutarDML(lstParametros, "vip.Consulta_Eliminar");
        }
        
        public DataSet TraerConsultas()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta("select * from vip.Consulta");
        }
        
        public DataSet TraerConsultaXId(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.Consulta_TraerXId");
        }
        public DataSet TraerConsultaXCriterio(string nombre, string correo, string ci, string estado)
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
            return conProxy.EjecutarConsulta(lstParametros, "vip.Consulta_TraerXCriterio");
        }
    }
}
