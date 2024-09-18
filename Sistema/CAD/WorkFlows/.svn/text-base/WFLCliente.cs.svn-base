using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CAD.WorkFlows
{
    public class WFLCliente
    {
        public int Insertar(string nombre, string apellidos, string direccion, string telefono, string celular, string celular2, string ci, string correo, string ocupacion, string lugarTrabajo, string telefonoTrabajo, string correoTrabajo, DateTime fechaNacimiento, string genero, string estadoCivil, bool tieneHijos, int numeroHijos, DateTime fechaIngreso, int numeroCliente, bool recibirNotificaciones, int empresaId, string usuarioId, DateTime fecha, string estado)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                // Comienzo insertando el master

                DAO.DAOCliente serv = new CAD.DAO.DAOCliente();
                int codigoServ = serv.Insertar(nombre, apellidos, direccion, telefono, celular, celular2, ci, correo, ocupacion, lugarTrabajo, telefonoTrabajo, correoTrabajo, fechaNacimiento, genero, estadoCivil, tieneHijos, numeroHijos, fechaIngreso, numeroCliente, recibirNotificaciones, empresaId, usuarioId, fecha, estado, transaccion);

                if (codigoServ < 1)
                    throw new Exception("Error al grabar el cliente");
                transaccion.Commit();
                return codigoServ;
            }
            catch (Exception x)
            {
                transaccion.Rollback();
                throw x;
            }
        }
        public int Insertar(string nombre, string apellidos, string direccion, string telefono, string celular, string celular2, string ci, string correo, string ocupacion, string lugarTrabajo, string telefonoTrabajo, string correoTrabajo, DateTime fechaNacimiento, string genero, string estadoCivil, bool tieneHijos, int numeroHijos, DateTime fechaIngreso, int numeroCliente, bool recibirNotificaciones, int empresaId, string usuarioId, DateTime fecha, string estado, int distribucion)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                // Comienzo insertando el master

                DAO.DAOCliente serv = new CAD.DAO.DAOCliente();
                DAO.DAODistribucionPago objDistribucion = new CAD.DAO.DAODistribucionPago();
                int codigoServ = serv.Insertar(nombre, apellidos, direccion, telefono, celular, celular2, ci, correo, ocupacion, lugarTrabajo, telefonoTrabajo, correoTrabajo, fechaNacimiento, genero, estadoCivil, tieneHijos, numeroHijos, fechaIngreso, numeroCliente, recibirNotificaciones, empresaId, usuarioId, fecha, estado, transaccion);
                int codigoDistribucion = -1;
                if (codigoServ < 1)
                    throw new Exception("Error al grabar el cliente");
                if ((distribucion > 0) && (empresaId > 0))
                    codigoDistribucion = objDistribucion.Insertar(codigoServ, distribucion, true, usuarioId, fecha, transaccion);
                else
                    codigoDistribucion = 0;
                if (codigoDistribucion == -1)
                    throw new Exception("Error al grabar la distribucion");
                transaccion.Commit();
                return codigoServ;
            }
            catch (Exception x)
            {
                transaccion.Rollback();
                throw x;
            }
        }
        public int Insertar(string nombre, string apellidos, string direccion, string telefono, string celular, string celular2, string ci, string correo, string ocupacion, string lugarTrabajo, string telefonoTrabajo, string correoTrabajo, DateTime fechaNacimiento, string genero, string estadoCivil, bool tieneHijos, int numeroHijos, DateTime fechaIngreso, int numeroCliente, bool recibirNotificaciones, int empresaId, string usuarioId, DateTime fecha, string estado, int distribucion, DateTime fechaInicio)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                // Comienzo insertando el master

                DAO.DAOCliente serv = new CAD.DAO.DAOCliente();
                DAO.DAODistribucionPago objDistribucion = new CAD.DAO.DAODistribucionPago();
                DAO.DAOClienteFecha objClienteFecha = new CAD.DAO.DAOClienteFecha();
                int codigoServ = serv.Insertar(nombre, apellidos, direccion, telefono, celular, celular2, ci, correo, ocupacion, lugarTrabajo, telefonoTrabajo, correoTrabajo, fechaNacimiento, genero, estadoCivil, tieneHijos, numeroHijos, fechaIngreso, numeroCliente, recibirNotificaciones, empresaId, usuarioId, fecha, estado, transaccion);
                int codigoDistribucion = -1;
                bool codigoFecha = false;
                if (codigoServ < 1)
                    throw new Exception("Error al grabar el cliente");
                if ((distribucion > 0) && (empresaId > 0))
                    codigoDistribucion = objDistribucion.Insertar(codigoServ, distribucion, true, usuarioId, fecha, transaccion);
                else
                    codigoDistribucion = 0;
                if (codigoDistribucion == -1)
                    throw new Exception("Error al grabar la distribucion");
                if (codigoDistribucion > 0)
                {
                    if (fechaInicio.ToShortDateString() != "01/01/1900")
                    {
                        codigoFecha = objClienteFecha.Insertar(codigoServ, fechaInicio, true, usuarioId, fecha, transaccion);
                        if (!codigoFecha)
                            throw new Exception("Error al grabar la fecha de inicio");
                    }
                }
                transaccion.Commit();
                return codigoServ;
            }
            catch (Exception x)
            {
                transaccion.Rollback();
                throw x;
            }
        }
        public int Insertar(DataTable Conjunto)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            int iRetorno = -1;
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                // Comienzo insertando el master
                foreach (DataRow row in Conjunto.Rows)
                {
                    DAO.DAOCliente serv = new CAD.DAO.DAOCliente();
                    DAO.DAODistribucionPago objDistribucion = new CAD.DAO.DAODistribucionPago();
                    DAO.DAOClienteFecha objClienteFecha = new CAD.DAO.DAOClienteFecha();

                    int codigoServ = serv.Insertar(row["nombre"].ToString(), row["apellidos"].ToString(), row["direccion"].ToString(), row["telefono"].ToString(), row["celular"].ToString(), row["celular2"].ToString(), row["ci"].ToString(), row["correo"].ToString(), row["ocupacion"].ToString(), row["lugarTrabajo"].ToString(), row["telefonoTrabajo"].ToString(), row["correoTrabajo"].ToString(), Convert.ToDateTime(row["fechaNacimiento"].ToString()), row["genero"].ToString(), row["estadoCivil"].ToString(), Convert.ToBoolean(row["tieneHijos"].ToString()), Convert.ToInt32(row["numeroHijos"].ToString()), Convert.ToDateTime(row["fechaIngreso"].ToString()), Convert.ToInt32(row["numeroCliente"].ToString()), Convert.ToBoolean(row["recibirNotificaciones"].ToString()), Convert.ToInt32(row["empresaId"].ToString()), row["usuarioId"].ToString(), Convert.ToDateTime(row["fecha"].ToString()), row["estado"].ToString(), transaccion);
                    int codigoDistribucion = -1;
                    bool codigoFecha = false;
                    if (codigoServ < 1)
                        throw new Exception("Error al grabar el cliente");
                    if ((Convert.ToInt32(row["Distribucion"].ToString()) > 0) && ((Convert.ToInt32(row["EmpresaId"].ToString()) > 0)))
                        codigoDistribucion = objDistribucion.Insertar(codigoServ, Convert.ToInt32(row["Distribucion"].ToString()), true, row["UsuarioId"].ToString(), Convert.ToDateTime(row["Fecha"].ToString()), transaccion);
                    else
                        codigoDistribucion = 0;
                    if (codigoDistribucion == -1)
                        throw new Exception("Error al grabar la distribucion");
                    if (codigoDistribucion > 0)
                    {
                        if (Convert.ToDateTime(row["FechaInicio"].ToString()).ToShortDateString() != "01/01/1900")
                        {
                            codigoFecha = objClienteFecha.Insertar(codigoServ, Convert.ToDateTime(row["FechaInicio"].ToString()), true, row["UsuarioId"].ToString(), Convert.ToDateTime(row["Fecha"].ToString()), transaccion);
                            if (!codigoFecha)
                                throw new Exception("Error al grabar la fecha de inicio");
                        }
                    }
                    iRetorno = codigoServ;
                }
                transaccion.Commit();
                return iRetorno;
            }
            catch (Exception x)
            {
                transaccion.Rollback();
                throw x;
            }
        }
    }
}
