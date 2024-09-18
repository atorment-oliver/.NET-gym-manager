using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.WorkFlows
{
    public class WFLGrupo
    {
        public int Insertar(string nombre, int horarioId, int servicioId, bool estado, string usuarioId, DateTime fecha, string nombreServicio, bool restriccionHorario, int cupo, bool estadoservicio, string usuarioIdServicio, DateTime fechaServicio, DataSet detalle)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                // Comienzo insertando el master

                DAO.DAOServicio serv = new CAD.DAO.DAOServicio();
                int codigoServ = serv.Insertar(nombreServicio, restriccionHorario, cupo, estadoservicio, usuarioIdServicio, fechaServicio, transaccion);

                if (codigoServ < 1)
                    throw new Exception("Error al grabar el servicio");

                DAO.DAOGrupo factura = new CAD.DAO.DAOGrupo();
                int codigoFactura = factura.Insertar(nombre, horarioId, codigoServ, estado, usuarioId, fecha, transaccion);

                if (codigoFactura < 1)
                    throw new Exception("Error al grabar el maestro");

                // Continuo insertando los detalles
                DAO.DAOGrupoDia linea = new CAD.DAO.DAOGrupoDia();
                foreach (DataRow fila in detalle.Tables[0].Rows)
                {
                    int codigoDetalle = linea.Insertar(codigoFactura, Convert.ToInt32(fila["diaId"]), transaccion);
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
        public bool InsertarGrupoActualizarServicio(string nombre, int horarioId, int servicioId, bool estado, string usuarioId, DateTime fecha, int servicioid, string nombreServicio, bool restriccionHorario, int cupo, bool estadoservicio, string usuarioIdServicio, DateTime fechaServicio, DataSet detalle)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                // Comienzo insertando el master

                DAO.DAOServicio serv = new CAD.DAO.DAOServicio();
                if(!serv.Actualizar(servicioid, nombreServicio, restriccionHorario, cupo, estadoservicio, usuarioIdServicio, fechaServicio, transaccion))
                    throw new Exception("Error al actualizar el servicio");

                DAO.DAOGrupo factura = new CAD.DAO.DAOGrupo();
                int codigoFactura = factura.Insertar(nombre, horarioId, servicioid, estado, usuarioId, fecha, transaccion);

                if (codigoFactura < 1)
                    throw new Exception("Error al grabar el maestro");

                // Continuo insertando los detalles
                DAO.DAOGrupoDia linea = new CAD.DAO.DAOGrupoDia();
                foreach (DataRow fila in detalle.Tables[0].Rows)
                {
                    int codigoDetalle = linea.Insertar(codigoFactura, Convert.ToInt32(fila["diaId"]), transaccion);
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
        public bool InsertarServicioActualizarGrupo(int id, string nombre, int horarioId, int servicioId, bool estado, string usuarioId, DateTime fecha, string nombreServicio, bool restriccionHorario, int cupo, bool estadoservicio, string usuarioIdServicio, DateTime fechaServicio, DataSet detalle)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                // Comienzo insertando el master

                DAO.DAOServicio serv = new CAD.DAO.DAOServicio();
                int codigoServ = serv.Insertar(nombreServicio, restriccionHorario, cupo, estadoservicio, usuarioIdServicio, fechaServicio, transaccion);

                if (codigoServ < 1)
                    throw new Exception("Error al grabar el servicio");

                DAO.DAOGrupo factura = new CAD.DAO.DAOGrupo();
                int codigoFactura = factura.Insertar(nombre, horarioId, codigoServ, estado, usuarioId, fecha, transaccion);
                DAO.DAOGrupoDia linea = new CAD.DAO.DAOGrupoDia();
                if (codigoFactura < 1)
                    throw new Exception("Error al grabar el maestro");

                // Continuo insertando los detalles
                if (factura.Actualizar(id, nombre, horarioId, codigoServ, estado, usuarioId, fecha, transaccion))
                {
                    // Continuo insertando los detalles
                    foreach (DataRow fila in detalle.Tables[0].Rows)
                    {
                        int codigoDetalle = linea.Insertar(id, Convert.ToInt32(fila["diaId"]), transaccion);
                        if (codigoDetalle < 1)
                            throw new Exception("Error al grabar un detalle");
                    }
                    transaccion.Commit();
                    return true;
                }
                else
                    throw new Exception("Error al actualizar el maestro");
            }
            catch (Exception x)
            {
                transaccion.Rollback();
                throw x;
            }
        }
        public bool Actualizar(int id, string nombre, int horarioId, int servicioId, bool estado, string usuarioId, DateTime fecha, int idServicio, string nombreServicio, bool restriccionHorario, int cupo, bool estadoservicio, string usuarioIdServicio, DateTime fechaServicio, DataSet detalle)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                // Comienzo insertando el master
                DAO.DAOServicio servicio = new CAD.DAO.DAOServicio();
                DAO.DAOGrupo factura = new CAD.DAO.DAOGrupo();
                DAO.DAOGrupoDia linea = new CAD.DAO.DAOGrupoDia();
                if (linea.EliminarXGrupoId(id, transaccion))
                {
                    if (servicio.Actualizar(idServicio, nombreServicio, restriccionHorario, cupo, estadoservicio, usuarioIdServicio, fechaServicio, transaccion))
                    {
                        if (factura.Actualizar(id, nombre, horarioId, idServicio, estado, usuarioId, fecha, transaccion))
                        {
                            // Continuo insertando los detalles
                            foreach (DataRow fila in detalle.Tables[0].Rows)
                            {
                                int codigoDetalle = linea.Insertar(id, Convert.ToInt32(fila["diaId"]), transaccion);
                                if (codigoDetalle < 1)
                                    throw new Exception("Error al grabar un detalle");
                            }
                            transaccion.Commit();
                            return true;
                        }
                        else
                            throw new Exception("Error al actualizar el maestro");
                    }
                    else
                        throw new Exception("Error al actualizar el servicio");
                }
                else
                    throw new Exception("Error al eliminar los dias");
            }
            catch (Exception x)
            {
                transaccion.Rollback();
                throw x;
            }
        }
    }
}
