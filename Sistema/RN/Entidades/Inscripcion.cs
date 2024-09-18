using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class Inscripcion
    {
        #region Atributos
        private int id;
        private int clientePaqueteId;
        private int grupoId;
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
        public int ClientePaqueteId
        {
            get { return clientePaqueteId; }
            set { clientePaqueteId = value; }
        }
        public int GrupoId
        {
            get { return grupoId; }
            set { grupoId = value; }
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
        public Inscripcion()
        {
            id = -1;
            clientePaqueteId = -1;
            grupoId = -1;
            usuarioId = string.Empty;
            estado = true;
            fecha = DateTime.Now;

        }
        public Inscripcion(int id, int clientePaqueteId, int grupoId, bool estado, string usuarioId, DateTime fecha)
        {
            this.id = id;
            this.clientePaqueteId = clientePaqueteId;
            this.grupoId = grupoId;
            this.usuarioId = usuarioId;
            this.fecha = fecha;
            this.estado = estado;
        }
        #endregion
    }
}
