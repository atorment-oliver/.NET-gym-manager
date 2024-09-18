using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class Parametro
    {
        #region Atributos
        private string id;
        private string nombre;
        private string valor;
        private bool visible;
        private DateTime fecha;
        private string usuario;
        private bool estado;
        #endregion
        #region Propiedades
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
       public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
        #endregion
        #region Metodos
        public Parametro()
        {
            id = string.Empty;
            nombre = string.Empty;
            valor = string.Empty;
            visible = false;
            fecha = DateTime.Now;
            estado = true;
            usuario = string.Empty;
        }
        public Parametro(string id, string nombre, string valor, bool visible, string usuario, DateTime fecha, bool estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.valor = valor;
            this.visible = visible;
            this.fecha = fecha;
            this.usuario = usuario;
            this.estado = estado;
        }
        #endregion
    }
}
