using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CClienteFecha
    {
        #region DMLS
        public static bool Insertar(ClienteFecha objProxy)
        {
            ValidationException x = new ValidationException();
            if ((objProxy.ClienteId) <= 0)
                x.AgregarError("Ingrese el cliente");

            if (x.Cantidad > 0)
                throw x;

            DAOClienteFecha daoProxy = new DAOClienteFecha();
            return daoProxy.Insertar(objProxy.ClienteId, objProxy.FechaInicio, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha);
        }
        public static bool Actualizar(ClienteFecha objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.ClienteId <= 0)
                x.AgregarError("Ingrese el código");

            if ((objProxy.ClienteId) <= 0)
                x.AgregarError("Ingrese el cliente");

            if (x.Cantidad > 0)
                throw x;

            DAOClienteFecha daoProxy = new DAOClienteFecha();
            return daoProxy.Actualizar(objProxy.ClienteId, objProxy.FechaInicio, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha);
        }
        public static bool EliminarClienteFecha(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOClienteFecha daoProxy = new DAOClienteFecha();
            return daoProxy.Eliminar(codigo);
        }

        #endregion
        #region Selects
        public static List<ClienteFecha> Traer()
        {
            DAOClienteFecha daoProxy = new DAOClienteFecha();
            DataSet dtsProxy = daoProxy.TraerClienteFechas();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<ClienteFecha> TraerXId(int codigo)
        {
            DAOClienteFecha daoProxy = new DAOClienteFecha();
            DataSet dtsProxy = daoProxy.TraerClienteFechaXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<ClienteFecha> TraerXIdCliente(int codigo)
        {
            DAOClienteFecha daoProxy = new DAOClienteFecha();
            DataSet dtsProxy = daoProxy.TraerClienteFechaXIdCliente(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        
        #endregion
        #region Metodos Privados
        private static List<ClienteFecha> CargarLista(DataTable tabla)
        {
            List<ClienteFecha> lstProxy = new List<ClienteFecha>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static ClienteFecha Cargar(DataRow fila)
        {
            ClienteFecha objProxy = new ClienteFecha();
            objProxy.ClienteId = Convert.ToInt32(fila["clienteId"].ToString());
            objProxy.FechaInicio = Convert.ToDateTime(fila["FechaInicio"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());

            return objProxy;
        }
        #endregion
    }
}
