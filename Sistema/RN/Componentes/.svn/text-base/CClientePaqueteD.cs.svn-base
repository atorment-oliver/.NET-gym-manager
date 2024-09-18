using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CClientePaqueteD
    {
        #region DMLS
        public static bool Insertar(ClientePaquete objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.ClienteId < 0)
                x.AgregarError("Ingrese el Cliente");

            if (x.Cantidad > 0)
                throw x;

            DAOClientePaquete daoProxy = new DAOClientePaquete();
            return daoProxy.Insertar(objProxy.ClienteId, objProxy.PaqueteId, objProxy.FechaRegistro, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha) > 0;
        }
        #endregion
        #region Metodos Privados
        private static List<ClientePaquete> CargarLista(DataTable tabla)
        {
            List<ClientePaquete> lstProxy = new List<ClientePaquete>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static ClientePaquete Cargar(DataRow fila)
        {
            ClientePaquete objProxy = new ClientePaquete();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.PaqueteId = Convert.ToInt32(fila["paqueteId"].ToString());
            objProxy.ClienteId = Convert.ToInt32(fila["clienteId"].ToString());
            objProxy.FechaRegistro = Convert.ToDateTime(fila["fechaRegistro"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());

            return objProxy;
        }
        #endregion
    }
}
