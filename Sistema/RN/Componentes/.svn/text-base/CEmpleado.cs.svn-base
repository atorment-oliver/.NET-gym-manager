using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CEmpleado
    {
        #region DMLS
        public static bool Insertar(Empleado objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre del empleado");

            if (x.Cantidad > 0)
                throw x;

            DAOEmpleado daoProxy = new DAOEmpleado();
            return daoProxy.Insertar(objProxy.Nombre) > 0;
        }
        public static bool ActualizarEmpleado(Empleado objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre");

            if (x.Cantidad > 0)
                throw x;

            DAOEmpleado daoProxy = new DAOEmpleado();
            return daoProxy.Actualizar(objProxy.Codigo, objProxy.Nombre);
        }
        public static bool EliminarEmpleado(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOEmpleado daoProxy = new DAOEmpleado();
            return daoProxy.Eliminar(codigo);
        }
        #endregion
        #region Selects
        public static List<Empleado> Traer()
        {   
            DAOEmpleado daoProxy = new DAOEmpleado();
            DataSet dtsProxy = daoProxy.TraerEmpleado();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Empleado> TraerXId(int codigo)
        {
            DAOEmpleado daoProxy = new DAOEmpleado();
            DataSet dtsProxy = daoProxy.TraerEmpleadoXId(codigo);

            
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Empleado> TraerXNombre(string nombre)
        {
            DAOEmpleado daoProxy = new DAOEmpleado();
            DataSet dtsProxy = daoProxy.TraerEmpleadoXNombre(nombre);


            return CargarLista(dtsProxy.Tables[0]);
        }
        #endregion
        #region Metodos Privados
        private static List<Empleado> CargarLista(DataTable tabla)
        {
            List<Empleado> lstProxy = new List<Empleado>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Empleado Cargar(DataRow fila)
        {
            Empleado objProxy = new Empleado();
            objProxy.Codigo = Convert.ToInt32(fila["codigo"]);
            objProxy.Nombre = fila["nombre"].ToString();
            return objProxy;
        }
        #endregion
    }
}
