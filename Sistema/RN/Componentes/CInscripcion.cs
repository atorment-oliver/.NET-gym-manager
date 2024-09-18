using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CInscripcion
    {
        #region DMLS
        public static bool Insertar(Inscripcion objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.ClientePaqueteId < 0)
                x.AgregarError("Ingrese el cliente");

            if (x.Cantidad > 0)
                throw x;

            DAOInscripcion daoProxy = new DAOInscripcion();
            return daoProxy.Insertar(objProxy.ClientePaqueteId, objProxy.GrupoId, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha) > 0;
        }
        public static bool Actualizar(Inscripcion objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (objProxy.ClientePaqueteId < 0)
                x.AgregarError("Ingrese el cliente");

            if (x.Cantidad > 0)
                throw x;

            DAOInscripcion daoProxy = new DAOInscripcion();
            return daoProxy.Actualizar(objProxy.Id, objProxy.ClientePaqueteId, objProxy.GrupoId, objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha);
        }
        public static bool EliminarInscripcion(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOInscripcion daoProxy = new DAOInscripcion();
            return daoProxy.Eliminar(codigo);
        }

        #endregion
        #region Selects
        public static List<Inscripcion> Traer()
        {
            DAOInscripcion daoProxy = new DAOInscripcion();
            DataSet dtsProxy = daoProxy.TraerInscripcion();
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Inscripcion> TraerXId(int codigo)
        {
            DAOInscripcion daoProxy = new DAOInscripcion();
            DataSet dtsProxy = daoProxy.TraerInscripcionXId(codigo);
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Inscripcion> TraerXGrupoId(int codigo, int clientepaqueteid)
        {
            DAOInscripcion daoProxy = new DAOInscripcion();
            DataSet dtsProxy = daoProxy.TraerXGrupoId(codigo, clientepaqueteid);
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Inscripcion> TraerXGrupoId(int codigo)
        {
            DAOInscripcion daoProxy = new DAOInscripcion();
            DataSet dtsProxy = daoProxy.TraerXGrupoId(codigo);
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Inscripcion> TraerXIdClientePaqueteId(int codigo)
        {
            DAOInscripcion daoProxy = new DAOInscripcion();
            DataSet dtsProxy = daoProxy.TraerXIdClientePaqueteId(codigo);
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Inscripcion> TraerXCriterio(string clientePaqueteId, string grupoId, string estado)
        {
            DAOInscripcion daoProxy = new DAOInscripcion();
            DataSet dtsProxy = daoProxy.TraerInscripcionXCriterio(clientePaqueteId, grupoId, estado);
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Inscripcion> TraerXClienteGrupo(int clientePaqueteId, int grupoId)
        {
            DAOInscripcion daoProxy = new DAOInscripcion();
            DataSet dtsProxy = daoProxy.TraerInscripcionXClienteGrupo(clientePaqueteId, grupoId);
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerTiempo(int clientePaqueteId, DateTime fecha)
        {
            DAOInscripcion daoProxy = new DAOInscripcion();
            DataSet dtsProxy = daoProxy.TraerTiempo(clientePaqueteId, fecha);
            return (dtsProxy.Tables[0]);
        }
        public static DataTable TraerXCriterioD(string clientePaqueteId, string grupoId, string estado)
        {
            DAOInscripcion daoProxy = new DAOInscripcion();
            DataSet dtsProxy = daoProxy.TraerInscripcionXCriterio(clientePaqueteId, grupoId, estado);
            return dtsProxy.Tables[0];
        }
        
        #endregion
        #region Metodos Privados
        private static List<Inscripcion> CargarLista(DataTable tabla)
        {
            List<Inscripcion> lstProxy = new List<Inscripcion>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Inscripcion Cargar(DataRow fila)
        {
            Inscripcion objProxy = new Inscripcion();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.ClientePaqueteId = Convert.ToInt32(fila["clientePaqueteId"].ToString());
            objProxy.GrupoId = Convert.ToInt32(fila["grupoId"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.UsuarioId = (fila["usuarioId"].ToString());
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());
            return objProxy;
        }
        #endregion
    }
}
