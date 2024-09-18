using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class TipoPaquete
    {
        #region Atributos
        private int id;
        private string nombre;
        private string limiteServicios;
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
        public string LimiteServicios
        {
            get { return limiteServicios; }
            set { limiteServicios = value; }
        }
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
       
        #endregion
        #region Metodos
        public TipoPaquete()
        {
            id = -1;
            nombre = string.Empty;
            limiteServicios = string.Empty;
            estado = true;
        }
        public TipoPaquete(int id, string nombre, string limiteServicios, bool estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.limiteServicios = limiteServicios;
            this.estado = estado;
        }
        #endregion
    }
}
