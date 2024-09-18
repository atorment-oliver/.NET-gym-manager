using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using RN;
using CAD;
using System.Configuration;
using System.Resources;
using Comunicacion;

namespace Procesos
{
    class Notificaciones
    {
        string aconexion;
        public Notificaciones()
        {
            aconexion = ConfigurationSettings.AppSettings["DB"].ToString();
        }
        public void EnviarNotificacionSinCi()
        {
            CAD.SQLConexion conexion = new SQLConexion(aconexion);
            DataSet objCliente = conexion.EjecutarConsulta("vip.Cliente_TraerSinCi");
            string sMensajes = string.Empty;
            string sClientes = string.Empty;
            System.Resources.ResourceManager mgr = new System.Resources.ResourceManager("Procesos.Mensajes", System.Reflection.Assembly.GetExecutingAssembly());
            sMensajes = mgr.GetString("NotificacionClienteSinCiCuerpoHtml");
            foreach (DataRow Row in objCliente.Tables[0].Rows)
            {
                sClientes = sClientes + "<tr>";
                sClientes = sClientes + "<td>" + Row["nombre"].ToString() + " " + Row["apellidos"].ToString() + "</td>";
                sClientes = sClientes + "<td>" + Row["celular"].ToString() + "</td>";
                sClientes = sClientes + "<td>" + Row["correo"].ToString() + "</td>";
                sClientes = sClientes + "<td>" + Convert.ToDateTime(Row["fechaIngreso"]).ToString("dd/MM/yyyy") + "</td>";
                sClientes = sClientes + "</tr>";
            }
            sMensajes = (sMensajes.Replace("[Listado]", sClientes)).Replace("[Fecha]",DateTime.Now.ToShortDateString());
            Comunicacion.Email objMail = new Email();
            List<string> lstCorreos = ConfigurationSettings.AppSettings["correos"].ToString().Split(';').ToList();
            objMail.To = lstCorreos;

            try
            {
                if (objCliente.Tables[0].Rows.Count != 0)
                {
                    objMail.Cc.Add("ppmiranda@vipcenter.com.bo");
                    objMail.SendMail(true, mgr.GetString("NotificacionClienteSinCiAsunto"), sMensajes);
                }
            }
            catch (Exception error)
            {
                throw new Exception("No se pudo enviar la notificacion de clientes sin ci");
            }
        }
        public void EliminarClientesSinPagos()
        {
            CAD.SQLConexion conexion = new SQLConexion(aconexion);
            DataSet objCliente = conexion.EjecutarConsulta("vip.Cliente_SinPagos");
            conexion.EjecutarConsulta("vip.Cliente_EliminarSinPagos");
            string sMensajes = string.Empty;
            string sClientes = string.Empty;
            System.Resources.ResourceManager mgr = new System.Resources.ResourceManager("Procesos.Mensajes", System.Reflection.Assembly.GetExecutingAssembly());
            sMensajes = mgr.GetString("NotificacionClienteSinPagoCuerpoHtml");
            foreach (DataRow Row in objCliente.Tables[0].Rows)
            {
                sClientes = sClientes + "<tr>";
                sClientes = sClientes + "<td>" + Row["nombre"].ToString() + " " + Row["apellidos"].ToString() + "</td>";
                sClientes = sClientes + "<td>" + Row["celular"].ToString() + "</td>";
                sClientes = sClientes + "<td>" + Row["correo"].ToString() + "</td>";
                sClientes = sClientes + "<td>" + Convert.ToDateTime(Row["fechaIngreso"]).ToString("dd/MM/yyyy") + "</td>";
                sClientes = sClientes + "</tr>";
            }
            sMensajes = sMensajes.Replace("[Listado]", sClientes);
            Comunicacion.Email objMail = new Email();
            List<string> lstCorreos = ConfigurationSettings.AppSettings["correos"].ToString().Split(';').ToList();
            objMail.To = lstCorreos;

            try
            {
                if (objCliente.Tables[0].Rows.Count != 0)
                    objMail.SendMail(true, mgr.GetString("NotificacionClienteSinPagoAsunto"), sMensajes);
            }
            catch (Exception error)
            {
                throw new Exception("No se pudo enviar la notificacion de clientes sin ci");
            }
        }
        public void DeshabilitarClientesMorosos()
        {
            CAD.SQLConexion conexion = new SQLConexion(aconexion);
            conexion.EjecutarConsulta("vip.Cliente_DeshabilitarNoPagados");

            string sMensajes = string.Empty;
            string sClientes = string.Empty;
            System.Resources.ResourceManager mgr = new System.Resources.ResourceManager("Procesos.Mensajes", System.Reflection.Assembly.GetExecutingAssembly());
            sMensajes = mgr.GetString("NotificacionClienteDeshabilitadoHtml1");

            Comunicacion.Email objMail = new Email();
            List<string> lstCorreos = ConfigurationSettings.AppSettings["correos"].ToString().Split(';').ToList();
            objMail.To = lstCorreos;
            try
            {
                objMail.SendMail(true, mgr.GetString("NotificacionClienteDeshabilitadoAsunto"), sMensajes);
            }
            catch (Exception error)
            {
                throw new Exception("No se pudo deshabilitar los clientes morosos");
            }
        }
        public void NotificarPagosPorVencer()
        {
            CAD.SQLConexion conexion = new SQLConexion(aconexion);
            DataSet objCliente = conexion.EjecutarConsulta("vip.PagoCliente_PagosPorVencer");

            string sMensajes = string.Empty;
            string sClientes = string.Empty;
            System.Resources.ResourceManager mgr = new System.Resources.ResourceManager("Procesos.Mensajes", System.Reflection.Assembly.GetExecutingAssembly());
            sMensajes = mgr.GetString("NotificacionPagosPorVencerCuerpoHtml");

            Comunicacion.Email objMail = new Email();
            List<string> lstCorreos = ConfigurationSettings.AppSettings["correos"].ToString().Split(';').ToList();
            objMail.To = lstCorreos;
            foreach (DataRow Row in objCliente.Tables[0].Rows)
            {
                sClientes = sClientes + "<tr>";
                sClientes = sClientes + "<td>" + Row["numeroCliente"].ToString() + "</td>";
                sClientes = sClientes + "<td>" + Row["nombreCliente"].ToString() + "</td>";
                sClientes = sClientes + "<td>" + Row["telefono"].ToString() + "</td>";
                sClientes = sClientes + "<td>" + Row["celular"].ToString() + "</td>";
                sClientes = sClientes + "<td>" + Row["correo"].ToString() + "</td>";
                sClientes = sClientes + "<td>" + Row["nombrePaquete"].ToString() + "</td>";
                sClientes = sClientes + "<td>" + Convert.ToDateTime(Row["fechaFin"]).ToString("dd/MM/yyyy") + "</td>";
                sClientes = sClientes + "</tr>";
            }
            if (objCliente.Tables[0].Rows.Count != 0)
            {
                sMensajes = sMensajes.Replace("[Listado]", sClientes);
                try
                {
                    objMail.Cc.Add(ConfigurationSettings.AppSettings["vencimientos"].ToString());
                    objMail.SendMail(true, mgr.GetString("NotificacionPagosPorVencerAsunto"), sMensajes);
                }
                catch (Exception error)
                {
                    throw new Exception(error.Message);
                }
            }
        }
        public void NotificarPagosPorVencerCliente3()
        {
            CAD.SQLConexion conexion = new SQLConexion(aconexion);
            DataSet objCliente = conexion.EjecutarConsulta("vip.PagoCliente_PagosPorVencerCliente3");

            string sMensajes = string.Empty;
            string sClientes = string.Empty;
            System.Resources.ResourceManager mgr = new System.Resources.ResourceManager("Procesos.Mensajes", System.Reflection.Assembly.GetExecutingAssembly());
            sMensajes = mgr.GetString("NotificacionPagosPorVencerClienteCuerpoHtml");

            Comunicacion.Email objMail = new Email();
            foreach (DataRow Row in objCliente.Tables[0].Rows)
            {
                if (!string.IsNullOrEmpty(Row["correo"].ToString()))
                {
                    List<string> lstCorreos = new List<string>();
                    lstCorreos.Add(Row["correo"].ToString());
                    objMail.To = lstCorreos;
                    sMensajes = string.Empty;
                    sClientes = string.Empty;
                    sMensajes = mgr.GetString("NotificacionPagosPorVencerClienteCuerpoHtml");
                    sClientes = sClientes + "<tr>";
                    sClientes = sClientes + "<td>" + Row["numeroCliente"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Row["nombreCliente"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Row["telefono"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Row["celular"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Row["correo"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Row["nombrePaquete"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Convert.ToDateTime(Row["fechaFin"]).ToString("dd/MM/yyyy") + "</td>";
                    sClientes = sClientes + "</tr>";
                    if (objCliente.Tables[0].Rows.Count != 0)
                    {
                        sMensajes = sMensajes.Replace("[Listado]", sClientes);
                        sMensajes = sMensajes.Replace("[dias]", "3");
                        try
                        {
                            objMail.SendMail(true, mgr.GetString("NotificacionPagosPorVencerAsunto"), sMensajes);
                        }
                        catch (Exception error)
                        {
                            throw new Exception(error.Message);
                        }
                    }
                }
            }
        }
        public void NotificarPagosPorVencerCliente2()
        {
            CAD.SQLConexion conexion = new SQLConexion(aconexion);
            DataSet objCliente = conexion.EjecutarConsulta("vip.PagoCliente_PagosPorVencerCliente2");

            string sMensajes = string.Empty;
            string sClientes = string.Empty;
            System.Resources.ResourceManager mgr = new System.Resources.ResourceManager("Procesos.Mensajes", System.Reflection.Assembly.GetExecutingAssembly());
            

            Comunicacion.Email objMail = new Email();
            foreach (DataRow Row in objCliente.Tables[0].Rows)
            {
                if (!string.IsNullOrEmpty(Row["correo"].ToString()))
                {
                    List<string> lstCorreos = new List<string>();
                    lstCorreos.Add(Row["correo"].ToString());
                    objMail.To = lstCorreos;
                    sMensajes = string.Empty;
                    sClientes = string.Empty;
                    sMensajes = mgr.GetString("NotificacionPagosPorVencerClienteCuerpoHtml");
                    sClientes = sClientes + "<tr>";
                    sClientes = sClientes + "<td>" + Row["numeroCliente"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Row["nombreCliente"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Row["telefono"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Row["celular"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Row["correo"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Row["nombrePaquete"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Convert.ToDateTime(Row["fechaFin"]).ToString("dd/MM/yyyy") + "</td>";
                    sClientes = sClientes + "</tr>";
                    if (objCliente.Tables[0].Rows.Count != 0)
                    {
                        sMensajes = sMensajes.Replace("[Listado]", sClientes);
                        sMensajes = sMensajes.Replace("[dias]", "2");
                        try
                        {
                            objMail.SendMail(true, mgr.GetString("NotificacionPagosPorVencerAsunto"), sMensajes);
                        }
                        catch (Exception error)
                        {
                            throw new Exception(error.Message);
                        }
                    }
                }
            }
        }
        public void NotificarPagosPorVencerCliente()
        {
            CAD.SQLConexion conexion = new SQLConexion(aconexion);
            DataSet objCliente = conexion.EjecutarConsulta("vip.PagoCliente_PagosPorVencerCliente");

            string sMensajes = string.Empty;
            string sClientes = string.Empty;
            System.Resources.ResourceManager mgr = new System.Resources.ResourceManager("Procesos.Mensajes", System.Reflection.Assembly.GetExecutingAssembly());
            sMensajes = mgr.GetString("NotificacionPagosPorVencerClienteCuerpoHtml");

            Comunicacion.Email objMail = new Email();
            foreach (DataRow Row in objCliente.Tables[0].Rows)
            {
                if (!string.IsNullOrEmpty(Row["correo"].ToString()))
                {
                    List<string> lstCorreos = new List<string>();
                    lstCorreos.Add(Row["correo"].ToString());
                    objMail.To = lstCorreos;
                    sMensajes = string.Empty;
                    sClientes = string.Empty;
                    sMensajes = mgr.GetString("NotificacionPagosPorVencerClienteCuerpoHtml");
                    sClientes = sClientes + "<tr>";
                    sClientes = sClientes + "<td>" + Row["numeroCliente"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Row["nombreCliente"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Row["telefono"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Row["celular"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Row["correo"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Row["nombrePaquete"].ToString() + "</td>";
                    sClientes = sClientes + "<td>" + Convert.ToDateTime(Row["fechaFin"]).ToString("dd/MM/yyyy") + "</td>";
                    sClientes = sClientes + "</tr>";
                    if (objCliente.Tables[0].Rows.Count != 0)
                    {
                        sMensajes = sMensajes.Replace("[Listado]", sClientes);
                        sMensajes = sMensajes.Replace("[dias]", "1");
                        try
                        {
                            objMail.SendMail(true, mgr.GetString("NotificacionPagosPorVencerAsunto"), sMensajes);
                        }
                        catch (Exception error)
                        {
                            throw new Exception(error.Message);
                        }
                    }
                }
            }
        }
    }    
}
