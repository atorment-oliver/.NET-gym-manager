using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class Licencia
    {
        #region Atributos
        private int id;
        private string descripcion;
        private int clientePaqueteId;
        private DateTime fechaSolicitud;
        private DateTime fechaInicioLicencia;
        private DateTime fechaFinLicencia;
        private string usuarioId;
        private bool estado;
        private DateTime fecha;
        #endregion
        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int ClientePaqueteId
        {
            get { return clientePaqueteId; }
            set { clientePaqueteId = value; }
        }
        public DateTime FechaSolicitud
        {
            get { return fechaSolicitud; }
            set { fechaSolicitud = value; }
        }
        public DateTime FechaInicioLicencia
        {
            get { return fechaInicioLicencia; }
            set { fechaInicioLicencia = value; }
        }
        public DateTime FechaFinLicencia
        {
            get { return fechaFinLicencia; }
            set { fechaFinLicencia = value; }
        }
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
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
        public Licencia()
        {
            id = -1;
            descripcion = string.Empty;
            clientePaqueteId = -1;
            fechaSolicitud = DateTime.Now;
            fechaInicioLicencia = DateTime.Now;
            fechaFinLicencia = DateTime.Now;
            usuarioId = string.Empty;
            estado = true;
            Fecha = DateTime.Now;
        }
        public Licencia(int id, string descripcion, int clientePaqueteId, DateTime fechaSolicitud, DateTime fechaInicioLicencia, DateTime fechaFinLicencia, bool estado, string usuarioId, DateTime fecha)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.clientePaqueteId = clientePaqueteId;
            this.fechaSolicitud = fechaSolicitud;
            this.fechaInicioLicencia = fechaInicioLicencia;
            this.fechaFinLicencia = fechaFinLicencia;
            this.estado = estado;
            this.usuarioId = usuarioId;
            this.fecha = fecha;
        }
        #endregion
    }
}
