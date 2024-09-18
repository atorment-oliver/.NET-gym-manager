using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace CAD.WorkFlows
{
    public class WFLPagoEmpresa
    {
        public int Insertar(int EmpresaId, int clientePaqueteId, string concepto, string formaPago, string numeroFactura, string digitosTarjeta_12, string numeroAprobacionPOS, string numeroCheque, string nombreBancoCheque, string numeroCuentaTransferencia, string nombreBancoTransferencia, int intercambioId, int nroPago, DateTime fechaPeriodoInicio, DateTime fechaPeriodoFin, decimal monto, DateTime fechaPago, string usuarioId, DateTime fecha, bool estado)
        {
            // Inicio la transacción
            SQLConexion conProxy = new SQLConexion();
            SqlTransaction transaccion = conProxy.IniciarTransaccion();
            try
            {
                // Comienzo insertando el master

                DAO.DAOPagoEmpresa serv = new CAD.DAO.DAOPagoEmpresa();
                int codigoServ = serv.Insertar(EmpresaId, clientePaqueteId, concepto, formaPago, numeroFactura, digitosTarjeta_12, numeroAprobacionPOS, numeroCheque, nombreBancoCheque, numeroCuentaTransferencia, nombreBancoTransferencia, intercambioId, nroPago, fechaPeriodoInicio, fechaPeriodoFin, monto, fechaPago, usuarioId, fecha, estado, transaccion);

                if (codigoServ < 1)
                    throw new Exception("Error al grabar el servicio");
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

                DAO.DAOPagoEmpresa serv = new CAD.DAO.DAOPagoEmpresa();

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
