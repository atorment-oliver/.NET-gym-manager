using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Instrumentacion;
using System.Web.Profile;
using System.Data;
using System.Web.Security;
using Microsoft.Reporting.WebForms;
using RN.Entidades;

public partial class Caja_Revision : MyPage
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        ResultGrid.CssClass = "ui-widget-content";
        if (ResultGrid.Rows.Count > 0)
        {
            ResultGrid.UseAccessibleHeader = true;
            ResultGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
            ResultGrid.HeaderRow.CssClass = "ui-widget-header";
            ResultGrid.FooterRow.TableSection = TableRowSection.TableFooter;

            if (ResultGrid.TopPagerRow != null)
                ResultGrid.TopPagerRow.TableSection = TableRowSection.TableHeader;

            if (ResultGrid.BottomPagerRow != null)
                ResultGrid.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!AppSecurity.HasAccess("DiferenciaCaja"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Revision.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }

        if (!IsPostBack)
        {
            txtFechaDesdeBuscar.Text = DateTime.Now.ToShortDateString();
            txtFechaHastaBuscar.Text = DateTime.Now.ToShortDateString();
            CargarCajeros();
            SetFocus();
            Search();
        }
        lblScriptShow.Text = string.Empty;
    }
    private void CargarCajeros()
    {
        DataTable dtCajeros = AppSecurity.GetUsersList("", "", "", false, true);
        dtCajeros = Concatenar(dtCajeros);
        ddlCajeroBuscar.DataSource = dtCajeros;
        ddlCajeroBuscar.DataTextField = "NombreCompleto";
        ddlCajeroBuscar.DataValueField = "UserId";
        ddlCajeroBuscar.DataBind();
        Guid guid = new Guid();
        ListItem lis = new ListItem("Todos", guid.ToString());
        lis.Selected = true;
        ddlCajeroBuscar.Items.Add(lis);
    }
    private DataTable Concatenar(DataTable data)
    {
        DataTable dtInforme = new DataTable();
        for (int i = 0; i < data.Columns.Count; i++)
        {
            dtInforme.Columns.Add(data.Columns[i].ColumnName, typeof(String));
        }
        dtInforme.Columns.Add("NombreCompleto");
        for (int i = 0; i < data.Rows.Count; i++)
        {
            if (RN.Componentes.CCaja.TraerXCriterio("", data.Rows[i]["UserId"].ToString(), "").Count != 0)
                dtInforme.Rows.Add(data.Rows[i][0].ToString(), data.Rows[i][1].ToString(), data.Rows[i][2].ToString(), data.Rows[i][3].ToString(), data.Rows[i][4].ToString(), data.Rows[i][5].ToString(), data.Rows[i][6].ToString(), data.Rows[i][7].ToString(), data.Rows[i][8].ToString(), data.Rows[i][9].ToString(), string.Format("{0} {1}", data.Rows[i]["FirstName"].ToString(), data.Rows[i]["LastName"].ToString()));
        }
        return dtInforme;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (Convert.ToDouble(txtCierreBs.Text) != Convert.ToDouble(lblSistemaBs.Text))
        //{
        //    TextLogs.WriteInfo("El monto esperado por el sistema no cuadra con el monto ingresado.");
        //    SetInformation(Helper.MessageType.Error, "El monto esperado por el sistema no cuadra con el monto ingresado.");
        //    lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        //    return;
        //}

        List<RN.Entidades.MovimientoCaja> movimientos = RN.Componentes.CMovimientoCaja.TraerXId(Convert.ToInt32(MovimientoId.Value));
        try
        {
            RN.Entidades.MovimientoCaja movimiento = movimientos[0];
            TextLogs.WriteDebug("Actualizando movimiento: " + MovimientoId.Value);
            TextLogs.WriteInfo("Ingresando a actualizar movimiento.");

            movimiento.MontoCierreSus = Convert.ToDecimal(txtCierreSus.Text);
            movimiento.MontoCierreBob = Convert.ToDecimal(txtCierreBs.Text);
            movimiento.MontoAdministracionBob = Convert.ToDecimal(txtAdministracionBs.Text);
            movimiento.MontoAdministracionSus = Convert.ToDecimal(txtAdministracionSus.Text);
            movimiento.Observacion = txtObservacion.Text;
            movimiento.Observado = false;
            movimiento.MontoCorregido = Convert.ToDecimal(txtCuadre.Text);
            movimiento.MontoCorregidoSus = Convert.ToDecimal(txtCuadreSus.Text);
            movimiento.ObservacionAdm = txtObservacionAdm.Text;
            
            
            RN.Componentes.CMovimientoCaja.Actualizar(movimiento);
            TextLogs.WriteInfo("Se actualizo el movimiento.");
            SetViewPanel(true);
            SetFocus();
            Search();
            TextLogs.WriteInfo("El movimiento ha sido guardado correctamente.");
            SetInformation(Helper.MessageType.Info, "El movimiento ha sido guardado correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
        catch (System.Data.SqlClient.SqlException err)
        {
            MensajesError(err);
        }
        catch (Exception err)
        {
            TextLogs.WriteError("No se pudo guardar la empresa", err);
            SetInformation(Helper.MessageType.Error, "Verifique los datos ingresados.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
    }
    private void MensajesError(System.Data.SqlClient.SqlException eVariable)
    {
        string sError = "No se pudo guardar la empresa";
        string sTipo = string.Empty;
        switch (eVariable.Number.ToString())
        {
            case "08001":
                sTipo = "Error de conexion con la base de datos";
                break;
            default:
                sTipo = "Error no clasificado";
                break;
        }
        TextLogs.WriteError(sError, eVariable);
        SetInformation(Helper.MessageType.Error, sTipo);
        lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de Movimientos de caja INVISIBLE.");
        SetViewPanel(false);

        Limpiar();
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de movimientos de caja VISIBLE.");
        SetViewPanel(true);
    }

    protected void Seach_Click(object sender, EventArgs e)
    {
        if (revFechaIngreso.IsValid && RegularExpressionValidator3.IsValid)
        {
            TextLogs.WriteInfo("Filtrando resultados del listado de empresas.");
            SetFocus();
            Search();
        }
        else
        {
            SetInformation(Helper.MessageType.Info, "Error en las fechas.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName);

        if (e.CommandName == "Editar")
        {
            TextLogs.WriteInfo("Recuperando datos del movimiento de caja seleccionado.");
            SetViewPanel(false);
            LoadData(e.CommandArgument.ToString());
            return;
        }
        Search();
    }
    protected void ResultGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TextLogs.WriteInfo("Cambiando índice de página.");
        TextLogs.WriteDebug("Nuevo índice: " + e.NewPageIndex);
        ResultGrid.PageIndex = e.NewPageIndex;
        Search();
    }

    private void SetViewPanel(bool status)
    {
        pnlNuevo.Visible = !status;
        pnlVer.Visible = status;
        SetFocus();
    }
    private void SetFocus()
    {
        if (pnlNuevo.Visible)
        {
            Page.SetFocus(txtCierreBs);
            return;
        }
        Page.SetFocus(ddlCajeroBuscar);
    }
    private void Search()
    {
        CargarMovimientos();
        lblInfo.Text = ResultGrid.Rows.Count.ToString();
        TextLogs.WriteDebug("Resultados encontrados en el grid: " + lblInfo.Text);
    }
    public string IsClosed(object id)
    {
        bool abierto = Convert.ToBoolean(DataBinder.Eval(id, "estado"));
        if (abierto)
            return "Activo";

        return "Cerrado";
    }
    public string IsObserved(object id)
    {
        if (Convert.ToBoolean(DataBinder.Eval(id, "observado")))
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
    public string GetCajero(object id)
    {
        Helper.Member usuario = AppSecurity.GetUser(new Guid(DataBinder.Eval(id, "usuarioId").ToString()));
        if (usuario == null)
            return string.Empty;

        return usuario.FirstName + " " + usuario.LastName;
    }
    private void Limpiar()
    {
        MovimientoId.Value = string.Empty;
        txtAdministracionBs.Text = string.Empty;
        txtAdministracionSus.Text = string.Empty;
        txtCuadre.Text = string.Empty;
        txtCierreBs.Text = string.Empty;
        txtCierreSus.Text = string.Empty;
        txtObservacion.Text = string.Empty;
        TextLogs.WriteInfo("Valores del formulario limpiados.");
    }
    private void LoadData(string id)
    {
        TextLogs.WriteInfo("Cargando datos del movimiento a a los controles del formulario.");
        TextLogs.WriteDebug("Cargando movimiento: " + id);
        List<RN.Entidades.MovimientoCaja> movimiento = RN.Componentes.CMovimientoCaja.TraerXId(Convert.ToInt32(id));

        MovimientoId.Value = id;
        txtObservacion.Text = movimiento[0].Observacion;
        txtCierreSus.Text = movimiento[0].MontoCierreSus.ToString();
        txtCierreBs.Text = movimiento[0].MontoCierreBob.ToString();
        txtAdministracionSus.Text = movimiento[0].MontoAdministracionSus.ToString();
        txtAdministracionBs.Text = movimiento[0].MontoAdministracionBob.ToString();
        lblAperturaBs.Text = movimiento[0].MontoAperturaBob.ToString();
        lblAperturaSus.Text = movimiento[0].MontoAperturaSus.ToString();
        lblTipoCambio.Text = movimiento[0].TipoCambio.ToString();        
        lblEstado.Text = movimiento[0].Estado == true ? "Abierto" : "Cerrado";
        lblFechaApertura.Text = movimiento[0].FechaHoraApertura.ToShortDateString() + " " + movimiento[0].FechaHoraApertura.ToShortTimeString();
        CargarReporte(movimiento[0].FechaHoraApertura, movimiento[0].FechaHoraCierre.Value, movimiento[0].UsuarioId.ToString(), movimiento[0].Id);
        // Recupera los pagos registrados en el sistema durante el turno del cajero
        List<RN.Entidades.Caja> caja = RN.Componentes.CCaja.TraerXId(movimiento[0].CajaId);
        DateTime fechaApertura = movimiento[0].FechaHoraApertura;
        DateTime fechaCierre = movimiento[0].FechaHoraCierre.Value;

        List<RN.Entidades.PagoCliente> pagosCliente = RN.Componentes.CPagoCliente.TraerXCriterio(fechaApertura, fechaCierre, caja[0].CajeroId);
        List<RN.Entidades.PagoEmpresa> pagosEmpresa = RN.Componentes.CPagoEmpresa.TraerXCriterio(fechaApertura, fechaCierre, caja[0].CajeroId);

        decimal monto = 0;
        decimal montoEfectivo = 0;
        decimal montoCheque = 0;
        decimal montoTarjeta = 0;
        decimal montoTransferencia = 0;
        decimal montoIntercambio = 0;
        foreach (RN.Entidades.PagoCliente pago in pagosCliente)
        {
            if (pago.FormaPago == "ef")
                montoEfectivo += pago.Monto;
            else if (pago.FormaPago == "ch")
                montoCheque += pago.Monto;
            else if (pago.FormaPago == "ta")
                montoTarjeta += pago.Monto;
            else if (pago.FormaPago == "tr")
                montoTransferencia += pago.Monto;
            else if (pago.FormaPago == "in")
                montoIntercambio += pago.Monto;
        }
        foreach (RN.Entidades.PagoEmpresa pago in pagosEmpresa)
        {
            if (pago.FormaPago == "ef")
                montoEfectivo += pago.Monto;
            else if (pago.FormaPago == "ch")
                montoCheque += pago.Monto;
            else if (pago.FormaPago == "ta")
                montoTarjeta += pago.Monto;
            else if (pago.FormaPago == "tr")
                montoTransferencia += pago.Monto;
            else if (pago.FormaPago == "in")
                montoIntercambio += pago.Monto;
        }

        lblPagosCheque.Text = montoCheque.ToString("f2");
        lblPagosEfectivo.Text = montoEfectivo.ToString("f2");
        lblPagosTarjeta.Text = montoTarjeta.ToString("f2");
        lblPagosTransferencia.Text = montoTransferencia.ToString("f2");
        lblPagosIntercambio.Text = montoIntercambio.ToString("f2");
        
        monto = montoCheque + montoEfectivo + montoIntercambio + montoTarjeta + montoTransferencia;
        lblPagos.Text = monto.ToString("f2");

        monto = montoEfectivo;
        monto += movimiento[0].MontoAperturaBob;
        monto += (movimiento[0].TipoCambio * movimiento[0].MontoAperturaSus);

        lblSistemaBs.Text = monto.ToString("f2");
        lblDiferenciaBob.Text = (monto - movimiento[0].MontoCierreBob - movimiento[0].MontoCierreSus * movimiento[0].TipoCambio).ToString("f2");

        lblFechaCierre.Text = "-";
        if (!movimiento[0].Estado)
            lblFechaCierre.Text = movimiento[0].FechaHoraCierre.Value.ToShortDateString() + " " + movimiento[0].FechaHoraCierre.Value.ToShortTimeString();

        if (caja == null || caja.Count < 1)
            return;

        Helper.Member usuario = AppSecurity.GetUser(new Guid(caja[0].CajeroId));
        if (usuario == null)
            return;

        lblObservado.Text = string.IsNullOrEmpty(movimiento[0].Observacion) || movimiento[0].Observacion == "-" ? "El Cierre NO fue observado" : "El cierre SI fue observado";
        txtCuadre.Enabled = movimiento[0].Observado;
        txtCuadreSus.Enabled = movimiento[0].Observado;
        txtObservacionAdm.Enabled = movimiento[0].Observado;
        btnSave.Visible = movimiento[0].Observado;

        if (!movimiento[0].Observado)
        {
            txtCuadre.Text = movimiento[0].MontoCorregido.ToString();
            txtCuadreSus.Text = movimiento[0].MontoCorregidoSus.ToString();
        }
        txtObservacionAdm.Text = movimiento[0].ObservacionAdm;
        lblCaja.Text = usuario.FirstName + " " + usuario.LastName;

        //BlockTextBox(!movimiento[0].Estado);            
        BlockTextBox(false);            

        TextLogs.WriteInfo("Datos del movimiento fueron cargados al formulario correctamente.");
    }
    public void BlockTextBox(bool state)
    {
        txtAdministracionBs.Enabled = state;
        txtAdministracionSus.Enabled = state;
        txtCierreBs.Enabled = state;
        txtCierreSus.Enabled = state;
        txtFechaDesdeBuscar.Enabled = state;
        txtFechaHastaBuscar.Enabled = state;
        txtObservacion.Enabled = state;
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
    private void CargarMovimientos()
    {
        ResultGrid.DataBind();
    }
    private void CargarReporte(DateTime fechaPago, DateTime fechaCierrePago, string usuarioId, int id)
    {
        DataTable datos = RN.Componentes.CPagoCliente.TraerXCaja(fechaPago, fechaCierrePago, usuarioId, id);
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
        rvPagos.LocalReport.ReportPath = Server.MapPath("~/Reportes/rRecaudacion.rdlc");
        rvPagos.LocalReport.SetParameters(new ReportParameter("FechaInicio", fechaPago.ToShortDateString(), true));
        rvPagos.LocalReport.SetParameters(new ReportParameter("FechaFin", fechaCierrePago.ToShortDateString(), true));
        rvPagos.LocalReport.SetParameters(new ReportParameter("Cajero", responsable, true));
        rvPagos.LocalReport.SetParameters(new ReportParameter("Cheques", montoCheque.ToString(), true));
        rvPagos.LocalReport.SetParameters(new ReportParameter("Tarjeta", montoTarjeta.ToString(), true));
        rvPagos.LocalReport.SetParameters(new ReportParameter("Transferencia", montoTransferencia.ToString(), true));
        rvPagos.LocalReport.SetParameters(new ReportParameter("Efectivo", montoEfectivo.ToString(), true));
        rvPagos.LocalReport.DataSources.Add(new ReportDataSource("Pagos", datos));
        rvPagos.LocalReport.Refresh();
    }
}