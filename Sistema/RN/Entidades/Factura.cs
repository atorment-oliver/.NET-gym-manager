using System;
using System.Collections.Generic;

namespace RN.Entidades
{
    public class Factura
    {
        #region Atributos
        private int codigo;
        private DateTime fecha;
        private string nombreFactura;
        private string nitFactura;
        private List<DFactura> detalle;
        #endregion
        #region Propiedades
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public string NombreFactura
        {
            get { return nombreFactura; }
            set { nombreFactura = value; }
        }
        public string NitFactura
        {
            get { return nitFactura; }
            set { nitFactura = value; }
        }
        public List<DFactura> Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }
        #endregion
        #region Metodos
        public Factura()
        {
            codigo = -1;
            fecha = DateTime.Now;
            nombreFactura = string.Empty;
            nitFactura = string.Empty;
            detalle = new List<DFactura>();
        }
        #endregion
    }
}
