using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.DAO
{
    public class DAOPagoCliente
    {
        public int Insertar(int clientePaqueteId, string concepto, string formaPago, string numeroFactura, string digitosTarjeta_12, string numeroAprobacionPOS, string numeroCheque, string nombreBancoCheque, string numeroCuentaTransferencia, string nombreBancoTransferencia, int intercambioId, int nroPago, DateTime fechaPeriodoInicio, DateTime fechaPeriodoFin, decimal monto, DateTime fechaPago, string usuarioId, DateTime fecha, bool estado, int clienteid, int nroRecibo)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Direction = ParameterDirection.Output;
            lstParametros.Add(prmA);
            
            DbParameter prmAA = new SqlParameter();
            prmAA.DbType = DbType.Int32;
            prmAA.ParameterName = "@clientePaqueteId";
            prmAA.Value = clientePaqueteId;
            prmAA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmAA);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.String;
            prmB.ParameterName = "@concepto";
            prmB.Value = concepto;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.String;
            prmC.ParameterName = "@formaPago";
            prmC.Value = formaPago;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@numeroFactura";
            prmD.Value = numeroFactura;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@digitosTarjeta_12";
            prmE.Value = digitosTarjeta_12;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.String;
            prmF.ParameterName = "@numeroAprobacionPOS";
            prmF.Value = numeroAprobacionPOS;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            DbParameter prmFD = new SqlParameter();
            prmFD.DbType = DbType.String;
            prmFD.ParameterName = "@numeroCheque";
            prmFD.Value = numeroCheque;
            prmFD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmFD);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.String;
            prmG.ParameterName = "@nombreBancoCheque";
            prmG.Value = nombreBancoCheque;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmH = new SqlParameter();
            prmH.DbType = DbType.String;
            prmH.ParameterName = "@numeroCuentaTransferencia";
            prmH.Value = numeroCuentaTransferencia;
            prmH.Direction = ParameterDirection.Input;
            lstParametros.Add(prmH);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.String;
            prmI.ParameterName = "@nombreBancoTransferencia";
            prmI.Value = nombreBancoTransferencia;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.Int32;
            prmJ.ParameterName = "@intercambioId";
            prmJ.Value = intercambioId;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.Int32;
            prmK.ParameterName = "@nroPago";
            prmK.Value = nroPago;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            DbParameter prmL = new SqlParameter();
            prmL.DbType = DbType.DateTime;
            prmL.ParameterName = "@fechaPeriodoInicio";
            prmL.Value = fechaPeriodoInicio;
            prmL.Direction = ParameterDirection.Input;
            lstParametros.Add(prmL);

            DbParameter prmM = new SqlParameter();
            prmM.DbType = DbType.DateTime;
            prmM.ParameterName = "@fechaPeriodoFin";
            prmM.Value = fechaPeriodoFin;
            prmM.Direction = ParameterDirection.Input;
            lstParametros.Add(prmM);

            DbParameter prmN = new SqlParameter();
            prmN.DbType = DbType.Decimal;
            prmN.ParameterName = "@monto";
            prmN.Value = monto;
            prmN.Direction = ParameterDirection.Input;
            lstParametros.Add(prmN);

            DbParameter prmO = new SqlParameter();
            prmO.DbType = DbType.DateTime;
            prmO.ParameterName = "@fechaPago";
            prmO.Value = fechaPago;
            prmO.Direction = ParameterDirection.Input;
            lstParametros.Add(prmO);

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

            DbParameter prmX = new SqlParameter();
            prmX.DbType = DbType.Int32;
            prmX.ParameterName = "@ClienteId";
            prmX.Value = clienteid;
            prmX.Direction = ParameterDirection.Input;
            lstParametros.Add(prmX);

            DbParameter prmY = new SqlParameter();
            prmY.DbType = DbType.Int32;
            prmY.ParameterName = "@nroRecibo";
            prmY.Value = nroRecibo;
            prmY.Direction = ParameterDirection.Input;
            lstParametros.Add(prmY);

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.PagoCliente_Insertar"))
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
        public bool Actualizar(int id, int clientePaqueteId, string concepto, string formaPago, string numeroFactura, string digitosTarjeta_12, string numeroAprobacionPOS, string numeroCheque, string nombreBancoCheque, string numeroCuentaTransferencia, string nombreBancoTransferencia, int intercambioId, int nroPago, DateTime fechaPeriodoInicio, DateTime fechaPeriodoFin, decimal monto, DateTime fechaPago, string usuarioId, DateTime fecha, bool estado)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmAA = new SqlParameter();
            prmAA.DbType = DbType.Int32;
            prmAA.ParameterName = "@clientePaqueteId";
            prmAA.Value = concepto;
            prmAA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmAA);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.String;
            prmB.ParameterName = "@concepto";
            prmB.Value = concepto;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.String;
            prmC.ParameterName = "@formaPago";
            prmC.Value = formaPago;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.String;
            prmD.ParameterName = "@numeroFactura";
            prmD.Value = numeroFactura;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            DbParameter prmE = new SqlParameter();
            prmE.DbType = DbType.String;
            prmE.ParameterName = "@digitosTarjeta_12";
            prmE.Value = digitosTarjeta_12;
            prmE.Direction = ParameterDirection.Input;
            lstParametros.Add(prmE);

            DbParameter prmF = new SqlParameter();
            prmF.DbType = DbType.String;
            prmF.ParameterName = "@numeroAprobacionPOS";
            prmF.Value = numeroAprobacionPOS;
            prmF.Direction = ParameterDirection.Input;
            lstParametros.Add(prmF);

            DbParameter prmFD = new SqlParameter();
            prmFD.DbType = DbType.String;
            prmFD.ParameterName = "@numeroCheque";
            prmFD.Value = numeroCheque;
            prmFD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmFD);

            DbParameter prmG = new SqlParameter();
            prmG.DbType = DbType.String;
            prmG.ParameterName = "@nombreBancoCheque";
            prmG.Value = nombreBancoCheque;
            prmG.Direction = ParameterDirection.Input;
            lstParametros.Add(prmG);

            DbParameter prmH = new SqlParameter();
            prmH.DbType = DbType.String;
            prmH.ParameterName = "@numeroCuentaTransferencia";
            prmH.Value = numeroCuentaTransferencia;
            prmH.Direction = ParameterDirection.Input;
            lstParametros.Add(prmH);

            DbParameter prmI = new SqlParameter();
            prmI.DbType = DbType.String;
            prmI.ParameterName = "@nombreBancoTransferencia";
            prmI.Value = nombreBancoTransferencia;
            prmI.Direction = ParameterDirection.Input;
            lstParametros.Add(prmI);

            DbParameter prmJ = new SqlParameter();
            prmJ.DbType = DbType.Int32;
            prmJ.ParameterName = "@intercambioId";
            prmJ.Value = intercambioId;
            prmJ.Direction = ParameterDirection.Input;
            lstParametros.Add(prmJ);

            DbParameter prmK = new SqlParameter();
            prmK.DbType = DbType.Int32;
            prmK.ParameterName = "@nroPago";
            prmK.Value = nroPago;
            prmK.Direction = ParameterDirection.Input;
            lstParametros.Add(prmK);

            DbParameter prmL = new SqlParameter();
            prmL.DbType = DbType.DateTime;
            prmL.ParameterName = "@fechaPeriodoInicio";
            prmL.Value = fechaPeriodoInicio;
            prmL.Direction = ParameterDirection.Input;
            lstParametros.Add(prmL);

            DbParameter prmM = new SqlParameter();
            prmM.DbType = DbType.DateTime;
            prmM.ParameterName = "@fechaPeriodoFin";
            prmM.Value = fechaPeriodoFin;
            prmM.Direction = ParameterDirection.Input;
            lstParametros.Add(prmM);

            DbParameter prmN = new SqlParameter();
            prmN.DbType = DbType.Decimal;
            prmN.ParameterName = "@monto";
            prmN.Value = monto;
            prmN.Direction = ParameterDirection.Input;
            lstParametros.Add(prmN);

            DbParameter prmO = new SqlParameter();
            prmO.DbType = DbType.DateTime;
            prmO.ParameterName = "@fechaPago";
            prmO.Value = fechaPago;
            prmO.Direction = ParameterDirection.Input;
            lstParametros.Add(prmO);

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
            return conProxy.EjecutarDML(lstParametros, "vip.PagoCliente_Actualizar");
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
            return conProxy.EjecutarDML(lstParametros, "vip.PagoCliente_Eliminar");
        }
        public DataSet TraerPagoClientes()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta("select * from vip.PagoCliente");
        }
        public DataSet TraerPagoClienteXId(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoCliente_TraerXId");
        }
        public DataSet TraerPagoClienteXIdPaqueteD(int id, int clientepaquete)
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
            prmB.ParameterName = "@ClientePaqueteId";
            prmB.Value = clientepaquete;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoCliente_TraerXIdPaqueteRecibo");
        }
        public DataSet TraerPagoClienteXIdPaquete(int id, int clientepaquete)
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
            prmB.ParameterName = "@ClientePaqueteId";
            prmB.Value = clientepaquete;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoCliente_TraerXIdPaquete");
        }
        public DataSet TraerPagoClienteXIdPaqueteCliente(int id, int clientepaquete)
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
            prmB.ParameterName = "@ClientePaqueteId";
            prmB.Value = clientepaquete;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoCliente_TraerXIdPaqueteCliente");
        }
        public DataSet TraerRecibos(int clientepaquete)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.Int32;
            prmB.ParameterName = "@ClientePaqueteId";
            prmB.Value = clientepaquete;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoCliente_TraerRecibos");
        }
        public DataSet TraerRecibosCaja(string clientepaquete)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.String;
            prmB.ParameterName = "@ClientePaqueteId";
            prmB.Value = clientepaquete;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoCliente_TraerRecibosCaja");
        }
        public DataSet TraerPagoClienteXCriterio(string nombre, string correo, string ci, string estado)
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
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoCliente_TraerXCriterio");
        }
        public DataSet TraerPagoClienteXCriterio(DateTime fechaPagoInicio, DateTime fechaPagoFin, string cajeroId)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

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
            prmD.ParameterName = "@cajeroId";
            prmD.Value = cajeroId;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoCliente_TraerXCriterio");
        }
        public DataSet TraerPagoClienteXFechaPago(DateTime fechaPagoInicio, DateTime fechaPagoFin)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

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

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoCliente_TraerXFechaPago");
        }
        public DataSet TraerXFiltro(string clienteId, DateTime fechaPagoInicio, DateTime fechaPagoFin, string empresaId, string grupoId, string formaPago, string paqueteId, string servicioId, string promocionId)
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

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoCliente_TraerXFiltro");
        }
        public DataSet TraerPagoClienteXCaja(DateTime FechaCaja, DateTime FechaCierreCaja, string usuarioId, int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.DateTime;
            prmA.ParameterName = "@FechaCaja";
            prmA.Value = FechaCaja;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.DateTime;
            prmB.ParameterName = "@FechaCierreCaja";
            prmB.Value = FechaCierreCaja;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            DbParameter prmC = new SqlParameter();
            prmC.DbType = DbType.String;
            prmC.ParameterName = "@usuarioId";
            prmC.Value = usuarioId;
            prmC.Direction = ParameterDirection.Input;
            lstParametros.Add(prmC);

            DbParameter prmD = new SqlParameter();
            prmD.DbType = DbType.Int32;
            prmD.ParameterName = "@id";
            prmD.Value = id;
            prmD.Direction = ParameterDirection.Input;
            lstParametros.Add(prmD);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoCliente_TraerXCaja");
        }
        public DataSet TraerMaximoRecibo()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoCliente_TraerMaximoRecibo");
        }
    }
}
