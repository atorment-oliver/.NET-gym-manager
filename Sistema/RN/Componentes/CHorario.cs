using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CHorario
    {
        #region DMLS
        public static bool Insertar(Horario objProxy)
        {
            ValidationException x = new ValidationException();

            if (objProxy.HoraInicio.Length < 5)
                x.AgregarError("La hora de inicio no está bien representada");

            if (objProxy.HoraFin.Length < 5)
                x.AgregarError("La hora de finalización no está bien representada");

            if (x.Cantidad > 0)
                throw x;

            int hora = Convert.ToInt32(objProxy.HoraInicio.Substring(0, 2));
            int minuto = Convert.ToInt32(objProxy.HoraInicio.Substring(3, 2));
            DateTime inicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hora, minuto, 0);

            hora = Convert.ToInt32(objProxy.HoraFin.Substring(0, 2));
            minuto = Convert.ToInt32(objProxy.HoraFin.Substring(3, 2));
            DateTime fin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hora, minuto, 0);

            if (inicio >= fin)
                x.AgregarError("La hora de inicio debe ser menor a la hora de finalización");

            if (objProxy.SalaId <= 0)
                x.AgregarError("No se tiene una sala definida");

            if (x.Cantidad > 0)
                throw x;

            DAOHorario daoProxy = new DAOHorario();
            return daoProxy.Insertar(objProxy.HoraInicio, objProxy.HoraFin, objProxy.FinDeSemana, objProxy.SalaId, objProxy.Estado) > 0;
        }
        public static bool Actualizar(Horario objProxy)
        {
            ValidationException x = new ValidationException();

            if (objProxy.HoraInicio.Length < 5)
                x.AgregarError("La hora de inicio no está bien representada");

            if (objProxy.HoraFin.Length < 5)
                x.AgregarError("La hora de finalización no está bien representada");

            if (x.Cantidad > 0)
                throw x;

            int hora = Convert.ToInt32(objProxy.HoraInicio.Substring(0, 2));
            int minuto = Convert.ToInt32(objProxy.HoraInicio.Substring(3, 2));
            DateTime inicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hora, minuto, 0);

            hora = Convert.ToInt32(objProxy.HoraFin.Substring(0, 2));
            minuto = Convert.ToInt32(objProxy.HoraFin.Substring(3, 2));
            DateTime fin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hora, minuto, 0);

            if (inicio >= fin)
                x.AgregarError("La hora de inicio debe ser menor a la hora de finalización");

            if (objProxy.SalaId <= 0)
                x.AgregarError("No se tiene una sala definida");

            DAOHorario daoProxy = new DAOHorario();
            return daoProxy.Actualizar(objProxy.Id, objProxy.HoraInicio, objProxy.HoraFin, objProxy.FinDeSemana, objProxy.SalaId, objProxy.Estado);
        }
        public static bool Eliminar(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOHorario daoProxy = new DAOHorario();
            return daoProxy.Eliminar(codigo);
        }
        #endregion
        #region Selects
        public static Horario TraerXId(int codigo)
        {
            DAOHorario daoProxy = new DAOHorario();
            DataSet dtsProxy = daoProxy.TraerHorarioXId(codigo);
            
            if (dtsProxy.Tables.Count > 0 && dtsProxy.Tables[0].Rows.Count > 0)
                return Cargar(dtsProxy.Tables[0].Rows[0]);
            return null;
        }
        public static List<Horario> TraerXSala(int salaID)
        {
            DAOHorario daoProxy = new DAOHorario();
            DataSet dtsProxy = daoProxy.TraerHorarioXSala(salaID);

            if (dtsProxy.Tables.Count > 0 && dtsProxy.Tables[0].Rows.Count > 0)
                return CargarLista(dtsProxy.Tables[0]);
            return null;
        }
        public static DataTable TraerXCriterio(string horaInicio, string horaFin, int salaId)
        {
            DAOHorario daoProxy = new DAOHorario();
            DataSet dtsProxy = daoProxy.TraerHorarioXCriterio(horaInicio, horaFin, salaId);
            
            return dtsProxy.Tables[0];
        }
        public static DataTable TraerXCriterioCruce(string horaInicio, string horaFin, int salaId, bool finDeSemana, bool estado)
        {
            DAOHorario daoProxy = new DAOHorario();
            DataSet dtsProxy = daoProxy.TraerHorarioXCriterioCruce(horaInicio, horaFin, finDeSemana, salaId, estado);

            return dtsProxy.Tables[0];
        }
        public static DataTable TraerReporte()
        {
            DAOHorario daoProxy = new DAOHorario();
            DataSet dtsProxy = daoProxy.TraerReporte();
            return dtsProxy.Tables[0];
        }
        #endregion
        #region Metodos Privados
        private static List<Horario> CargarLista(DataTable tabla)
        {
            List<Horario> lstProxy = new List<Horario>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Horario Cargar(DataRow fila)
        {
            Horario objProxy = new Horario();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.HoraInicio = fila["horaInicio"].ToString();
            objProxy.HoraFin = fila["horaFIn"].ToString();
            objProxy.SalaId = Convert.ToInt32(fila["salaId"]);
            objProxy.FinDeSemana = Convert.ToBoolean(fila["finDeSemana"].ToString());
            objProxy.Estado = Convert.ToBoolean(fila["estado"].ToString());
            
            return objProxy;
        }
        #endregion
    }
}
