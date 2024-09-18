using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class Unidad
    {
        #region Atributos
        private int id;
        private string nombre;
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
       
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
       
        #endregion
        #region Metodos
        public Unidad()
        {
            id = -1;
            nombre = string.Empty;
            estado = true;
        }
        public Unidad(int id, string nombre, bool estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.estado = estado;
        }
        #endregion
    }
}
