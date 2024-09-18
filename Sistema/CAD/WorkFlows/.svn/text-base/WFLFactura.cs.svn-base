using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.WorkFlows
{
    public class WFLFactura
    {
        public int Insertar(DateTime fecha, string nombre, string nit, DataSet detalle)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                // Comienzo insertando el master
                DAO.DAOFactura factura = new CAD.DAO.DAOFactura();
                int codigoFactura = factura.Insertar(fecha, nombre, nit, transaccion);

                if (codigoFactura < 1)
                    throw new Exception("Error al grabar el maestro");

                // Continuo insertando los detalles
                DAO.DAODFactura linea = new CAD.DAO.DAODFactura();
                foreach (DataRow fila in detalle.Tables[0].Rows)
                {
                    int codigoDetalle = linea.Insertar(codigoFactura, Convert.ToInt32(fila["producto_id"]), Convert.ToInt32(fila["cantidad"]), transaccion);
                    if (codigoDetalle < 1)
                        throw new Exception("Error al grabar un detalle");
                }

                transaccion.Commit();
                return codigoFactura;
            }
            catch (Exception x)
            {
                transaccion.Rollback();
                throw x;
            }           
        }
    }
}
