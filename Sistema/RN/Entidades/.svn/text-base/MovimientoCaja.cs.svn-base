using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class MovimientoCaja
    {
        #region Atributos
        private int id;
        private int cajaId;
        private DateTime fechaHoraApertura;
        private decimal montoAperturaBob;
        private decimal montoAperturaSus;
        private DateTime? fechaHoraCierre;
        private decimal montoCierreBob;
        private decimal montoCierreSus;
        private decimal montoAdministracionBob;
        private decimal montoAdministracionSus;
        private decimal tipoCambio;
        private string observacion;
        private string usuarioId;
        private DateTime fecha;
        private bool estado;
        private bool observado;
        private decimal montoCorregido;
        private string observacionAdm;
        private decimal montoCorregidoSus;

        #endregion
        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int CajaId
        {
            get { return cajaId; }
            set { cajaId = value; }
        }
        public DateTime FechaHoraApertura
        {
            get { return fechaHoraApertura; }
            set { fechaHoraApertura = value; }
        }
        public decimal MontoAperturaBob
        {
            get { return montoAperturaBob; }
            set { montoAperturaBob = value; }
        }
        public decimal MontoAperturaSus
        {
            get { return montoAperturaSus; }
            set { montoAperturaSus = value; }
        }
        public DateTime? FechaHoraCierre
        {
            get { return fechaHoraCierre; }
            set { fechaHoraCierre = value; }
        }
        public decimal MontoCierreBob
        {
            get { return montoCierreBob; }
            set { montoCierreBob = value; }
        }
        public decimal MontoCierreSus
        {
            get { return montoCierreSus; }
            set { montoCierreSus = value; }
        }
        public decimal MontoAdministracionBob
        {
            get { return montoAdministracionBob; }
            set { montoAdministracionBob = value; }
        }
        public decimal MontoAdministracionSus
        {
            get { return montoAdministracionSus; }
            set { montoAdministracionSus = value; }
        }
        public decimal TipoCambio
        {
            get { return tipoCambio; }
            set { tipoCambio = value; }
        }
        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
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
        public bool Observado
        {
            get { return observado; }
            set { observado = value; }
        }
        public decimal MontoCorregido
        {
            get { return montoCorregido; }
            set { montoCorregido = value; }
        }
        public string ObservacionAdm
        {
            get { return observacionAdm; }
            set { observacionAdm = value; }
        }
        public decimal MontoCorregidoSus
        {
            get { return montoCorregidoSus; }
            set { montoCorregidoSus = value; }
        }
        #endregion
        #region Metodos
        public MovimientoCaja()
        {
            id = -1;
            cajaId = -1;
            fechaHoraApertura = DateTime.Now;
            montoAperturaBob = 0;
            montoAperturaSus = 0;
            fechaHoraCierre = DateTime.Now;
            montoCierreBob = 0;
            montoCierreSus = 0;
            montoAdministracionBob = 0;
            montoAdministracionSus = 0;
            tipoCambio = 0;
            observacion = string.Empty;
            usuarioId = string.Empty;
            fecha = DateTime.Now;
            estado = true;
            observado = false;
            montoCorregido = 0;
            observacionAdm = string.Empty;
            montoCorregidoSus = 0;
        }
        public MovimientoCaja(int id, int cajaId, DateTime fechaHoraApertura, decimal montoAperturaBob, decimal montoAperturaSus, DateTime fechaHoraCierre, decimal montoCierreBob, decimal montoCierreSus, decimal montoAdministracionBob, decimal montoAdministracionSus, string observacion, decimal tipoCambio, string usuarioId, DateTime fecha, bool estado)
        {
            this.id = id;
            this.cajaId = cajaId;
            this.fechaHoraApertura = fechaHoraApertura;
            this.montoAperturaBob = montoAperturaBob;
            this.montoAperturaSus = montoAperturaSus;
            this.fechaHoraCierre = fechaHoraCierre;
            this.montoCierreBob = montoCierreBob;
            this.montoCierreSus = montoCierreSus;
            this.montoAdministracionBob = montoAdministracionBob;
            this.montoAdministracionSus = montoAdministracionSus;
            this.observacion = observacion;
            this.tipoCambio = tipoCambio;
            this.usuarioId = usuarioId;
            this.fecha = fecha;
            this.estado = estado;
            observado = false;
            montoCorregido = 0;
            observacionAdm = string.Empty;
            montoCorregidoSus = 0;
        }
        #endregion
    }
}
