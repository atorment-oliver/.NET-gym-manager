using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CEmpresa
    {
        #region DMLS
        public static bool Insertar(Empresa objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre del Empresa");

            if (x.Cantidad > 0)
                throw x;

            DAOEmpresa daoProxy = new DAOEmpresa();
            return daoProxy.Insertar(objProxy.Nombre,objProxy.Descripcion,objProxy.NombrePersonaContacto,objProxy.Telefono,objProxy.Correo,objProxy.Direccion,objProxy.FechaRegistro,objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado) > 0;
        }
        public static bool Actualizar(Empresa objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre");

            if (x.Cantidad > 0)
                throw x;

            DAOEmpresa daoProxy = new DAOEmpresa();
            return daoProxy.Actualizar(objProxy.Id, objProxy.Nombre, objProxy.Descripcion, objProxy.NombrePersonaContacto, objProxy.Telefono, objProxy.Correo, objProxy.Direccion, objProxy.FechaRegistro, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado);
        }
        public static bool EliminarEmpresa(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOEmpresa daoProxy = new DAOEmpresa();
            return daoProxy.Eliminar(codigo);
        }
        #endregion
        #region Selects
        public static List<Empresa> Traer()
        {
            DAOEmpresa daoProxy = new DAOEmpresa();
            DataSet dtsProxy = daoProxy.TraerEmpresas();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Empresa> TraerXId(int codigo)
        {
            DAOEmpresa daoProxy = new DAOEmpresa();
            DataSet dtsProxy = daoProxy.TraerEmpresaXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Empresa> TraerXCriterio(string nombre, string nombrePersonaContacto, string correo, string estado)
        {
            DAOEmpresa daoProxy = new DAOEmpresa(); 
            DataSet dtsProxy = daoProxy.TraerEmpresaXCriterio(nombre,nombrePersonaContacto, correo, estado);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXCriterioData(string nombre, string nombrePersonaContacto, string correo, string estado)
        {
            DAOEmpresa daoProxy = new DAOEmpresa();
            DataSet dtsProxy = daoProxy.TraerEmpresaXCriterio(nombre, nombrePersonaContacto, correo, estado);


            return (dtsProxy.Tables[0]);
        }
        #endregion
        #region Metodos Privados
        private static List<Empresa> CargarLista(DataTable tabla)
        {
            List<Empresa> lstProxy = new List<Empresa>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Empresa Cargar(DataRow fila)
        {
            Empresa objProxy = new Empresa();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Nombre = fila["nombre"].ToString();
            objProxy.Descripcion = fila["descripcion"].ToString();
            objProxy.NombrePersonaContacto = fila["nombrePersonaContacto"].ToString();
            objProxy.Telefono = fila["telefono"].ToString();
            objProxy.Correo = fila["correo"].ToString();
            objProxy.Direccion = fila["direccion"].ToString();
            objProxy.FechaRegistro = Convert.ToDateTime(fila["fechaRegistro"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.UsuarioId = fila["usuarioId"].ToString();
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());
            return objProxy;
        }
        #endregion
    }
}
