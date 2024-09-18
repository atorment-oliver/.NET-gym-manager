using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class Paquete
    {
        #region Atributos
        private int id;
        private string nombre;
        private int unidadId;
        private int tiempo;
        private int tipoPaqueteId;
        private double precio;
        private string diasValidez;
        private DateTime fechaRegistro;
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
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int UnidadId
        {
            get { return unidadId; }
            set { unidadId = value; }
        }
        public int Tiempo
        {
            get { return tiempo; }
            set { tiempo = value; }
        }
        public int TipoPaqueteId
        {
            get { return tipoPaqueteId; }
            set { tipoPaqueteId = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public string DiasValidez
        {
            get { return diasValidez; }
            set { diasValidez = value; }
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
        #endregion
        #region Metodos
        public Paquete()
        {
            id = -1;
            nombre = string.Empty;
            unidadId = -1;
            tiempo = -1;
            tipoPaqueteId = -1;
            precio = -1;
            diasValidez = string.Empty;
            fechaRegistro = DateTime.Now;
            estado = true;
            usuarioId = string.Empty;
            estado = true;
            fecha = DateTime.Now;

        }
        public Paquete(int id, string nombre, int unidadId, int tiempo, int tipoPaqueteId, double precio, string diasValidez, DateTime fechaRegistro, bool estado, string usuarioId, DateTime fecha)
        {
            this.id = id;
            this.nombre = nombre;
            this.unidadId = unidadId;
            this.tiempo = tiempo;
            this.tipoPaqueteId = tipoPaqueteId;
            this.precio = precio;
            this.diasValidez = diasValidez;
            this.fechaRegistro = fechaRegistro;
            this.usuarioId = usuarioId;
            this.fecha = fecha;
            this.estado = estado;
        }
        #endregion
    }
}
