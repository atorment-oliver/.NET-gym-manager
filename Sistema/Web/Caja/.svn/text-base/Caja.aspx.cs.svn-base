using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Instrumentacion;
using System.Web.Profile;
using System.Data;
using RN.Entidades;
using System.Configuration;
using Microsoft.Reporting.WebForms;

public partial class Caja_Caja : MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblScriptShow.Text = string.Empty;
        if (!AppSecurity.HasAccess("Caja"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Caja.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }

        if (!IsPostBack)
        {
            Search();
            CargarCajero();            
        }        
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        RN.Entidades.MovimientoCaja caja = new RN.Entidades.MovimientoCaja();
        if (string.IsNullOrEmpty(CajaId.Value))
        {
            TextLogs.WriteInfo("Iniciando registro de apertura de caja.");
            TextLogs.WriteDebug("Insertando apertura de caja por monto Bs: " + txtMontoBs.Text + " monto Sus: " + txtMontoSus.Text);

            TextLogs.WriteInfo("Verificando que los montos de apertura sean menores al monto de cierre anterior.");
            if (Convert.ToDouble(txtMontoBs.Text) < Convert.ToDouble(lblUltimoMontoCierreBob.Text) || Convert.ToDouble(txtMontoSus.Text) < Convert.ToDouble(lblUltimoMontoCierreSus.Text))
            {
                TextLogs.WriteInfo("Se intentó abrir una caja con un monto inferior al monto de cierre registrado.");
                SetInformation(Helper.MessageType.Warning, "La apertura de la caja no puede ser realizada con un monto inferior al monto de cierre registrado.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                return;
            }

            MembershipUser user = Membership.GetUser();
            caja.CajaId = Convert.ToInt32(MovimientoId.Value);
            caja.FechaHoraApertura = DateTime.Now;
            caja.MontoAperturaBob = Convert.ToDecimal(txtMontoBs.Text);
            caja.MontoAperturaSus = Convert.ToDecimal(txtMontoSus.Text);
            caja.TipoCambio = Convert.ToDecimal(txtTipoCambio.Text);
            caja.Estado = true;
            caja.Fecha = DateTime.Now;
            caja.UsuarioId = user.ProviderUserKey.ToString();

            bool estado = RN.Componentes.CMovimientoCaja.Insertar(caja);
            if (estado)
            {
                TextLogs.WriteInfo("Se realizó la apertura de la caja.");
                if (AppSecurity.HasAccess("Clientes"))
                    Response.Redirect("../Clientes/Clientes.aspx", true);
                else
                {
                    SetInformation(Helper.MessageType.Info, "No se asignó acceso al formulario de clientes.");
                    lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                }
            }
            else
            {
                TextLogs.WriteInfo("Ocurrio un error al realizar la apertura de la caja.");
                SetInformation(Helper.MessageType.Info, "La apertura de la caja no pudo ser registrada.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
        }
        else
        {
            TextLogs.WriteInfo("Iniciando registro de cierre de caja.");
            TextLogs.WriteDebug("Cerrando Caja: " + CajaId.Value);

            MembershipUser user = Membership.GetUser();
            List<MovimientoCaja> movimientoCaja = RN.Componentes.CMovimientoCaja.TraerXId(Convert.ToInt32(CajaId.Value));
            caja.Id = Convert.ToInt32(CajaId.Value);
            caja.CajaId = movimientoCaja[0].CajaId;
            caja.FechaHoraApertura = movimientoCaja[0].FechaHoraApertura;
            caja.MontoCierreBob = Convert.ToDecimal(txtMontoCierreBob.Text);
            caja.MontoAdministracionBob = Convert.ToDecimal(txtMontoCierreAdministracionBob.Text);
            caja.MontoCierreSus = Convert.ToDecimal(txtMontoCierreSus.Text);
            caja.MontoAdministracionSus = Convert.ToDecimal(txtMontoCierreAdministracionSus.Text);
            caja.Estado = false;
            caja.Fecha = DateTime.Now;
            caja.UsuarioId = user.ProviderUserKey.ToString();
            caja.Observado = false;
            caja.MontoCorregido = 0;

            //if (txtObservacion.Text != "-" && txtObservacion.Text != "")
            if (Convert.ToDecimal(lblCalculoSistemaBob.Text) != Convert.ToDecimal(txtMontoCierreBob.Text))
            {
                caja.Observacion = txtObservacion.Text;
                caja.Observado = true;

            }

            bool estado = RN.Componentes.CMovimientoCaja.Actualizar(caja);
            if (estado)
            {
                try
                {
                    if (caja.Observado)
                    {
                        TextLogs.WriteInfo("Enviando notificaciones por cierre de caja.");
                        SendMailObservacion();
                    }
                    TextLogs.WriteInfo("Caja cerrada.");
                    upReporte.Visible = true;
                    fsCierreCaja.Visible = false;
                    try
                    {
                        List<RN.Entidades.Caja> cajas = RN.Componentes.CCaja.EstaAbierto(user.ProviderUserKey.ToString());

                        List<RN.Entidades.MovimientoCaja> ultimoCierre = RN.Componentes.CMovimientoCaja.UltimoCierre(cajas[0].Id.ToString());
                        if (ultimoCierre.Count != 0)
                        {
                            CargarReporte(ultimoCierre[0].FechaHoraApertura, ultimoCierre[0].FechaHoraCierre.Value, ultimoCierre[0].UsuarioId.ToString(), ultimoCierre[0].Id);
                        }
                        //Response.Redirect("./Caja.aspx?status=ok", true);
                        btnOK.Visible = false;
                        btnAceptar.Visible = true;
                        TextLogs.WriteInfo("Notificaciones por cierre de caja enviadas satifactoriamente.");
                    }
                    catch (Exception err)
                    {
                        TextLogs.WriteInfo("Ocurrio un error al realizar el cierre de la caja.");
                        SetInformation(Helper.MessageType.Info, "El cierre de caja no pudo ser registrado.");
                        lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                    }
                }
                catch (Exception error)
                {
                    TextLogs.WriteError("No se pudieron enviar las notificaciones por cierre de caja.", error);
                    Response.Redirect("./Caja.aspx?status=ok", true);
                }

            }
            //TextLogs.WriteInfo("Ocurrio un error al realizar el cierre de la caja.");
            //SetInformation(Helper.MessageType.Info, "El cierre de caja no pudo ser registrado.");
            //lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
    }
    private void SendMailObservacion()
    {
        Comunicacion.Email mail = new Comunicacion.Email();
        
        List<RN.Entidades.MovimientoCaja> mcaja = RN.Componentes.CMovimientoCaja.TraerXId(Convert.ToInt32(CajaId.Value));
        if (mcaja.Count != 0)
        {
            List<RN.Entidades.Caja> caja = RN.Componentes.CCaja.TraerXId(Convert.ToInt32(mcaja[0].CajaId));
            if (caja.Count != 0)
            {
                string idPrivilegio = AppSettings.GetRevisionID;
                
                MembershipUser user = Membership.GetUser();
                ProfileCommon profile = Profile.GetProfile(user.UserName);
                if (user != null)
                {
                    Configuration.Template template = AppSettings.GetTemplate("DiferenciaCaja");
                    mail.To.Add(template.CopyTo);

                    List<string> emails = AppSecurity.GetEmailByPrivilege(Convert.ToInt32(idPrivilegio));
                    foreach (string email in emails)
                    {
                        mail.To.Add(email);
                    }

                    string file = AppSettings.LoadFile(template.File);
                    file = file.Replace("[USUARIO]", string.Format("{0} {1}", profile.FirstName, profile.LastName));
                    file = file.Replace("[CAJA]", caja[0].Numero.ToString());
                    file = file.Replace("[FECHA]", string.Format("{0} {1}", mcaja[0].FechaHoraCierre.Value.ToShortDateString(), mcaja[0].FechaHoraCierre.Value.ToShortTimeString()));
                    file = file.Replace("[MONTO_SISTEMA]", lblCalculoSistemaBob.Text);
                    file = file.Replace("[MONTO_USUARIO]", (mcaja[0].MontoCierreBob + mcaja[0].MontoCierreSus * mcaja[0].TipoCambio).ToString());
                    file = file.Replace("[OBSERVACION]", mcaja[0].Observacion);
                    
                    mail.SendMail(AppSettings.SendHtml, template.Subject, file);
                    TextLogs.WriteInfo("Se envió a su correo electrónico de reporte de la observación.");
                }
               
                
            }
        }
    }

    private void Search()
    {        
        MembershipUser user = Membership.GetUser();        
        TextLogs.WriteInfo("Verificando si el usuario tiene una caja activa.");
        TextLogs.WriteDebug("Verificando la caja del usuario " + user.ProviderUserKey.ToString());
        List <RN.Entidades.Caja> caja = RN.Componentes.CCaja.EstaAbierto(user.ProviderUserKey.ToString());
        if (caja.Count != 0)
        {
            TextLogs.WriteInfo("Caja existente y activa");
            TextLogs.WriteInfo("Verificando si la caja está abierta.");
            TextLogs.WriteDebug("Verificando la caja " + caja[0].Id.ToString());
            List<RN.Entidades.MovimientoCaja> movimientoCaja = RN.Componentes.CMovimientoCaja.EstaAbierto(caja[0].Id.ToString());
            if (movimientoCaja.Count != 0)
            {
                TextLogs.WriteInfo("Caja abierta.");

                lblCaja.Text = "Cierre de Caja";
                btnOK.Text = "Cierre de Caja";
                btnOK.Attributes.Add("OnClick", "javascript:return Info();");
                
                CajaId.Value = movimientoCaja[0].Id.ToString();
                CajeroId.Value = user.ProviderUserKey.ToString();
                MovimientoId.Value = caja[0].Id.ToString();

                lblNroCajaCierre.Text = caja[0].Id.ToString();                                
                lblMontoAperturaBob.Text = movimientoCaja[0].MontoAperturaBob.ToString();
                lblMontoAperturaSus.Text = movimientoCaja[0].MontoAperturaSus.ToString();
                lblHoraAperturar.Text = movimientoCaja[0].FechaHoraApertura.ToString();
                lblTipoCambio.Text = movimientoCaja[0].TipoCambio.ToString();
                if (string.IsNullOrEmpty(movimientoCaja[0].FechaHoraCierre.ToString()))
                    CargarReporte(Convert.ToDateTime(movimientoCaja[0].FechaHoraApertura.ToShortDateString()), Convert.ToDateTime(movimientoCaja[0].FechaHoraApertura.ToShortDateString()), movimientoCaja[0].UsuarioId.ToString(), movimientoCaja[0].Id);
                else
                    CargarReporte(Convert.ToDateTime(movimientoCaja[0].FechaHoraApertura.ToShortDateString()), Convert.ToDateTime(movimientoCaja[0].FechaHoraCierre.Value), movimientoCaja[0].UsuarioId.ToString(), movimientoCaja[0].Id);
                // Cambiar al momento de registrar pagos
                DateTime fechaApertura = movimientoCaja[0].FechaHoraApertura;
                DateTime fechaCierre = DateTime.Now;
                List<PagoCliente> pagosCliente = RN.Componentes.CPagoCliente.TraerXCriterio(fechaApertura, fechaCierre, caja[0].CajeroId);
                List<PagoEmpresa> pagosEmpresa = RN.Componentes.CPagoEmpresa.TraerXCriterio(fechaApertura, fechaCierre, caja[0].CajeroId);

                decimal monto = 0;
                decimal montoEfectivo = 0;
                decimal montoCheque = 0;
                decimal montoTarjeta = 0;
                decimal montoIntercambio = 0;
                decimal montoTransferencia = 0;

                foreach (PagoCliente pago in pagosCliente)
                {
                    switch (pago.FormaPago)
                    {
                        case "ef":
                            {
                                montoEfectivo += pago.Monto;
                                break;
                            }
                        case "ta":
                            {
                                montoTarjeta += pago.Monto;
                                break;
                            }
                        case "ch":
                            {
                                montoCheque += pago.Monto;
                                break;
                            }
                        case "tr":
                            {
                                montoTransferencia += pago.Monto;
                                break;
                            }
                        case "in":
                            {
                                montoIntercambio += pago.Monto;
                                break;
                            }
                    }
                }
                foreach (PagoEmpresa pago in pagosEmpresa)
                {
                    switch (pago.FormaPago)
                    {
                        case "ef":
                            {
                                montoEfectivo += pago.Monto;
                                break;
                            }
                        case "ta":
                            {
                                montoTarjeta += pago.Monto;
                                break;
                            }
                        case "ch":
                            {
                                montoCheque += pago.Monto;
                                break;
                            }
                        case "tr":
                            {
                                montoTransferencia += pago.Monto;
                                break;
                            }
                        case "in":
                            {
                                montoIntercambio += pago.Monto;
                                break;
                            }
                    }
                }
                monto = montoCheque + montoEfectivo + montoIntercambio + montoTarjeta + montoTransferencia;
                
                lblPagosBob.Text = monto.ToString("F2");
                lblPagosEfectivo.Text = montoEfectivo.ToString("F2");
                lblPagosCheque.Text = montoCheque.ToString("F2");
                lblPagosTarjeta.Text = montoTarjeta.ToString("F2");
                lblPagosTransferencia.Text = montoTransferencia.ToString("F2");
                lblPagosIntercambio.Text = montoIntercambio.ToString("F2");

                monto = montoEfectivo;
                monto += movimientoCaja[0].MontoAperturaBob;
                monto += (movimientoCaja[0].TipoCambio * movimientoCaja[0].MontoAperturaSus);

                lblCalculoSistemaBob.Text = monto.ToString("f2");
                lblDiferenciaBob.Text = monto.ToString("f2");

                txtMontoCierreBob.Attributes.Add("onBlur", "javascript:EvaluateCierre();");
                txtMontoCierreSus.Attributes.Add("onBlur", "javascript:EvaluateCierre();");
                txtObservacion.Attributes.Add("onBlur", "javascript:EvaluateObservacion();");

                txtMontoCierreAdministracionBob.Text = "0";
                txtMontoCierreAdministracionSus.Text = "0";
                txtMontoCierreBob.Text = "0";
                txtMontoCierreSus.Text = "0";

                Page.SetFocus(txtMontoCierreBob);
                HabilitarCampos(true);

                upReporte.Visible = true;
                List<RN.Entidades.Caja> cajas = RN.Componentes.CCaja.EstaAbierto(user.ProviderUserKey.ToString());
                List<RN.Entidades.MovimientoCaja> ultimoCierre = RN.Componentes.CMovimientoCaja.UltimaApertura(cajas[0].Id.ToString());
                if (ultimoCierre.Count != 0)
                {
                    CargarReporte(ultimoCierre[0].FechaHoraApertura, DateTime.Now, ultimoCierre[0].UsuarioId.ToString(), ultimoCierre[0].Id);
                }
            }
            else
            {
                TextLogs.WriteInfo("Caja cerrada.");

                lblCaja.Text = "Apertura Caja";
                btnOK.Text = "Abrir Caja";

                List<Caja> cajas = RN.Componentes.CCaja.TraerXCriterio(string.Empty, user.ProviderUserKey.ToString(), "true");
                lblNroCaja.Text = cajas[0].Numero.ToString();                
                MovimientoId.Value = caja[0].Id.ToString();
                lblFechaApertura.Text = DateTime.Now.ToShortDateString();

                List<RN.Entidades.MovimientoCaja> ultimoCierre = RN.Componentes.CMovimientoCaja.UltimoCierre(caja[0].Id.ToString());
                if (ultimoCierre.Count != 0)
                {
                    TextLogs.WriteInfo("Se recupero un cierre anterior.");

                    if (ultimoCierre[0].Observado)
                    {
                        TextLogs.WriteInfo("La caja está observada. No podrá abrir una nueva caja hasta que el encargado de contabilidad corriga la caja anterior.");
                        SetInformation(Helper.MessageType.Info, "La caja está observada.<br/>No podrá abrir una nueva caja hasta que el encargado de contabilidad corriga la caja anterior.");
                        lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                        btnOK.Enabled = false;
                        return;
                    }

                    lblFechaUltimoCierre.Text = ultimoCierre[0].FechaHoraCierre.ToString();
                    lblUltimoMontoCierreBob.Text = (ultimoCierre[0].MontoCierreBob - ultimoCierre[0].MontoAdministracionBob + ultimoCierre[0].MontoCorregido).ToString();
                    lblUltimoMontoCierreSus.Text = (ultimoCierre[0].MontoCierreSus - ultimoCierre[0].MontoAdministracionSus + ultimoCierre[0].MontoCorregidoSus).ToString();
                    txtMontoBs.Text = (ultimoCierre[0].MontoCierreBob - ultimoCierre[0].MontoAdministracionBob + ultimoCierre[0].MontoCorregido).ToString();
                    txtMontoSus.Text = (ultimoCierre[0].MontoCierreSus - ultimoCierre[0].MontoAdministracionSus + ultimoCierre[0].MontoCorregidoSus).ToString();

                    if (Request.QueryString.Count > 0 && !string.IsNullOrEmpty(Request.QueryString["status"]))
                    {
                        TextLogs.WriteInfo("Se redireccionó después de un cierre de caja..");

                        if (Request.QueryString["status"].ToLower() == "ok")
                        {
                            SetInformation(Helper.MessageType.Info, "La caja fue cerrada correctamente. Para realizar operaciones en el sistema debe abrir nuevamente su CAJA.");
                            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                        }
                    }
                }
                else
                {
                    TextLogs.WriteInfo("No existe un cierre anterior.");

                    txtMontoBs.Text = "0";
                    txtMontoSus.Text = "0";
                    lblUltimoMontoCierreBob.Text = "0";
                    lblUltimoMontoCierreSus.Text = "0";
                    lblFechaUltimoCierre.Text = "-";                    
                }
                List<RN.Entidades.Parametro> lstParametro = RN.Componentes.CParametro.TraerXId(AppSettings.ParametroTipoCambio());
                bool Habilitado = false;
                decimal dTipoCambio = 0;
                if (lstParametro.Count != 0)
                {
                    Habilitado = lstParametro[0].Estado;
                    dTipoCambio = Convert.ToDecimal(lstParametro[0].Valor);
                }
                if (!Habilitado)
                {
                    //txtTipoCambio.Text = dTipoCambio.ToString();
                    txtTipoCambio.Text = string.Empty;
                }
                else
                {
                    RSSReader reader = new RSSReader();
                    reader.URL = ConfigurationManager.AppSettings["BCB_URL"];
                    reader.LoadXML();
                    txtTipoCambio.Text = reader.Venta.ToString();
                }
                

                HabilitarCampos(false);
                Page.SetFocus(txtMontoBs);
            }
        }
        else
        {
            pnlNuevo.Visible = false;
            SetInformation(Helper.MessageType.Info, "No puede abrir ni cerrar caja debido a que el usuario actual no es un Cajero.");
            lblScriptShow.Text = "<script language='JavaScript'> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
    }
    private void CargarCajero()
    {
        MembershipUser user = Membership.GetUser();
        ProfileCommon profile = Profile.GetProfile(user.UserName);
        lblCajero.Text = profile.FirstName + " " + profile.LastName;
        lblCajeroCierre.Text = profile.FirstName + " " + profile.LastName;
    }
    private void HabilitarCampos(bool habilitar)
    {
        fsCierreCaja.Visible = habilitar;
        fsAperturaCaja.Visible = !habilitar;

        if (habilitar)
            lblSaludo.Text = GetLocalResourceObject("Cierre").ToString();
        else
            lblSaludo.Text = GetLocalResourceObject("Apertura").ToString();

        // Si voy a cerrar caja evito llegar al bloqueo.
        if (habilitar)
            return;

        // Bloquear apertura de varias cajas al dia.
        MembershipUser user = Membership.GetUser();  
        List <RN.Entidades.Caja> caja = RN.Componentes.CCaja.EstaAbierto(user.ProviderUserKey.ToString());
        List<RN.Entidades.MovimientoCaja> ultimoCierre = RN.Componentes.CMovimientoCaja.UltimoCierre(caja[0].Id.ToString());
        if (ultimoCierre.Count != 0)
        {
            if (DateTime.Now.ToShortDateString() == ultimoCierre[0].FechaHoraApertura.ToShortDateString())
            {
                fsCierreCaja.Visible = false;
                fsAperturaCaja.Visible = false;
                lblSaludo.Text = GetLocalResourceObject("Bloqueo").ToString();
                btnOK.Visible = false;
            }
        }
    }
    public void SetInformation(Helper.MessageType type, string message)
    {
        popupMessage.Text = message;
        switch (type)
        {
            case Helper.MessageType.Info:
                popupTitle.Text = "INFORMACION";
                break;
            case Helper.MessageType.Warning:
                popupTitle.Text = "ADVERTENCIA";
                break;
            case Helper.MessageType.Error:
                popupTitle.Text = "ERROR";
                break;
            default:
                break;
        }
    }
    private void CargarReporte(DateTime fechaPago, DateTime fechaCierrePago, string usuarioId, int id)
    {
        DataTable datos = RN.Componentes.CPagoCliente.TraerXCaja(fechaPago, fechaCierrePago, usuarioId, id);
        rvPagos.Visible = true;
        string userName = string.Empty;
        MembershipUserCollection user = Membership.GetAllUsers();
        foreach (MembershipUser xUsuario in user)
        {
            if (xUsuario.ProviderUserKey.ToString().Equals(usuarioId))
                userName = xUsuario.UserName;
        }
        Helper.Member usuario = AppSecurity.GetUser(userName);
        string responsable = string.Empty;
        if (usuario != null)
            responsable = usuario.FirstName + " " + usuario.LastName;
        else
            responsable = "--";


        List<PagoCliente> pagosCliente = RN.Componentes.CPagoCliente.TraerXCriterio(fechaPago, fechaCierrePago, usuarioId);
        List<PagoEmpresa> pagosEmpresa = RN.Componentes.CPagoEmpresa.TraerXCriterio(fechaPago, fechaCierrePago, usuarioId);

        decimal monto = 0;
        decimal montoEfectivo = 0;
        decimal montoCheque = 0;
        decimal montoTarjeta = 0;
        decimal montoIntercambio = 0;
        decimal montoTransferencia = 0;

        foreach (PagoCliente pago in pagosCliente)
        {
            switch (pago.FormaPago)
            {
                case "ef":
                    {
                        montoEfectivo += pago.Monto;
                        break;
                    }
                case "ta":
                    {
                        montoTarjeta += pago.Monto;
                        break;
                    }
                case "ch":
                    {
                        montoCheque += pago.Monto;
                        break;
                    }
                case "tr":
                    {
                        montoTransferencia += pago.Monto;
                        break;
                    }
                case "in":
                    {
                        montoIntercambio += pago.Monto;
                        break;
                    }
            }
        }
        foreach (PagoEmpresa pago in pagosEmpresa)
        {
            switch (pago.FormaPago)
            {
                case "ef":
                    {
                        montoEfectivo += pago.Monto;
                        break;
                    }
                case "ta":
                    {
                        montoTarjeta += pago.Monto;
                        break;
                    }
                case "ch":
                    {
                        montoCheque += pago.Monto;
                        break;
                    }
                case "tr":
                    {
                        montoTransferencia += pago.Monto;
                        break;
                    }
                case "in":
                    {
                        montoIntercambio += pago.Monto;
                        break;
                    }
            }
        }

        rvPagos.LocalReport.DataSources.Clear();
        rvPagos.LocalReport.ReportPath = Server.MapPath("~/Reportes/rRecaudacionCierre.rdlc");
        rvPagos.LocalReport.SetParameters(new ReportParameter("FechaInicio", fechaPago.ToShortDateString(), true));
        rvPagos.LocalReport.SetParameters(new ReportParameter("FechaFin", fechaPago.ToShortDateString(), true));
        rvPagos.LocalReport.SetParameters(new ReportParameter("Cajero", responsable, true));
        rvPagos.LocalReport.SetParameters(new ReportParameter("Cheques", montoCheque.ToString(), true));
        rvPagos.LocalReport.SetParameters(new ReportParameter("Tarjeta", montoTarjeta.ToString(), true));
        rvPagos.LocalReport.SetParameters(new ReportParameter("Transferencia", montoTransferencia.ToString(), true));
        rvPagos.LocalReport.SetParameters(new ReportParameter("Efectivo", montoEfectivo.ToString(), true));
        rvPagos.LocalReport.DataSources.Add(new ReportDataSource("Pagos", datos));
        rvPagos.LocalReport.Refresh();
    }
    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        ShowDialog("dialogRecibos");
    }
    private void ShowDialog(string dialogId)
    {
        string script = string.Format(@"showDialog('{0}');", dialogId);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void CloseDialog(string dialogId)
    {
        string script = string.Format(@"closeDialog('{0}')", dialogId);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    protected void grdPagosRegistrados_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TextLogs.WriteInfo("Cambiando índice de página.");
        TextLogs.WriteDebug("Nuevo índice: " + e.NewPageIndex);
        //grdPagosRegistrados.PageIndex = e.NewPageIndex;
        //grdPagosRegistrados.DataBind();
    }
    protected void grdPagosRegistrados_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdPagosRegistrados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Imprimir")
        {
            //ist<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
           
            //CargarReporteRecibo(Convert.ToInt32(e.CommandArgument));
            //CloseDialogCargadoShowDialog("dialogRecibos", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci, "dialogImpresionRecibo");
        }
    }
    protected void btnCerrarRecibos_Click(object sender, EventArgs e)
    {
        CloseDialog("dialogRecibos");
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        Response.Redirect("./Caja.aspx?status=ok", true);
    }
}
