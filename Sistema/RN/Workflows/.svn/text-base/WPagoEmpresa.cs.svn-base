using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Workflows
{
    public class WPagoEmpresa
    {
        #region DMLS
        public static bool Insertar(List<PagoEmpresa> objProxys)
        {
            ValidationException x = new ValidationException();
            bool bRetorno = false;
            foreach (RN.Entidades.PagoEmpresa objProxy in objProxys)
            {
                if (objProxy.Fecha < DateTime.Now.AddDays(-1))
                    x.AgregarError("La fecha debe ser mayor a la fecha actual");

                if (objProxy.ClientePaqueteId < 0)
                    x.AgregarError("No ingresó el cliente paquete");

                if (x.Cantidad > 0)
                    throw x;

                // Paso el detalle a un DataSet para enviarlo a la CAD
                CAD.WorkFlows.WFLPagoEmpresa wflProxy = new CAD.WorkFlows.WFLPagoEmpresa();
                bRetorno = bRetorno & wflProxy.Insertar(objProxy.EmpresaId, objProxy.ClientePaqueteId, objProxy.Concepto, objProxy.FormaPago, objProxy.NumeroFactura, objProxy.DigitosTarjeta_12, objProxy.NumeroAprobacionPOS, objProxy.NumeroCheque, objProxy.NombreBancoCheque, objProxy.NumeroCuentaTransferencia, objProxy.NombreBancoTransferencia, objProxy.IntercambioId, objProxy.NroPago, objProxy.FechaPeriodoInicio, objProxy.FechaPeriodoFin, objProxy.Monto, objProxy.FechaPago, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado) > 0;
            }
            return bRetorno;
        }
        public static bool Eliminar(int id)
        {
            ValidationException x = new ValidationException();
            if (id < 0)
                x.AgregarError("No ingresó el id");

            if (x.Cantidad > 0)
                throw x;

            // Paso el detalle a un DataSet para enviarlo a la CAD
            CAD.WorkFlows.WFLPagoEmpresa wflProxy = new CAD.WorkFlows.WFLPagoEmpresa();
            return wflProxy.Eliminar(id);
        }
        #endregion
    }
}
