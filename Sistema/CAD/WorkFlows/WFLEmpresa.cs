using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.WorkFlows
{
    public class WFLEmpresa
    {
        public int Insertar(string nombre, string descripcion, string nombrePersonaContacto, string telefono, string correo, string direccion, DateTime fechaRegistro, string usuarioId, DateTime fecha,bool estado, DataSet detalle)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                // Comienzo insertando el master
                DAO.DAOEmpresa factura = new CAD.DAO.DAOEmpresa();
                int codigoFactura = factura.Insertar(nombre, descripcion, nombrePersonaContacto, telefono, correo, direccion, fechaRegistro, usuarioId, fecha, estado, transaccion);

                if (codigoFactura < 1)
                    throw new Exception("Error al grabar el maestro");

                // Continuo insertando los detalles
                DAO.DAOEmpresaPaquete linea = new CAD.DAO.DAOEmpresaPaquete();
                foreach (DataRow fila in detalle.Tables[0].Rows)
                {
                    bool codigoDetalle = linea.Insertar(codigoFactura, Convert.ToInt32(fila["paqueteId"]), Convert.ToDecimal(fila["costo"]), transaccion);
                    if (!codigoDetalle)
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
        public bool Actualizar(int id, string nombre, string descripcion, string nombrePersonaContacto, string telefono, string correo, string direccion, DateTime fechaRegistro, string usuarioId, DateTime fecha, bool estado, DataSet detalle)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                // Comienzo insertando el master
                DAO.DAOEmpresa factura = new CAD.DAO.DAOEmpresa();
                bool codigoFactura = factura.Actualizar(id, nombre, descripcion, nombrePersonaContacto, telefono, correo, direccion, fechaRegistro, usuarioId, fecha, estado, transaccion);

                if (!codigoFactura)
                    throw new Exception("Error al grabar el maestro");

                // Continuo insertando los detalles
                DAO.DAOEmpresaPaquete linea = new CAD.DAO.DAOEmpresaPaquete();
                foreach (DataRow fila in detalle.Tables[0].Rows)
                {
                    bool codigoDetalle = linea.Actualizar(Convert.ToInt32(fila["empresaId"].ToString()), Convert.ToInt32(fila["paqueteId"].ToString()), Convert.ToDecimal(fila["costo"].ToString()), transaccion);
                    if (!codigoDetalle)
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
