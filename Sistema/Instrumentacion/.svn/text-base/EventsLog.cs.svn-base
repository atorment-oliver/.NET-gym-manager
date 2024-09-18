using System;
using System.Diagnostics;

namespace Instrumentacion
{
    public class EventsLog
    {
        public static void InsertarErrorEventLog(string strOrigen, System.Exception e)
        {
            // Verifico que en el EventLog exista el origen
            // Se puede utilizar la sobrecarga para indicarle en que servidor hacer el log
            // El punto "." representa el machineName localhost
            //EventLogPermission eventLogPermission = new EventLogPermission(EventLogPermissionAccess.Administer, ".");
            //eventLogPermission.PermitOnly();
            if (!EventLog.SourceExists(strOrigen, "."))
            {
                // Si el origen no existe en el EventLog, lo creo dentro del grupo de errores de Aplicacion
                EventSourceCreationData srcData = new EventSourceCreationData(strOrigen, "Application");
                EventLog.CreateEventSource(srcData);
            }
            // Escribo el registro del error en el EventLog
            /*
             * e.Source = Origen del mensaje Ej. Si fue un error del motor de base de datos 
             * e.Message = Mensaje que indica el error que ocurrio
             * e.StackTrace = Pila de llamadas (Metodos) que se ocuparon antes de que se de el error
             */
            // Si no especifico el tipo de Error, el EventLog lo va a tomar como "Informacion"
            EventLog.WriteEntry(strOrigen, e.Source + "\n" + e.Message + "\n" + e.StackTrace, EventLogEntryType.Error);
            // Vuelvo a lanzar al error para que siga escalando hasta la capa de interfaz de usuario
        }
        public static void InsertarWarningEventLog(string strOrigen, System.Exception e)
        {
            // Verifico que en el EventLog exista el origen
            if (!EventLog.SourceExists(strOrigen, "."))
            {
                // Si el origen no existe en el EventLog, lo creo dentro del grupo de errores de Aplicacion
                EventSourceCreationData srcData = new EventSourceCreationData(strOrigen, "Application");
                EventLog.CreateEventSource(srcData);
            }
            // Escribo el registro del warning en el EventLog
            EventLog.WriteEntry(strOrigen, e.Source + "\n" + e.Message + "\n" + e.StackTrace, EventLogEntryType.Warning);
        }
        public static void InsertarInformacionEventLog(string strOrigen, string strMensaje)
        {
            // Verifico que en el EventLog exista el orig
            if (!EventLog.SourceExists(strOrigen, "."))
            {
                // Si el origen no existe en el EventLog, lo creo dentro del grupo de errores de Aplicacion
                EventSourceCreationData srcData = new EventSourceCreationData(strOrigen, "Application");
                EventLog.CreateEventSource(srcData);
            }
            // Escribo el registro del warning en el EventLog
            EventLog.WriteEntry(strOrigen, strMensaje, EventLogEntryType.Information, 123);
        }
    }
}
