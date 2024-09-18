using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Workflows
{
    public class WLicencia
    {
        #region DMLS
        public static bool Insertar(Licencia objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Fecha < DateTime.Now.AddDays(-1))
                x.AgregarError("La fecha debe ser mayor a la fecha actual");

            if (objProxy.ClientePaqueteId < 0)
                x.AgregarError("No ingresó el cliente paquete");

            if (x.Cantidad > 0)
                throw x;

            // Paso el detalle a un DataSet para enviarlo a la CAD
            CAD.WorkFlows.WFLLicencia wflProxy = new CAD.WorkFlows.WFLLicencia();
            return wflProxy.Insertar(objProxy.Descripcion,objProxy.ClientePaqueteId, objProxy.FechaSolicitud,objProxy.FechaInicioLicencia,objProxy.FechaFinLicencia, objProxy.Estado, objProxy.UsuarioId,objProxy.Fecha) > 0;
        }
        public static bool Eliminar(int id)
        {
            ValidationException x = new ValidationException();
            if (id < 0)
                x.AgregarError("No ingresó el id");

            if (x.Cantidad > 0)
                throw x;

            // Paso el detalle a un DataSet para enviarlo a la CAD
            CAD.WorkFlows.WFLLicencia wflProxy = new CAD.WorkFlows.WFLLicencia();
            return wflProxy.Eliminar(id);
        }
        #endregion
    }
}
