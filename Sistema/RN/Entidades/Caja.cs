using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class Caja
    {
        #region Atributos
        private int id;
        private int numero;
        private string cajeroId;
        private DateTime fechaCreacion;
        private bool estado;
        #endregion
        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public string CajeroId
        {
            get { return cajeroId; }
            set { cajeroId = value; }
        }
        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
       
        #endregion
        #region Metodos
        public Caja()
        {
            id = -1;
            numero = -1;
            cajeroId = string.Empty;
            fechaCreacion = DateTime.Now;
            estado = true;
        }
        public Caja(int id, int numero, string cajeroId, DateTime fechaCreacion, bool estado)
        {
            this.id = id;
            this.numero = numero;
            this.cajeroId = cajeroId;
            this.fechaCreacion = fechaCreacion;
            this.estado = estado;
        }
        #endregion
    }
}
