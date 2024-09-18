using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class Servicio
    {
        #region Atributos
        private int id;
        private string nombre;
        private bool restriccionHorario;
        private int cupo;
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
        public bool RestriccionHorario
        {
            get { return restriccionHorario; }
            set { restriccionHorario = value; }
        }
        public int Cupo
        {
            get { return cupo; }
            set { cupo = value; }
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
        public Servicio()
        {
            id = -1;
            nombre = string.Empty;
            restriccionHorario = true;
            cupo = -1;
            estado = true;
            usuarioId = string.Empty;
            estado = true;
            fecha = DateTime.Now;

        }
        public Servicio(int id, string nombre, bool restriccionHorario, int cupo, bool estado, string usuarioId, DateTime fecha)
        {
            this.id = id;
            this.nombre = nombre;
            this.restriccionHorario = restriccionHorario;
            this.cupo = cupo;
            this.usuarioId = usuarioId;
            this.fecha = fecha;
            this.estado = estado;
        }
        #endregion
    }
}
