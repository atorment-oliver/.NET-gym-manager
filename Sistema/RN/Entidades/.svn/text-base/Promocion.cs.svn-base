using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class Promocion
    {
        #region Atributos
        private int id;
        private string nombre;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private decimal montoDescuento;
        private string usuarioId;
        private bool estado;
        private DateTime fecha;
        private bool mensual;
        #endregion
        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }
        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }
        public decimal MontoDescuento
        {
            get { return montoDescuento; }
            set { montoDescuento = value; }
        }
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public bool Mensual
        {
            get { return mensual; }
            set { mensual = value; }
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
        #endregion
        #region Metodos
        public Promocion()
        {
            id = -1;
            nombre = string.Empty;
            fechaInicio = DateTime.Now;
            fechaFin = DateTime.Now;
            montoDescuento = -1;
            usuarioId = string.Empty;
            estado = true;
            Fecha = DateTime.Now;
            mensual = true;
        }
        public Promocion(int id, string nombre, DateTime fechaInicio, DateTime fechaFin, decimal montoDescuento, bool estado, string usuarioId, DateTime fecha, bool mensual)
        {
            this.id = id;
            this.nombre = nombre;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.montoDescuento = montoDescuento;
            this.estado = estado;
            this.usuarioId = usuarioId;
            this.fecha = fecha;
            this.mensual = mensual;
        }
        #endregion
    }
}
