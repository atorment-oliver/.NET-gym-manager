using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace CAD.WorkFlows
{
    public class WFLLicencia
    {
        public int Insertar(string descripcion, int clientePaqueteId, DateTime fechaSolicitud, DateTime fechaInicioLicencia, DateTime fechaFinLicencia, bool estado, string usuarioId, DateTime fecha)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                // Comienzo insertando el master

                DAO.DAOLicencia serv = new CAD.DAO.DAOLicencia();
                int codigoServ = serv.Insertar(descripcion, clientePaqueteId, fechaSolicitud, fechaInicioLicencia, fechaFinLicencia, estado, usuarioId, fecha, transaccion);

                if (codigoServ < 1)
                    throw new Exception("Error al grabar el servicio");
                //else
                //{
                //    DAO.DAOClientePaquete factura = new CAD.DAO.DAOClientePaquete();
                //    if (!factura.DarLicencia(clientePaqueteId, fechaInicioLicencia, fechaFinLicencia, transaccion))
                //        throw new Exception("Error al grabar el maestro");
                //}
                transaccion.Commit();
                return codigoServ;
            }
            catch (Exception x)
            {
                transaccion.Rollback();
                throw x;
            }
        }
        public bool Eliminar(int id)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                // Comienzo insertando el master

                DAO.DAOLicencia serv = new CAD.DAO.DAOLicencia();
                
                DAO.DAOClientePaquete factura = new CAD.DAO.DAOClientePaquete();
                if (!factura.QuitarLicencia(id, transaccion))
                {
                    throw new Exception("Error al grabar el maestro");
                }
                else
                {
                    bool codigoServ = serv.Eliminar(id, transaccion);
                    if (!codigoServ)
                        throw new Exception("Error al grabar el servicio");
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
