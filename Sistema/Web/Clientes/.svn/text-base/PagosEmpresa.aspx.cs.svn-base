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
using Microsoft.Reporting.WebForms;

public partial class Clientes_PagosEmpresa : System.Web.UI.Page
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
        base.OnPreRender(e);
        grdPaquetesAdeudados.CssClass = "ui-widget-content";
        if (grdPaquetesAdeudados.Rows.Count > 0)
        {
            grdPaquetesAdeudados.UseAccessibleHeader = true;
            grdPaquetesAdeudados.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdPaquetesAdeudados.HeaderRow.CssClass = "ui-widget-header";
            grdPaquetesAdeudados.FooterRow.TableSection = TableRowSection.TableFooter;

            if (grdPaquetesAdeudados.TopPagerRow != null)
                grdPaquetesAdeudados.TopPagerRow.TableSection = TableRowSection.TableHeader;

            if (grdPaquetesAdeudados.BottomPagerRow != null)
                grdPaquetesAdeudados.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!AppSecurity.HasAccess("PagosEmpresa"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Empresas.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }

        if (!IsPostBack)
        {
            SetFocus();
            Search();
            CargarAno();
        }
        lblScriptShow.Text = string.Empty;
    }
    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        RN.Entidades.PagoEmpresa objEmpresa = new RN.Entidades.PagoEmpresa();
        List<RN.Entidades.PagoEmpresa> lstPagos = new List<RN.Entidades.PagoEmpresa>();
        if (string.IsNullOrEmpty(EmpresaId.Value))
        {
            try
            {
                CheckBox chkSelec;
                Label lblPre;
                int iContador = 0;
                bool bCorrecto = false;
                DateTime dtFecha = DateTime.Now;
                foreach (GridViewRow row2 in grdPaquetesAdeudados.Rows)
                {

                    chkSelec = (CheckBox)row2.FindControl("cbSeleccionarMes");
                    lblPre = (Label)row2.FindControl("lblPrecioPaquete");
                    if (iContador == 0)
                        txtFechaPeriodoInicio.Text = ((Label)row2.FindControl("lblfechaRegistro")).Text;
                    if (chkSelec.Checked)
                    {
                        TextLogs.WriteDebug("Insertando pago: " + hdnEmpresaId.Value);
                        TextLogs.WriteInfo("Entrando a crear pago.");
                        RN.Entidades.PagoEmpresa objPago = new RN.Entidades.PagoEmpresa();
                        objPago.EmpresaId = Convert.ToInt32(hdnEmpresaId.Value);
                        objPago.ClientePaqueteId = Convert.ToInt32(grdPaquetesAdeudados.DataKeys[row2.RowIndex].Value.ToString());
                        objPago.Concepto = txtConcepto.Text;
                        objPago.FormaPago = ddlFormaPago.SelectedValue.ToString();
                        if (!String.IsNullOrEmpty(txtNumeroFactura.Text))
                            objPago.NumeroFactura = txtNumeroFactura.Text;
                        else
                            objPago.NumeroFactura = "0";
                        objPago.DigitosTarjeta_12 = txtDigitosTarjeta.Text;
                        objPago.NumeroAprobacionPOS = txtNumeroAprobacionPOS.Text;
                        objPago.NumeroCheque = txtNumeroCheque.Text;
                        objPago.NombreBancoCheque = txtNombreBancoCheque.Text;
                        objPago.NumeroCuentaTransferencia = txtNumeroCuentaTransferencia.Text;
                        objPago.NombreBancoTransferencia = txtNombreBancoTransferencia.Text;
                        if (!String.IsNullOrEmpty(txtIntercambioId.Text))
                            objPago.IntercambioId = Convert.ToInt32(txtIntercambioId.Text);
                        else
                            objPago.IntercambioId = 0;
                        if (!String.IsNullOrEmpty(txtNroPago.Text))
                            objPago.NroPago = Convert.ToInt32(txtNroPago.Text);
                        else
                            objPago.NroPago = 0;
                        objPago.FechaPeriodoInicio = Convert.ToDateTime(((Label)row2.FindControl("lblfechaRegistro")).Text);
                        objPago.FechaPeriodoFin = Convert.ToDateTime(((Label)row2.FindControl("lblfechaFin")).Text);
                        if (trPromocion.Visible)
                            objPago.Monto = Convert.ToDecimal(txtTotalDescuento.Text);
                        //else
                        //    objPago.Monto = Convert.ToDecimal(txtMonto.Text);
                        objPago.Monto = Convert.ToDecimal(lblPre.Text);
                        objPago.FechaPago = dtFecha;
                        objPago.Estado = true;
                        MembershipUser user = Membership.GetUser();
                        objPago.UsuarioId = user.ProviderUserKey.ToString();
                        objPago.Fecha = DateTime.Now;
                        lstPagos.Add(objPago);
                    }
                }
                if (RN.Workflows.WPagoEmpresa.Insertar(lstPagos))
                {
                    bCorrecto = true;
                }
                else
                    bCorrecto = false;
                
                TextLogs.WriteInfo("El pago ha sido guardado correctamente.");
                SetInformation(Helper.MessageType.Info, "El pago ha sido guardado correctamente.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                SetViewPanel2(false);
                CargarReporteRecibo(hdnEmpresaId.Value.ToString(), dtFecha);
            }
            catch (System.Data.SqlClient.SqlException err)
            {
                MensajesError(err);
            }
            catch (Exception err)
            {
                TextLogs.WriteError("No se pudo guardar el pago", err);
                SetInformation(Helper.MessageType.Error, "Error no clasificado");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
        }
        else
        {
            try
            {
                TextLogs.WriteDebug("Actualizando Pago Empresa: " + EmpresaId.Value);
                TextLogs.WriteInfo("Entrando a actualizar emrpesa.");
                MembershipUser user = Membership.GetUser();
                //objEmpresa.Id = Convert.ToInt32(EmpresaId.Value);
                //objEmpresa.Nombre = txtNombre.Text;
                //objEmpresa.Descripcion = txtDescripcion.Text;
                //objEmpresa.NombrePersonaContacto = txtPersonaContacto.Text;
                //objEmpresa.Telefono = txtTelefono.Text;
                //objEmpresa.Correo = txtCorreo.Text;
                //objEmpresa.Direccion = txtDireccion.Text;
                //objEmpresa.FechaRegistro = DateTime.Now;
                //objEmpresa.Estado = cbEstado.Checked;
                //objEmpresa.UsuarioId = user.ProviderUserKey.ToString();
                //objEmpresa.Fecha = DateTime.Now;
                //RN.Componentes.CEmpresa.Actualizar(objEmpresa);
                TextLogs.WriteInfo("PagoEmpresa actualizada.");
                SetViewPanel(true);
                SetFocus();
                Search();
                SetInformation(Helper.MessageType.Info, "El pago ha sido guardado correctamente.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
            catch (System.Data.SqlClient.SqlException err)
            {
                MensajesError(err);
            }
            catch (Exception err)
            {
                TextLogs.WriteError("No se pudo guardar El pago", err);
                SetInformation(Helper.MessageType.Error, "Error no clasificado");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
        }

    }
    private void MensajesError(System.Data.SqlClient.SqlException eVariable)
    {
        string sError = "No se pudo guardar la PagoEmpresa";
        string sTipo = string.Empty;
        switch (eVariable.Number.ToString())
        {
            case "08001":
                sTipo = "Error de conexion con la base de datos";
                break;
            case "2627":
                sTipo = "Restriccion de nombre repetido";
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
        TextLogs.WriteInfo("Estableciendo la fecha de creación de la PagoEmpresa.");

        TextLogs.WriteInfo("Panel de busqueda de Empresas INVISIBLE.");
        SetViewPanel(false);
        Limpiar();
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de Empresas VISIBLE.");
        SetViewPanel(true);
    }
    protected void Seach_Click(object sender, EventArgs e)
    {
        if (revBuscarNombre.IsValid & revBuscarPersona.IsValid & revBuscarCorreo.IsValid)
        {
            TextLogs.WriteInfo("Filtrando resultados del listado de empresas.");
            SetFocus();
            Search();
        }
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para la PagoEmpresa: " + e.CommandArgument);

        if (e.CommandName == "Editar")
        {
            TextLogs.WriteInfo("Recuperando datos de la PagoEmpresa seleccionado.");
            SetViewPanel(false);
            LoadData(e.CommandArgument.ToString());
            return;
        }
        else if (e.CommandName == "Eliminar")
        {
            TextLogs.WriteInfo("Entrando a eliminar el pago seleccionado.");
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '=' });
            RN.Componentes.CPagoEmpresa.EliminarPagoEmpresa(Convert.ToInt32(commandArgs[0].ToString()), Convert.ToDateTime(commandArgs[1].ToString()));
            hdnEmpresaId.Value = string.Empty;

            TextLogs.WriteInfo("El Pago ha sido eliminado.");
            SetInformation(Helper.MessageType.Info, "El Pago ha sido eliminado.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
        if (e.CommandName == "Imprimir")
        {
            TextLogs.WriteInfo("Recuperando datos de la PagoEmpresa seleccionado.");
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '=' });
            CargarReporteRecibo(commandArgs[0].ToString(), Convert.ToDateTime(commandArgs[1].ToString()));
            SetViewPanel2(false);
            LoadData(commandArgs[0].ToString());
            
        }
        Search();
    }
    private void CargarReporteRecibo(string id, DateTime fecha)
    {
        DataTable dtLicencia;
        MembershipUser user = Membership.GetUser();
        //dtLicencia = RN.Componentes.CPagoEmpresa.TraerXPagoId(id);
        dtLicencia = RN.Componentes.CPagoEmpresa.TraerXPagoIdFecha(id, fecha);
        //dtLicencia = RN.Componentes.CPagoEmpresa.TraerXIdReporte(Convert.ToInt32(id));
        rpRecibo.Visible = true;
        rpRecibo.LocalReport.DataSources.Clear();
        rpRecibo.LocalReport.ReportPath = Server.MapPath("rPagosId.rdlc");
        rpRecibo.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dtLicencia));
        rpRecibo.LocalReport.Refresh();
    }
    protected void ResultGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TextLogs.WriteInfo("Cambiando índice de página.");
        TextLogs.WriteDebug("Nuevo índice: " + e.NewPageIndex);
        ResultGrid.PageIndex = e.NewPageIndex;
        Search();
    }
    protected void ddlFormaPago_SelectedIndexChanged(object sender, EventArgs e)
    {
        HabilitarFormaPago();
    }
    private void HabilitarFormaPago()
    {
        if (ddlFormaPago.SelectedValue == "ef")
        {
            trPagoTarjeta.Visible = false;
            trPagoTarjeta2.Visible = false;
            trPagoCheque.Visible = false;
            trPagoCheque2.Visible = false;
            trPagoCuenta.Visible = false;
            trPagoCuenta2.Visible = false;
            trPagoIntercambio.Visible = false;
            trPagoIntercambio2.Visible = false;
        }
        if (ddlFormaPago.SelectedValue == "ta")
        {
            trPagoTarjeta.Visible = true;
            trPagoTarjeta2.Visible = true;
            trPagoCheque.Visible = false;
            trPagoCheque2.Visible = false;
            trPagoCuenta.Visible = false;
            trPagoCuenta2.Visible = false;
            trPagoIntercambio.Visible = false;
            trPagoIntercambio2.Visible = false;
        }
        if (ddlFormaPago.SelectedValue == "ch")
        {
            trPagoTarjeta.Visible = false;
            trPagoTarjeta2.Visible = false;
            trPagoCheque.Visible = true;
            trPagoCheque2.Visible = true;
            trPagoCuenta.Visible = false;
            trPagoCuenta2.Visible = false;
            trPagoIntercambio.Visible = false;
            trPagoIntercambio2.Visible = false;
        }
        if (ddlFormaPago.SelectedValue == "tr")
        {
            trPagoTarjeta.Visible = false;
            trPagoTarjeta2.Visible = false;
            trPagoCheque.Visible = false;
            trPagoCheque2.Visible = false;
            trPagoCuenta.Visible = true;
            trPagoCuenta2.Visible = true;
            trPagoIntercambio.Visible = false;
            trPagoIntercambio2.Visible = false;
        }
        if (ddlFormaPago.SelectedValue == "in")
        {
            trPagoTarjeta.Visible = false;
            trPagoTarjeta2.Visible = false;
            trPagoCheque.Visible = false;
            trPagoCheque2.Visible = false;
            trPagoCuenta.Visible = false;
            trPagoCuenta2.Visible = false;
            trPagoIntercambio.Visible = true;
            trPagoIntercambio2.Visible = true;
        }
        LimpiarPago();
    }
    private void LimpiarPago()
    {
        txtConcepto.Text = string.Empty;
        txtNumeroFactura.Text = string.Empty;
        txtDigitosTarjeta.Text = string.Empty;
        txtNumeroAprobacionPOS.Text = string.Empty;
        txtNumeroCheque.Text = string.Empty;
        txtNombreBancoCheque.Text = string.Empty;
        txtNumeroCuentaTransferencia.Text = string.Empty;
        txtNombreBancoTransferencia.Text = string.Empty;
        txtIntercambioId.Text = string.Empty;
        txtNroPago.Text = string.Empty;
        txtFechaPeriodoInicio.Text = string.Empty;
        txtFechaPeriodoFin.Text = string.Empty;
        txtFechaPeriodoInicio.Enabled = false;
        txtFechaPeriodoFin.Enabled = false;
        txtMonto.Enabled = false;
        txtMonto.Text = "0";
        txtTotalDescuento.Text = "0";
        lblNombreDescuento.Text = "-";
        //ddlFormaPago.SelectedValue = "ef";
    }
    protected void grdPaquetesAdeudados_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TextLogs.WriteInfo("Cambiando índice de página.");
        TextLogs.WriteDebug("Nuevo índice: " + e.NewPageIndex);
        grdPaquetesAdeudados.PageIndex = e.NewPageIndex;
        grdPaquetesAdeudados.DataBind();
    }
    public void cbSeleccionarMes_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        //bool bMarcado = false;
        if (chkStatus.Checked)
            MarcarChecks(true, row);
        else
            MarcarChecks(false, row);
    }
    public void cbSeleccionarMes_OnCheckedChanged1(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        //bool bMarcado = false;
        if (chkStatus.Checked)
            MarcarChecks2(true, row);
        else
            MarcarChecks2(false, row);
    }
    private void MarcarChecks(bool bMarcado, GridViewRow row)
    {
        CheckBox chkSelec;
        Label lblCosto;
        decimal dCosto = 0;
        int iContador = 0;
        foreach (GridViewRow row2 in grdPaquetesAdeudados.Rows)
        {
            if (row2.RowIndex <= row.RowIndex)
            {
                chkSelec = (CheckBox)row2.FindControl("cbSeleccionarMes");
                chkSelec.Checked = bMarcado;
                if (iContador == 0)
                    txtFechaPeriodoInicio.Text = ((Label)row2.FindControl("lblfechaRegistro")).Text;
                if (bMarcado)
                {
                    lblCosto = (Label)row2.FindControl("lblPrecioPaquete");
                    dCosto = dCosto + Convert.ToDecimal(lblCosto.Text);
                    iContador++;
                    txtFechaPeriodoFin.Text = ((Label)row2.FindControl("lblfechaFin")).Text;
                }
            }
        }
        if (!bMarcado)
        {
            dCosto = 0;
            DeshabilitarChecks();
            txtFechaPeriodoInicio.Text = string.Empty;
            txtFechaPeriodoFin.Text = string.Empty;
        }
        if (trPromocion.Visible)
        {
            txtTotalDescuento.Text = (dCosto - Convert.ToDecimal(txtDescuento.Text)).ToString();
        }
        txtMonto.Text = dCosto.ToString();
        txtMonto.Enabled = false;
    }
    private void MarcarChecks2(bool bMarcado, GridViewRow row)
    {
        CheckBox chkSelec;
        Label lblCosto;
        decimal dCosto = 0;
        int iContador = 0;
        foreach (GridViewRow row2 in grdPaquetesAdeudados.Rows)
        {

            chkSelec = (CheckBox)row2.FindControl("cbSeleccionarMes");
            chkSelec.Checked = bMarcado;
            if (iContador == 0)
                txtFechaPeriodoInicio.Text = ((Label)row2.FindControl("lblfechaRegistro")).Text;
            if (bMarcado)
            {
                lblCosto = (Label)row2.FindControl("lblPrecioPaquete");
                dCosto = dCosto + Convert.ToDecimal(lblCosto.Text);
                iContador++;
                txtFechaPeriodoFin.Text = ((Label)row2.FindControl("lblfechaFin")).Text;
            }

        }
        if (!bMarcado)
        {
            dCosto = 0;
            DeshabilitarChecks();
            txtFechaPeriodoInicio.Text = string.Empty;
            txtFechaPeriodoFin.Text = string.Empty;
        }
        if (trPromocion.Visible)
        {
            txtTotalDescuento.Text = (dCosto - Convert.ToDecimal(txtDescuento.Text)).ToString();
        }
        txtMonto.Text = dCosto.ToString();
        txtMonto.Enabled = false;
    }
    private void DeshabilitarChecks()
    {
        int iContador = 0;
        foreach (GridViewRow row in grdPaquetesAdeudados.Rows)
        {
            CheckBox chkSelec;
            chkSelec = (CheckBox)row.FindControl("cbSeleccionarMes");
            chkSelec.Checked = false;
            if (iContador == 0)
                chkSelec.Enabled = true;

            iContador++;
        }
    }
    private void SetViewPanel(bool status)
    {
        pnlNuevo.Visible = !status;
        pnlVer.Visible = status;
        //PnlGridEmpleados.Visible = status;
        SetFocus();
    }
    private void SetViewPanel2(bool status)
    {
        pnlNuevo.Visible = status;
        pnlVer.Visible = status;
        pnlReporte.Visible = !status;
        //PnlGridEmpleados.Visible = status;
        SetFocus();
    }
    private void SetFocus()
    {
        if (pnlNuevo.Visible)
        {
            Page.SetFocus(txtSearchCI);
            return;
        }
        Page.SetFocus(txtBuscarNombre);
    }
    private void Search()
    {
        CargarEmpresas();
        lblInfo.Text = ResultGrid.Rows.Count.ToString();
        TextLogs.WriteDebug("Resultados encontrados en el grid: " + lblInfo.Text);
    }
    public string IsApproved(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "estado"));
        if (approved)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
    public string IsLockedOut(object id)
    {
        bool locked = Convert.ToBoolean(DataBinder.Eval(id, "estado"));
        if (locked)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
    private void Limpiar()
    {
        EmpresaId.Value = string.Empty;
        txtSearchCI.Text = string.Empty;
        txtConcepto.Text = string.Empty;
        txtNumeroFactura.Text = string.Empty;
        txtDigitosTarjeta.Text = string.Empty;
        txtNumeroAprobacionPOS.Text = string.Empty;
        txtNumeroCheque.Text = string.Empty;
        txtNombreBancoCheque.Text = string.Empty;
        txtNumeroCuentaTransferencia.Text = string.Empty;
        txtNombreBancoTransferencia.Text = string.Empty;
        txtIntercambioId.Text = string.Empty;
        txtNroPago.Text = string.Empty;
        txtFechaPeriodoInicio.Text = string.Empty;
        txtFechaPeriodoFin.Text = string.Empty;
        txtMonto.Text = string.Empty;
        txtDescuento.Text = string.Empty;
        txtTotalDescuento.Text = string.Empty;
        txtMonto.Text = string.Empty;
        hdnEmpresaId.Value = string.Empty;
        lblFechaSolicitud.Text = DateTime.Now.ToShortDateString();
        grdPaquetesAdeudados.DataBind();
        TextLogs.WriteInfo("Valores del formulario limpiados.");
    }
    private void LoadData(string userName)
    {
        TextLogs.WriteInfo("Cargando datos de la PagoEmpresa a los controles del formulario.");
        TextLogs.WriteDebug("Cargando PagoEmpresa: " + userName);
        List<RN.Entidades.PagoEmpresa> lEmpresa = RN.Componentes.CPagoEmpresa.TraerXId(Convert.ToInt32(userName));
        EmpresaId.Value = userName;
        //txtNombre.Text = lEmpresa[0].Nombre;
        //txtDescripcion.Text = lEmpresa[0].Descripcion;
        //txtPersonaContacto.Text = lEmpresa[0].NombrePersonaContacto;
        //txtTelefono.Text = lEmpresa[0].Telefono;
        //txtCorreo.Text = lEmpresa[0].Correo;
        //txtDireccion.Text = lEmpresa[0].Direccion;
        //txtFechaCreacion.Text = lEmpresa[0].FechaRegistro.ToString();
        //cbEstado.Checked = Convert.ToBoolean(lEmpresa[0].Estado.ToString());
        TextLogs.WriteInfo("Datos del usuario cargados al formulario correctamente.");
    }
    private void CargarAno()
    {
        for (int i = 2012; i <= DateTime.Now.Year; i++)
        {
            ListItem lst = new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString());
            ddlAno.Items.Add(lst);
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
    private void CargarEmpresas()
    {
        ResultGrid.DataBind();
    }
    protected void btnCargarDeudas_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(hdnEmpresaId.Value))
        {
            SetInformation(Helper.MessageType.Info, "Por favor ingrese una empresa");
            txtSearchCI.Focus();
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
        else
            grdPaquetesAdeudados.DataBind();
    }
    protected void btnImpresionRecibo_Click(object sender, EventArgs e)
    {
        SetViewPanel2(true);
        SetViewPanel(true);
        SetFocus();
        Search();
    }
    private void CloseDialog(string dialogId)
    {
        string script = string.Format(@"closeDialog('{0}');", dialogId);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void ShowDialog(string dialogId)
    {
        string script = string.Format(@"showDialog('{0}');", dialogId);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    public string GetMonto(object item, string name)
    {
        return Convert.ToDouble(DataBinder.Eval(item, name)).ToString("f2");
    }
    protected void IbtBuscarEmpleado_Click(object sender, ImageClickEventArgs e)
    {
        PnlListadoEmpleados_ModalPopupExtender.Show();
        LoadGridEmpleados("");

    }
    protected void LoadGridEmpleados(string ApellidoPaterno)
    {

        GrvEmpleados.DataSource = RN.Componentes.CEmpresa.TraerXCriterio(ApellidoPaterno, string.Empty, string.Empty, "true");
        GrvEmpleados.DataBind();
        GrvEmpleados.Visible = true;
    }
    protected void GrvEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandArgument.ToString() != string.Empty)
        {
            int Index;
            Index = Convert.ToInt32(e.CommandArgument);
            GrvEmpleados.SelectedIndex = Index;
            List<RN.Entidades.Empresa> DatosEmpleado = RN.Componentes.CEmpresa.TraerXId(Convert.ToInt32(GrvEmpleados.SelectedDataKey["id"].ToString()));

            txtSearchCI.Text = DatosEmpleado[0].Nombre;
            hdnEmpresaId.Value = DatosEmpleado[0].Id.ToString();
            //TxtCargoJefe.Text = Empleado.Cargo;

            PnlListadoEmpleados_ModalPopupExtender.Hide();
            //PnlListadoEmpleados_ModalPopupExtender.Dispose();

        }
    }
    protected void BtnBuscarEmpleados_Click(object sender, EventArgs e)
    {


        string Criterio = TxtApellidoPaternoBuscar.Text.Replace(',', ' ');
        TxtApellidoPaternoBuscar.Text = Criterio.Trim();



        LoadGridEmpleados(TxtApellidoPaternoBuscar.Text);
        PnlListadoEmpleados_ModalPopupExtender.Show();
    }
    protected void BtnPnlEmpleadosClose_Click(object sender, ImageClickEventArgs e)
    {
        PnlListadoEmpleados_ModalPopupExtender.Hide();
    }
    public string TraerEmpresa(object id)
    {
        string approved = Convert.ToString(DataBinder.Eval(id, "empresaId"));
        if (!String.IsNullOrEmpty(approved))

            return RN.Componentes.CEmpresa.TraerXId(Convert.ToInt32(approved))[0].Nombre;
        else
            return string.Empty;
    }
}
