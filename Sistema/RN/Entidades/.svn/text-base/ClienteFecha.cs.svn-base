using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class ClienteFecha
    {
        #region Atributos
        private int clienteId;
        private DateTime fechaInicio;
        private bool estado;
        private DateTime fecha;
        private string usuarioId;
        #endregion
        #region Propiedades
        public int ClienteId
        {
            get { return clienteId; }
            set { clienteId = value; }
        }
        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public string UsuarioId
        {
            get { return usuarioId; }
            set { usuarioId = value; }
        }
        #endregion
        #region Metodos
        public ClienteFecha()
        {
            clienteId = -1;
            fechaInicio = DateTime.Now;
            estado = true;
            fecha = DateTime.Now;
            usuarioId = string.Empty;
        }
        public ClienteFecha(int clienteId, DateTime fechaInicio, bool estado, DateTime fecha, string usuarioId)
        {
            this.clienteId = clienteId;
            this.fechaInicio = fechaInicio;
            this.estado = estado;
            this.fecha = fecha;
            this.usuarioId = usuarioId;
        }
        #endregion
    }
}
