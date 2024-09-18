using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.WorkFlows
{
    public class WFLClientePaquete
    {
        public int Insertar(int clienteId, int paqueteId, DateTime fechaRegistro, bool estado, string usuarioId, DateTime fecha, int adicional, DataSet detalle)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                // Comienzo insertando el master
                DAO.DAOClientePaquete factura = new CAD.DAO.DAOClientePaquete();
                int codigoFactura = factura.Insertar(clienteId, paqueteId, fechaRegistro, estado, usuarioId, fecha, adicional, transaccion);

                if (codigoFactura < 1)
                    throw new Exception("Error al grabar el maestro");

                // Continuo insertando los detalles
                DAO.DAOInscripcion linea = new CAD.DAO.DAOInscripcion();
                foreach (DataRow fila in detalle.Tables[0].Rows)
                {
                    int codigoDetalle = linea.Insertar(codigoFactura, Convert.ToInt32(fila["grupoId"]), Convert.ToBoolean(fila["estado"]), (fila["usuarioId"]).ToString(), Convert.ToDateTime(fila["fecha"]), transaccion);
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
        public bool InsertarInscripcion(int clientepaqueteid, DataSet detalle)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                DAO.DAOInscripcion linea = new CAD.DAO.DAOInscripcion();
                if (clientepaqueteid < 1)
                    throw new Exception("Falta codigo cliente paquete");
                foreach (DataRow fila in detalle.Tables[0].Rows)
                {
                    int codigoDetalle = linea.Insertar(clientepaqueteid, Convert.ToInt32(fila["grupoId"]), Convert.ToBoolean(fila["estado"]), (fila["usuarioId"]).ToString(), Convert.ToDateTime(fila["fecha"]), transaccion);
                    if (codigoDetalle < 1)
                        throw new Exception("Error al grabar un detalle");
                }

                transaccion.Commit();
                return true;
            }
            catch (Exception x)
            {
                transaccion.Rollback();
                throw x;
            }
        }
    }
}
