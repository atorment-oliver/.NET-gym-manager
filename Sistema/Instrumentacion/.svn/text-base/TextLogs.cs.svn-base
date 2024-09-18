using System;
using System.Configuration;

namespace Instrumentacion
{
    public class TextLogs
    {
        private static string strLogger;
        public static void Configure()
        {
            log4net.Config.XmlConfigurator.Configure();
            strLogger = ConfigurationManager.AppSettings["Logger"];
        }
        public static void WriteError(string mensaje, Exception x)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(strLogger);
            log.Error(mensaje, x);
        }
        public static void WriteInfo(string mensaje)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(strLogger);
            log.Info(mensaje);
        }
        public static void WriteWarning(string mensaje, Exception x)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(strLogger);
            log.Warn(mensaje, x);
        }
        public static void WriteDebug(string mensaje)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(strLogger);
            log.Debug(mensaje);
        }
    }
}
