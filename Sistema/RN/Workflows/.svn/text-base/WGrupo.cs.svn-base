using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Workflows
{
    public class WGrupo
    {
        #region DMLS
        public static bool Insertar(Grupo objProxy, Servicio objServicio)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Fecha < DateTime.Now.AddDays(-1))
                x.AgregarError("La fecha debe ser mayor a la fecha actual");

            if (objProxy.Detalle.Count < 1)
                x.AgregarError("No ingresó el detalle");


            foreach (GrupoDia detalle in objProxy.Detalle)
            {
                if (detalle.DiaId <= 0)
                    x.AgregarError("Alguno de los elementos del detalle presentan problemas.");
            }
            if(objServicio.Nombre.ToString() == "")
                x.AgregarError("No ingresó el nombre del servicio");
            if (objServicio.Cupo < 0)
                x.AgregarError("No ingresó el cupo del servicio");
            if (x.Cantidad > 0)
                throw x;

            // Paso el detalle a un DataSet para enviarlo a la CAD
            DataSet dtsDetalle = Set(objProxy.Detalle);
            CAD.WorkFlows.WFLGrupo wflProxy = new CAD.WorkFlows.WFLGrupo();
            return wflProxy.Insertar(objProxy.Nombre, objProxy.HorarioId, objProxy.ServicioId,objProxy.Estado,objProxy.UsuarioId, objProxy.Fecha, objServicio.Nombre, objServicio.RestriccionHorario,objServicio.Cupo, objServicio.Estado, objServicio.UsuarioId, objServicio.Fecha, dtsDetalle) > 0;
        }
        public static bool InsertarGrupoActualizarServicio(Grupo objProxy, Servicio objServicio)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Fecha < DateTime.Now.AddDays(-1))
                x.AgregarError("La fecha debe ser mayor a la fecha actual");

            if (objProxy.Detalle.Count < 1)
                x.AgregarError("No ingresó el detalle");


            foreach (GrupoDia detalle in objProxy.Detalle)
            {
                if (detalle.DiaId <= 0)
                    x.AgregarError("Alguno de los elementos del detalle presentan problemas.");
            }
            if (objServicio.Nombre.ToString() == "")
                x.AgregarError("No ingresó el nombre del servicio");
            if (objServicio.Cupo < 0)
                x.AgregarError("No ingresó el cupo del servicio");
            if (x.Cantidad > 0)
                throw x;

            // Paso el detalle a un DataSet para enviarlo a la CAD
            DataSet dtsDetalle = Set(objProxy.Detalle);
            CAD.WorkFlows.WFLGrupo wflProxy = new CAD.WorkFlows.WFLGrupo();
            return wflProxy.InsertarGrupoActualizarServicio(objProxy.Nombre, objProxy.HorarioId, objProxy.ServicioId, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha, objServicio.Id, objServicio.Nombre, objServicio.RestriccionHorario, objServicio.Cupo, objServicio.Estado, objServicio.UsuarioId, objServicio.Fecha, dtsDetalle);
        }
        public static bool InsertarServicioActualizarGrupo(Grupo objProxy, Servicio objServicio)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Fecha < DateTime.Now.AddDays(-1))
                x.AgregarError("La fecha debe ser mayor a la fecha actual");

            if (objProxy.Detalle.Count < 1)
                x.AgregarError("No ingresó el detalle");


            foreach (GrupoDia detalle in objProxy.Detalle)
            {
                if (detalle.DiaId <= 0)
                    x.AgregarError("Alguno de los elementos del detalle presentan problemas.");
            }
            if (objServicio.Nombre.ToString() == "")
                x.AgregarError("No ingresó el nombre del servicio");
            if (objServicio.Cupo < 0)
                x.AgregarError("No ingresó el cupo del servicio");
            if (x.Cantidad > 0)
                throw x;

            // Paso el detalle a un DataSet para enviarlo a la CAD
            DataSet dtsDetalle = Set(objProxy.Detalle);
            CAD.WorkFlows.WFLGrupo wflProxy = new CAD.WorkFlows.WFLGrupo();
            return wflProxy.InsertarServicioActualizarGrupo(objProxy.Id ,objProxy.Nombre, objProxy.HorarioId, objProxy.ServicioId, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha, objServicio.Nombre, objServicio.RestriccionHorario, objServicio.Cupo, objServicio.Estado, objServicio.UsuarioId, objServicio.Fecha, dtsDetalle);
        }
        public static bool Actualizar(Grupo objProxy, Servicio objServicio)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Fecha < DateTime.Now.AddDays(-1))
                x.AgregarError("La fecha debe ser mayor a la fecha actual");

            if (objProxy.Detalle.Count < 1)
                x.AgregarError("No ingresó el detalle");

            if (objServicio.Nombre.ToString() == "")
                x.AgregarError("No ingresó el nombre del servicio");
            if (objServicio.Cupo < 0)
                x.AgregarError("No ingresó el cupo del servicio");
            if (objServicio.Id <= 0)
                x.AgregarError("No ingresó id del servicio");
            foreach (GrupoDia detalle in objProxy.Detalle)
            {
                if (detalle.DiaId <= 0)
                    x.AgregarError("Alguno de los elementos del detalle presentan problemas.");
            }

            if (x.Cantidad > 0)
                throw x;

            // Paso el detalle a un DataSet para enviarlo a la CAD
            DataSet dtsDetalle = Set(objProxy.Detalle);
            CAD.WorkFlows.WFLGrupo wflProxy = new CAD.WorkFlows.WFLGrupo();
            return wflProxy.Actualizar(objProxy.Id, objProxy.Nombre, objProxy.HorarioId, objProxy.ServicioId, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha, objServicio.Id, objServicio.Nombre, objServicio.RestriccionHorario, objServicio.Cupo, objServicio.Estado, objServicio.UsuarioId, objServicio.Fecha, dtsDetalle);
        }
        #endregion
        public static Grupo TraerXId(int codigo)
        {
            DAOFactura daoProxy = new DAOFactura();
            DataSet dtsProxy = daoProxy.TraerFacturaXId(codigo);

            return Cargar(dtsProxy.Tables[0].Rows[0], dtsProxy.Tables[1]);
        }
        #region Metodos Privados
        private static List<Grupo> CargarLista(DataTable tabla)
        {
            List<Grupo> lstProxy = new List<Grupo>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static List<GrupoDia> CargarListaDetalle(DataTable tabla)
        {
            List<GrupoDia> lstProxy = new List<GrupoDia>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(CargarDetalle(fila));
            }
            return lstProxy;
        }
        private static Grupo Cargar(DataRow fila)
        {
            Grupo objProxy = new Grupo();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Nombre = fila["nombre"].ToString();
            objProxy.HorarioId = Convert.ToInt32(fila["horarioId"].ToString());
            objProxy.ServicioId = Convert.ToInt32(fila["servicioId"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());

            objProxy.Detalle = null;

            return objProxy;
        }
        private static Grupo Cargar(DataRow fila, DataTable detalle)
        {
            Grupo objProxy = new Grupo();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Nombre = fila["nombre"].ToString();
            objProxy.HorarioId = Convert.ToInt32(fila["horarioId"].ToString());
            objProxy.ServicioId = Convert.ToInt32(fila["servicioId"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());

            objProxy.Detalle = CargarListaDetalle(detalle);

            return objProxy;
        }
        private static GrupoDia CargarDetalle(DataRow fila)
        {
            GrupoDia objProxy = new GrupoDia();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.GrupoId = Convert.ToInt32(fila["grupoId"].ToString());
            objProxy.DiaId = Convert.ToInt32(fila["diaId"].ToString());
            return objProxy;
        }
        private static DataSet Set(List<GrupoDia> detalle)
        {
            DataSet dtsDetalle = new DataSet();
            DataTable tblProxy = dtsDetalle.Tables.Add();
            tblProxy.Columns.Add("grupoId", typeof(Int32));
            tblProxy.Columns.Add("diaId", typeof(Int32));

            foreach (GrupoDia item in detalle)
            {
                tblProxy.Rows.Add(item.GrupoId, item.DiaId);
            }
            return dtsDetalle;
        }
        #endregion
    }
}
