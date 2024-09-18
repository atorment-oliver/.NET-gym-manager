using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CCliente
    {
        #region DMLS
        public static bool Insertar(Cliente objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre del Cliente");

            if (x.Cantidad > 0)
                throw x;

            DAOCliente daoProxy = new DAOCliente();
            return daoProxy.Insertar(objProxy.Nombre, objProxy.Apellidos, objProxy.Direccion, objProxy.Telefono, objProxy.Celular, objProxy.Celular2, objProxy.Ci, objProxy.Correo, objProxy.Ocupacion, objProxy.LugarTrabajo, objProxy.TelefonoTrabajo, objProxy.CorreoTrabajo, objProxy.FechaNacimiento, objProxy.Genero, objProxy.EstadoCivil, objProxy.TieneHijos, objProxy.NumeroHijos, objProxy.FechaIngreso, objProxy.NumeroCliente, objProxy.RecibirNotificaciones, objProxy.EmpresaId, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado) > 0;
        }
        public static int InsertarId(Cliente objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre del Cliente");

            if (x.Cantidad > 0)
                throw x;

            DAOCliente daoProxy = new DAOCliente();
            return daoProxy.Insertar(objProxy.Nombre, objProxy.Apellidos, objProxy.Direccion, objProxy.Telefono, objProxy.Celular, objProxy.Celular2, objProxy.Ci, objProxy.Correo, objProxy.Ocupacion, objProxy.LugarTrabajo, objProxy.TelefonoTrabajo, objProxy.CorreoTrabajo, objProxy.FechaNacimiento, objProxy.Genero, objProxy.EstadoCivil, objProxy.TieneHijos, objProxy.NumeroHijos, objProxy.FechaIngreso, objProxy.NumeroCliente, objProxy.RecibirNotificaciones, objProxy.EmpresaId, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado);
        }
        public static bool Actualizar(Cliente objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre");

            if (x.Cantidad > 0)
                throw x;

            DAOCliente daoProxy = new DAOCliente();
            return daoProxy.Actualizar(objProxy.Id, objProxy.Nombre, objProxy.Apellidos, objProxy.Direccion, objProxy.Telefono, objProxy.Celular, objProxy.Celular2, objProxy.Ci, objProxy.Correo, objProxy.Ocupacion, objProxy.LugarTrabajo, objProxy.TelefonoTrabajo, objProxy.CorreoTrabajo, objProxy.FechaNacimiento, objProxy.Genero, objProxy.EstadoCivil, objProxy.TieneHijos, objProxy.NumeroHijos, objProxy.FechaIngreso, objProxy.NumeroCliente, objProxy.RecibirNotificaciones, objProxy.EmpresaId, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado);
        }
        public static bool EliminarCliente(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOCliente daoProxy = new DAOCliente();
            return daoProxy.Eliminar(codigo);
        }
        public static int TraerMaximoNumero()
        {
            DAOCliente daoProxy = new DAOCliente();
            DataSet dtsProxy = daoProxy.TraerMaximoNumero();
            if (dtsProxy.Tables[0].Rows.Count != 0)
                return Convert.ToInt32(dtsProxy.Tables[0].Rows[0][0].ToString());
            else
                return 0;
        }
        public static bool ExisteCi()
        {
            DAOCliente daoProxy = new DAOCliente();
            DataSet dtsProxy = daoProxy.ExisteCi();
            if (dtsProxy.Tables[0].Rows.Count != 0)
                return Convert.ToInt32(dtsProxy.Tables[0].Rows.Count)> 0;
            else
                return false;
        }
        #endregion
        #region Selects
        public static List<Cliente> Traer()
        {
            DAOCliente daoProxy = new DAOCliente();
            DataSet dtsProxy = daoProxy.TraerClientes();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Cliente> TraerXId(int codigo)
        {
            DAOCliente daoProxy = new DAOCliente();
            DataSet dtsProxy = daoProxy.TraerClienteXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Cliente> TraerXCriterio(string nombre, string correo, string ci, string estado)
        {
            DAOCliente daoProxy = new DAOCliente();
            DataSet dtsProxy = daoProxy.TraerClienteXCriterio(nombre, correo, ci, estado);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Cliente> ValidarDatos(string nombre, string apellido, string ci)
        {
            DAOCliente daoProxy = new DAOCliente();
            DataSet dtsProxy = daoProxy.ValidarDatos(nombre, apellido, ci);

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Cliente> TraerXCriterioSinEmpresa(string nombre, string correo, string ci, string estado)
        {
            DAOCliente daoProxy = new DAOCliente();
            DataSet dtsProxy = daoProxy.TraerClienteXCriterioSinEmpresa(nombre, correo, ci, estado);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Cliente> TraerXOrCriterio(string nombre, string correo, string ci, string estado)
        {
            DAOCliente daoProxy = new DAOCliente();
            DataSet dtsProxy = daoProxy.TraerClienteXOrCriterio(nombre, correo, ci, estado);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Cliente> TraerSinCi()
        {
            DAOCliente daoProxy = new DAOCliente();
            DataSet dtsProxy = daoProxy.TraerSinCi();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXOrCriterioEmpresa(string nombre, string correo, string ci, string estado)
        {
            DAOCliente daoProxy = new DAOCliente();
            DataSet dtsProxy = daoProxy.TraerClienteXCriterio(nombre, correo, ci, estado);


            return dtsProxy.Tables[0];
        }
        public static DataTable TraerXCriterioData(string nombre, string nombrePersonaContacto, string correo, string estado)
        {
            DAOCliente daoProxy = new DAOCliente();
            DataSet dtsProxy = daoProxy.TraerClienteXCriterio(nombre, nombrePersonaContacto, correo, estado);


            return (dtsProxy.Tables[0]);
        }
        public static DataTable TraerXOrCriterioPaquetes(string nombre, string correo, string ci, string estado, string clientePaqueteId)
        {
            DAOCliente daoProxy = new DAOCliente();
            DataSet dtsProxy = daoProxy.TraerXOrCriterioPaquetes(nombre, correo, ci, estado, clientePaqueteId);


            return (dtsProxy.Tables[0]);
        }
        public static DataTable TraerXOrCriterioPaquetesReporte(string nombre, string correo, string ci, string estado, string clientePaqueteId)
        {
            DAOCliente daoProxy = new DAOCliente();
            DataSet dtsProxy = daoProxy.TraerXOrCriterioPaquetesReporte(nombre, correo, ci, estado, clientePaqueteId);


            return (dtsProxy.Tables[0]);
        }
        public static DataTable TraerXFiltro(string clienteId, DateTime fechaPagoInicio, DateTime fechaPagoFin, string empresaId, string grupoId, string formaPago, string paqueteId, string servicioId, string promocionId, string estado, string estadonr, string estadopago)
        {
            DAOCliente daoProxy = new DAOCliente();
            return daoProxy.TraerXFiltro(clienteId, fechaPagoInicio, fechaPagoFin, empresaId, grupoId, formaPago, paqueteId, servicioId, promocionId, estado, estadonr, estadopago).Tables[0];
        }
        public static DataTable TraerXFiltro2(string clienteId, DateTime fechaPagoInicio, DateTime fechaPagoFin, string empresaId, string grupoId, string formaPago, string paqueteId, string servicioId, string promocionId, string estado, string estadonr, string estadopago)
        {
            DAOCliente daoProxy = new DAOCliente();
            return daoProxy.TraerXFiltro2(clienteId, fechaPagoInicio, fechaPagoFin, empresaId, grupoId, formaPago, paqueteId, servicioId, promocionId, estado, estadonr, estadopago).Tables[0];
        }
        public static DataTable TraerXFiltro3(string clienteId, DateTime fechaPagoInicio, DateTime fechaPagoFin, string empresaId, string grupoId, string formaPago, string paqueteId, string servicioId, string promocionId, string estado, string estadonr, string estadopago)
        {
            DAOCliente daoProxy = new DAOCliente();
            return daoProxy.TraerXFiltro3(clienteId, fechaPagoInicio, fechaPagoFin, empresaId, grupoId, formaPago, paqueteId, servicioId, promocionId, estado, estadonr, estadopago).Tables[0];
        }
        public static DataTable TraerDatos(string estado)
        {
            DAOCliente daoProxy = new DAOCliente();
            return daoProxy.TraerDatos(estado).Tables[0];
        }
        public static DataTable TraerConEmpresa(string nombre)
        {
            DAOCliente daoProxy = new DAOCliente();
            DataSet dtsProxy = daoProxy.TraerClienteConEmpresa(nombre);
            return (dtsProxy.Tables[0]);
        }
        #endregion
        #region Metodos Privados
        private static List<Cliente> CargarLista(DataTable tabla)
        {
            List<Cliente> lstProxy = new List<Cliente>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Cliente Cargar(DataRow fila)
        {
            Cliente objProxy = new Cliente();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Nombre = fila["nombre"].ToString();
            objProxy.Apellidos = fila["apellidos"].ToString();
            objProxy.Direccion = fila["direccion"].ToString();
            objProxy.Telefono = fila["telefono"].ToString();
            objProxy.Celular = fila["celular"].ToString();
            objProxy.Ci = fila["ci"].ToString();
            objProxy.CiCi = fila["ciCi"].ToString();
            objProxy.Correo = fila["correo"].ToString();
            objProxy.Ocupacion = fila["ocupacion"].ToString();
            objProxy.LugarTrabajo = fila["lugarTrabajo"].ToString();
            objProxy.TelefonoTrabajo = fila["telefonoTrabajo"].ToString();
            objProxy.CorreoTrabajo = fila["correoTrabajo"].ToString();

            if (fila["fechaNacimiento"] == System.DBNull.Value)
                objProxy.FechaNacimiento = new DateTime(1900,1,1);
            else
                objProxy.FechaNacimiento = Convert.ToDateTime(fila["fechaNacimiento"].ToString());
            objProxy.Genero = fila["genero"].ToString();
            objProxy.EstadoCivil = fila["estadoCivil"].ToString();
            objProxy.TieneHijos = Convert.ToBoolean(fila["tieneHijos"].ToString());
            objProxy.NumeroHijos = Convert.ToInt32(fila["numeroHijos"].ToString());
            objProxy.FechaIngreso = Convert.ToDateTime(fila["fechaIngreso"].ToString());
            //objProxy.NumeroCliente = Convert.ToInt32(fila["numeroCliente"].ToString());
            if (string.IsNullOrEmpty(fila["numeroCliente"].ToString()))
                objProxy.NumeroCliente = Convert.ToInt32(0);
            else
                objProxy.NumeroCliente = Convert.ToInt32(fila["numeroCliente"].ToString());
            objProxy.RecibirNotificaciones = Convert.ToBoolean(fila["recibirNotificaciones"].ToString());
            if (fila["empresaId"].ToString() == "")
                objProxy.EmpresaId = 0;
            else
                objProxy.EmpresaId = Convert.ToInt32(fila["empresaId"].ToString());
            objProxy.UsuarioId = fila["usuarioId"].ToString();
            objProxy.Direccion = fila["direccion"].ToString();
            objProxy.Estado = fila["estado"].ToString();
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());
            return objProxy;
        }
        #endregion
    }
}
