using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Workflows
{
    public class WEmpresa
    {
        #region DMLS
        public static bool Insertar(EmpresaD objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Fecha < DateTime.Now.AddDays(-1))
                x.AgregarError("La fecha debe ser mayor a la fecha actual");

            if (objProxy.Detalle.Count < 1)
                x.AgregarError("No ingresó el detalle");


            foreach (EmpresaPaquete detalle in objProxy.Detalle)
            {
                if (detalle.EmpresaId < 0)
                    x.AgregarError("Alguno de los elementos del detalle presentan problemas.");
                if (detalle.PaqueteId <= 0)
                    x.AgregarError("Alguno de los elementos del detalle presentan problemas.");
            }

            if (x.Cantidad > 0)
                throw x;

            // Paso el detalle a un DataSet para enviarlo a la CAD
            DataSet dtsDetalle = Set(objProxy.Detalle);
            CAD.WorkFlows.WFLEmpresa wflProxy = new CAD.WorkFlows.WFLEmpresa();
            return wflProxy.Insertar(objProxy.Nombre, objProxy.Descripcion, objProxy.NombrePersonaContacto, objProxy.Telefono, objProxy.Correo, objProxy.Direccion, objProxy.FechaRegistro, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado, dtsDetalle) > 0;
        }
        public static int InsertarCodigo(EmpresaD objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Fecha < DateTime.Now.AddDays(-1))
                x.AgregarError("La fecha debe ser mayor a la fecha actual");

            if (objProxy.Detalle.Count < 1)
                x.AgregarError("No ingresó el detalle");


            foreach (EmpresaPaquete detalle in objProxy.Detalle)
            {
                if (detalle.EmpresaId <= 0)
                    x.AgregarError("Alguno de los elementos del detalle presentan problemas.");
                if (detalle.PaqueteId <= 0)
                    x.AgregarError("Alguno de los elementos del detalle presentan problemas.");
            }

            if (x.Cantidad > 0)
                throw x;

            // Paso el detalle a un DataSet para enviarlo a la CAD
            DataSet dtsDetalle = Set(objProxy.Detalle);
            CAD.WorkFlows.WFLEmpresa wflProxy = new CAD.WorkFlows.WFLEmpresa();
            return wflProxy.Insertar(objProxy.Nombre, objProxy.Descripcion, objProxy.NombrePersonaContacto, objProxy.Telefono, objProxy.Correo, objProxy.Direccion, objProxy.FechaRegistro, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado, dtsDetalle);
        }
        public static bool Actualizar(EmpresaD objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Fecha < DateTime.Now.AddDays(-1))
                x.AgregarError("La fecha debe ser mayor a la fecha actual");

            if (objProxy.Detalle.Count < 1)
                x.AgregarError("No ingresó el detalle");


            foreach (EmpresaPaquete detalle in objProxy.Detalle)
            {
                if (detalle.EmpresaId <= 0)
                    x.AgregarError("Alguno de los elementos del detalle presentan problemas.");
                if (detalle.PaqueteId <= 0)
                    x.AgregarError("Alguno de los elementos del detalle presentan problemas.");
            }

            if (x.Cantidad > 0)
                throw x;

            // Paso el detalle a un DataSet para enviarlo a la CAD
            DataSet dtsDetalle = Set(objProxy.Detalle);
            CAD.WorkFlows.WFLEmpresa wflProxy = new CAD.WorkFlows.WFLEmpresa();
            return wflProxy.Actualizar(objProxy.Id, objProxy.Nombre, objProxy.Descripcion, objProxy.NombrePersonaContacto, objProxy.Telefono, objProxy.Correo, objProxy.Direccion, objProxy.FechaRegistro, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado, dtsDetalle);
        }
        #endregion
        public static EmpresaD TraerXId(int codigo)
        {
            DAOFactura daoProxy = new DAOFactura();
            DataSet dtsProxy = daoProxy.TraerFacturaXId(codigo);

            return Cargar(dtsProxy.Tables[0].Rows[0], dtsProxy.Tables[1]);
        }
        #region Metodos Privados
        private static List<EmpresaD> CargarLista(DataTable tabla)
        {
            List<EmpresaD> lstProxy = new List<EmpresaD>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static List<EmpresaPaquete> CargarListaDetalle(DataTable tabla)
        {
            List<EmpresaPaquete> lstProxy = new List<EmpresaPaquete>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(CargarDetalle(fila));
            }
            return lstProxy;
        }
        private static EmpresaD Cargar(DataRow fila)
        {
            EmpresaD objProxy = new EmpresaD();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Nombre = (fila["nombre"].ToString());
            objProxy.Descripcion = (fila["descripcion"].ToString());
            objProxy.NombrePersonaContacto = (fila["nombrePersonaContacto"].ToString());
            objProxy.Telefono = (fila["telefono"].ToString());
            objProxy.Correo = (fila["correo"].ToString());
            objProxy.Direccion = (fila["direccion"].ToString());
            objProxy.FechaRegistro = Convert.ToDateTime(fila["fechaRegistro"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());

            objProxy.Detalle = null;

            return objProxy;
        }
        private static EmpresaD Cargar(DataRow fila, DataTable detalle)
        {
            EmpresaD objProxy = new EmpresaD();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Nombre = (fila["nombre"].ToString());
            objProxy.Descripcion = (fila["descripcion"].ToString());
            objProxy.NombrePersonaContacto = (fila["nombrePersonaContacto"].ToString());
            objProxy.Telefono = (fila["telefono"].ToString());
            objProxy.Correo = (fila["correo"].ToString());
            objProxy.Direccion = (fila["direccion"].ToString());
            objProxy.FechaRegistro = Convert.ToDateTime(fila["fechaRegistro"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.Detalle = CargarListaDetalle(detalle);

            return objProxy;
        }
        private static EmpresaPaquete CargarDetalle(DataRow fila)
        {
            EmpresaPaquete objProxy = new EmpresaPaquete();
            objProxy.EmpresaId = Convert.ToInt32(fila["empresaId"]);
            objProxy.PaqueteId = Convert.ToInt32(fila["paqueteId"].ToString());
            objProxy.Costo = Convert.ToDecimal(fila["Costo"].ToString());
            return objProxy;
        }
        private static DataSet Set(List<EmpresaPaquete> detalle)
        {
            DataSet dtsDetalle = new DataSet();
            DataTable tblProxy = dtsDetalle.Tables.Add();
            tblProxy.Columns.Add("empresaId", typeof(Int32));
            tblProxy.Columns.Add("paqueteId", typeof(Int32));
            tblProxy.Columns.Add("costo", typeof(decimal));
            foreach (EmpresaPaquete item in detalle)
            {
                tblProxy.Rows.Add(item.EmpresaId, item.PaqueteId, item.Costo);
            }
            return dtsDetalle;
        }
        #endregion
    }
}
