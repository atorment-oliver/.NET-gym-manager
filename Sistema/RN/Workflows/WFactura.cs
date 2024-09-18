using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.WorkFlows
{
    public class WFactura
    {
        #region DMLS
        public static bool InsertarFactura(Factura objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Fecha < DateTime.Now.AddDays(-1))
                x.AgregarError("La fecha debe ser mayor a la fecha actual");

            if (objProxy.Detalle.Count < 1)
                x.AgregarError("No ingresó el detalle");


            foreach (DFactura detalle in objProxy.Detalle)
            {                
                if (detalle.Producto_id < 1 || detalle.Cantidad < 1)
                    x.AgregarError("Alguno de los elementos del detalle presentan problemas.");
            }

            if (x.Cantidad > 0)
                throw x;

            // Paso el detalle a un DataSet para enviarlo a la CAD
            DataSet dtsDetalle = Set(objProxy.Detalle);
            CAD.WorkFlows.WFLFactura wflProxy = new CAD.WorkFlows.WFLFactura();
            return wflProxy.Insertar(objProxy.Fecha, objProxy.NombreFactura, objProxy.NitFactura, dtsDetalle) > 0;
        }
        #endregion
        public static Factura TraerXId(int codigo)
        {
            DAOFactura daoProxy = new DAOFactura();
            DataSet dtsProxy = daoProxy.TraerFacturaXId(codigo);

            return Cargar(dtsProxy.Tables[0].Rows[0], dtsProxy.Tables[1]);
        }        
        #region Metodos Privados
        private static List<Factura> CargarLista(DataTable tabla)
        {
            List<Factura> lstProxy = new List<Factura>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static List<DFactura> CargarListaDetalle(DataTable tabla)
        {
            List<DFactura> lstProxy = new List<DFactura>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(CargarDetalle(fila));
            }
            return lstProxy;
        }
        private static Factura Cargar(DataRow fila)
        {
            Factura objProxy = new Factura();
            objProxy.Codigo = Convert.ToInt32(fila["codigo"]);
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"]);
            objProxy.NitFactura = fila["nitFactura"].ToString();
            objProxy.NombreFactura = fila["nombreFactura"].ToString();

            objProxy.Detalle = null;

            return objProxy;
        }
        private static Factura Cargar(DataRow fila, DataTable detalle)
        {
            Factura objProxy = new Factura();
            objProxy.Codigo = Convert.ToInt32(fila["codigo"]);
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"]);
            objProxy.NitFactura = fila["nitFactura"].ToString();
            objProxy.NombreFactura = fila["nombreFactura"].ToString();

            objProxy.Detalle = CargarListaDetalle(detalle);

            return objProxy;
        }
        private static DFactura CargarDetalle(DataRow fila)
        {
            DFactura objProxy = new DFactura();
            objProxy.Codigo = Convert.ToInt32(fila["codigo"]);
            objProxy.Cantidad = Convert.ToInt32(fila["cantidad"]);
            objProxy.Producto_id = Convert.ToInt32(fila["producto_id"]);
            return objProxy;
        }
        private static DataSet Set(List<DFactura> detalle)
        {
            DataSet dtsDetalle = new DataSet();
            DataTable tblProxy = dtsDetalle.Tables.Add();
            tblProxy.Columns.Add("Producto_id", typeof(Int32));
            tblProxy.Columns.Add("Cantidad", typeof(Int32));

            foreach (DFactura item in detalle)
            {
                tblProxy.Rows.Add(item.Producto_id, item.Cantidad);
            }
            return dtsDetalle;
        }
        #endregion
    }
}
