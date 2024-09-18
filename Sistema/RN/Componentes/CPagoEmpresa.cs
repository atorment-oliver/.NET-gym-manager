using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CPagoEmpresa
    {
        #region DMLS
        public static bool Insertar(PagoEmpresa objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.ClientePaqueteId < 0)
                x.AgregarError("Ingrese el codigo de clientepaquete");

            if (x.Cantidad > 0)
                throw x;

            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            return daoProxy.Insertar(objProxy.EmpresaId, objProxy.ClientePaqueteId, objProxy.Concepto, objProxy.FormaPago, objProxy.NumeroFactura, objProxy.DigitosTarjeta_12, objProxy.NumeroAprobacionPOS, objProxy.NumeroCheque, objProxy.NombreBancoCheque, objProxy.NumeroCuentaTransferencia, objProxy.NombreBancoTransferencia, objProxy.IntercambioId, objProxy.NroPago, objProxy.FechaPeriodoInicio, objProxy.FechaPeriodoFin, objProxy.Monto, objProxy.FechaPago, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado) > 0;
        }
        public static int InsertarId(PagoEmpresa objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.ClientePaqueteId < 0)
                x.AgregarError("Ingrese el codigo de clientepaquete");

            if (x.Cantidad > 0)
                throw x;

            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            return daoProxy.Insertar(objProxy.EmpresaId, objProxy.ClientePaqueteId, objProxy.Concepto, objProxy.FormaPago, objProxy.NumeroFactura, objProxy.DigitosTarjeta_12, objProxy.NumeroAprobacionPOS, objProxy.NumeroCheque, objProxy.NombreBancoCheque, objProxy.NumeroCuentaTransferencia, objProxy.NombreBancoTransferencia, objProxy.IntercambioId, objProxy.NroPago, objProxy.FechaPeriodoInicio, objProxy.FechaPeriodoFin, objProxy.Monto, objProxy.FechaPago, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado);
        }
        public static bool Actualizar(PagoEmpresa objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.EmpresaId <= 0)
                x.AgregarError("Ingrese el código");

            if (objProxy.ClientePaqueteId < 0)
                x.AgregarError("Ingrese el codigo de clientepaquete");

            if (x.Cantidad > 0)
                throw x;

            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            return daoProxy.Actualizar(objProxy.Id, objProxy.EmpresaId, objProxy.ClientePaqueteId, objProxy.Concepto, objProxy.FormaPago, objProxy.NumeroFactura, objProxy.DigitosTarjeta_12, objProxy.NumeroAprobacionPOS, objProxy.NumeroCheque, objProxy.NombreBancoCheque, objProxy.NumeroCuentaTransferencia, objProxy.NombreBancoTransferencia, objProxy.IntercambioId, objProxy.NroPago, objProxy.FechaPeriodoInicio, objProxy.FechaPeriodoFin, objProxy.Monto, objProxy.FechaPago, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado);
        }
        public static bool EliminarPagoEmpresa(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            return daoProxy.Eliminar(codigo);
        }
        public static bool EliminarPagoEmpresa(int codigo, DateTime fechaPago)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            return daoProxy.EliminarPago(codigo, fechaPago);
        }
        #endregion
        #region Selects
        public static List<PagoEmpresa> Traer()
        {
            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            DataSet dtsProxy = daoProxy.TraerPagoEmpresas();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<PagoEmpresa> TraerXId(int codigo)
        {
            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            DataSet dtsProxy = daoProxy.TraerPagoEmpresaXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<PagoEmpresa> TraerXIdClientePaquete(int codigo)
        {
            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            DataSet dtsProxy = daoProxy.TraerPagoEmpresaXIdClientePaquete(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<PagoEmpresa> TraerXIdEmpresa(int codigo)
        {
            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            DataSet dtsProxy = daoProxy.TraerPagoEmpresaXIdEmpresa(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<PagoEmpresa> TraerXCriterio(string nombre, string correo, string ci, string estado)
        {
            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            DataSet dtsProxy = daoProxy.TraerPagoEmpresaXCriterio(nombre, correo, ci, estado);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<PagoEmpresa> TraerXCriterio(DateTime fechaPagoInicio, DateTime fechaPagoFin, string cajeroId)
        {
            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            DataSet dtsProxy = daoProxy.TraerPagoEmpresaXCriterio(fechaPagoInicio, fechaPagoFin, cajeroId);
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXOrCriterioEmpresa(string nombre, string correo, string ci, string estado)
        {
            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            DataSet dtsProxy = daoProxy.TraerPagoEmpresaXCriterio(nombre, correo, ci, estado);


            return dtsProxy.Tables[0];
        }
        public static DataTable TraerXCriterioData(string nombre, string nombrePersonaContacto, string correo, string estado)
        {
            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            DataSet dtsProxy = daoProxy.TraerPagoEmpresaXCriterio(nombre, nombrePersonaContacto, correo, estado);


            return (dtsProxy.Tables[0]);
        }
        public static DataTable TraerXIdReporte(int codigo)
        {
            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            DataSet dtsProxy = daoProxy.TraerPagoEmpresaXId(codigo);


            return (dtsProxy.Tables[0]);
        }
        public static DataTable TraerXFiltro(string clienteId, DateTime fechaPagoInicio, DateTime fechaPagoFin, string grupoId, string formaPago, string paqueteId, string servicioId, string promocionId)
        {
            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            return daoProxy.TraerXFiltro(clienteId, fechaPagoInicio, fechaPagoFin, grupoId, formaPago, paqueteId, servicioId, promocionId).Tables[0];
        }
        public static DataTable TraerXPagoId(string id)
        {
            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            return daoProxy.TraerXPagoId(id).Tables[0];
        }
        public static DataTable TraerXPagoIdFecha(string id, DateTime fecha)
        {
            DAOPagoEmpresa daoProxy = new DAOPagoEmpresa();
            return daoProxy.TraerXPagoIdFecha(id, fecha).Tables[0];
        }
        #endregion
        #region Metodos Privados
        private static List<PagoEmpresa> CargarLista(DataTable tabla)
        {
            List<PagoEmpresa> lstProxy = new List<PagoEmpresa>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static PagoEmpresa Cargar(DataRow fila)
        {
            PagoEmpresa objProxy = new PagoEmpresa();
            objProxy.EmpresaId = Convert.ToInt32(fila["empresaId"]);
            objProxy.ClientePaqueteId = Convert.ToInt32(fila["clientePaqueteId"].ToString());
            objProxy.Concepto = fila["concepto"].ToString();
            objProxy.FormaPago = fila["formaPago"].ToString();
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
            return objProxy;
        }
        #endregion
    }
}
