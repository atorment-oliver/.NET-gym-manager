using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN.Entidades
{
    public class Grupo
    {
        #region Atributos

        private int id;
        private string nombre;
        private int horarioId;
        private int servicioId;
        private bool estado;
        private string usuarioId;
        private DateTime fecha;
        private List<GrupoDia> detalle;

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
        public int HorarioId
        {
            get { return horarioId; }
            set { horarioId = value; }
        }
        public int ServicioId
        {
            get { return servicioId; }
            set { servicioId = value; }
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
        public List<GrupoDia> Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }
        #endregion
        #region Metodos
        public Grupo()
        {
            id = -1;
            nombre = string.Empty;
            horarioId = -1;
            servicioId = -1;
            usuarioId = string.Empty;
            estado = true;
            fecha = DateTime.Now;
            detalle = new List<GrupoDia>();

        }
        public Grupo(int id, string nombre, int horarioId, int servicioId, bool estado, string usuarioId, DateTime fecha, List<GrupoDia> detalle)
        {
            this.id = id;
            this.nombre = nombre;
            this.horarioId = horarioId;
            this.servicioId = servicioId;
            this.usuarioId = usuarioId;
            this.fecha = fecha;
            this.estado = estado;
            this.detalle = detalle;
        }
        #endregion
    }
}
