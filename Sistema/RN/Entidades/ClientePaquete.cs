using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class ClientePaquete
    {
        #region Atributos
        private int id;
        private int clienteId;
        private int paqueteId;
        private DateTime fechaRegistro;
        private bool estado;
        private string usuarioId;
        private int adicional;
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
        public int PaqueteId
        {
            get { return paqueteId; }
            set { paqueteId = value; }
        }
        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
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
        public int Adicional
        {
            get { return adicional; }
            set { adicional = value; }
        }
        #endregion
        #region Metodos
        public ClientePaquete()
        {
            id = -1;
            clienteId = -1;
            paqueteId = -1;
            fechaRegistro = DateTime.Now;
            estado = true;
            usuarioId = string.Empty;
            estado = true;
            fecha = DateTime.Now;
            adicional = -1;
        }
        public ClientePaquete(int id, int clienteId, int paqueteId, DateTime fechaRegistro, bool estado, string usuarioId, DateTime fecha, int adicional)
        {
            this.id = id;
            this.clienteId = clienteId;
            this.paqueteId = paqueteId;
            this.fechaRegistro = fechaRegistro;
            this.usuarioId = usuarioId;
            this.fecha = fecha;
            this.estado = estado;
            this.adicional = adicional;
        }
        #endregion
    }
}
