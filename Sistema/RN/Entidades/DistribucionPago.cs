using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class DistribucionPago
    {
        #region Atributos
        private int id;
        private int clienteId;
        private int porcentaje;
        private bool estado;
        private string usuarioId;
        private DateTime fecha;

        #endregion
        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int ClienteId
        {
            get { return clienteId; }
            set { clienteId = value; }
        }
        public int Porcentaje
        {
            get { return porcentaje; }
            set { porcentaje = value; }
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
        #endregion
        #region Metodos
        public DistribucionPago()
        {
            id = -1;
            clienteId = -1;
            porcentaje = -1;
            estado = true;
            usuarioId = string.Empty;
            estado = true;
            fecha = DateTime.Now;

        }
        public DistribucionPago(int id, int clienteId, int porcentaje, bool estado, string usuarioId, DateTime fecha)
        {
            this.id = id;
            this.clienteId = clienteId;
            this.porcentaje = porcentaje;
            this.usuarioId = usuarioId;
            this.fecha = fecha;
            this.estado = estado;
        }
        #endregion
    }
}
