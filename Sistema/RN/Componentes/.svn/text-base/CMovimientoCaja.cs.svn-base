using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CMovimientoCaja
    {
        #region DMLS
        public static bool Insertar(MovimientoCaja objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.MontoAperturaBob <0 || objProxy.MontoAperturaSus < 0)
                x.AgregarError("Ingrese el monto de apertura en Bs. y/o Sus.");

            if (x.Cantidad > 0)
                throw x;

            DAOMovimientoCaja daoProxy = new DAOMovimientoCaja();
            return daoProxy.Insertar(objProxy.CajaId, objProxy.FechaHoraApertura, objProxy.MontoAperturaBob, objProxy.MontoAperturaSus, objProxy.TipoCambio, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado) > 0;
        }
        public static bool Actualizar(MovimientoCaja objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if (objProxy.CajaId <=0)
                x.AgregarError("Ingrese la caja");

            if (x.Cantidad > 0)
                throw x;

            DAOMovimientoCaja daoProxy = new DAOMovimientoCaja();
            return daoProxy.Actualizar(objProxy.Id, objProxy.MontoCorregido, objProxy.MontoCorregidoSus, objProxy.Observado, objProxy.ObservacionAdm, objProxy.CajaId, objProxy.FechaHoraCierre, objProxy.Observacion, objProxy.MontoCierreBob, objProxy.MontoCierreSus, objProxy.MontoAdministracionBob, objProxy.MontoAdministracionSus, objProxy.UsuarioId, objProxy.Fecha, objProxy.Estado);
        }
        public static bool EliminarMovimientoCaja(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOMovimientoCaja daoProxy = new DAOMovimientoCaja();
            return daoProxy.Eliminar(codigo);
        }
        #endregion
        #region Selects
        public static List<MovimientoCaja> Traer()
        {
            DAOMovimientoCaja daoProxy = new DAOMovimientoCaja();
            DataSet dtsProxy = daoProxy.TraerMovimientoCajas();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<MovimientoCaja> TraerXId(int codigo)
        {
            DAOMovimientoCaja daoProxy = new DAOMovimientoCaja();
            DataSet dtsProxy = daoProxy.TraerMovimientoCajaXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<MovimientoCaja> TraerXCriterio(string nombre, string nombrePersonaContacto, string correo, string estado)
        {
            DAOMovimientoCaja daoProxy = new DAOMovimientoCaja();
            DataSet dtsProxy = daoProxy.TraerMovimientoCajaXCriterio(nombre, nombrePersonaContacto, correo, estado);


            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<MovimientoCaja> TraerXObservacion(DateTime fechaDesdeCierre, DateTime fechaHastaCierre, Guid cajeroId, char tipo)
        {
            DAOMovimientoCaja daoProxy = new DAOMovimientoCaja();
            DataSet dtsProxy = daoProxy.TraerMovimientoCajaXObservacion(fechaDesdeCierre, fechaHastaCierre, cajeroId, tipo);
            
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static DataTable TraerXCriterioData(string nombre, string nombrePersonaContacto, string correo, string estado)
        {
            DAOMovimientoCaja daoProxy = new DAOMovimientoCaja();
            DataSet dtsProxy = daoProxy.TraerMovimientoCajaXCriterio(nombre, nombrePersonaContacto, correo, estado);


            return (dtsProxy.Tables[0]);
        }
        public static List<MovimientoCaja> EstaAbierto(string codigo)
        {
            ValidationException x = new ValidationException();

            if (x.Cantidad > 0)
                throw x;

            DAOMovimientoCaja daoProxy = new DAOMovimientoCaja();
            DataSet dtsProxy = daoProxy.EstaAbierto(codigo);
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<MovimientoCaja> UltimoCierre(string codigo)
        {
            ValidationException x = new ValidationException();

            if (x.Cantidad > 0)
                throw x;

            DAOMovimientoCaja daoProxy = new DAOMovimientoCaja();
            DataSet dtsProxy = daoProxy.UltimoCierre(codigo);
            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<MovimientoCaja> UltimaApertura(string codigo)
        {
            ValidationException x = new ValidationException();

            if (x.Cantidad > 0)
                throw x;

            DAOMovimientoCaja daoProxy = new DAOMovimientoCaja();
            DataSet dtsProxy = daoProxy.UltimaApertura(codigo);
            return CargarLista(dtsProxy.Tables[0]);
        }
        #endregion
        #region Metodos Privados
        private static List<MovimientoCaja> CargarLista(DataTable tabla)
        {
            List<MovimientoCaja> lstProxy = new List<MovimientoCaja>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static MovimientoCaja Cargar(DataRow fila)
        {
            DateTime? fechaHoraCierre = null;
            if (fila["fechaHoraCierre"] != System.DBNull.Value)
                fechaHoraCierre = Convert.ToDateTime(fila["fechaHoraCierre"].ToString());

            MovimientoCaja objProxy = new MovimientoCaja();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.CajaId = Convert.ToInt32(fila["cajaId"].ToString());
            objProxy.FechaHoraApertura = Convert.ToDateTime(fila["fechaHoraApertura"].ToString());
            objProxy.MontoAperturaBob = Convert.ToDecimal(fila["montoAperturaBob"].ToString());
            objProxy.MontoAperturaSus = Convert.ToDecimal(fila["montoAperturaSus"].ToString());
            objProxy.FechaHoraCierre =  fechaHoraCierre;
            objProxy.MontoCierreBob = Convert.ToDecimal(fila["montoCierreBob"].ToString());
            objProxy.MontoCierreSus = Convert.ToDecimal(fila["montoCierreSus"].ToString());
            objProxy.MontoAdministracionBob = Convert.ToDecimal(fila["montoAdministracionBob"].ToString());
            objProxy.MontoAdministracionSus = Convert.ToDecimal(fila["montoAdministracionSus"].ToString());
            objProxy.TipoCambio = Convert.ToDecimal(fila["tipoCambio"].ToString());
            objProxy.Observacion = fila["observacion"].ToString();
            objProxy.ObservacionAdm = fila["observacionAdm"].ToString();
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            objProxy.Observado = Convert.ToBoolean(fila["observado"].ToString());
            objProxy.MontoCorregido = Convert.ToDecimal(fila["montocorreccion"].ToString());
            objProxy.MontoCorregidoSus = Convert.ToDecimal(fila["montocorreccionSus"].ToString());
            objProxy.UsuarioId = fila["usuarioId"].ToString();
            objProxy.Fecha = Convert.ToDateTime(fila["fecha"].ToString());
            return objProxy;
        }
        #endregion
    }
}
