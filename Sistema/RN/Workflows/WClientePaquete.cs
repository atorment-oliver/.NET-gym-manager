using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Workflows
{
    public class WClientePaquete
    {
        #region DMLS
        public static bool Insertar(ClientePaqueteD objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Fecha < DateTime.Now.AddDays(-1))
                x.AgregarError("La fecha debe ser mayor a la fecha actual");

            if (objProxy.Detalle.Count < 1)
                x.AgregarError("No ingresó el detalle");


            foreach (Inscripcion detalle in objProxy.Detalle)
            {
                if (detalle.ClientePaqueteId <= 0)
                    x.AgregarError("Alguno de los elementos del detalle presentan problemas.");
            }

            if (x.Cantidad > 0)
                throw x;

            // Paso el detalle a un DataSet para enviarlo a la CAD
            DataSet dtsDetalle = Set(objProxy.Detalle);
            CAD.WorkFlows.WFLClientePaquete wflProxy = new CAD.WorkFlows.WFLClientePaquete();
            return wflProxy.Insertar(objProxy.ClienteId, objProxy.PaqueteId, objProxy.FechaRegistro, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha, objProxy.Adicional, dtsDetalle) > 0;
        }
        public static bool InsertarInscripcion(int clientepaquete, List<Inscripcion> Detalle)
        {
            ValidationException x = new ValidationException();
            
            if (clientepaquete < 1)
                x.AgregarError("No ingresó el codigo cliente paquete");


            foreach (Inscripcion detalle in Detalle)
            {
                if (detalle.ClientePaqueteId <= 0)
                    x.AgregarError("Alguno de los elementos del detalle presentan problemas.");
            }

            if (x.Cantidad > 0)
                throw x;

            // Paso el detalle a un DataSet para enviarlo a la CAD
            DataSet dtsDetalle = Set(Detalle);
            CAD.WorkFlows.WFLClientePaquete wflProxy = new CAD.WorkFlows.WFLClientePaquete();
            return wflProxy.InsertarInscripcion(clientepaquete, dtsDetalle);
        }
        public static int InsertarCodigo(ClientePaqueteD objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Fecha < DateTime.Now.AddDays(-1))
                x.AgregarError("La fecha debe ser mayor a la fecha actual");

            if (objProxy.Detalle.Count < 1)
                x.AgregarError("No ingresó el detalle");


            foreach (Inscripcion detalle in objProxy.Detalle)
            {
                if (detalle.GrupoId <= 0)
                    x.AgregarError("Alguno de los elementos del detalle presentan problemas.");
            }

            if (x.Cantidad > 0)
                throw x;

            // Paso el detalle a un DataSet para enviarlo a la CAD
            DataSet dtsDetalle = Set(objProxy.Detalle);
            CAD.WorkFlows.WFLClientePaquete wflProxy = new CAD.WorkFlows.WFLClientePaquete();
            return wflProxy.Insertar(objProxy.ClienteId, objProxy.PaqueteId, objProxy.FechaRegistro, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha, objProxy.Adicional, dtsDetalle);
        }
        #endregion
        public static ClientePaqueteD TraerXId(int codigo)
        {
            DAOFactura daoProxy = new DAOFactura();
            DataSet dtsProxy = daoProxy.TraerFacturaXId(codigo);

            return Cargar(dtsProxy.Tables[0].Rows[0], dtsProxy.Tables[1]);
        }
        #region Metodos Privados
        private static List<ClientePaqueteD> CargarLista(DataTable tabla)
        {
            List<ClientePaqueteD> lstProxy = new List<ClientePaqueteD>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static List<Inscripcion> CargarListaDetalle(DataTable tabla)
        {
            List<Inscripcion> lstProxy = new List<Inscripcion>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(CargarDetalle(fila));
            }
            return lstProxy;
        }
        private static ClientePaqueteD Cargar(DataRow fila)
        {
            ClientePaqueteD objProxy = new ClientePaqueteD();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.ClienteId = Convert.ToInt32(fila["clienteId"].ToString());
            objProxy.PaqueteId = Convert.ToInt32(fila["paqueteId"].ToString());
            objProxy.FechaRegistro = Convert.ToDateTime(fila["fechaRegistro"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());

            objProxy.Detalle = null;

            return objProxy;
        }
        private static ClientePaqueteD Cargar(DataRow fila, DataTable detalle)
        {
            ClientePaqueteD objProxy = new ClientePaqueteD();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.ClienteId = Convert.ToInt32(fila["clienteId"].ToString());
            objProxy.PaqueteId = Convert.ToInt32(fila["paqueteId"].ToString());
            objProxy.FechaRegistro = Convert.ToDateTime(fila["fechaRegistro"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());

            objProxy.Detalle = CargarListaDetalle(detalle);

            return objProxy;
        }
        private static Inscripcion CargarDetalle(DataRow fila)
        {
            Inscripcion objProxy = new Inscripcion();
            objProxy.ClientePaqueteId = Convert.ToInt32(fila["clientePaqueteId"]);
            objProxy.GrupoId = Convert.ToInt32(fila["grupoId"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            return objProxy;
        }
        private static DataSet Set(List<Inscripcion> detalle)
        {
            DataSet dtsDetalle = new DataSet();
            DataTable tblProxy = dtsDetalle.Tables.Add();
            tblProxy.Columns.Add("clientePaqueteId", typeof(Int32));
            tblProxy.Columns.Add("grupoId", typeof(Int32));
            tblProxy.Columns.Add("usuarioId", typeof(String));
            tblProxy.Columns.Add("fecha", typeof(DateTime));
            tblProxy.Columns.Add("estado", typeof(Boolean));
            foreach (Inscripcion item in detalle)
            {
                tblProxy.Rows.Add(item.ClientePaqueteId, item.GrupoId, item.UsuarioId, item.Fecha, item.Estado);
            }
            return dtsDetalle;
        }
        #endregion
    }
}
