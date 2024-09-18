using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CGrupo
    {
        #region DMLS
        public static int Insertar(Grupo objProxy)
        {
            ValidationException x = new ValidationException();
            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre del Grupo");

            if (x.Cantidad > 0)
                throw x;

            DAOGrupo daoProxy = new DAOGrupo();
            return daoProxy.Insertar(objProxy.Nombre, objProxy.HorarioId, objProxy.ServicioId, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha);
        }
        public static bool Actualizar(Grupo objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (string.IsNullOrEmpty(objProxy.Nombre))
                x.AgregarError("Ingrese el nombre");

            if (x.Cantidad > 0)
                throw x;

            DAOGrupo daoProxy = new DAOGrupo();
            return daoProxy.Actualizar(objProxy.Id, objProxy.Nombre, objProxy.HorarioId, objProxy.ServicioId, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha);
        }
        public static bool ActualizarHorario(int id, int horarioId)
        {
            ValidationException x = new ValidationException();
            if (horarioId <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOGrupo daoProxy = new DAOGrupo();
            return daoProxy.ActualizarHorarioId(id, horarioId);
        }
        public static bool EliminarPaquete(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOGrupo daoProxy = new DAOGrupo();
            return daoProxy.Eliminar(codigo);
        }

        #endregion
        #region Selects
        public static List<Grupo> Traer()
        {
            DAOGrupo daoProxy = new DAOGrupo();
            DataSet dtsProxy = daoProxy.TraerGrupos();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Grupo> TraerXId(int codigo)
        {
            DAOGrupo daoProxy = new DAOGrupo();
            DataSet dtsProxy = daoProxy.TraerGrupoXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Grupo> TraerXCriterio(string nombre, string tipoPaqueteId, string estado)
        {
            DAOGrupo daoProxy = new DAOGrupo();
            DataSet dtsProxy = daoProxy.TraerGrupoXCriterio(nombre, tipoPaqueteId, estado);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXCriterioD(string nombre, string servicioId, string estado)
        {
            DAOGrupo daoProxy = new DAOGrupo();
            DataSet dtsProxy = daoProxy.TraerGrupoXCriterio(nombre, servicioId, estado);


            return dtsProxy.Tables[0];
        }
        public static DataTable Grupo_TraerXServicio(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");
            DAOGrupo daoProxy = new DAOGrupo();
            DataSet dtsProxy = daoProxy.Grupo_TraerXServicio(codigo);
            return dtsProxy.Tables[0];
        }
        public static DataTable Grupo_TraerXServicioHorario(int codigo)
        {
            ValidationException x = new ValidationException();
            DAOGrupo daoProxy = new DAOGrupo();
            DataSet dtsProxy = daoProxy.Grupo_TraerServicioHorario(codigo);
            return dtsProxy.Tables[0];
        }
        public static DataTable Grupo_TraerXServicioHorarioCliente(int codigo)
        {
            ValidationException x = new ValidationException();
            DAOGrupo daoProxy = new DAOGrupo();
            DataSet dtsProxy = daoProxy.Grupo_TraerServicioHorarioCliente(codigo);
            return dtsProxy.Tables[0];
        }
        public static DataTable Grupo_TraerHorario(int codigo, int clientepaqueteid, DateTime fecha)
        {
            ValidationException x = new ValidationException();
            DAOGrupo daoProxy = new DAOGrupo();
            DataSet dtsProxy = daoProxy.Grupo_TraerHorario(codigo, clientepaqueteid, fecha);
            return dtsProxy.Tables[0];
        }
        public static DataTable Grupo_TraerHorarioIn(int codigo, int clientepaqueteid, DateTime fecha)
        {
            ValidationException x = new ValidationException();
            DAOGrupo daoProxy = new DAOGrupo();
            DataSet dtsProxy = daoProxy.Grupo_TraerHorarioIn(codigo, clientepaqueteid, fecha);
            return dtsProxy.Tables[0];
        }
        public static DataTable Grupo_TraerHorarioValidando(string salaId)
        {
            DAOGrupo daoProxy = new DAOGrupo();
            DataSet dtsProxy = daoProxy.Grupo_TraerValidando(salaId);
            return dtsProxy.Tables[0];
        }
        public static DataTable Grupo_TraerIdValidando(int id)
        {
            DAOGrupo daoProxy = new DAOGrupo();
            DataSet dtsProxy = daoProxy.Grupo_TraerIdValidando(id);
            return dtsProxy.Tables[0];
        }
        public static DataTable Grupo_TraerValidandoCrucesHorario(int id, int id2)
        {
            DAOGrupo daoProxy = new DAOGrupo();
            DataSet dtsProxy = daoProxy.Grupo_TraerValidandoCrucesHorario(id, id2);
            return dtsProxy.Tables[0];
        }
        #endregion
        #region Metodos Privados
        private static List<Grupo> CargarLista(DataTable tabla)
        {
            List<Grupo> lstProxy = new List<Grupo>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Grupo Cargar(DataRow fila)
        {
            Grupo objProxy = new Grupo();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.Nombre = fila["nombre"].ToString();
            objProxy.HorarioId = Convert.ToInt32(fila["horarioId"].ToString());
            objProxy.ServicioId = Convert.ToInt32(fila["servicioId"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());

            return objProxy;
        }
        #endregion
    }
}
