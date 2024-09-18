using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RN.Entidades
{
    public class PagoCliente
    {
        #region Atributos
        private int id;
        private int clientePaqueteId;
        private string concepto;
        private string formaPago;
        private string numeroFactura;
        private string digitosTarjeta_12;
        private string numeroAprobacionPOS;
        private string numeroCheque;
        private string nombreBancoCheque;
        private string numeroCuentaTransferencia;
        private string nombreBancoTransferencia;
        private int intercambioId;
        private int nroPago;
        private DateTime fechaPeriodoInicio;
        private DateTime fechaPeriodoFin;
        private decimal monto;
        private DateTime fechaPago;
        private string usuarioId;
        private DateTime fecha;
        private bool estado;
        private int nroRecibo;
        #endregion
        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int ClientePaqueteId
        {
            get { return clientePaqueteId; }
            set { clientePaqueteId = value; }
        }
        public string Concepto
        {
            get { return concepto; }
            set { concepto = value; }
        }
        public string FormaPago
        {
            get { return formaPago; }
            set { formaPago = value; }
        }
        public string NumeroFactura
        {
            get { return numeroFactura; }
            set { numeroFactura = value; }
        }
        public string DigitosTarjeta_12
        {
            get { return digitosTarjeta_12; }
            set { digitosTarjeta_12 = value; }
        }
        public string NumeroAprobacionPOS
        {
            get { return numeroAprobacionPOS; }
            set { numeroAprobacionPOS = value; }
        }
        public string NumeroCheque
        {
            get { return numeroCheque; }
            set { numeroCheque = value; }
        }
        public string NombreBancoCheque
        {
            get { return nombreBancoCheque; }
            set { nombreBancoCheque = value; }
        }
        public string NumeroCuentaTransferencia
        {
            get { return numeroCuentaTransferencia; }
            set { numeroCuentaTransferencia = value; }
        }
        public string NombreBancoTransferencia
        {
            get { return nombreBancoTransferencia; }
            set { nombreBancoTransferencia = value; }
        }
        public int IntercambioId
        {
            get { return intercambioId; }
            set { intercambioId = value; }
        }
        public int NroPago
        {
            get { return nroPago; }
            set { nroPago = value; }
        }
        public DateTime FechaPeriodoInicio
        {
            get { return fechaPeriodoInicio; }
            set { fechaPeriodoInicio = value; }
        }
        public DateTime FechaPeriodoFin
        {
            get { return fechaPeriodoFin; }
            set { fechaPeriodoFin = value; }
        }
        public decimal Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        public DateTime FechaPago
        {
            get { return fechaPago; }
            set { fechaPago = value; }
        }
        public string UsuarioId
        {
            get { return usuarioId; }
            set { usuarioId = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public int NroRecibo
        {
            get { return nroRecibo; }
            set { nroRecibo = value; }
        }
        #endregion
        #region Metodos
        public PagoCliente()
        {
            id = -1;
            clientePaqueteId = -1;
            concepto = string.Empty;
            formaPago = string.Empty;
            numeroFactura = string.Empty;
            digitosTarjeta_12 = string.Empty;
            numeroAprobacionPOS = string.Empty;
            numeroCheque = string.Empty;
            nombreBancoCheque = string.Empty;
            numeroCuentaTransferencia = string.Empty;
            nombreBancoTransferencia = string.Empty;
            intercambioId = -1;
            nroPago = -1;
            fechaPeriodoInicio = DateTime.Now;
            fechaPeriodoFin = DateTime.Now;
            monto = -1;
            fechaPago = DateTime.Now;
            usuarioId = string.Empty;
            fecha = DateTime.Now;
            estado = false;
            nroRecibo = -1;
        }
        public PagoCliente(int id, int clientePaqueteId, string concepto, string formaPago, string numeroFactura, string digitosTarjeta_12, string numeroAprobacionPOS, string numeroCheque, string nombreBancoCheque, string numeroCuentaTransferencia, string nombreBancoTransferencia, int intercambioId, int nroPago, DateTime fechaPeriodoInicio, DateTime fechaPeriodoFin, decimal monto, DateTime fechaPago, string usuarioId, DateTime fecha, bool estado, int nroRecibo)
        {
            this.id = id;
            this.clientePaqueteId = clientePaqueteId;
            this.concepto = concepto;
            this.formaPago = formaPago;
            this.numeroFactura = numeroFactura;
            this.digitosTarjeta_12 = digitosTarjeta_12;
            this.numeroAprobacionPOS = numeroAprobacionPOS;
            this.numeroCheque = numeroCheque;
            this.nombreBancoCheque = nombreBancoCheque;
            this.numeroCuentaTransferencia = numeroCuentaTransferencia;
            this.nombreBancoTransferencia = nombreBancoTransferencia;
            this.intercambioId = intercambioId;
            this.nroPago = nroPago;
            this.fechaPeriodoInicio = fechaPeriodoInicio;
            this.fechaPeriodoFin = fechaPeriodoFin;
            this.monto = monto;
            this.fechaPago = fechaPago;
            this.usuarioId = usuarioId;
            this.fecha = fecha;
            this.estado = estado;
            this.nroRecibo = nroRecibo;
        }
        #endregion
    }
}
