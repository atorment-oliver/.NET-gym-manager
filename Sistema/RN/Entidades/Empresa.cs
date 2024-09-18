using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class Empresa
    {
        #region Atributos
        private int id;
        private string nombre;
        private string descripcion;
        private string nombrePersonaContacto;
        private string telefono;
        private string correo;
        private string direccion;
        private DateTime fechaRegistro;
        private string usuarioId;
        private DateTime fecha;
        private bool estado;

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
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string NombrePersonaContacto
        {
            get { return nombrePersonaContacto; }
            set { nombrePersonaContacto = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
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
        public Empresa()
        {
            id = -1;
            nombre = string.Empty;
            descripcion = string.Empty;
            nombrePersonaContacto = string.Empty;
            telefono = string.Empty;
            correo = string.Empty;
            direccion = string.Empty;
            fechaRegistro = DateTime.Now;
            usuarioId = string.Empty;
            fecha = DateTime.Now;
            estado = true;
        }
        public Empresa(int id, string nombre, string descripcion, string nombrePersonaContacto, string telefono, string correo, string direccion, DateTime fechaRegistro, string usuarioId, DateTime fecha, bool estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.nombrePersonaContacto = nombrePersonaContacto;
            this.telefono = telefono;
            this.correo = correo;
            this.direccion = direccion;
            this.fechaRegistro = fechaRegistro;
            this.usuarioId = usuarioId;
            this.fecha = fecha;
            this.estado = estado;
        }
        #endregion
    }
}
