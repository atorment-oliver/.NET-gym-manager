using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Workflows
{
    public class WCliente
    {
        #region DMLS
        public static bool Insertar(List<RN.Entidades.ClienteDistribucion> objProxys)
        {
            ValidationException x = new ValidationException();
            bool bRetorno = true;
            foreach (RN.Entidades.ClienteDistribucion objProxy in objProxys)
            {
                if (string.IsNullOrEmpty(objProxy.Nombre))
                {
                    x.AgregarError("Ingrese el nombre del Cliente");
                    bRetorno = false;
                }

                if (x.Cantidad > 0)
                {
                    bRetorno = false;
                    throw x;
                }

                // Paso el detalle a un DataSet para enviarlo a la CAD
                CAD.WorkFlows.WFLCliente wflProxy = new CAD.WorkFlows.WFLCliente();
                bRetorno = bRetorno & wflProxy.Insertar(objProxy.Nombre, objProxy.Apellidos, objProxy.Direccion, objProxy.Telefono, objProxy.Celular, objProxy.Celular2, objProxy.Ci, objProxy.Correo, objProxy.Ocupacion, objProxy.LugarTrabajo, objProxy.TelefonoTrabajo, objProxy.CorreoTrabajo, objProxy.FechaNacimiento, objProxy.Genero, objProxy.EstadoCivil, objProxy.TieneHijos, objProxy.NumeroHijos, objProxy.FechaIngreso, objProxy.NumeroCliente, objProxy.RecibirNotificaciones, objProxy.EmpresaId, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado, objProxy.Distribucion) > 0;
            }
            return bRetorno;
        }
        public static bool InsertarFecha(List<RN.Entidades.ClienteDistribucion> objProxys)
        {
            ValidationException x = new ValidationException();
            bool bRetorno = false;
            // Paso el detalle a un DataSet para enviarlo a la CAD
            CAD.WorkFlows.WFLCliente wflProxy = new CAD.WorkFlows.WFLCliente();
            //bRetorno = bRetorno & wflProxy.Insertar(objProxy.Nombre, objProxy.Apellidos, objProxy.Direccion, objProxy.Telefono, objProxy.Celular, objProxy.Celular2, objProxy.Ci, objProxy.Correo, objProxy.Ocupacion, objProxy.LugarTrabajo, objProxy.TelefonoTrabajo, objProxy.CorreoTrabajo, objProxy.FechaNacimiento, objProxy.Genero, objProxy.EstadoCivil, objProxy.TieneHijos, objProxy.NumeroHijos, objProxy.FechaIngreso, objProxy.NumeroCliente, objProxy.RecibirNotificaciones, objProxy.EmpresaId, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado, objProxy.Distribucion, objProxy.FechaInicio) > 0;
            DataTable dtDatos = new DataTable();
            dtDatos =  CargarTable(objProxys);
            if (dtDatos.Rows.Count != 0)
                bRetorno = wflProxy.Insertar(dtDatos) > 0;
            else
                bRetorno = false;

            //bRetorno = bRetorno & wflProxy.Insertar(objProxy.Nombre, objProxy.Apellidos, objProxy.Direccion, objProxy.Telefono, objProxy.Celular, objProxy.Celular2, objProxy.Ci, objProxy.Correo, objProxy.Ocupacion, objProxy.LugarTrabajo, objProxy.TelefonoTrabajo, objProxy.CorreoTrabajo, objProxy.FechaNacimiento, objProxy.Genero, objProxy.EstadoCivil, objProxy.TieneHijos, objProxy.NumeroHijos, objProxy.FechaIngreso, objProxy.NumeroCliente, objProxy.RecibirNotificaciones, objProxy.EmpresaId, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado, objProxy.Distribucion, objProxy.FechaInicio) > 0;

            return bRetorno;
        }
        public static DataTable CargarTable(List<RN.Entidades.ClienteDistribucion> objProxys)
        {
            DataTable Datos = new DataTable();
            DataRow dr;
            if (objProxys.Count != 0)
            {
                Datos.Columns.Add(new DataColumn("nombre", objProxys[0].Nombre.GetType()));
                Datos.Columns.Add(new DataColumn("apellidos", objProxys[0].Apellidos.GetType()));
                Datos.Columns.Add(new DataColumn("direccion", objProxys[0].Direccion.GetType()));
                Datos.Columns.Add(new DataColumn("Telefono", objProxys[0].Telefono.GetType()));
                Datos.Columns.Add(new DataColumn("Celular", objProxys[0].Celular.GetType()));
                Datos.Columns.Add(new DataColumn("Celular2", objProxys[0].Celular2.GetType()));
                Datos.Columns.Add(new DataColumn("Ci", objProxys[0].Ci.GetType()));
                Datos.Columns.Add(new DataColumn("Correo", objProxys[0].Correo.GetType()));
                Datos.Columns.Add(new DataColumn("Ocupacion", objProxys[0].Ocupacion.GetType()));
                Datos.Columns.Add(new DataColumn("LugarTrabajo", objProxys[0].LugarTrabajo.GetType()));
                Datos.Columns.Add(new DataColumn("TelefonoTrabajo", objProxys[0].TelefonoTrabajo.GetType()));
                Datos.Columns.Add(new DataColumn("CorreoTrabajo", objProxys[0].CorreoTrabajo.GetType()));
                Datos.Columns.Add(new DataColumn("FechaNacimiento", objProxys[0].FechaNacimiento.GetType()));
                Datos.Columns.Add(new DataColumn("Genero", objProxys[0].Genero.GetType()));
                Datos.Columns.Add(new DataColumn("EstadoCivil", objProxys[0].EstadoCivil.GetType()));
                Datos.Columns.Add(new DataColumn("TieneHijos", objProxys[0].TieneHijos.GetType()));
                Datos.Columns.Add(new DataColumn("NumeroHijos", objProxys[0].NumeroHijos.GetType()));
                Datos.Columns.Add(new DataColumn("FechaIngreso", objProxys[0].FechaIngreso.GetType()));
                Datos.Columns.Add(new DataColumn("NumeroCliente", objProxys[0].NumeroCliente.GetType()));
                Datos.Columns.Add(new DataColumn("RecibirNotificaciones", objProxys[0].RecibirNotificaciones.GetType()));
                Datos.Columns.Add(new DataColumn("EmpresaId", objProxys[0].EmpresaId.GetType()));
                Datos.Columns.Add(new DataColumn("UsuarioId", objProxys[0].UsuarioId.GetType()));
                Datos.Columns.Add(new DataColumn("Fecha", objProxys[0].Fecha.GetType()));
                Datos.Columns.Add(new DataColumn("Estado", objProxys[0].Estado.GetType()));
                Datos.Columns.Add(new DataColumn("Distribucion", objProxys[0].Distribucion.GetType()));
                Datos.Columns.Add(new DataColumn("FechaInicio", objProxys[0].FechaInicio.GetType()));
            }
            foreach (RN.Entidades.ClienteDistribucion Fila in objProxys)
            {
                dr = Datos.NewRow();
                dr["nombre"] = Fila.Nombre;
                dr["apellidos"] = Fila.Apellidos;
                dr["direccion"] = Fila.Direccion;
                dr["Telefono"] = Fila.Telefono;
                dr["Celular"] = Fila.Celular;
                dr["Celular2"] = Fila.Celular2;
                dr["Ci"] = Fila.Ci;
                dr["Correo"] = Fila.Correo;
                dr["Ocupacion"] = Fila.Ocupacion;
                dr["LugarTrabajo"] = Fila.LugarTrabajo;
                dr["TelefonoTrabajo"] = Fila.TelefonoTrabajo;
                dr["CorreoTrabajo"] = Fila.CorreoTrabajo;
                dr["FechaNacimiento"] = Fila.FechaNacimiento;
                dr["Genero"] = Fila.Genero;
                dr["EstadoCivil"] = Fila.EstadoCivil;
                dr["TieneHijos"] = Fila.TieneHijos;
                dr["FechaIngreso"] = Fila.FechaIngreso;
                dr["NumeroHijos"] = Fila.NumeroHijos;
                dr["NumeroCliente"] = Fila.NumeroCliente;
                dr["RecibirNotificaciones"] = Fila.RecibirNotificaciones;
                dr["EmpresaId"] = Fila.EmpresaId;
                dr["UsuarioId"] = Fila.UsuarioId;
                dr["Fecha"] = Fila.Fecha;
                dr["Estado"] = Fila.Estado;
                dr["Distribucion"] = Fila.Distribucion;
                dr["FechaInicio"] = Fila.FechaInicio;
                Datos.Rows.Add(dr);
            }
            return Datos;
        }
        #endregion
    }
}
