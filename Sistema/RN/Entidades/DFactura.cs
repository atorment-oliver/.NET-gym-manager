using System;

namespace RN.Entidades
{
    public class DFactura
    {
        #region Atributos
        private int codigo;
        private int producto_id;
        private int cantidad;
        #endregion
        #region Propiedades
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public int Producto_id
        {
            get { return producto_id; }
            set { producto_id = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        #endregion
        #region Metodos
        public DFactura()
        {
            codigo = -1;
            producto_id = -1;
            cantidad = 0;
        }
        #endregion
    }
}
