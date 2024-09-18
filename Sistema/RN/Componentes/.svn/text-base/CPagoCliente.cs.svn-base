using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CPagoCliente
    {
        #region DMLS
        public static bool Insertar(PagoCliente objProxy, int clienteid)
        {
            ValidationException x = new ValidationException();
            if (objProxy.ClientePaqueteId < 0)
                x.AgregarError("Ingrese el codigo de clientepaquete");

            if (x.Cantidad > 0)
                throw x;

            DAOPagoCliente daoProxy = new DAOPagoCliente();
            return daoProxy.Insertar(objProxy.ClientePaqueteId, objProxy.Concepto, objProxy.FormaPago, objProxy.NumeroFactura, objProxy.DigitosTarjeta_12, objProxy.NumeroAprobacionPOS, objProxy.NumeroCheque, objProxy.NombreBancoCheque, objProxy.NumeroCuentaTransferencia, objProxy.NombreBancoTransferencia, objProxy.IntercambioId, objProxy.NroPago, objProxy.FechaPeriodoInicio, objProxy.FechaPeriodoFin, objProxy.Monto, objProxy.FechaPago, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado, clienteid, objProxy.NroRecibo) > 0;
        }
        public static int InsertarId(PagoCliente objProxy, int clienteid)
        {
            ValidationException x = new ValidationException();
            if (objProxy.ClientePaqueteId < 0)
                x.AgregarError("Ingrese el codigo de clientepaquete");

            if (x.Cantidad > 0)
                throw x;

            DAOPagoCliente daoProxy = new DAOPagoCliente();
            return daoProxy.Insertar(objProxy.ClientePaqueteId, objProxy.Concepto, objProxy.FormaPago, objProxy.NumeroFactura, objProxy.DigitosTarjeta_12, objProxy.NumeroAprobacionPOS, objProxy.NumeroCheque, objProxy.NombreBancoCheque, objProxy.NumeroCuentaTransferencia, objProxy.NombreBancoTransferencia, objProxy.IntercambioId, objProxy.NroPago, objProxy.FechaPeriodoInicio, objProxy.FechaPeriodoFin, objProxy.Monto, objProxy.FechaPago, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado, clienteid, objProxy.NroRecibo);
        }
        public static bool Actualizar(PagoCliente objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (objProxy.ClientePaqueteId < 0)
                x.AgregarError("Ingrese el codigo de clientepaquete");

            if (x.Cantidad > 0)
                throw x;

            DAOPagoCliente daoProxy = new DAOPagoCliente();
            return daoProxy.Actualizar(objProxy.Id, objProxy.ClientePaqueteId, objProxy.Concepto, objProxy.FormaPago, objProxy.NumeroFactura, objProxy.DigitosTarjeta_12, objProxy.NumeroAprobacionPOS, objProxy.NumeroCheque, objProxy.NombreBancoCheque, objProxy.NumeroCuentaTransferencia, objProxy.NombreBancoTransferencia, objProxy.IntercambioId, objProxy.NroPago, objProxy.FechaPeriodoInicio, objProxy.FechaPeriodoFin, objProxy.Monto, objProxy.FechaPago, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado);
        }
        public static bool EliminarPagoCliente(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOPagoCliente daoProxy = new DAOPagoCliente();
            return daoProxy.Eliminar(codigo);
        }
       
        #endregion
        #region Selects
        public static List<PagoCliente> Traer()
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            DataSet dtsProxy = daoProxy.TraerPagoClientes();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<PagoCliente> TraerXId(int codigo)
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            DataSet dtsProxy = daoProxy.TraerPagoClienteXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<PagoCliente> TraerXIdClientePaquete(int codigo, int clientepaquete)
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            DataSet dtsProxy = daoProxy.TraerPagoClienteXIdPaquete(codigo, clientepaquete);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXIdClientePaqueteD(int codigo, int clientepaquete)
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            DataSet dtsProxy = daoProxy.TraerPagoClienteXIdPaqueteD(codigo, clientepaquete);

            return dtsProxy.Tables[0];
        }
        public static DataTable TraerXIdClientePaqueteData(int codigo, int clientepaquete)
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            DataSet dtsProxy = daoProxy.TraerPagoClienteXIdPaquete(codigo, clientepaquete);

            return dtsProxy.Tables[0];
        }
        public static DataTable TraerXIdClientePaqueteDataCliente(int codigo, int clientepaquete)
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            DataSet dtsProxy = daoProxy.TraerPagoClienteXIdPaqueteCliente(codigo, clientepaquete);

            return dtsProxy.Tables[0];
        }
        public static DataTable TraerRecibos(int codigo)
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            DataSet dtsProxy = daoProxy.TraerRecibos(codigo);

            return dtsProxy.Tables[0];
        }
        public static DataTable TraerRecibosCaja(string codigo)
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            DataSet dtsProxy = daoProxy.TraerRecibosCaja(codigo);

            return dtsProxy.Tables[0];
        }
        public static List<PagoCliente> TraerXCriterio(string nombre, string correo, string ci, string estado)
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            DataSet dtsProxy = daoProxy.TraerPagoClienteXCriterio(nombre, correo, ci, estado);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<PagoCliente> TraerXCriterio(DateTime fechaPagoInicio, DateTime fechaPagoFin, string cajeroId)
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            DataSet dtsProxy = daoProxy.TraerPagoClienteXCriterio(fechaPagoInicio, fechaPagoFin, cajeroId);
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXFechaPago(DateTime fechaPagoInicio, DateTime fechaPagoFin)
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            return daoProxy.TraerPagoClienteXFechaPago(fechaPagoInicio, fechaPagoFin).Tables[0];
        }
        public static DataTable TraerXFiltro(string clienteId, DateTime fechaPagoInicio, DateTime fechaPagoFin, string empresaId, string grupoId, string formaPago, string paqueteId, string servicioId, string promocionId)
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            return daoProxy.TraerXFiltro(clienteId, fechaPagoInicio, fechaPagoFin, empresaId, grupoId, formaPago, paqueteId, servicioId, promocionId).Tables[0];
        }
        public static DataTable TraerXCaja(DateTime fechaCaja, DateTime fechaCierreCaja, string usuarioId, int id)
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            return daoProxy.TraerPagoClienteXCaja(fechaCaja, fechaCierreCaja, usuarioId, id).Tables[0];
        }
        public static DataTable TraerXOrCriterioEmpresa(string nombre, string correo, string ci, string estado)
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            DataSet dtsProxy = daoProxy.TraerPagoClienteXCriterio(nombre, correo, ci, estado);


            return dtsProxy.Tables[0];
        }
        public static DataTable TraerXCriterioData(string nombre, string nombrePersonaContacto, string correo, string estado)
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            DataSet dtsProxy = daoProxy.TraerPagoClienteXCriterio(nombre, nombrePersonaContacto, correo, estado);


            return (dtsProxy.Tables[0]);
        }
        public static int TraerMaximoRecibo()
        {
            DAOPagoCliente daoProxy = new DAOPagoCliente();
            return Convert.ToInt32(daoProxy.TraerMaximoRecibo().Tables[0].Rows[0][0].ToString());
        }
        #endregion
        #region Metodos Privados
        private static List<PagoCliente> CargarLista(DataTable tabla)
        {
            List<PagoCliente> lstProxy = new List<PagoCliente>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static PagoCliente Cargar(DataRow fila)
        {
            PagoCliente objProxy = new PagoCliente();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.ClientePaqueteId = Convert.ToInt32(fila["clientePaqueteId"].ToString());
            objProxy.Concepto = fila["concepto"].ToString();
            objProxy.FormaPago = fila["formaPago"].ToString();
            if (String.IsNullOrEmpty(fila["numeroFactura"].ToString()))
                objProxy.NumeroFactura = "0";
            else
                objProxy.NumeroFactura = fila["numeroFactura"].ToString();
            objProxy.DigitosTarjeta_12 = fila["digitosTarjeta_12"].ToString();
            objProxy.NumeroAprobacionPOS = fila["numeroAprobacionPOS"].ToString();
            objProxy.NumeroCheque = fila["numeroCheque"].ToString();
            objProxy.NombreBancoCheque = fila["nombreBancoCheque"].ToString();
            objProxy.NumeroCuentaTransferencia = fila["numeroCuentaTransferencia"].ToString();
            objProxy.NombreBancoTransferencia = fila["nombreBancoTransferencia"].ToString();
            objProxy.IntercambioId = Convert.ToInt32(fila["intercambioId"].ToString());
            objProxy.NroPago = Convert.ToInt32(fila["nroPago"].ToString());
            objProxy.FechaPeriodoInicio = Convert.ToDateTime(fila["fechaPeriodoInicio"].ToString());
            objProxy.FechaPeriodoFin = Convert.ToDateTime(fila["fechaPeriodoFin"].ToString());
            objProxy.Monto = Convert.ToDecimal(fila["monto"].ToString());
            objProxy.FechaPago = Convert.ToDateTime(fila["fechaPago"].ToString());
            objProxy.UsuarioId = fila["usuarioId"].ToString();
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());
            objProxy.NroRecibo = Convert.ToInt32(fila["nroRecibo"].ToString());
            return objProxy;
        }
        #endregion
    }
}
