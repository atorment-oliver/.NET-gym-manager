using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.DAO
{
    public class DAOPagoEmpresa
    {
        public int Insertar(int empresaId, int clientePaqueteId, string concepto, string formaPago, string numeroFactura, string digitosTarjeta_12, string numeroAprobacionPOS, string numeroCheque, string nombreBancoCheque, string numeroCuentaTransferencia, string nombreBancoTransferencia, int intercambioId, int nroPago, DateTime fechaPeriodoInicio, DateTime fechaPeriodoFin, decimal monto, DateTime fechaPago, string usuarioId, DateTime fecha, bool estado)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Direction = ParameterDirection.Output;
            lstParametros.Add(prmA);

            DbParameter prmAX = new SqlParameter();
            prmAX.DbType = DbType.Int32;
            prmAX.ParameterName = "@empresaId";
            prmAX.Value = empresaId;
            prmAX.Direction = ParameterDirection.Input;
            lstParametros.Add(prmAX);

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

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.PagoEmpresa_Insertar"))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public int Insertar(int empresaId, int clientePaqueteId, string concepto, string formaPago, string numeroFactura, string digitosTarjeta_12, string numeroAprobacionPOS, string numeroCheque, string nombreBancoCheque, string numeroCuentaTransferencia, string nombreBancoTransferencia, int intercambioId, int nroPago, DateTime fechaPeriodoInicio, DateTime fechaPeriodoFin, decimal monto, DateTime fechaPago, string usuarioId, DateTime fecha, bool estado, SqlTransaction transaccion)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();
            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Direction = ParameterDirection.Output;
            lstParametros.Add(prmA);

            DbParameter prmAX = new SqlParameter();
            prmAX.DbType = DbType.Int32;
            prmAX.ParameterName = "@empresaId";
            prmAX.Value = empresaId;
            prmAX.Direction = ParameterDirection.Input;
            lstParametros.Add(prmAX);

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

            SQLConexion conProxy = new SQLConexion();
            if (conProxy.EjecutarDML(lstParametros, "vip.PagoEmpresa_Insertar", transaccion))
                return Convert.ToInt32(prmA.Value);
            return -1;

        }
        public bool Actualizar(int id, int empresaId, int clientePaqueteId, string concepto, string formaPago, string numeroFactura, string digitosTarjeta_12, string numeroAprobacionPOS, string numeroCheque, string nombreBancoCheque, string numeroCuentaTransferencia, string nombreBancoTransferencia, int intercambioId, int nroPago, DateTime fechaPeriodoInicio, DateTime fechaPeriodoFin, decimal monto, DateTime fechaPago, string usuarioId, DateTime fecha, bool estado)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmAX = new SqlParameter();
            prmAX.DbType = DbType.Int32;
            prmAX.ParameterName = "@empresaId";
            prmAX.Value = empresaId;
            prmAX.Direction = ParameterDirection.Input;
            lstParametros.Add(prmAX);

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

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.PagoEmpresa_Actualizar");
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
            return conProxy.EjecutarDML(lstParametros, "vip.PagoEmpresa_Eliminar");
        }
        public bool EliminarPago(int codigo, DateTime fechaPago)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@Id";
            prmA.Value = codigo;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            DbParameter prmB = new SqlParameter();
            prmB.DbType = DbType.DateTime;
            prmB.ParameterName = "@fechaPago";
            prmB.Value = fechaPago;
            prmB.Direction = ParameterDirection.Input;
            lstParametros.Add(prmB);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.PagoEmpresa_EliminarPago");
        }
        public bool Eliminar(int codigo, SqlTransaction transaccion)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@Id";
            prmA.Value = codigo;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarDML(lstParametros, "vip.PagoEmpresa_Eliminar", transaccion);
        }
        public DataSet TraerPagoEmpresas()
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta("select * from vip.PagoEmpresa");
        }
        public DataSet TraerPagoEmpresaXId(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoEmpresa_TraerXId");
        }
        public DataSet TraerPagoEmpresaXIdClientePaquete(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoEmpresa_TraerXIdClientePaquete");
        }
        public DataSet TraerPagoEmpresaXIdEmpresa(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoEmpresa_TraerXIdEmpresa");
        }
        public DataSet TraerPagoEmpresaXIdReporte(int id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.Int32;
            prmA.ParameterName = "@id";
            prmA.Value = id;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoEmpresa_TraerXIdPaqueteRecibo");
        }
        public DataSet TraerPagoEmpresaXCriterio(string nombre, string correo, string ci, string estado)
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
            prmD.ParameterName = "@nombrePersonaContacto";
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
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoEmpresa_TraerXCriterio");
        }
        public DataSet TraerXFiltro(string clienteId, DateTime fechaPagoInicio, DateTime fechaPagoFin, string grupoId, string formaPago, string paqueteId, string servicioId, string promocionId)
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
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoEmpresa_TraerXFiltro");
        }
        public DataSet TraerXPagoId(string id)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmAA = new SqlParameter();
            prmAA.DbType = DbType.String;
            prmAA.ParameterName = "@id";
            prmAA.Value = id;
            prmAA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmAA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoEmpresa_TraerPago");
        }
        public DataSet TraerXPagoIdFecha(string id, DateTime fecha)
        {
            List<DbParameter> lstParametros = new List<DbParameter>();

            DbParameter prmAA = new SqlParameter();
            prmAA.DbType = DbType.String;
            prmAA.ParameterName = "@id";
            prmAA.Value = id;
            prmAA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmAA);

            DbParameter prmA = new SqlParameter();
            prmA.DbType = DbType.DateTime;
            prmA.ParameterName = "@fecha";
            prmA.Value = fecha;
            prmA.Direction = ParameterDirection.Input;
            lstParametros.Add(prmA);

            SQLConexion conProxy = new SQLConexion();
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoEmpresa_TraerPagoFecha");
        }
        public DataSet TraerPagoEmpresaXCriterio(DateTime fechaPagoInicio, DateTime fechaPagoFin, string cajeroId)
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
            return conProxy.EjecutarConsulta(lstParametros, "vip.PagoEmpresa_TraerXCriterioCaja");
        }
    }
}
