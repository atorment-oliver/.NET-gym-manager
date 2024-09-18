using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class PromocionCliente
    {
        #region Atributos
        private int id;
        private int clientePaqueteId;
        private int promocionId;
        private DateTime fechaAsignacion;
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
        public int ClientePaqueteId
        {
            get { return clientePaqueteId; }
            set { clientePaqueteId = value; }
        }
        public int PromocionId
        {
            get { return promocionId; }
            set { promocionId = value; }
        }
        public DateTime FechaAsignacion
        {
            get { return fechaAsignacion; }
            set { fechaAsignacion = value; }
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
        public PromocionCliente()
        {
            id = -1;
            clientePaqueteId = -1;
            promocionId = -1;
            fechaAsignacion = DateTime.Now;
            usuarioId = string.Empty;
            estado = true;
            Fecha = DateTime.Now;
        }
        public PromocionCliente(int id, int clientePaqueteId, int promocionId, DateTime fechaAsignacion, bool estado, string usuarioId, DateTime fecha)
        {
            this.id = id;
            this.clientePaqueteId = clientePaqueteId;
            this.promocionId = promocionId;
            this.fechaAsignacion = fechaAsignacion;
            this.estado = estado;
            this.usuarioId = usuarioId;
            this.fecha = fecha;
        }
        #endregion
    }
}
