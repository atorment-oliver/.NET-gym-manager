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
using System.Configuration;

public partial class Clientes_Clientes : MyPage
{
    DataTable dtListado= new DataTable();
    DataTable dtLicencia;
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        ResultGrid.CssClass = "ui-widget-whiteContent";
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
        grdServicios.CssClass = "ui-widget-whiteContent";
        if (grdServicios.Rows.Count > 0)
        {
            grdServicios.UseAccessibleHeader = true;
            grdServicios.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdServicios.HeaderRow.CssClass = "ui-widget-header";
            grdServicios.FooterRow.TableSection = TableRowSection.TableFooter;

            if (grdServicios.TopPagerRow != null)
                grdServicios.TopPagerRow.TableSection = TableRowSection.TableHeader;

            if (grdServicios.BottomPagerRow != null)
                grdServicios.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        grdHorario.CssClass = "ui-widget-whiteContent";
        if (grdHorario.Rows.Count > 0)
        {
            grdHorario.UseAccessibleHeader = true;
            grdHorario.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdHorario.HeaderRow.CssClass = "ui-widget-header";
            grdHorario.FooterRow.TableSection = TableRowSection.TableFooter;

            if (grdHorario.TopPagerRow != null)
                grdHorario.TopPagerRow.TableSection = TableRowSection.TableHeader;

            if (grdHorario.BottomPagerRow != null)
                grdHorario.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        grdHorarioIn.CssClass = "ui-widget-whiteContent";
        if (grdHorarioIn.Rows.Count > 0)
        {
            grdHorarioIn.UseAccessibleHeader = true;
            grdHorarioIn.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdHorarioIn.HeaderRow.CssClass = "ui-widget-header";
            grdHorarioIn.FooterRow.TableSection = TableRowSection.TableFooter;

            if (grdHorarioIn.TopPagerRow != null)
                grdHorarioIn.TopPagerRow.TableSection = TableRowSection.TableHeader;

            if (grdHorarioIn.BottomPagerRow != null)
                grdHorarioIn.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        grdHorariosSeleccionados.CssClass = "ui-widget-whiteContent";
        if (grdHorariosSeleccionados.Rows.Count > 0)
        {
            grdHorariosSeleccionados.UseAccessibleHeader = true;
            grdHorariosSeleccionados.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdHorariosSeleccionados.HeaderRow.CssClass = "ui-widget-header";
            grdHorariosSeleccionados.FooterRow.TableSection = TableRowSection.TableFooter;

            if (grdHorariosSeleccionados.TopPagerRow != null)
                grdHorariosSeleccionados.TopPagerRow.TableSection = TableRowSection.TableHeader;

            if (grdHorariosSeleccionados.BottomPagerRow != null)
                grdHorariosSeleccionados.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        grdAdicionales.CssClass = "ui-widget-whiteContent";
        if (grdAdicionales.Rows.Count > 0)
        {
            grdAdicionales.UseAccessibleHeader = true;
            grdAdicionales.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdAdicionales.HeaderRow.CssClass = "ui-widget-header";
            grdAdicionales.FooterRow.TableSection = TableRowSection.TableFooter;

            if (grdAdicionales.TopPagerRow != null)
                grdAdicionales.TopPagerRow.TableSection = TableRowSection.TableHeader;

            if (grdAdicionales.BottomPagerRow != null)
                grdAdicionales.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        grdHistorialLicencias.CssClass = "ui-widget-whiteContent";
        if (grdHistorialLicencias.Rows.Count > 0)
        {
            grdHistorialLicencias.UseAccessibleHeader = true;
            grdHistorialLicencias.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdHistorialLicencias.HeaderRow.CssClass = "ui-widget-header";
            grdHistorialLicencias.FooterRow.TableSection = TableRowSection.TableFooter;

            if (grdHistorialLicencias.TopPagerRow != null)
                grdHistorialLicencias.TopPagerRow.TableSection = TableRowSection.TableHeader;

            if (grdHistorialLicencias.BottomPagerRow != null)
                grdHistorialLicencias.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        grdPaquetesAdeudados.CssClass = "ui-widget-whiteContent";
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
        grdPagosRegistrados.CssClass = "ui-widget-whiteContent";
        if (grdPagosRegistrados.Rows.Count > 0)
        {
            grdPagosRegistrados.UseAccessibleHeader = true;
            grdPagosRegistrados.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdPagosRegistrados.HeaderRow.CssClass = "ui-widget-header";
            grdPagosRegistrados.FooterRow.TableSection = TableRowSection.TableFooter;

            if (grdPagosRegistrados.TopPagerRow != null)
                grdPagosRegistrados.TopPagerRow.TableSection = TableRowSection.TableHeader;

            if (grdPagosRegistrados.BottomPagerRow != null)
                grdPagosRegistrados.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Context.Session["Inscripciones"] != null)
            dtListado = (DataTable)this.Context.Session["Inscripciones"];
        else
            this.Context.Session["Inscripciones"] = dtListado;

        if (!AppSecurity.HasAccess("Clientes"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Clientes.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }
                
        MembershipUser user = Membership.GetUser();
        List<RN.Entidades.Caja> caja = RN.Componentes.CCaja.TraerXCriterio(string.Empty, user.ProviderUserKey.ToString(), "true");
        if (caja == null || caja.Count <= 0)
        {
            // Verificar si es administrador y si hay caja observada.
            if (this.User.IsInRole("Administrador"))
            {

            }

            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Clientes sin ser cajero");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }

        TextLogs.WriteInfo("Verificando si cajero abrio su caja.");
        List<RN.Entidades.MovimientoCaja> objCaja = RN.Componentes.CMovimientoCaja.EstaAbierto(caja[0].Id.ToString());
        if (objCaja.Count == 0 || objCaja[0].Estado == false)
        {
            TextLogs.WriteInfo("El usuario no abrió su caja, redireccionandolo a la página de apertura de caja.");
            Response.Redirect("../Caja/Caja.aspx");
        }
        else 
        {
            if (objCaja[0].FechaHoraApertura.Day != DateTime.Now.Day)
            {
                TextLogs.WriteInfo("El usuario abrió su caja el día anterior, redireccionandolo a la página de cierre de caja.");
                Response.Redirect("../Caja/Caja.aspx");
            }
        }

        ClienteControl.BAlerta = true;
        ClienteControl.userControlClick += new UserControlDelegate(UserControlDemo_userControlClick);
        ClienteControl.ClienteId = hdnAutoCompleteClienteId.Value.ToString();
        //if (IsPostBack && String.IsNullOrEmpty(NuevoCliente.Value))
        //    CargarDatosPanel();
        if (!IsPostBack)
        {
            CargarPaquete();
            CargarDatosPanel();
            CargarIntercambio();
            lblFechaSolicitud.Text = DateTime.Now.ToShortDateString();
        }
        AdicionarColumas();
        CargarTable();
    }
    private void AdicionarColumas()
    {
        if (dtListado.Columns.Count == 0)
        {
            dtListado.Columns.Add("id", typeof(Int32));
            dtListado.Columns.Add("nombreServicio", typeof(String));
            dtListado.Columns.Add("nombreSala", typeof(String));
            dtListado.Columns.Add("Hora", typeof(String));
            dtListado.Columns.Add("cupo", typeof(String));
            dtListado.Columns.Add("grupoLunes", typeof(Boolean));
            dtListado.Columns.Add("grupoMartes", typeof(Boolean));
            dtListado.Columns.Add("grupoMiercoles", typeof(Boolean));
            dtListado.Columns.Add("grupoJueves", typeof(Boolean));
            dtListado.Columns.Add("grupoViernes", typeof(Boolean));
            dtListado.Columns.Add("grupoSabado", typeof(Boolean));
            dtListado.Columns.Add("grupoDomingo", typeof(Boolean));
            //dtListado.Columns.Add("estado", typeof(Boolean));
        }
    }
    private void LimpiarTable()
    {
        dtListado.Rows.Clear();
        this.Context.Session["Inscripciones"] = null;
    }
    private void CargarTable()
    {
        grdHorariosSeleccionados.DataSource = dtListado;
        grdHorariosSeleccionados.DataKeyNames = new string[] { "id" };
        grdHorariosSeleccionados.DataBind();
    }
    private void CargarIntercambio()
    {
        txtIntercambioId.DataSource = RN.Componentes.CIntercambio.Traer();
        txtIntercambioId.DataTextField = "nombre";
        txtIntercambioId.DataValueField = "id";
        txtIntercambioId.DataBind();
    }
    void UserControlDemo_userControlClick(ControlClienteEventHandler valor)
    {
        if (valor.SDML.Equals("Insertar"))
        {
            List <RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(valor.ICodigo);
            CloseDialogCargado("dialogCliente", valor.ICodigo.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
            hdnAutoCompleteClienteId.Value = valor.ICodigo.ToString();
            ClienteControl.ClienteId = valor.ICodigo.ToString();
            ClienteControl.ActualizarHiden();
            CargarPaquete();
            CargarDatosPanel();
            CargarIntercambio();
        }
        if (valor.SDML.Equals("Actualizar"))
        {
            CloseDialog("dialogCliente");
            CargarDatosPanel();
        }
        if (valor.SDML.Equals("Cerrar"))
        {
            CloseDialog("dialogCliente");
            CargarDatosPanel();
        }
    }
    private void CargarPaquete()
    {
        //ddlPaquete.DataSource = RN.Componentes.CPaquete.TraerXCriterioD("", "", "");
        ddlPaquete.DataSource = RN.Componentes.CPaquete.TraerSinAdicional2(hdnAutoCompleteClienteId.Value);
        ddlPaquete.DataTextField = "nombre";
        ddlPaquete.DataValueField = "id";
        ddlPaquete.DataBind();
        if (String.IsNullOrEmpty(HabilitarCombo.Value))
        {
            ddlPaqueteCliente.Visible = true;
            //ddlPaqueteClienteHide.Visible = false;
            if (!String.IsNullOrEmpty(hdnAutoCompleteClienteId.Value))
            {
                ddlPaqueteCliente.DataSource = RN.Componentes.CPaquete.TraerSinAdicional(hdnAutoCompleteClienteId.Value);
                ddlPaqueteCliente.DataTextField = "nombre";
                ddlPaqueteCliente.DataValueField = "id";
                ddlPaqueteCliente.DataBind();
            }
            ddlPaqueteCliente.Items.Add(new ListItem("Sin Paquete", "0"));
        }
        //else
        //{
        //    ddlPaqueteCliente.Visible = false;
        //    ddlPaqueteClienteHide.Visible = true;
        //    DataTable dtCom = RN.Componentes.CPaquete.TraerPaqueteAdicionalPadre(HabilitarCombo.Value);
        //    ddlPaqueteClienteHide.DataSource = dtCom;
        //    ddlPaqueteClienteHide.DataTextField = "nombre";
        //    ddlPaqueteClienteHide.DataValueField = "id";
        //    ddlPaqueteClienteHide.DataBind();
        //    if (dtCom.Rows.Count == 0)
        //    {
        //        ddlPaqueteClienteHide.Visible = false;
        //        ddlPaqueteCliente.Visible = true;
        //        ddlPaqueteCliente.Enabled = false;
        //        //ddlPaqueteCliente.SelectedValue = "0";
        //        //ddlPaqueteCliente.Visible = true;
        //        //ddlPaqueteClienteHide.Visible = false;
        //        //ddlPaqueteCliente.Enabled = false;
        //    }
        //    Combo.Value = "Si";
        //}
        CargarDescripcionPaquete();
        CargarGrupo();
    }
    private void CargarGrupo()
    {
        ddlGrupo.DataSource = RN.Componentes.CServicio.TraerXCriterio(string.Empty, string.Empty,"1");
        ddlGrupo.DataTextField = "nombre";
        ddlGrupo.DataValueField = "id";
        ddlGrupo.DataBind();
    }
    private void CargarDescripcionServicio()
    {
        if (ddlGrupo.Items.Count <= 0)
        {
            TextLogs.WriteWarning("Se intentó ingresar al formulario de clientes sin contar con grupos registrados.", new Exception("No se encontraron grupos registrados."));
            //SetInformation(Helper.MessageType.Info, "No se encontraron grupos registrados.");
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "popup", "<script language=JavaScript> $(window).load(function () { $('.osx').click(); }); </script>");
            MensajeGuardado("No se encontraron grupos registrados.");            
            return;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MembershipUser user = Membership.GetUser();
        if (!String.IsNullOrEmpty(ClienteControl.ClienteId))
        {
            TextLogs.WriteDebug("Insertando Cliente paquete: " + ClienteControl.ClienteId);
            TextLogs.WriteInfo("Entrando a crear cliente paquete.");
            RN.Entidades.ClientePaquete objCliente = new RN.Entidades.ClientePaquete();
            objCliente.ClienteId = Convert.ToInt32(ClienteControl.ClienteId);
            objCliente.PaqueteId = Convert.ToInt32(ddlPaquete.SelectedValue.ToString());
            objCliente.UsuarioId = user.ProviderUserKey.ToString();
            objCliente.Fecha = DateTime.Now;
            objCliente.FechaRegistro = DateTime.Now;
            objCliente.Estado = true;
            RN.Componentes.CClientePaquete.Insertar(objCliente);
            TextLogs.WriteInfo("El cliente paquete ha sido guardado correctamente.");
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
    protected void lbName_Click(object sender, EventArgs e)
    {
        var editLink = ((LinkButton)sender);
        upPaqueteSeleccion.Update();
    }
    private void MensajeGuardado(string mensaje)
    {
        string script = string.Format(@"$.msgBox('"+ mensaje +"');");
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void MensajeGuardadoCargado(string mensaje, string id, string nombre, string ci)
    {
        string script = string.Format(@"$.msgBox('{0}');CargarBusqueda('{1}','{2}','{3}')",mensaje, id, nombre, ci);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void CloseDialog(string dialogId)
    {
        string script = string.Format(@"closeDialog('{0}')", dialogId);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void CloseDialogMensaje(string dialogId, string mensaje)
    {
        string script = string.Format(@"$.msgBox('{1}');closeDialog('{0}')", dialogId, mensaje);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void CloseDialogCargado(string dialogId, string id, string nombre, string ci)
    {
        string script = string.Format(@"closeDialog('{0}');CargarBusqueda('{1}','{2}','{3}')", dialogId, id, nombre, ci);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void CloseDialogMensajeCargadoShowDialog(string dialogId, string mensaje, string id, string nombre, string ci, string shodialog)
    {
        string script = string.Format(@"$.msgBox('{0}');closeDialog('{1}');CargarBusqueda('{2}','{3}','{4}');showDialog('{5}');TestCheckBox();", mensaje, dialogId, id, nombre, ci, shodialog);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void CloseDialogCargadoShowDialog(string dialogId, string id, string nombre, string ci, string shodialog)
    {
        string script = string.Format(@"closeDialog('{0}');CargarBusqueda('{1}','{2}','{3}');showDialog('{4}')", dialogId, id, nombre, ci, shodialog);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void CloseDialogCargado(string dialogId)
    {
        string script = string.Format(@"closeDialog('{0}');", dialogId);
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
        ClientScript.RegisterClientScriptBlock(this.GetType(), "popup", "<script language=JavaScript> " + script + " $(window).load(function () { $('#basic-modal-content').modal(); }); </script>");
    }
    private void CloseDialogCargadoMensaje(string dialogId, string id, string nombre, string ci, string mensaje)
    {
        string script = string.Format(@"closeDialog('{0}');CargarBusqueda('{1}','{2}','{3}');$.msgBox('{4}')", dialogId, id, nombre, ci, mensaje);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void ShowDialog(string dialogId)
    {
        string script = string.Format(@"showDialog('{0}');LimpiarBusqueda();", dialogId);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void ShowDialogCargado(string dialogId, string id, string nombre, string ci)
    {
        string script = string.Format(@"showDialog('{0}');;CargarBusqueda('{1}','{2}','{3}')", dialogId, id, nombre, ci);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void LimpiarBusqueda()
    {
        string script = string.Format(@"LimpiarBusqueda();");
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    public void MensajeGuardado()
    {
        //SetInformation(Helper.MessageType.Info, "El cliente se ha sido guardado correctamente.");
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "popup", "<script language=JavaScript> $(window).load(function () { $('.osx').click(); }); </script>");
        MensajeGuardado("El cliente se ha sido guardado correctamente.");
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        hdnServicioId.Value = string.Empty;
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        CargarPaquete();
        CargarDatosPanel();
    }
    private void CargarDatosPanel()
    {
        if (!String.IsNullOrEmpty(hdnAutoCompleteClienteId.Value.ToString()))
        {
            int iCliente = CargarDatosCliente();
            ClienteControl.ClienteId = hdnAutoCompleteClienteId.Value.ToString();
            CargarDatosPaquete(iCliente);
            CargarDescripcionPaqueteCliente();
            CargarDescripcionPromocion();
            CargarPrecioReal();
            ClienteControl.CargarDatos();
            tbFechaPrecio.Visible = true;
            ddlPaquete.Enabled = true;
            Botones(true);
        }
        else
        {
            lblNumeroCliente.Text = "-";
            lblNombreCliente.Text = "-";
            lblEmpresaCliente.Text = "-";
            lblCiCliente.Text = "-";
            lblEdadCliente.Text = "-";
            lblDireccionCliente.Text = "-";
            lblTelefonoCliente.Text = "-";
            lblFechaIngreso.Text = "-";
            lblEmpresaCliente.Text = "-";
            lblTelefonoEmpresa.Text = "-";
            lblPersonaEmpresa.Text = "-";
            lblCoberturaEmpresa.Text = "-";
            lblCoberturaEmpresaMonto.Text = "-";
            ddlPaqueteCliente.SelectedValue = "0";
            lblPromocionCliente.Text = "-";
            lblCostoPromocionCliente.Text = "0";
            CargarDescripcionPaqueteCliente();
            ClienteControl.CargarDatos();
            ClientePaqueteId.Value = string.Empty;
            Botones(false);
            lbEliminar.Enabled = false;
            btnExtender.Enabled = false;
            btnLicencia.Enabled = false;
            btnPromocion.Enabled = false;
            btnImprimirRecibo.Enabled = false;
            btnPago.Enabled = false;
        }
        ResultGrid.DataBind();
        CargarDescripcionServicio();
        grdServicios.DataBind();
        grdHistorialLicencias.DataBind();
        grdPaquetesAdeudados.DataBind();
        grdPagosRegistrados.DataBind();
    }
    private void CargarPrecioReal()
    {
        if(!String.IsNullOrEmpty(ClientePaqueteId.Value))
        {
            DataTable dtPrecio = RN.Componentes.CClientePaquete.TraerXIdPrecioReal(Convert.ToInt32(ClientePaqueteId.Value));
            if (dtPrecio.Rows.Count != 0)
            {
                decimal dDescuento = 0;
                List<RN.Entidades.PromocionCliente> objPromo = RN.Componentes.CPromocionCliente.TraerXIdClienteMensual(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                if (objPromo.Count != 0)
                {
                    PromocionClienteId.Value = objPromo[0].Id.ToString();
                    List<RN.Entidades.Promocion> objPr = RN.Componentes.CPromocion.TraerXId(objPromo[0].PromocionId);
                    if (objPr.Count != 0)
                    {
                        if (objPr[0].Mensual)
                        {
                            dDescuento = objPr[0].MontoDescuento;
                        }
                    }
                }
                if (Convert.ToDouble(dtPrecio.Rows[0][0]) - Convert.ToDouble(dDescuento) < 0)
                    dDescuento = 0;
                else
                    dDescuento = Convert.ToDecimal(dtPrecio.Rows[0][0]) - (dDescuento);
                lblPrecioPaquete.Text = Convert.ToDouble(dDescuento).ToString("f2") + " Bs.";
                if (!String.IsNullOrEmpty(hdnAutoCompleteClienteId.Value))
                {
                    List<RN.Entidades.ClientePaquete> lstCli = RN.Componentes.CClientePaquete.TraerXId(Convert.ToInt32(ClientePaqueteId.Value));
                    if (lstCli.Count != 0)
                    {
                        DataTable dtClientePquete = RN.Componentes.CClientePaquete.TraerXIdPrecioRealPaquete(Convert.ToInt32(hdnAutoCompleteClienteId.Value), lstCli[0].PaqueteId);
                        if (dtClientePquete.Rows.Count != 0)
                            lblCoberturaEmpresaMonto.Text = Convert.ToDouble(dtClientePquete.Rows[0][1].ToString()).ToString("f2") + " Bs.";
                    }
                }
                
            }
            else
            {
                lblPrecioPaquete.Text = "-";
                lblCoberturaEmpresaMonto.Text = "-";
            }
        }
        else
        {
            lblPrecioPaquete.Text = "- Bs.";
            lblCoberturaEmpresaMonto.Text = "- Bs.";
        }
        List<RN.Entidades.DistribucionPago> lstDis = RN.Componentes.CDistribucionPago.TraerXIdCliente(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        if (lstDis.Count != 0)
        {
            lblCoberturaEmpresa.Text = lstDis[0].Porcentaje.ToString();
        }
        else
        {
            lblCoberturaEmpresa.Text = "Sin registrar";
            lblCoberturaEmpresaMonto.Text = "0 Bs.";
        }
    }
    private void CargarGridServicios()
    {
        if(!String.IsNullOrEmpty(ClientePaqueteId.Value))
        {
            grdServicios.DataSource = null;
            grdServicios.DataBind();
            grdServicios.DataSource = RN.Componentes.CGrupo.Grupo_TraerXServicioHorarioCliente(Convert.ToInt32(ClientePaqueteId.Value));
            grdServicios.DataKeyNames = new string[] { "id" };
            grdServicios.DataBind();
        }
    }
    private void Botones(bool Habilitar)
    {
        btnCliente.Enabled = Habilitar;
        btndPaquetes.Enabled = Habilitar;
        if (string.IsNullOrEmpty(ClientePaqueteId.Value))
        {
            btnPago.Enabled = false;
            btnImprimirRecibo.Enabled = false;
            btnLicencia.Enabled = false;
        }
        else
        {
            btnPago.Enabled = true;
            btnImprimirRecibo.Enabled = true;
            btnLicencia.Enabled = true;
        }
    }
    public int Edad(DateTime fechaNacimiento)
    {
        int edad = DateTime.Now.Year - fechaNacimiento.Year;
        DateTime nacimientoAhora = fechaNacimiento.AddYears(edad);
        if (DateTime.Now.CompareTo(nacimientoAhora) < 0)
        {
            edad--;
        }

        return edad;
    }
    private int CargarDatosCliente()
    {
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value.ToString()));
        if (lstCliente.Count != 0)
        {
            lblNumeroCliente.Text = lstCliente[0].NumeroCliente.ToString();
            lblNombreCliente.Text = string.Format("{0} {1}", lstCliente[0].Nombre.ToString(), lstCliente[0].Apellidos.ToString());
            lblEdadCliente.Text = Edad(lstCliente[0].FechaNacimiento).ToString();
            lblFechaIngreso.Text = lstCliente[0].FechaIngreso.ToShortDateString();

            lblCiCliente.Text = string.IsNullOrEmpty(lstCliente[0].Ci) ? "-" : lstCliente[0].Ci + lstCliente[0].CiCi;
            lblDireccionCliente.Text = string.IsNullOrEmpty(lstCliente[0].Direccion) ? "-" : lstCliente[0].Direccion;
            lblTelefonoCliente.Text = string.IsNullOrEmpty(lstCliente[0].Telefono) ? "-" : lstCliente[0].Telefono;
            txtSearchCI.Text = lstCliente[0].Nombre + " " + lstCliente[0].Apellidos + " - " + lstCliente[0].Ci + lstCliente[0].CiCi;
            CargarDatosEmpresa(lstCliente[0].EmpresaId);
            return lstCliente[0].Id;
        }
        else
            return 0;
    }
    private void CargarDatosEmpresa(int codigo)
    {
        List<RN.Entidades.Empresa> lstEmpresa = RN.Componentes.CEmpresa.TraerXId(codigo);
        if (lstEmpresa.Count != 0)
        {
            pnlEmpresa.Visible = true;
            lblEmpresaCliente.Text = lstEmpresa[0].Nombre.ToString();
            lblTelefonoEmpresa.Text = lstEmpresa[0].Telefono.ToString();
            lblPersonaEmpresa.Text = lstEmpresa[0].NombrePersonaContacto.ToString();
        }
        else
        {
            pnlEmpresa.Visible = false;
        }
    }
    private void CargarServicio(int id)
    {
        grdServicios.DataBind();
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para f: " + e.CommandArgument);
        if (e.CommandName == "Eliminar")
        {
            TextLogs.WriteInfo("Ingresando a eliminar la Paquete.");
            string[] sValores = e.CommandArgument.ToString().Split('=');
            hdnServicioId.Value = sValores[0];

            if (RN.Componentes.CInscripcion.EliminarInscripcion(Convert.ToInt32(hdnServicioId.Value)))
            {
                hdnServicioId.Value = string.Empty;
                TextLogs.WriteInfo("La inscripcion ha sido eliminada.");
                //SetInformation(Helper.MessageType.Info, "La inscripcion ha sido eliminada.");
                //lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                //ShowDialog("La inscripcion ha sido eliminada.");
            }
            else
            {
                TextLogs.WriteInfo("No se puede eliminar la inscripcion.");
                SetInformation(Helper.MessageType.Info, "No se puede eliminar la inscripcion.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
        }
        if (e.CommandName == "Adicionar")
        {
            List<RN.Entidades.ClientePaquete> lstCliePaque = RN.Componentes.CClientePaquete.TraerXId(Convert.ToInt32(ClientePaqueteId.Value));
            if (lstCliePaque.Count != 0)
            {
                List<RN.Entidades.Paquete> lstPaquete = RN.Componentes.CPaquete.TraerXId(lstCliePaque[0].PaqueteId);
                if (lstPaquete.Count != 0)
                {
                    if (lstPaquete[0].TipoPaqueteId == 2 && grdServicios.Rows.Count > 0)
                    {
                        MensajeGuardado("Ha alcanzado el límite de servicios");
                    }
                    else
                    {
                        Datos.Value = string.Empty;
                        Combo.Value = string.Empty;
                        Adicionar.Value = "OtroServicio";
                        Grillas(true);
                        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                        List<RN.Entidades.ClienteFecha> objCl = RN.Componentes.CClienteFecha.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                        if (objCl.Count != 0)
                            txtFechaInicioPaquete.Text = objCl[0].FechaInicio.ToShortDateString();
                        else
                            txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
                        txtFechaInicioPaquete.Enabled = true;

                        if (lstCliePaque.Count != 0)
                        {
                            ddlPaquete.SelectedValue = lstCliePaque[0].PaqueteId.ToString();
                        }
                        CargarDatosPanel();
                        ddlPaquete.Enabled = false;
                        tbFechaPrecio.Visible = false;
                        grdHorarioIn.DataBind();
                        grdHorario.DataBind();
                        List<RN.Entidades.ClientePaquete> objCliente = RN.Componentes.CClientePaquete.TraerXCIdCliente(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                        if (objCliente.Count != 0)
                        {
                            DataTable dtTiempo = RN.Componentes.CClientePaquete.TraerTiempoPaquete(Convert.ToInt32(objCliente[0].Id.ToString()));
                            double dDiasVacacion = 0;
                            if (objCliente.Count != 0)
                            {
                                dtTiempo = RN.Componentes.CClientePaquete.TraerTiempoPaquete(Convert.ToInt32(objCliente[0].Id.ToString()));

                                List<RN.Entidades.Licencia> objLicencia = RN.Componentes.CLicencia.TraerXClientePaqueteId2(objCliente[0].Id);
                                if (objLicencia.Count != 0)
                                {
                                    foreach (RN.Entidades.Licencia row in objLicencia)
                                    {
                                        dDiasVacacion = dDiasVacacion + (row.FechaFinLicencia - row.FechaInicioLicencia).TotalDays;
                                    }
                                }
                            }
                            if (dtTiempo.Rows.Count > 0)
                                txtFechaInicioPaquete.Text = Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()).AddDays(dDiasVacacion+1).ToShortDateString();
                        }
                        else
                            txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
                        ShowDialogCargado("dialogPaquetes", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
                    }
                }
            }
        }
        if (e.CommandName == "Modificar")
        {
            List<RN.Entidades.ClientePaquete> lstCliePaque = RN.Componentes.CClientePaquete.TraerXId(Convert.ToInt32(ClientePaqueteId.Value));
            if (lstCliePaque.Count != 0)
            {
                List<RN.Entidades.Paquete> lstPaquete = RN.Componentes.CPaquete.TraerXId(lstCliePaque[0].PaqueteId);
                if (lstPaquete.Count != 0)
                {
                    Datos.Value = string.Empty;
                    Combo.Value = string.Empty;
                    Adicionar.Value = "OtroServicio";
                    hdnServicioId.Value = e.CommandArgument.ToString();
                    Grillas(true);
                    List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                    List<RN.Entidades.ClienteFecha> objCl = RN.Componentes.CClienteFecha.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                    if (objCl.Count != 0)
                        txtFechaInicioPaquete.Text = objCl[0].FechaInicio.ToShortDateString();
                    else
                        txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
                    //txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
                    txtFechaInicioPaquete.Enabled = true;

                    if (lstCliePaque.Count != 0)
                    {
                        ddlPaquete.SelectedValue = lstCliePaque[0].PaqueteId.ToString();
                    }
                    CargarDatosPanel();
                    ddlPaquete.Enabled = false;
                    tbFechaPrecio.Visible = false;
                    grdHorarioIn.DataBind();
                    grdHorario.DataBind();
                    List<RN.Entidades.ClientePaquete> objCliente = RN.Componentes.CClientePaquete.TraerXCIdCliente(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                    if (objCliente.Count != 0)
                    {
                        DataTable dtTiempo = RN.Componentes.CClientePaquete.TraerTiempoPaquete(Convert.ToInt32(objCliente[0].Id.ToString()));
                        double dDiasVacacion = 0;
                        if (objCliente.Count != 0)
                        {
                            dtTiempo = RN.Componentes.CClientePaquete.TraerTiempoPaquete(Convert.ToInt32(objCliente[0].Id.ToString()));

                            List<RN.Entidades.Licencia> objLicencia = RN.Componentes.CLicencia.TraerXClientePaqueteId2(objCliente[0].Id);
                            if (objLicencia.Count != 0)
                            {
                                foreach (RN.Entidades.Licencia row in objLicencia)
                                {
                                    dDiasVacacion = dDiasVacacion + (row.FechaFinLicencia - row.FechaInicioLicencia).TotalDays;
                                }
                            }
                        }
                        if (dtTiempo.Rows.Count > 0)
                            txtFechaInicioPaquete.Text = Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()).AddDays(dDiasVacacion + 1).ToShortDateString();
                    }
                    else
                        txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
                    ShowDialogCargado("dialogPaquetes", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
                }
            }
        }
        if (e.CommandName == "Registrar")
        {
            if (!string.IsNullOrEmpty(ClientePaqueteId.Value))
            {
                List<RN.Entidades.ClientePaquete> lstCliePaque = RN.Componentes.CClientePaquete.TraerXId(Convert.ToInt32(ClientePaqueteId.Value));
                if (lstCliePaque.Count != 0)
                {
                    List<RN.Entidades.Paquete> lstPaquete = RN.Componentes.CPaquete.TraerXId(lstCliePaque[0].PaqueteId);
                    if (lstPaquete.Count != 0)
                    {
                        if (lstPaquete[0].TipoPaqueteId == 2 && grdServicios.Rows.Count > 0)
                        {
                            MensajeGuardado("Ha alcanzado el límite de servicios");
                        }
                        else
                        {
                            Datos.Value = string.Empty;
                            Combo.Value = string.Empty;
                            Adicionar.Value = "OtroServicio";
                            Grillas(true);
                            List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                            List<RN.Entidades.ClienteFecha> objCl = RN.Componentes.CClienteFecha.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                            if (objCl.Count != 0)
                                txtFechaInicioPaquete.Text = objCl[0].FechaInicio.ToShortDateString();
                            else
                                txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
                            //txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
                            txtFechaInicioPaquete.Enabled = true;

                            if (lstCliePaque.Count != 0)
                            {
                                ddlPaquete.SelectedValue = lstCliePaque[0].PaqueteId.ToString();
                            }
                            CargarDatosPanel();
                            ddlPaquete.Enabled = false;
                            tbFechaPrecio.Visible = false;
                            grdHorarioIn.DataBind();
                            grdHorario.DataBind();
                            List<RN.Entidades.ClientePaquete> objCliente = RN.Componentes.CClientePaquete.TraerXCIdCliente(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                            if (objCliente.Count != 0)
                            {
                                DataTable dtTiempo = RN.Componentes.CClientePaquete.TraerTiempoPaquete(Convert.ToInt32(objCliente[0].Id.ToString()));
                                double dDiasVacacion = 0;
                                if (objCliente.Count != 0)
                                {
                                    dtTiempo = RN.Componentes.CClientePaquete.TraerTiempoPaquete(Convert.ToInt32(objCliente[0].Id.ToString()));

                                    List<RN.Entidades.Licencia> objLicencia = RN.Componentes.CLicencia.TraerXClientePaqueteId2(objCliente[0].Id);
                                    if (objLicencia.Count != 0)
                                    {
                                        foreach (RN.Entidades.Licencia row in objLicencia)
                                        {
                                            dDiasVacacion = dDiasVacacion + (row.FechaFinLicencia - row.FechaInicioLicencia).TotalDays;
                                        }
                                    }
                                }
                                if (dtTiempo.Rows.Count > 0)
                                    txtFechaInicioPaquete.Text = Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()).AddDays(dDiasVacacion + 1).ToShortDateString();
                            }
                            else
                                txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
                            ShowDialogCargado("dialogPaquetes", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
                        }
                    }
                }
            }
            else
            {
                MensajeGuardado("Debe seleccionar un paquete");
            }
        }
        grdHorario.DataBind();
        grdServicios.DataBind();
    }
    private void CargarDatosPaquete(int codigo)
    {
        List<RN.Entidades.ClientePaquete> lstcPaquete = RN.Componentes.CClientePaquete.TraerXCIdCliente(codigo);
        if (String.IsNullOrEmpty(Datos.Value))
        {
            if (lstcPaquete.Count != 0)
                ClientePaqueteId.Value = lstcPaquete[0].Id.ToString();
        }
        //if (!String.IsNullOrEmpty(Combo.Value))
        //{
        //    //CargarServicio(Convert.ToInt32(ClientePaqueteId.Value));
        //    ClientePaqueteId.Value = ddlPaqueteClienteHide.SelectedValue.ToString();
        //}

        if (String.IsNullOrEmpty(ClientePaqueteId.Value))
        {
            lbLicencias.Enabled = false;
            btnPromocion.Enabled = false;
            btnPago.Enabled = false;
            btnImprimirRecibo.Enabled = false;
        }
        else
        {
            DataTable lstLic = RN.Componentes.CLicencia.TraerXClientePaqueteId(Convert.ToInt32(ClientePaqueteId.Value));
            if (lstLic.Rows.Count != 0)
                lbLicencias.Enabled = true;
            btnLicencia.Enabled = true;
            List<RN.Entidades.Cliente> lstClien = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
            if (lstClien.Count != 0)
            {
                if (lstClien[0].EmpresaId == 0)
                    btnPromocion.Enabled = true;
                else
                    btnPromocion.Enabled = false;
            }
            btnPago.Enabled = true;
            DataTable lstPagoClien = RN.Componentes.CPagoCliente.TraerXIdClientePaqueteDataCliente(Convert.ToInt32(hdnAutoCompleteClienteId.Value), Convert.ToInt32(hdnAutoCompleteClienteId.Value));
            if (lstPagoClien.Rows.Count != 0)
                btnImprimirRecibo.Enabled = true;
        }
        if (String.IsNullOrEmpty(ClientePaqueteId.Value))
        {
            if (lstcPaquete.Count > 0)
            {
                ddlPaqueteCliente.SelectedValue = lstcPaquete[0].PaqueteId.ToString();
                CargarServicio(lstcPaquete[0].Id);
                if (lstcPaquete[0].Estado)
                    lblEstadoPaquete.Text = "Vigente";
                else
                    lblEstadoPaquete.Text = "Vencido";
                lblEstadoPagoPaquete.Text = "Pendiente";
                lblFechaInicio.Text = lstcPaquete[0].FechaRegistro.ToShortDateString();
                CargarFechaExpiraPaquete();
                ddlPaqueteCliente.SelectedValue = lstcPaquete[0].PaqueteId.ToString();
                lbEliminar.Enabled = true;
                ClientePaqueteId.Value = lstcPaquete[0].Id.ToString();
                if (RN.Componentes.CClientePaquete.TieneAdicional(lstcPaquete[0].Id))
                {
                    ddlPaqueteCliente.Enabled = false;
                    HabilitarCombo.Value = lstcPaquete[0].Id.ToString();
                    CargarPaquete();
                }
                else
                {
                    ddlPaqueteCliente.Enabled = false;
                    HabilitarCombo.Value = string.Empty;
                    CargarPaquete();
                }
                btnExtender.Enabled = true;
            }
            else
            {
                ddlPaqueteCliente.SelectedValue = "0";
                lblPrecioPaquete.Text = "-";
                lblEstadoPaquete.Text = "-";
                lblEstadoPagoPaquete.Text = "-";
                lblFechaInicio.Text = "-";
                btnExtender.Enabled = false;
            }
        }
        else
        {
            if (lstcPaquete.Count > 0)
            {
                //ClientePaqueteId.Value = lstcPaquete[0].Id.ToString();
                List<RN.Entidades.Paquete> lstPaquete = RN.Componentes.CPaquete.TraerXId(lstcPaquete[0].PaqueteId);
                if (lstcPaquete.Count > 1)
                {
                    List<RN.Entidades.ClientePaquete> lstcPaqueteHabilitado = RN.Componentes.CClientePaquete.TraerXCIdClienteHabilitado(codigo, true);
                    foreach (RN.Entidades.ClientePaquete row in lstcPaqueteHabilitado)
                    {
                        if (row.Id.ToString() == ClientePaqueteId.Value.ToString())
                        {
                            CargarServicio(row.Id);
                            if (row.Estado)
                                lblEstadoPaquete.Text = "Habilitado";
                            else
                                lblEstadoPaquete.Text = "Vencido";
                            List<RN.Entidades.PagoCliente> lstcPagoClien = RN.Componentes.CPagoCliente.TraerXIdClientePaquete(Convert.ToInt32(hdnAutoCompleteClienteId.Value), Convert.ToInt32(ClientePaqueteId.Value));
                            if (lstcPagoClien.Count != 0)
                            {
                                lblEstadoPagoPaquete.Text = "Pagado";
                                lbEliminar.Enabled = false;
                            }
                            else
                            {
                                lblEstadoPagoPaquete.Text = "Pendiente";
                                lbEliminar.Enabled = true;
                            }
                            lblFechaInicio.Text = row.FechaRegistro.ToShortDateString();
                            CargarFechaExpiraPaquete();
                            ddlPaqueteCliente.SelectedValue = row.PaqueteId.ToString();
                            if (RN.Componentes.CClientePaquete.TieneAdicionalPadre(row.Id))
                            {
                                ddlPaqueteCliente.Enabled = false;
                                HabilitarCombo.Value = row.Id.ToString();
                                CargarPaquete();
                            }
                            else
                            {
                                ddlPaqueteCliente.Enabled = false;
                                HabilitarCombo.Value = string.Empty;
                                CargarPaquete();
                            }
                            //ddlPaquete.Enabled = false;
                            lbEliminar.Enabled = true;
                        }
                    }
                }
                if (lstcPaquete.Count == 1)
                {
                    if (lstPaquete[0].Estado)
                        lblEstadoPaquete.Text = "Habilitado";
                    else
                        lblEstadoPaquete.Text = "Vencido";
                    List<RN.Entidades.PagoCliente> lstcPagoClien = RN.Componentes.CPagoCliente.TraerXIdClientePaquete(Convert.ToInt32(hdnAutoCompleteClienteId.Value), Convert.ToInt32(ClientePaqueteId.Value));
                    if (lstcPagoClien.Count != 0)
                    {
                        lblEstadoPagoPaquete.Text = "Pagado";
                        lbEliminar.Enabled = false;
                    }
                    else
                    {
                        lblEstadoPagoPaquete.Text = "Pendiente";
                        lbEliminar.Enabled = true;
                    }
                    lblFechaInicio.Text = lstcPaquete[0].FechaRegistro.ToShortDateString();
                    CargarFechaExpiraPaquete();
                    ddlPaqueteCliente.SelectedValue = lstcPaquete[0].PaqueteId.ToString();
                    lbEliminar.Enabled = true;
                    if (RN.Componentes.CClientePaquete.TieneAdicional(lstcPaquete[0].Id))
                    {
                        ddlPaqueteCliente.Enabled = false;
                        HabilitarCombo.Value = lstcPaquete[0].Id.ToString();
                        CargarPaquete();
                    }
                    else
                    {
                        ddlPaqueteCliente.Enabled = false;
                        HabilitarCombo.Value = string.Empty;
                        CargarPaquete();
                    }
                }
                btnExtender.Enabled = true;
            }
            else
            {
                ClientePaqueteId.Value = string.Empty;
                ddlPaqueteCliente.SelectedValue = "0";
                lblFechaInicio.Text = "-";
                lblTiempoPaquete.Text = "-";
                lblDiasLicencia.Text = "-";
                lblPrecioPaquete.Text = "-";
                lblEstadoPaquete.Text = "-";
                lblEstadoPagoPaquete.Text = "-";
                lbEliminar.Enabled = false;
                btnExtender.Enabled = false;
                ddlPaqueteCliente.Enabled = false;

            }
        }

    }
    private void CargarFechaExpiraPaquete()
    {
        List<RN.Entidades.Paquete> lstPaquetes = RN.Componentes.CPaquete.TraerXId(Convert.ToInt32(ddlPaqueteCliente.SelectedValue));
        if (lstPaquetes.Count != 0)
        {
            decimal dDescuento = 0;
            List<RN.Entidades.PromocionCliente> objPromo = RN.Componentes.CPromocionCliente.TraerXIdClienteMensual(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
            if (objPromo.Count != 0)
            {
                PromocionClienteId.Value = objPromo[0].Id.ToString();
                List<RN.Entidades.Promocion> objPr = RN.Componentes.CPromocion.TraerXId(objPromo[0].PromocionId);
                if (objPr.Count != 0)
                {
                    if (objPr[0].Mensual)
                    {
                        dDescuento = objPr[0].MontoDescuento;
                    }
                }
            }
            if (lstPaquetes[0].Precio - Convert.ToDouble(dDescuento) < 0)
                dDescuento = 0;
            else
                dDescuento = Convert.ToDecimal(lstPaquetes[0].Precio) - (dDescuento);
            lblPrecioPaquete.Text = Convert.ToDouble(dDescuento).ToString("f2") + " Bs.";
            List<RN.Entidades.ClientePaquete> objCliente = RN.Componentes.CClientePaquete.TraerXCIdCliente(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
            DataTable dtTiempo = RN.Componentes.CClientePaquete.TraerTiempoPaquete(Convert.ToInt32(objCliente[0].Id.ToString()));

            if (dtTiempo.Rows.Count > 0)
                if (Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()) > DateTime.Now)
                {
                    double dDiasVacacion = 0;
                    List<RN.Entidades.Licencia> objLicencia = RN.Componentes.CLicencia.TraerXClientePaqueteId2(Convert.ToInt32(ClientePaqueteId.Value));
                    if (objLicencia.Count != 0)
                    {
                        foreach (RN.Entidades.Licencia row in objLicencia)
                        {
                            dDiasVacacion = dDiasVacacion + (row.FechaFinLicencia - row.FechaInicioLicencia).TotalDays;
                        }
                        lblDiasLicencia.Text = dDiasVacacion.ToString();
                    }
                    else
                    {
                        lblDiasLicencia.Text = "-";
                    }
                    lblTiempoPaquete.Text = Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()).AddDays(dDiasVacacion).ToShortDateString();
                }
                else
                    lblTiempoPaquete.Text = "Paquete expirado.";
        }
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        //txtSearch.Text = string.Empty;
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        NuevoCliente.Value = "Si";
        txtSearchCI.Text = string.Empty;
        hdnAutoCompleteClienteId.Value = string.Empty;
        ClienteControl.ClienteId = string.Empty;
        ClienteControl.ActualizarHiden();
        CargarDatosPanel();
        ShowDialog("dialogCliente");
        ClienteControl.SetFocus();
    }
    
    protected void ddlPaquete_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarDescripcionPaquete();
        grdHorario.DataBind();
        LimpiarTable();
        grdHorariosSeleccionados.DataBind();
        //CargarTable();
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
    private void MarcarChecks(bool bMarcado, GridViewRow row)
    {
        CheckBox chkSelec;
        Label lblCosto;
        decimal dCosto = 0;
        int iContador = 0;
        int i = 0;
        foreach (GridViewRow row2 in grdPaquetesAdeudados.Rows)
        {
            if (row2.RowIndex <= row.RowIndex)
            {
                chkSelec = (CheckBox)row2.FindControl("cbSeleccionarMes");
                chkSelec.Checked = bMarcado;
                if(iContador == 0)
                    txtFechaPeriodoInicio.Text = ((Label)row2.FindControl("lblfechaRegistro")).Text;
                if (bMarcado)
                {
                    lblCosto = (Label)row2.FindControl("lblPrecioTotal");
                    dCosto = dCosto + Convert.ToDecimal(lblCosto.Text);
                    iContador++;
                    txtFechaPeriodoFin.Text = ((Label)row2.FindControl("lblfechaFin")).Text;
                    if (i == 0)
                        txtConcepto.Text = ((Label)row2.FindControl("lblConcepto")).Text;
                    else
                    {
                        txtConcepto.Text = txtConcepto.Text + ""+ ((Label)row2.FindControl("lblConcepto")).Text;
                    }
                }
            }
            i++;
        }
        if (!bMarcado)
        {
            dCosto = 0;
            DeshabilitarChecks();
            txtFechaPeriodoInicio.Text = string.Empty;
            txtFechaPeriodoFin.Text = string.Empty;
            txtConcepto.Text = string.Empty;
        }
        //if (trPromocion.Visible)
        //{
        //    txtTotalDescuento.Text = (dCosto - Convert.ToDecimal(txtDescuento.Text)).ToString("f2");
        //}
        txtTotalDescuento.Text = dCosto.ToString("f2");
        txtMonto.Text = dCosto.ToString("f2");
        txtMonto.Enabled = true;
    }
    private void MarcarTodosChecks()
    {
        Label lblCosto;
        CheckBox chkSelec;
        decimal dCosto = 0;
        int i = 0;
        grdPaquetesAdeudados.DataBind();
        foreach (GridViewRow row2 in grdPaquetesAdeudados.Rows)
        {
            chkSelec = (CheckBox)row2.FindControl("cbSeleccionarMes");
            chkSelec.Checked = true;
            if (i == 0)
                txtFechaPeriodoInicio.Text = ((Label)row2.FindControl("lblfechaRegistro")).Text;
            if (chkSelec.Checked)
            {
                lblCosto = (Label)row2.FindControl("lblPrecioTotal");
                dCosto = dCosto + Convert.ToDecimal(lblCosto.Text);
                txtFechaPeriodoFin.Text = ((Label)row2.FindControl("lblfechaFin")).Text;
                if (i == 0)
                    txtConcepto.Text = ((Label)row2.FindControl("lblConcepto")).Text;
                else
                {
                    txtConcepto.Text = txtConcepto.Text + "" + ((Label)row2.FindControl("lblConcepto")).Text;
                }
            }
            i++;
        }
        if(i==0)
        {
            dCosto = 0;
            DeshabilitarChecks();
            txtFechaPeriodoInicio.Text = string.Empty;
            txtFechaPeriodoFin.Text = string.Empty;
            txtConcepto.Text = string.Empty;
        }
        //if (trPromocion.Visible)
        //{
        //    txtTotalDescuento.Text = (dCosto - (Convert.ToDecimal(txtDescuento.Text))*(i)).ToString("f2");
        //}
        txtTotalDescuento.Text = dCosto.ToString("f2");
        txtMonto.Text = dCosto.ToString("f2");
        txtMonto.Enabled = true;
    }
    public string GetPrecioPaquete(object item)
    {
        double monto = Convert.ToDouble(DataBinder.Eval(item, "precioPaquete"));
        return monto.ToString("f2");
    }
    public string GetPrecioDescuento(object item)
    {
        double monto = Convert.ToDouble(DataBinder.Eval(item, "Descuento"));
        return monto.ToString("f2");
    }
    public string GetPrecioTotal(object item)
    {
        double monto = Convert.ToDouble(DataBinder.Eval(item, "Total"));
        return monto.ToString("f2");
    }
    protected void ResultGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TextLogs.WriteInfo("Cambiando índice de página.");
        TextLogs.WriteDebug("Nuevo índice: " + e.NewPageIndex);
        ResultGrid.PageIndex = e.NewPageIndex;
        ResultGrid.DataBind();
    }
    protected void grdPaquetesAdeudados_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TextLogs.WriteInfo("Cambiando índice de página.");
        TextLogs.WriteDebug("Nuevo índice: " + e.NewPageIndex);
        grdPaquetesAdeudados.PageIndex = e.NewPageIndex;
        grdPaquetesAdeudados.DataBind();
    }
    public string FinSemana(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "finDeSemana"));
        if (!approved)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
    public string ListarDias(object id)
    {
        string sDias = string.Empty;
        int gId = Convert.ToInt32(DataBinder.Eval(id, "GrupoId"));
        if (gId != 0)
        {
            List<RN.Entidades.GrupoDia> lDias = RN.Componentes.CGrupoDia.TraerXGrupoId(gId);
            foreach (RN.Entidades.GrupoDia row in lDias)
            {
                switch (row.DiaId)
                {
                    case 1:
                        sDias = "Lun ";
                        break;
                    case 2:
                        sDias = sDias + "Mar ";
                        break;
                    case 3:
                        sDias = sDias + "Mier ";
                        break;
                    case 4:
                        sDias = sDias + "Jue ";
                        break;
                    case 5:
                        sDias = sDias + "Vie ";
                        break;
                    case 6:
                        sDias = sDias + "Sab ";
                        break;
                    case 7:
                        sDias = sDias + "Dom ";
                        break;
                    default:
                        sDias = "";
                        break;
                }
            }
        }
        return sDias;
    }
    public string IsApproved(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "estado"));
        if (approved)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
    public bool BotonSeleccionar(object id)
    {
        int approved = Convert.ToInt32(DataBinder.Eval(id, "id"));
        if (approved.ToString() == ClientePaqueteId.Value)
            return false;
        return true;
    }
    public string Adicional(object id)
    {
        int approved = Convert.ToInt32(DataBinder.Eval(id, "adicional"));
        if (approved!=-1)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
    public bool HabilitarAdicional(object id)
    {
        int approved = Convert.ToInt32(DataBinder.Eval(id, "adicional"));
        if (approved == -1)
            return true;
        else
            return false;
    }
    private void DeshabilitarChecks()
    {
        int iContador = 0;
        foreach (GridViewRow row in grdPaquetesAdeudados.Rows)
        {
            CheckBox chkSelec;
            chkSelec = (CheckBox)row.FindControl("cbSeleccionarMes");
            chkSelec.Checked = false;
            if(iContador ==0)
                chkSelec.Enabled = true;

            iContador++;
        }
    }
    public string IdNombre(object id)
    {
        string valor = (DataBinder.Eval(id, "id")).ToString();
        string nombre = (DataBinder.Eval(id, "nombreServicio")).ToString();
        return valor + "=" + nombre;
    }
    public bool HabilitarEliminar()
    {
        /*List<RN.Entidades.PagoCliente> lstPago = RN.Componentes.CPagoCliente.TraerXIdClientePaquete(Convert.ToInt32(hdnAutoCompleteClienteId.Value), Convert.ToInt32(ClientePaqueteId.Value));
        if (lstPago.Count != 0)
            return false;
        else
            return true;*/
        return true;
    }
    public bool HabilitarModificar()
    {
        //List<RN.Entidades.PagoCliente> lstPago = RN.Componentes.CPagoCliente.TraerXIdClientePaquete(Convert.ToInt32(hdnAutoCompleteClienteId.Value), Convert.ToInt32(ClientePaqueteId.Value));
        //if (lstPago.Count != 0)
        //    return false;
        //else
            return true;
    }
    private void CargarDescripcionPaquete()
    {
        if(!String.IsNullOrEmpty(hdnAutoCompleteClienteId.Value))
        {
            List<RN.Entidades.ClientePaquete> objCliente = RN.Componentes.CClientePaquete.TraerXCIdCliente(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
            if (objCliente.Count != 0)
            {
                DataTable dtTiempo = RN.Componentes.CClientePaquete.TraerTiempoPaquete(Convert.ToInt32(objCliente[0].Id.ToString()));
                double dDiasVacacion = 0;
                if (objCliente.Count != 0)
                {
                    dtTiempo = RN.Componentes.CClientePaquete.TraerTiempoPaquete(Convert.ToInt32(objCliente[0].Id.ToString()));

                    List<RN.Entidades.Licencia> objLicencia = RN.Componentes.CLicencia.TraerXClientePaqueteId2(objCliente[0].Id);
                    if (objLicencia.Count != 0)
                    {
                        foreach (RN.Entidades.Licencia row in objLicencia)
                        {
                            dDiasVacacion = dDiasVacacion + (row.FechaFinLicencia - row.FechaInicioLicencia).TotalDays;
                        }
                    }
                }
                if (dtTiempo.Rows.Count > 0)
                
                {
                    if (Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()) > DateTime.Now)
                        txtFechaInicioPaquete.Text = Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()).AddDays(dDiasVacacion + 1).ToShortDateString();
                    else
                    {
                        List<RN.Entidades.ClienteFecha> objCl = RN.Componentes.CClienteFecha.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                        if (objCl.Count != 0)
                            txtFechaInicioPaquete.Text = objCl[0].FechaInicio.ToShortDateString();
                        else
                            txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
                    }
                }
            }
            else
            {
                List<RN.Entidades.ClienteFecha> objCl = RN.Componentes.CClienteFecha.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                if (objCl.Count != 0)
                    txtFechaInicioPaquete.Text = objCl[0].FechaInicio.ToShortDateString();
                else
                    txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
            }
        }
        if (ddlPaquete.SelectedIndex != -1)
        {
            List<RN.Entidades.Paquete> lstPaquetes = RN.Componentes.CPaquete.TraerXId(Convert.ToInt32(ddlPaquete.SelectedValue));
            if (lstPaquetes.Count != 0)
            {
                if (!String.IsNullOrEmpty(hdnAutoCompleteClienteId.Value))
                {
                    DataTable dtClientePquete = RN.Componentes.CClientePaquete.TraerXIdPrecioRealPaquete(Convert.ToInt32(hdnAutoCompleteClienteId.Value), Convert.ToInt32(ddlPaquete.SelectedValue));
                    if (dtClientePquete.Rows.Count != 0)
                        lblPanelPrecioPaquete.Text = Convert.ToDouble(dtClientePquete.Rows[0][0]).ToString("f2") + " Bs.";
                }
                List<RN.Entidades.Unidad> lstUni = RN.Componentes.CUnidad.TraerXId(lstPaquetes[0].UnidadId);
                if(lstUni.Count != 0)
                    lblPanelTiempoPaquete.Text = lstPaquetes[0].Tiempo.ToString() + " " + lstUni[0].Nombre;
                //txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                lblPanelPrecioPaquete.Text = "-";
                lblPanelTiempoPaquete.Text = "-";
            }
        }
    }
    private void CargarDescripcionPaqueteCliente()
    {
        if (!String.IsNullOrEmpty(Combo.Value))
        {
            //if (ddlPaqueteClienteHide.SelectedIndex != -1)
            //{
            //    List<RN.Entidades.ClientePaquete> lstcPaquetes = RN.Componentes.CClientePaquete.TraerXId(Convert.ToInt32(ddlPaqueteClienteHide.SelectedValue));
                
            //    if (lstcPaquetes.Count != 0)
            //    {
            //        List<RN.Entidades.Paquete> lstPaquetes = RN.Componentes.CPaquete.TraerXId(lstcPaquetes[0].PaqueteId);
            //        if (lstPaquetes.Count != 0)
            //        {
            //            DataTable dtTiempo = RN.Componentes.CClientePaquete.TraerTiempoPaquete(Convert.ToInt32(ClientePaqueteId.Value));
            //            if (dtTiempo.Rows.Count > 0)
            //            {
            //                double dDiasVacacion = 0;
            //                List<RN.Entidades.Licencia> objLicencia = RN.Componentes.CLicencia.TraerXClientePaqueteId2(Convert.ToInt32(ClientePaqueteId.Value));
            //                if (objLicencia.Count != 0)
            //                {
            //                    foreach (RN.Entidades.Licencia row in objLicencia)
            //                    {
            //                        dDiasVacacion = dDiasVacacion + (row.FechaFinLicencia - row.FechaInicioLicencia).TotalDays;
            //                    }
            //                    lblDiasLicencia.Text = dDiasVacacion.ToString();
            //                }
            //                else
            //                {
            //                    lblDiasLicencia.Text = "-";
            //                }
            //                if (Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()) > DateTime.Now)
            //                    lblTiempoPaquete.Text = Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()).AddDays(dDiasVacacion).ToShortDateString();
            //                else
            //                    lblTiempoPaquete.Text = "Paquete expirado.";
            //            }
            //        }
            //        else
            //        {
            //            lblPrecioPaquete.Text = "-";
            //            lblDiasLicencia.Text = "-";
            //            lblTiempoPaquete.Text = "-";
            //            lblCoberturaEmpresaMonto.Text = "-";
            //            txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
            //        }
            //    }
            //    else
            //    {
            //        lblPrecioPaquete.Text = "-";
            //        lblDiasLicencia.Text = "-";
            //        lblTiempoPaquete.Text = "-";
            //        lblCoberturaEmpresaMonto.Text = "-";
            //        txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
            //    }
            //}
            //else
            //{
            //    lblPrecioPaquete.Text = "-";
            //    lblTiempoPaquete.Text = "-";
            //    lblDiasLicencia.Text = "-";
            //    lblEstadoPaquete.Text = "-";
            //    lblCoberturaEmpresaMonto.Text = "-";
            //    lblEstadoPagoPaquete.Text = "-";
            //    txtFechaInicioPaquete.Text = "-";
            //    lblFechaInicio.Text = "-";
            //}
        }
        else
        {
            if (ddlPaqueteCliente.SelectedIndex != -1)
            {
                List<RN.Entidades.Paquete> lstPaquetes = RN.Componentes.CPaquete.TraerXId(Convert.ToInt32(ddlPaqueteCliente.SelectedValue));
                if (lstPaquetes.Count != 0)
                {
                    DataTable dtTiempo = RN.Componentes.CClientePaquete.TraerTiempoPaquete(Convert.ToInt32(ClientePaqueteId.Value));
                    if (dtTiempo.Rows.Count > 0)
                    {
                        double dDiasVacacion = 0;
                        List<RN.Entidades.Licencia> objLicencia = RN.Componentes.CLicencia.TraerXClientePaqueteId2(Convert.ToInt32(ClientePaqueteId.Value));
                        if (objLicencia.Count != 0)
                        {
                            foreach (RN.Entidades.Licencia row in objLicencia)
                            {
                                dDiasVacacion = dDiasVacacion + (row.FechaFinLicencia - row.FechaInicioLicencia).TotalDays;
                            }
                            lblDiasLicencia.Text = dDiasVacacion.ToString();
                        }
                        else
                        {
                            lblDiasLicencia.Text = "-";
                        }
                        if (Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()) > DateTime.Now)
                            lblTiempoPaquete.Text = Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()).AddDays(dDiasVacacion).ToShortDateString();
                        else
                            lblTiempoPaquete.Text = "Paquete expirado.";
                    }
                }
                else
                {
                    lblPrecioPaquete.Text = "-";
                    lblDiasLicencia.Text = "-";
                    lblTiempoPaquete.Text = "-";
                    lblCoberturaEmpresaMonto.Text = "-";
                    if(!string.IsNullOrEmpty(hdnAutoCompleteClienteId.Value))
                    {
                    List<RN.Entidades.ClienteFecha> objCl = RN.Componentes.CClienteFecha.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                    if (objCl.Count != 0)
                        txtFechaInicioPaquete.Text = objCl[0].FechaInicio.ToShortDateString();
                    else
                        txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
                    }
                    else
                        txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
                }
            }
        }
    }
    private void CargarDescripcionPromocion()
    {
        if (!string.IsNullOrEmpty(ClientePaqueteId.Value))
        {
            List<RN.Entidades.PromocionCliente> objPromo = RN.Componentes.CPromocionCliente.TraerXIdClienteMensual(Convert.ToInt32(ClientePaqueteId.Value));
            if (objPromo.Count != 0)
            {
                PromocionClienteId.Value = objPromo[0].Id.ToString();
                List<RN.Entidades.Promocion> objPr = RN.Componentes.CPromocion.TraerXId(objPromo[0].PromocionId);
                if (objPr.Count != 0)
                {
                    //if (objPr[0].Mensual)
                    //{
                        lblPromocionCliente.Text = objPr[0].Nombre;
                        lblCostoPromocionCliente.Text = objPr[0].MontoDescuento.ToString();
                    //}
                }
                lblFechaAsignacionPromocion.Text = objPromo[0].FechaAsignacion.ToShortDateString();
            }
            else
            {
                List<RN.Entidades.PromocionCliente> objPromo2 = RN.Componentes.CPromocionCliente.TraerXIdClienteNoMensual(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                if (objPromo2.Count != 0)
                {
                    PromocionClienteId.Value = objPromo2[0].Id.ToString();
                    List<RN.Entidades.Promocion> objPr = RN.Componentes.CPromocion.TraerXId(objPromo2[0].PromocionId);
                    if (objPr.Count != 0)
                    {
                        if (!objPr[0].Mensual)
                        {
                            lblPromocionCliente.Text = objPr[0].Nombre;
                            lblCostoPromocionCliente.Text = objPr[0].MontoDescuento.ToString();
                        }
                    }
                }
                else
                {
                    lblPromocionCliente.Text = "-";
                    lblCostoPromocionCliente.Text = "-";
                    lblFechaAsignacionPromocion.Text = "-";
                }
            }
            /*List<RN.Entidades.PromocionCliente> objPromo2 = RN.Componentes.CPromocionCliente.TraerXIdCliente(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
            if (objPromo.Count != 0)
            {
                PromocionClienteId.Value = objPromo2[0].Id.ToString();
                List<RN.Entidades.Promocion> objPr2 = RN.Componentes.CPromocion.TraerXId(objPromo2[0].PromocionId);
                if (objPr2.Count != 0)
                {
                    if (!objPr2[0].Mensual)
                    {
                        lblPromocionCliente.Text = objPr2[0].Nombre;
                        lblCostoPromocionCliente.Text = objPr2[0].MontoDescuento.ToString();
                    }
                }
                lblFechaAsignacionPromocion.Text = objPromo2[0].FechaAsignacion.ToShortDateString();
            }
            else
            {
                lblPromocionCliente.Text = "-";
                lblCostoPromocionCliente.Text = "-";
                lblFechaAsignacionPromocion.Text = "-";
            }*/
        }
        else
        {
            lblPromocionCliente.Text = "-";
            lblCostoPromocionCliente.Text = "-";
            lblFechaAsignacionPromocion.Text = "-";
        }
        if (!string.IsNullOrEmpty(hdnAutoCompleteClienteId.Value))
        {
            //List<RN.Entidades.PromocionCliente> objPromo = RN.Componentes.CPromocionCliente.TraerXIdClientePago(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
            //if (objPromo.Count > 0)
            //{
            //    lbEliminarPromocion.Visible = false;
            //}
            //else
            //{
                List<RN.Entidades.PromocionCliente> objPromo3 = RN.Componentes.CPromocionCliente.TraerXIdCliente(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                if (objPromo3.Count != 0)
                {
                    lbEliminarPromocion.Visible = true;
                }
                else
                    lbEliminarPromocion.Visible = false;
            //}
            if (!String.IsNullOrEmpty(ClientePaqueteId.Value))
            {
                lbEliminar.Visible = HabilitarEliminar();
            }
        }
    }
    protected void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarDescripcionServicio();
        grdHorario.DataBind();
        grdHorarioIn.DataBind();
    }
    protected void btnGuardarServicios_Click(object sender, EventArgs e)
    {
        MembershipUser user = Membership.GetUser();
        Page.Validate("upPaqueteSeleccion");
        RN.Entidades.ClientePaquete objTipoPaquete = new RN.Entidades.ClientePaquete();
        RN.Entidades.ClientePaqueteD objCPDetalle = new RN.Entidades.ClientePaqueteD();
        List<RN.Entidades.Inscripcion> lstInscripciones = new List<RN.Entidades.Inscripcion>();
        bool bErrores = false;
        int icontador2 = 0;
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        if (Adicionar.Value.ToString().Equals("true"))
        {
            List<RN.Entidades.ClientePaquete> lstCliePaque = RN.Componentes.CClientePaquete.TraerXId(Convert.ToInt32(ClientePaqueteId.Value));
            List<RN.Entidades.Paquete> lstPa = RN.Componentes.CPaquete.TraerXId(lstCliePaque[0].PaqueteId);
            List<RN.Entidades.Paquete> lstPa2 = RN.Componentes.CPaquete.TraerXId(Convert.ToInt32(ddlPaquete.SelectedValue));
            if (lstPa.Count != 0)
            {
                if (lstPa[0].UnidadId == lstPa2[0].UnidadId)
                {
                    if (Page.IsValid)
                    {
                        if (lstCliePaque.Count != 0)
                        {
                            if (lstCliePaque[0].Adicional != -1)
                            {
                                bErrores = true;
                            }
                        }
                        if (!bErrores)
                        {
                            List<RN.Entidades.Paquete> lstPaque = RN.Componentes.CPaquete.TraerXId(lstCliePaque[0].PaqueteId);
                            if (lstPaque.Count != 0 && lstPa2.Count != 0)
                            {
                                foreach (GridViewRow row in grdHorariosSeleccionados.Rows)
                                {
                                    icontador2++;
                                    RN.Entidades.Inscripcion objIns = new RN.Entidades.Inscripcion();
                                    objIns.Estado = true;
                                    objIns.GrupoId = Convert.ToInt32(grdHorariosSeleccionados.DataKeys[row.RowIndex].Value.ToString());
                                    objIns.UsuarioId = user.ProviderUserKey.ToString();
                                    objIns.Fecha = DateTime.Now;
                                    lstInscripciones.Add(objIns);
                                }
                                if (icontador2 > 0 && lstPaque[0].TipoPaqueteId == 2)
                                {
                                    objCPDetalle.ClienteId = Convert.ToInt32(hdnAutoCompleteClienteId.Value);
                                    objCPDetalle.PaqueteId = Convert.ToInt32(ddlPaquete.SelectedValue.ToString());
                                    objCPDetalle.UsuarioId = user.ProviderUserKey.ToString();
                                    objCPDetalle.Estado = true;
                                    objCPDetalle.FechaRegistro = lstCliePaque[0].FechaRegistro;
                                    objCPDetalle.Fecha = DateTime.Now;

                                    objCPDetalle.Adicional = lstCliePaque[0].Id;
                                    objCPDetalle.Detalle = lstInscripciones;
                                    ClientePaqueteId.Value = RN.Workflows.WClientePaquete.InsertarCodigo(objCPDetalle).ToString();
                                    TextLogs.WriteInfo("La inscripción ha sido guardada correctamente.");
                                    MarcarTodosChecks();
                                    CloseDialogMensajeCargadoShowDialog("dialogPaquetes", "La inscripcion ha sido guardada correctamente.", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi, "dialogPagos");
                                    CargarDatosPanel();
                                    this.Context.Session["Inscripciones"] = null;
                                }
                                else
                                {
                                    if (icontador2 == 1 && lstPaque[0].TipoPaqueteId == 1)
                                    {
                                        objCPDetalle.ClienteId = Convert.ToInt32(hdnAutoCompleteClienteId.Value);
                                        objCPDetalle.PaqueteId = Convert.ToInt32(ddlPaquete.SelectedValue.ToString());
                                        objCPDetalle.UsuarioId = user.ProviderUserKey.ToString();
                                        objCPDetalle.Estado = true;
                                        objCPDetalle.FechaRegistro = lstCliePaque[0].FechaRegistro;
                                        objCPDetalle.Fecha = DateTime.Now;
                                        objCPDetalle.Adicional = lstCliePaque[0].Id;
                                        objCPDetalle.Detalle = lstInscripciones;
                                        ClientePaqueteId.Value = RN.Workflows.WClientePaquete.InsertarCodigo(objCPDetalle).ToString();
                                        TextLogs.WriteInfo("La inscripción ha sido guardada correctamente.");
                                        MarcarTodosChecks();
                                        CloseDialogMensajeCargadoShowDialog("dialogPaquetes", "La inscripcion ha sido guardada correctamente.", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi, "dialogPagos");
                                        CargarDatosPanel();
                                        this.Context.Session["Inscripciones"] = null;
                                    }
                                    else
                                        MensajeGuardado("El paquete seleccionado no permite agregar más servicios.");
                                }
                                if (icontador2 == 0)
                                    MensajeGuardado("Para registrar el paquete debe agregar mínimo un servicio.");
                            }
                        }
                    }
                    Adicionar.Value = string.Empty;
                }
                else
                    MensajeGuardado("Solo puede extender el paquete con otro que tenga la misma unidad de cálculo (Ej. meses)");
            }
        }
        else
        {
            if (Adicionar.Value.ToString().Equals("OtroServicio"))
            {
                
                foreach (GridViewRow row in grdHorariosSeleccionados.Rows)
                {
                    RN.Entidades.Inscripcion objIns = new RN.Entidades.Inscripcion();
                    objIns.Estado = true;
                    objIns.ClientePaqueteId = Convert.ToInt32(ClientePaqueteId.Value);
                    objIns.GrupoId = Convert.ToInt32(grdHorariosSeleccionados.DataKeys[row.RowIndex].Value.ToString());
                    objIns.UsuarioId = user.ProviderUserKey.ToString();
                    objIns.Fecha = DateTime.Now;
                    lstInscripciones.Add(objIns);
                }
                if (RN.Workflows.WClientePaquete.InsertarInscripcion(Convert.ToInt32(ClientePaqueteId.Value), lstInscripciones))
                {
                    CloseDialogMensajeCargadoShowDialog("dialogPaquetes", "El servicio ha sido guardada correctamente.", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi, "dialogPagos");
                    CargarDatosPanel();
                    this.Context.Session["Inscripciones"] = null;
                }
            }
            else
            {
                if (Page.IsValid)
                {
                    if (!String.IsNullOrEmpty(hdnAutoCompleteClienteId.Value))
                    {
                        List<RN.Entidades.ClientePaquete> objCliente = RN.Componentes.CClientePaquete.TraerXCIdCliente(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                        if (objCliente.Count == 0)
                        {
                            TextLogs.WriteDebug("Asociando el paquete a cliente: " + ddlPaquete.SelectedValue.ToString());
                            TextLogs.WriteInfo("Entrando a asociar el paquete a cliente");
                            objTipoPaquete.ClienteId = Convert.ToInt32(hdnAutoCompleteClienteId.Value);
                            objTipoPaquete.PaqueteId = Convert.ToInt32(ddlPaquete.SelectedValue.ToString());
                            objTipoPaquete.UsuarioId = user.ProviderUserKey.ToString();
                            objTipoPaquete.Estado = true;
                            objCPDetalle.FechaRegistro = Convert.ToDateTime(txtFechaInicioPaquete.Text);
                            objTipoPaquete.Fecha = DateTime.Now;

                            objCPDetalle.ClienteId = Convert.ToInt32(hdnAutoCompleteClienteId.Value);
                            objCPDetalle.PaqueteId = Convert.ToInt32(ddlPaquete.SelectedValue.ToString());
                            objCPDetalle.UsuarioId = user.ProviderUserKey.ToString();
                            objCPDetalle.Estado = true;
                            objCPDetalle.Fecha = DateTime.Now;

                            TextLogs.WriteInfo("Se creo una nuevo paquete.");
                            TextLogs.WriteInfo("El paquete ha sido guardado correctamente.");
                        }
                        else
                        {
                            //DataTable dtTiempo = RN.Componentes.CClientePaquete.TraerTiempoPaquete(Convert.ToInt32(objCliente[0].Id.ToString()));
                            //if (dtTiempo.Rows.Count > 0)
                            //    if (Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()) > DateTime.Now)
                            //        objCPDetalle.FechaRegistro = Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString());
                            //    else
                            objCPDetalle.FechaRegistro = Convert.ToDateTime(txtFechaInicioPaquete.Text);
                            TextLogs.WriteDebug("Asociando el paquete a cliente: " + ddlPaquete.SelectedValue.ToString());
                            TextLogs.WriteInfo("Entrando a asociar el paquete a cliente");
                            objTipoPaquete.ClienteId = Convert.ToInt32(hdnAutoCompleteClienteId.Value);
                            objTipoPaquete.UsuarioId = user.ProviderUserKey.ToString();
                            objTipoPaquete.PaqueteId = Convert.ToInt32(ddlPaquete.SelectedValue.ToString());
                            objTipoPaquete.Estado = true;
                            objTipoPaquete.Fecha = DateTime.Now;

                            objCPDetalle.ClienteId = Convert.ToInt32(hdnAutoCompleteClienteId.Value);
                            objCPDetalle.PaqueteId = Convert.ToInt32(ddlPaquete.SelectedValue.ToString());
                            objCPDetalle.UsuarioId = user.ProviderUserKey.ToString();
                            objCPDetalle.Estado = true;
                            objCPDetalle.Fecha = DateTime.Now;
                        }
                    }
                }
                int icontador = 0;
                bool bError = false;
                Page.Validate("upServicios");
                if (Page.IsValid)
                {
                    List<RN.Entidades.Paquete> lstPaquete = RN.Componentes.CPaquete.TraerXId(Convert.ToInt32(ddlPaquete.SelectedValue));
                    if (!bError)
                    {
                        foreach (GridViewRow row in grdHorariosSeleccionados.Rows)
                        {
                            icontador++;
                            RN.Entidades.Inscripcion objIns = new RN.Entidades.Inscripcion();
                            objIns.Estado = true;
                            objIns.GrupoId = Convert.ToInt32(grdHorariosSeleccionados.DataKeys[row.RowIndex].Value.ToString());
                            objIns.UsuarioId = user.ProviderUserKey.ToString();
                            objIns.Fecha = DateTime.Now;
                            lstInscripciones.Add(objIns);
                        }

                        List<RN.Entidades.ClientePaquete> objCliente = RN.Componentes.CClientePaquete.TraerXCIdCliente(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                        DataTable dtTiempo = new DataTable();
                        double dDiasVacacion = 0;
                        if (objCliente.Count != 0)
                        {
                            dtTiempo = RN.Componentes.CClientePaquete.TraerTiempoPaquete(Convert.ToInt32(objCliente[0].Id.ToString()));

                            List<RN.Entidades.Licencia> objLicencia = RN.Componentes.CLicencia.TraerXClientePaqueteId2(objCliente[0].Id);
                            if (objLicencia.Count != 0)
                            {
                                foreach (RN.Entidades.Licencia row in objLicencia)
                                {
                                    dDiasVacacion = dDiasVacacion + (row.FechaFinLicencia - row.FechaInicioLicencia).TotalDays;
                                }
                            }
                        }
                        if (dtTiempo.Rows.Count > 0)
                        {
                            if (Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()).AddDays(dDiasVacacion+1) <= Convert.ToDateTime(txtFechaInicioPaquete.Text))
                            {
                                if (icontador > 0)
                                {
                                    objCPDetalle.Detalle = lstInscripciones;
                                    ClientePaqueteId.Value = RN.Workflows.WClientePaquete.InsertarCodigo(objCPDetalle).ToString();
                                    TextLogs.WriteInfo("La inscripción ha sido guardada correctamente.");
                                    MarcarTodosChecks();
                                    CloseDialogMensajeCargadoShowDialog("dialogPaquetes", "La inscripcion ha sido guardada correctamente.", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi, "dialogPagos");
                                    this.Context.Session["Inscripciones"] = null;
                                }
                                else
                                    MensajeGuardado("Para guardar el paquete debe adicionar mínimo un servicio.");
                            }
                            else
                            {
                                List<RN.Entidades.ClienteFecha> objCl = RN.Componentes.CClienteFecha.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                                if (objCl.Count != 0)
                                    txtFechaInicioPaquete.Text = objCl[0].FechaInicio.ToShortDateString();
                                else
                                    txtFechaInicioPaquete.Text = Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()).AddDays(dDiasVacacion+1).ToShortDateString();
                                MensajeGuardado("La fecha de inicio debe ser mayor a la fecha de finalización del último paquete: " + Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()).AddDays(dDiasVacacion+1).ToShortDateString());
                            }
                        }
                        else
                        {
                            if (icontador > 0)
                            {
                                objCPDetalle.Detalle = lstInscripciones;
                                ClientePaqueteId.Value = RN.Workflows.WClientePaquete.InsertarCodigo(objCPDetalle).ToString();
                                TextLogs.WriteInfo("La inscripción ha sido guardada correctamente.");
                                MarcarTodosChecks();
                                CloseDialogMensajeCargadoShowDialog("dialogPaquetes", "La inscripcion ha sido guardada correctamente.", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi, "dialogPagos");
                                this.Context.Session["Inscripciones"] = null;
                            }
                            else
                                MensajeGuardado("Para guardar el paquete debe adicionar mínimo un servicio.");
                        }
                    }
                }
            }
        }
        LimpiarTable();
        CargarTable();
        CargarPaquete();
        CargarDatosPanel();
        CargarDescripcionPaquete();
    }

    protected void grdServicios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            ImageButton lb = e.Row.FindControl("Delete") as ImageButton;
            ScriptManager.GetCurrent(this).RegisterPostBackControl(lb);

            //ImageButton lb1 = e.Row.FindControl("Delete") as ImageButton;
            //ScriptManager.GetCurrent(this).RegisterPostBackControl(lb1);
        }
    }
    protected void lbEliminar_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hdnAutoCompleteClienteId.Value))
        {
            List<RN.Entidades.ClientePaquete> lstPaquetes = RN.Componentes.CClientePaquete.TraerXCIdClienteHabilitado(Convert.ToInt32(hdnAutoCompleteClienteId.Value), true);
            List<RN.Entidades.PromocionCliente> lstPromocion = new List<RN.Entidades.PromocionCliente>();
            bool enabled = false;
            bool enabled2 = false;
            bool enabled3 = false;
            if (!String.IsNullOrEmpty(ClientePaqueteId.Value))
            {
                List<RN.Entidades.PagoEmpresa> lstPagoEmpresa = RN.Componentes.CPagoEmpresa.TraerXIdClientePaquete(Convert.ToInt32(ClientePaqueteId.Value));
                if (lstPagoEmpresa.Count != 0)
                    enabled = false;
                else
                    enabled = true;
                List<RN.Entidades.PagoCliente> lstcPagoClien = RN.Componentes.CPagoCliente.TraerXIdClientePaquete(Convert.ToInt32(hdnAutoCompleteClienteId.Value), Convert.ToInt32(ClientePaqueteId.Value));
                if (lstcPagoClien.Count != 0)
                    enabled3 = false;
                else
                    enabled3 = true;
                lstPromocion = RN.Componentes.CPromocionCliente.TraerXIdPaqueteCliente(Convert.ToInt32(ClientePaqueteId.Value));
                if (lstPromocion.Count != 0)
                    enabled2 = false;
                else
                    enabled2 = true;

            }
            if (enabled)
            {
                if (enabled3)
                {
                    if (enabled2)
                    {
                        if (lstPaquetes.Count != 0)
                        {
                            RN.Componentes.CClientePaquete.EliminarClientePaquete(Convert.ToInt32(ClientePaqueteId.Value.ToString()));
                            int iCliente = CargarDatosCliente();
                        }
                        else
                            ClientePaqueteId.Value = string.Empty;
                    }
                    else
                        MensajeGuardado("No se puede eliminar porque existe una promocion asignada al paquete.");
                }
                else
                    MensajeGuardado("No se puede eliminar porque existen pagos registrados por el cliente.");
            }
            else
                MensajeGuardado("No se puede eliminar porque existen pagos registrados por la empresa.");
            if (!String.IsNullOrEmpty(Combo.Value))
                CargarPaquete();
            Combo.Value = string.Empty;
            if (lstPaquetes.Count != 0)
            {
                int iCliente = CargarDatosCliente();
                CargarDatosPaquete(iCliente);
                CargarDescripcionPaqueteCliente();
                List<RN.Entidades.ClientePaquete> lstPaquetes1 = RN.Componentes.CClientePaquete.TraerXCIdClienteHabilitado(Convert.ToInt32(hdnAutoCompleteClienteId.Value), true);
                if (lstPaquetes1.Count != 0)
                    ClientePaqueteId.Value = lstPaquetes1.Last().Id.ToString();
                else
                    ClientePaqueteId.Value = string.Empty;
                ClienteControl.CargarDatos();
                grdServicios.DataBind();
                ResultGrid.DataBind();
                CargarDatosPanel();
                MensajeGuardado("El paquete seleccionado ha sido eliminado del cliente.");
            }
        }
        else
            MensajeGuardado("Debe seleccionar un paquete");
    }
    protected void ResultGrid_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Selecc")
        {
            Datos.Value = "Seleccionado";
            ClientePaqueteId.Value = e.CommandArgument.ToString();
            if (RN.Componentes.CClientePaquete.TieneAdicional(Convert.ToInt32(e.CommandArgument.ToString())))
            {
                Combo.Value = "Si";
                //Combo.Value = string.Empty;
                List<RN.Entidades.ClientePaquete> lstcPaquete = RN.Componentes.CClientePaquete.DatosTieneAdicional(Convert.ToInt32(e.CommandArgument.ToString()));
                if (lstcPaquete.Count != 0)
                    HabilitarCombo.Value = lstcPaquete[0].Id.ToString();
            }
            else
            {
                Combo.Value = string.Empty;
                HabilitarCombo.Value = string.Empty;
            }
            CargarPaquete();
            CargarDatosPanel();
            grdHorario.DataBind();
            grdServicios.DataBind();
            btnSelect.Text = "<script language=JavaScript> $(document).ready(function() { closeDialog('dialogHistorial'); }); </script>";            
        }
    }
    protected void grdHorario_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        bool bError = false;
        if (e.CommandName == "Seleccionar")
        {
            CheckBox chL;
            CheckBox chM;
            CheckBox chMI;
            CheckBox chJ;
            CheckBox chV;
            CheckBox chS;
            CheckBox chD;
            List<RN.Entidades.Paquete> lstPaquete = RN.Componentes.CPaquete.TraerXId(Convert.ToInt32(ddlPaquete.SelectedValue));
            if (lstPaquete[0].TipoPaqueteId == 2)
            {
                if (dtListado.Rows.Count >= 1)
                {
                    bError = true;
                    MensajeGuardado("El paquete seleccionado no permite adquirir más servicios.");
                }
            }
            foreach (GridViewRow row in grdHorario.Rows)
            {
                if (grdHorario.DataKeys[row.RowIndex].Value.ToString() == e.CommandArgument.ToString())
                {
                    foreach (GridViewRow row2 in grdHorariosSeleccionados.Rows)
                    {
                        if (grdHorariosSeleccionados.DataKeys[row2.RowIndex].Value.ToString() == grdHorario.DataKeys[row.RowIndex].Value.ToString())
                        {
                            bError = true;
                            MensajeGuardado("El servicio seleccionado ya fue previamente agregado.");
                        }
                        if ((ConfigurationManager.AppSettings["DisciplinasAbiertas"].ToString().Equals(grdHorario.DataKeys[row.RowIndex].Value.ToString())) || (ConfigurationManager.AppSettings["DisciplinasAbiertas"].ToString().Equals(grdHorariosSeleccionados.DataKeys[row2.RowIndex].Value.ToString())))
                            bError = false;
                        else
                        {
                            DataTable dtCruce = RN.Componentes.CGrupo.Grupo_TraerValidandoCrucesHorario(Convert.ToInt32(grdHorariosSeleccionados.DataKeys[row2.RowIndex].Value.ToString()), Convert.ToInt32(grdHorarioIn.DataKeys[row.RowIndex].Value.ToString()));
                            if (dtCruce.Rows.Count != 0)
                            {
                                bError = true;
                                MensajeGuardado("Existe un cruce de horario.");
                            }
                        }
                    }
                }
            }
            foreach (GridViewRow row in grdHorario.Rows)
            {
                if (grdHorario.DataKeys[row.RowIndex].Value.ToString() == e.CommandArgument.ToString())
                {
                    if (!string.IsNullOrEmpty(ClientePaqueteId.Value))
                    {
                        List<RN.Entidades.Inscripcion> lstIns = RN.Componentes.CInscripcion.TraerXClienteGrupo(Convert.ToInt32(ClientePaqueteId.Value.ToString()), Convert.ToInt32(e.CommandArgument.ToString()));
                        if (lstIns.Count != 0)
                        {
                            bError = true;
                            MensajeGuardado("El servicio seleccionado ya ha sido agregado previamente.");
                        }
                    }
                    if (!bError)
                    {
                        chL = (CheckBox)row.FindControl("lblLunes");
                        chM = (CheckBox)row.FindControl("lblMartes");
                        chMI = (CheckBox)row.FindControl("lblMiercoles");
                        chJ = (CheckBox)row.FindControl("lblJueves");
                        chV = (CheckBox)row.FindControl("lblViernes");
                        chS = (CheckBox)row.FindControl("lblSabado");
                        chD = (CheckBox)row.FindControl("lblDomingo");
                        //dtListado.Rows.Add(Convert.ToInt32(e.CommandArgument), row.Cells[2].Text, row.Cells[3].Text, row.Cells[4].Text, row.Cells[5].Text, chL.Checked, chM.Checked, chMI.Checked, chJ.Checked, chV.Checked, chS.Checked, chD.Checked);
                        dtListado.Rows.Add(Convert.ToInt32(e.CommandArgument), row.Cells[2].Text, row.Cells[2].Text, row.Cells[3].Text, row.Cells[4].Text, chL.Checked, chM.Checked, chMI.Checked, chJ.Checked, chV.Checked, chS.Checked, chD.Checked);
                    }
                }
            }
            this.Context.Session["Inscripciones"] = dtListado;
            grdHorariosSeleccionados.DataBind();
        }
    }
    protected void grdHorariosSeleccionados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Eliminar")
        {
            dtListado = (DataTable)this.Context.Session["Inscripciones"];
            for (int i = 0; i < dtListado.Rows.Count; i++)
            {
                if (dtListado.Rows[i]["id"].ToString() == e.CommandArgument.ToString())
                    dtListado.Rows[i].Delete();
            }
            this.Context.Session["Inscripciones"] = dtListado;
            CargarTable();
        }
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        hdnServicioId.Value = string.Empty;
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        ClienteControl.CargarDatos();
        LimpiarTable();
        CloseDialogCargado("dialogPaquetes", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }
    protected void ResultGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            LinkButton lb = e.Row.FindControl("LBSelecc") as LinkButton;
            ScriptManager.GetCurrent(this).RegisterPostBackControl(lb);
        }
    }
    protected void btnExtender_Click(object sender, EventArgs e)
    {
        if (!lblTiempoPaquete.Text.Equals("Paquete expirado."))
        {
            Grillas(false);
            List<RN.Entidades.Cliente> objCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
            grdHorario.DataBind();
            if (objCliente.Count != 0)
            {
                Adicionar.Value = "true";
                ShowDialogCargado("dialogPaquetes", objCliente[0].Id.ToString(), objCliente[0].Nombre + " " + objCliente[0].Apellidos, objCliente[0].Ci + objCliente[0].CiCi);
            }
            List<RN.Entidades.ClientePaquete> lstCliePaque = RN.Componentes.CClientePaquete.TraerXId(Convert.ToInt32(ClientePaqueteId.Value));
            double dDiasVacacion = 0;
            if (objCliente.Count != 0)
            {
                List<RN.Entidades.Licencia> objLicencia = RN.Componentes.CLicencia.TraerXClientePaqueteId2(lstCliePaque[0].Id);
                if (objLicencia.Count != 0)
                {
                    foreach (RN.Entidades.Licencia row in objLicencia)
                    {
                        dDiasVacacion = dDiasVacacion + (row.FechaFinLicencia - row.FechaInicioLicencia).TotalDays;
                    }
                }
            }
            txtFechaInicioPaquete.Text = lstCliePaque[0].FechaRegistro.AddDays(dDiasVacacion).ToShortDateString();
            txtFechaInicioPaquete.Enabled = false;
        }
        else
            MensajeGuardado("No se puede extender paquetes expirados");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        ClienteControl.CargarDatos();
        LimpiarTable();
        CloseDialogCargado("dialogExtensiones", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        ClienteControl.CargarDatos();
        LimpiarTable();
        CloseDialogCargado("dialogHistorialLicencias", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        if (string.IsNullOrEmpty(hdnAutoCompleteClienteId.Value))
        {
            CloseDialog("dialogHistorial");            
            //CloseDialogCargado("dialogHistorial", string.Empty, string.Empty, string.Empty);
            return;
        }
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        ClienteControl.CargarDatos();
        LimpiarTable();
        CloseDialogCargado("dialogHistorial", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }
    protected void ddlPaqueteCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarDatosPanel();
    }
    protected void ddlPaqueteClienteHide_SelectedIndexChanged(object sender, EventArgs e)
    {
        Datos.Value = "Si";
        CargarDatosPanel();
    }
    protected void lbLicencias_Click(object sender, EventArgs e)
    {
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        txtMotivoLicencia.Text = string.Empty;
        txtFechaFinalLicencia.Text = string.Empty;
        txtFechaInicioLicencia.Text = string.Empty;
        lblLicenciaFechaSolicitud.Text = DateTime.Now.ToShortDateString();
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        grdHistorialLicencias.DataBind();
        ShowDialogCargado("dialogHistorialLicencias", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }
    protected void btnLicencia_Click(object sender, EventArgs e)
    {
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        txtMotivoLicencia.Text = string.Empty;
        //txtFechaFinalLicencia.Text = string.Empty;
        //txtFechaInicioLicencia.Text = string.Empty;
        txtFechaFinalLicencia.Text = DateTime.Now.AddDays(1).ToShortDateString();
        txtFechaInicioLicencia.Text = DateTime.Now.ToShortDateString();
        lblLicenciaFechaSolicitud.Text = DateTime.Now.ToShortDateString();
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        ShowDialogCargado("dialogLicencia", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }
    protected void btnCliente_Click(object sender, EventArgs e)
    {
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        ClienteControl.CargarDatos();
        ShowDialogCargado("dialogCliente", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }
    protected void btndPaquetes_Click(object sender, EventArgs e)
    {
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        Grillas(true);
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        List<RN.Entidades.ClienteFecha> objCl = RN.Componentes.CClienteFecha.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        if (objCl.Count != 0)
        {
            txtFechaInicioPaquete.Text = objCl[0].FechaInicio.ToShortDateString();
            txtFechaInicioPaquete.Enabled = false;
        }
        else
        {
            txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
            txtFechaInicioPaquete.Enabled = true;
        }
        //txtFechaInicioPaquete.Enabled = true;
        CargarDatosPanel();
        grdHorarioIn.DataBind();
        grdHorario.DataBind();
        List<RN.Entidades.ClientePaquete> objCliente = RN.Componentes.CClientePaquete.TraerXCIdCliente(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        if (objCliente.Count != 0)
        {
            DataTable dtTiempo = RN.Componentes.CClientePaquete.TraerTiempoPaquete(Convert.ToInt32(objCliente[0].Id.ToString()));
            double dDiasVacacion = 0;
            if (objCliente.Count != 0)
            {
                List<RN.Entidades.Licencia> objLicencia = RN.Componentes.CLicencia.TraerXClientePaqueteId2(objCliente[0].Id);
                if (objLicencia.Count != 0)
                {
                    foreach (RN.Entidades.Licencia row in objLicencia)
                    {
                        dDiasVacacion = dDiasVacacion + (row.FechaFinLicencia - row.FechaInicioLicencia).TotalDays;
                    }
                }
            }

            if (dtTiempo.Rows.Count > 0)
                txtFechaInicioPaquete.Text = Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()).AddDays(dDiasVacacion + 1).ToShortDateString();
        }
        else
        {
            List<RN.Entidades.ClienteFecha> objCl1 = RN.Componentes.CClienteFecha.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
            if (objCl1.Count != 0)
                txtFechaInicioPaquete.Text = objCl1[0].FechaInicio.ToShortDateString();
            else
                txtFechaInicioPaquete.Text = DateTime.Now.ToShortDateString();
        }
        ShowDialogCargado("dialogPaquetes", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }
    protected void btnPago_Click(object sender, EventArgs e)
    {
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        DeshabilitarChecks();
        cbEstadoPago.Checked = true;
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        //CargarDatosPanel();
        grdPaquetesAdeudados.DataBind();
        LimpiarPago();
        HabilitarFormaPago();
        ddlFormaPago.SelectedValue = "ef";
        List<RN.Entidades.PromocionCliente> lstPromo = RN.Componentes.CPromocionCliente.TraerXIdClienteValidando(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        if(lstPromo.Count!=0)
        {
            List<RN.Entidades.Promocion> lstPromocion = RN.Componentes.CPromocion.TraerXId(lstPromo[0].PromocionId);
            //if(lstPromocion.Count!=0)
            //    HabilitarDescuento(true, lstPromocion[0].MontoDescuento, lstPromocion[0].Nombre);
        }
        //else
        //    HabilitarDescuento(false, 0, "");
        MarcarTodosChecks();
        ShowDialogCargado("dialogPagos", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }
    //private void HabilitarDescuento(bool vBol, decimal monto, string nombre)
    //{
    //    trPromocion.Visible = vBol;
    //    trPromocion2.Visible = vBol;
    //    txtDescuento.Text = monto.ToString();
    //    lblNombreDescuento.Text = nombre;
    //}
    protected void btnGuardarPago_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ClientePaqueteId.Value))
        {
            CheckBox chkSelec;
            int iContador = 0;
            bool bCorrecto = false;
            DateTime dtPago = DateTime.Now;
            int iMaximo = RN.Componentes.CPagoCliente.TraerMaximoRecibo();
            foreach (GridViewRow row2 in grdPaquetesAdeudados.Rows)
            {
                chkSelec = (CheckBox)row2.FindControl("cbSeleccionarMes");
                if (iContador == 0)
                    txtFechaPeriodoInicio.Text = ((Label)row2.FindControl("lblfechaRegistro")).Text;
                if (chkSelec.Checked)
                {
                    TextLogs.WriteDebug("Insertando pago: " + ClienteControl.ClienteId);
                    TextLogs.WriteInfo("Entrando a crear pago.");
                    RN.Entidades.PagoCliente objPago = new RN.Entidades.PagoCliente();

                    objPago.ClientePaqueteId = Convert.ToInt32(grdPaquetesAdeudados.DataKeys[row2.RowIndex].Value.ToString());
                    objPago.Concepto = ((Label)row2.FindControl("lblConcepto")).Text;
                    //objPago.Concepto = txtConcepto.Text;
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
                    objPago.FechaPeriodoInicio = Convert.ToDateTime(txtFechaPeriodoInicio.Text);
                    objPago.FechaPeriodoFin = Convert.ToDateTime(txtFechaPeriodoFin.Text);
                    //if (trPromocion.Visible)
                    //    objPago.Monto = Convert.ToDecimal(((Label)row2.FindControl("lblPrecioTotal")).Text) - Convert.ToDecimal(txtDescuento.Text);
                    //else
                    //    objPago.Monto = Convert.ToDecimal(((Label)row2.FindControl("lblPrecioPaquete")).Text);
                    //objPago.Monto = Convert.ToDecimal(((Label)row2.FindControl("lblPrecioTotal")).Text);
                    objPago.Monto = Convert.ToDecimal(txtMonto.Text);
                    objPago.FechaPago = dtPago;
                    objPago.Estado = true;
                    MembershipUser user = Membership.GetUser();
                    objPago.UsuarioId = user.ProviderUserKey.ToString();
                    objPago.Fecha = DateTime.Now;
                    objPago.NroRecibo = iMaximo;
                    if (RN.Componentes.CPagoCliente.Insertar(objPago, Convert.ToInt32(hdnAutoCompleteClienteId.Value)))
                    {
                        bCorrecto = true;
                        lbEliminar.Enabled = false;
                    }
                    else
                        bCorrecto = false;
                }
            }
            if (bCorrecto)
            {
                List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                TextLogs.WriteInfo("El pago ha sido guardado correctamente.");
                //CloseDialogCargadoMensaje("dialogPagos", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci, "Pago registrado correctamente");
                CloseDialogMensajeCargadoShowDialog("dialogPagos", "El pago ha sido guardado correctamente.", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi, "dialogRecibos");
                CargarDatosPanel();
            }
        }
    }
    protected void btnCerrarPago_Click(object sender, EventArgs e)
    {
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        ClienteControl.CargarDatos();
        CargarDatosPanel();
        LimpiarTable();
        CloseDialogCargado("dialogPagos", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
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
        //txtIntercambioId.Text = string.Empty;
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
    private void LimpiarPagoSoloDatosPago()
    {
        //txtConcepto.Text = string.Empty;
        txtNumeroFactura.Text = string.Empty;
        txtDigitosTarjeta.Text = string.Empty;
        txtNumeroAprobacionPOS.Text = string.Empty;
        txtNumeroCheque.Text = string.Empty;
        txtNombreBancoCheque.Text = string.Empty;
        txtNumeroCuentaTransferencia.Text = string.Empty;
        txtNombreBancoTransferencia.Text = string.Empty;
        //txtIntercambioId.Text = string.Empty;
        txtNroPago.Text = string.Empty;
        //ddlFormaPago.SelectedValue = "ef";
    }
    private void Grillas(bool balor)
    {
        grdHorarioIn.Visible = balor;
        grdHorario.Visible = !balor;
    }
    protected void grdHorarioIn_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        bool bError = false;
        if (e.CommandName == "Seleccionar")
        {
            CheckBox chL;   
            CheckBox chM;
            CheckBox chMI;
            CheckBox chJ;
            CheckBox chV;
            CheckBox chS;
            CheckBox chD;
            List<RN.Entidades.Paquete> lstPaquete = RN.Componentes.CPaquete.TraerXId(Convert.ToInt32(ddlPaquete.SelectedValue));
            if (lstPaquete[0].TipoPaqueteId == 2)
            {
                if (dtListado.Rows.Count >= 1)
                {
                    bError = true;
                    MensajeGuardado("Ya alcanzó el límite de servicios");
                }
            }
            foreach (GridViewRow row in grdHorarioIn.Rows)
            {
                if (grdHorarioIn.DataKeys[row.RowIndex].Value.ToString() == e.CommandArgument.ToString())
                {
                    foreach (GridViewRow row2 in grdHorariosSeleccionados.Rows)
                    {
                        if (grdHorariosSeleccionados.DataKeys[row2.RowIndex].Value.ToString() == grdHorarioIn.DataKeys[row.RowIndex].Value.ToString())
                        {
                            bError = true;
                            MensajeGuardado("El servicio seleccionado ya ha sido agregado previamente.");
                        }
                        if ((ConfigurationManager.AppSettings["DisciplinasAbiertas"].ToString().Equals(grdHorariosSeleccionados.DataKeys[row2.RowIndex].Value.ToString())) || (ConfigurationManager.AppSettings["DisciplinasAbiertas"].ToString().Equals(grdHorarioIn.DataKeys[row.RowIndex].Value.ToString())))
                            bError = false;
                        else
                        {
                            DataTable dtCruce = RN.Componentes.CGrupo.Grupo_TraerValidandoCrucesHorario(Convert.ToInt32(grdHorariosSeleccionados.DataKeys[row2.RowIndex].Value.ToString()), Convert.ToInt32(grdHorarioIn.DataKeys[row.RowIndex].Value.ToString()));
                            if (dtCruce.Rows.Count != 0)
                            {
                                bError = true;
                                MensajeGuardado("Existe un cruce de horario.");
                            }
                        }
                    }
                }
            }
            foreach (GridViewRow row in grdHorarioIn.Rows)
            {
                if (grdHorarioIn.DataKeys[row.RowIndex].Value.ToString() == e.CommandArgument.ToString())
                {
                    if (!string.IsNullOrEmpty(ClientePaqueteId.Value))
                    {
                        List<RN.Entidades.Inscripcion> lstIns = RN.Componentes.CInscripcion.TraerXClienteGrupo(Convert.ToInt32(ClientePaqueteId.Value.ToString()), Convert.ToInt32(e.CommandArgument.ToString()));
                        if (lstIns.Count != 0)
                        {
                            DataTable dtTiempo = RN.Componentes.CInscripcion.TraerTiempo(Convert.ToInt32(ClientePaqueteId.Value.ToString()), Convert.ToDateTime(txtFechaInicioPaquete.Text));
                            if (dtTiempo.Rows.Count != 0)
                            {
                                if (Convert.ToDateTime(Convert.ToDateTime(dtTiempo.Rows[0][0].ToString()).ToShortDateString()) >= (Convert.ToDateTime(txtFechaInicioPaquete.Text)))
                                {
                                    bError = true;
                                    MensajeGuardado("El servicio seleccionado ya ha sido agregado previamente o el tiempo de inicio cruza con el anterior paquete.");
                                }
                                else

                                    bError = false;
                            }
                            
                        }
                    }
                    if (!bError)
                    {
                        chL = (CheckBox)row.FindControl("lblLunes");
                        chM = (CheckBox)row.FindControl("lblMartes");
                        chMI = (CheckBox)row.FindControl("lblMiercoles");
                        chJ = (CheckBox)row.FindControl("lblJueves");
                        chV = (CheckBox)row.FindControl("lblViernes");
                        chS = (CheckBox)row.FindControl("lblSabado");
                        chD = (CheckBox)row.FindControl("lblDomingo");
                        dtListado.Rows.Add(Convert.ToInt32(e.CommandArgument), row.Cells[2].Text, row.Cells[2].Text, row.Cells[3].Text, row.Cells[4].Text, chL.Checked, chM.Checked, chMI.Checked, chJ.Checked, chV.Checked, chS.Checked, chD.Checked);
                    }
                }
            }
            this.Context.Session["Inscripciones"] = dtListado;
            grdHorariosSeleccionados.DataBind();
        }
    }

    protected void grdServicios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TextLogs.WriteInfo("Cambiando índice de página.");
        TextLogs.WriteDebug("Nuevo índice: " + e.NewPageIndex);
        grdServicios.PageIndex = e.NewPageIndex;
        grdServicios.DataBind();
    }
    protected void grdHorario_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TextLogs.WriteInfo("Cambiando índice de página.");
        TextLogs.WriteDebug("Nuevo índice: " + e.NewPageIndex);
        grdHorario.PageIndex = e.NewPageIndex;
        grdHorario.DataBind();
    }
    protected void grdHorarioIn_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TextLogs.WriteInfo("Cambiando índice de página.");
        TextLogs.WriteDebug("Nuevo índice: " + e.NewPageIndex);
        grdHorarioIn.PageIndex = e.NewPageIndex;
        grdHorarioIn.DataBind();
    }
    public string GetFechaInicio(object id)
    {
        return Convert.ToDateTime(DataBinder.Eval(id, "fechaRegistro")).ToShortDateString();
    }
    public string GetFechaFinalizacion(object id)
    {
        return Convert.ToDateTime(DataBinder.Eval(id, "fechaFin")).ToShortDateString();
    }
    protected void btnCerrarLicencia_Click(object sender, EventArgs e)
    {
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        CloseDialogCargado("dialogLicencia", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }
    protected void btnGuardarLicencia_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(ClientePaqueteId.Value))
        {
            TextLogs.WriteDebug("Insertando licencia: " + ClienteControl.ClienteId);
            TextLogs.WriteInfo("Entrando a crear licencia.");
            List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
            MembershipUser user = Membership.GetUser();
            RN.Entidades.Licencia objLicencia = new RN.Entidades.Licencia();
            objLicencia.Fecha = DateTime.Now;
            objLicencia.ClientePaqueteId = Convert.ToInt32(ClientePaqueteId.Value);
            objLicencia.Descripcion = txtMotivoLicencia.Text;
            if (Convert.ToDateTime(txtFechaInicioLicencia.Text).ToShortDateString().Equals(Convert.ToDateTime(txtFechaFinalLicencia.Text).ToShortDateString()))
                txtFechaFinalLicencia.Text = Convert.ToDateTime(txtFechaFinalLicencia.Text).AddDays(1).ToShortDateString();
            objLicencia.FechaInicioLicencia = Convert.ToDateTime(txtFechaInicioLicencia.Text);
            objLicencia.FechaFinLicencia = Convert.ToDateTime(txtFechaFinalLicencia.Text);
            objLicencia.Estado = true;
            objLicencia.FechaSolicitud = DateTime.Now;
            objLicencia.UsuarioId = user.ProviderUserKey.ToString();
            DataTable dtTiempo = RN.Componentes.CClientePaquete.TraerTiempoPaquete(Convert.ToInt32(ClientePaqueteId.Value));
            if (dtTiempo.Rows.Count > 0)
            {
                if (Convert.ToDateTime(dtTiempo.Rows[0]["tiempo"].ToString()) <= DateTime.Now)
                    MensajeGuardado("El paquete ya expiró");
                else
                {
                    if (RN.Workflows.WLicencia.Insertar(objLicencia))
                    {
                        TextLogs.WriteInfo("Licencia registrada satisfactoriamente");
                        Comunicacion.Email objMail = new Comunicacion.Email();
                        List<RN.Entidades.Cliente> lisCliente = new List<RN.Entidades.Cliente>();
                        lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                        List<string> lstCorreos = new List<string>();
                        if(lstCliente.Count != 0)
                        {
                            if (!String.IsNullOrEmpty(lstCliente[0].Correo))
                                lstCorreos.Add(lstCliente[0].Correo);
                            if (!String.IsNullOrEmpty(lstCliente[0].CorreoTrabajo))
                                lstCorreos.Add(lstCliente[0].Correo);
                            if (!String.IsNullOrEmpty(user.Email))
                                lstCorreos.Add(user.Email);
                        }
                        if (lstCorreos.Count != 0)
                        {
                            objMail.To = lstCorreos;
                            try
                            {
                                TextLogs.WriteInfo("Enviando notificaciones por correo de licencia.");
                                Configuration.Template template = AppSettings.GetTemplate("LicenseGenerated");
                                string file = AppSettings.LoadFile(template.File);
                                if (AppSettings.SendCopy)
                                {
                                    TextLogs.WriteDebug("La copia del mail se enviará a: " + template.CopyTo);
                                    objMail.Cc.Add(template.CopyTo);
                                }
                                TextLogs.WriteDebug("Contenido del mail cargado con la siguiente información:\r\n" + file);

                                file = file.Replace("[CLIENTE]", lstCliente[0].Nombre + " " + lstCliente[0].Apellidos);
                                file = file.Replace("[FECHASOLICITUD]", DateTime.Now.ToShortDateString());
                                file = file.Replace("[DESDE]", txtFechaInicioLicencia.Text);
                                file = file.Replace("[HASTA]", txtFechaFinalLicencia.Text);
                                file = file.Replace("[MOTIVO]", txtMotivoLicencia.Text);

                                objMail.SendMail(AppSettings.SendHtml, template.Subject, file);

                                //objMail.SendMail(true, GetGlobalResourceObject("Mensajes", "NotifficacionLicenciaAsunto").ToString(), GetGlobalResourceObject("Mensajes", "NotificacionLicenciaCuerpoHtml").ToString().Replace("[Cliente]", lstCliente[0].Nombre + " " + lstCliente[0].Apellidos).Replace("[Desde]", txtFechaInicioLicencia.Text).Replace("[Hasta]", txtFechaFinalLicencia.Text).Replace("[FechaSolicitud]", DateTime.Now.ToShortDateString()).Replace("[Motivo]", txtMotivoLicencia.Text));
                                CloseDialogCargadoMensaje("dialogLicencia", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi, "Licencia registrada correctamente");
                                CargarDatosPanel();
                                TextLogs.WriteInfo("Se han enviado las notificaciones satisfactoriamente.");
                            }
                            catch (Exception error)
                            {
                                TextLogs.WriteError("No se pudieron enviar las notificaciones por licencias.", error);
                                CloseDialogCargadoMensaje("dialogLicencia", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi, "No se han configurado las opciones de notificaciones");
                                CargarDatosPanel();
                            }
                        }
                        else
                        {
                            TextLogs.WriteInfo("No se enviaron las notificaciones no se tienen correos registrados.");
                            CloseDialogCargadoMensaje("dialogLicencia", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi, "Licencia registrada correctamente, no se pudo enviar las notificaciones no se tienen correos registrados");
                            CargarDatosPanel();
                        }
                        TextLogs.WriteInfo("La licencia ha sido guardado correctamente.");
                    }
                    else
                        TextLogs.WriteDebug("No se pudo registrar la ");
                }

            }

        }
    }
    
    protected void grdHistorialLicencias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Imprimir")
        {
            List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
            CargarPaquete();
            CargarDatosPanel();
            grdHorario.DataBind();
            grdServicios.DataBind();
            CargarReporte(Convert.ToInt32(e.CommandArgument));
            CloseDialogCargadoShowDialog("dialogHistorialLicencias", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi, "dialogImpresionLicencia");
        }
        if (e.CommandName == "Notificar")
        {
            MembershipUser user = Membership.GetUser();
            List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
            CargarPaquete();
            CargarDatosPanel();
            grdHorario.DataBind();
            grdServicios.DataBind();
            Comunicacion.Email objMail = new Comunicacion.Email();
            List<RN.Entidades.Cliente> lisCliente = new List<RN.Entidades.Cliente>();
            lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
            List<string> lstCorreos = new List<string>();
            if (lstCliente.Count != 0)
            {
                if (!String.IsNullOrEmpty(lstCliente[0].Correo))
                    lstCorreos.Add(lstCliente[0].Correo);
                if (!String.IsNullOrEmpty(lstCliente[0].CorreoTrabajo))
                    lstCorreos.Add(lstCliente[0].Correo);
                if (!String.IsNullOrEmpty(user.Email))
                    lstCorreos.Add(user.Email);
            }
            List<RN.Entidades.Licencia> lstLicencia = RN.Componentes.CLicencia.TraerXId(Convert.ToInt32(e.CommandArgument));
            if (lstCorreos.Count != 0)
            {
                objMail.To = lstCorreos;
                if (lstLicencia.Count != 0)
                {
                    try
                    {
                        objMail.SendMail(true, GetGlobalResourceObject("Mensajes", "NotifficacionLicenciaAsunto").ToString(), GetGlobalResourceObject("Mensajes", "NotificacionLicenciaCuerpoHtml").ToString().Replace("[Cliente]", lstCliente[0].Nombre + " " + lstCliente[0].Apellidos).Replace("[Desde]", lstLicencia[0].FechaInicioLicencia.ToShortDateString()).Replace("[Hasta]", lstLicencia[0].FechaFinLicencia.ToShortDateString()).Replace("[FechaSolicitud]", lstLicencia[0].Fecha.ToShortDateString()).Replace("[Motivo]", lstLicencia[0].Descripcion));
                        MensajeGuardadoCargado("Las notificaciones de licencias han sido enviadas", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
                    }
                    catch (Exception error)
                    {
                        MensajeGuardadoCargado("No se han configurado las opciones de notificaciones", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
                    }
                }
                else 
                {
                    MensajeGuardadoCargado("Las notificaciones no se enviaron, no se tienen correos registrados", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
                }
            }
            
        }
    }
    private void CargarReporte(int id)
    {
        DataTable dtLicencia;
        MembershipUser user = Membership.GetUser();
        if (id == 0)
        {
            id = 0;
        }
        dtLicencia = RN.Componentes.CLicencia.TraerXIdImp(Convert.ToInt32(id));
        rvLicencias.Visible = true;
        rvLicencias.LocalReport.DataSources.Clear();
        rvLicencias.LocalReport.ReportPath = Server.MapPath("~/Reportes/rImpresionLicencia.rdlc");
        rvLicencias.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dtLicencia));
        rvLicencias.LocalReport.Refresh();
    }
    private void CargarReporteRecibo(int id)
    {
        DataTable dtLicencia;
        MembershipUser user = Membership.GetUser();
        if (id == 0)
        {
            id = 0;
        }
        dtLicencia = RN.Componentes.CPagoCliente.TraerXIdClientePaqueteD(Convert.ToInt32(id), Convert.ToInt32(id));
        rpRecibo.Visible = true;
        rpRecibo.LocalReport.DataSources.Clear();
        rpRecibo.LocalReport.ReportPath = Server.MapPath("~/Reportes/rRecibo.rdlc");
        rpRecibo.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dtLicencia));
        rpRecibo.LocalReport.Refresh();
    }
    protected void grdHistorialLicencias_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TextLogs.WriteInfo("Cambiando índice de página.");
        TextLogs.WriteDebug("Nuevo índice: " + e.NewPageIndex);
        grdHistorialLicencias.PageIndex = e.NewPageIndex;
        grdHistorialLicencias.DataBind();
    }

    protected void grdHistorialLicencias_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            //LinkButton lb = e.Row.FindControl("Seleccionar") as LinkButton;
            //ScriptManager.GetCurrent(this).RegisterPostBackControl(lb);
        }
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
            //trPagoIntercambio2.Visible = false;
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
            //trPagoIntercambio2.Visible = false;
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
            //trPagoIntercambio2.Visible = false;
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
            //trPagoIntercambio2.Visible = false;
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
            //trPagoIntercambio2.Visible = true;
        }
        LimpiarPagoSoloDatosPago();    
    }
    protected void ddlPromocion_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarMontoPromo();
    }
    protected void btnPromocion_Click(object sender, EventArgs e)
    {
        if (RN.Componentes.CPromocionCliente.TraerXIdClienteNoMensual(Convert.ToInt32(hdnAutoCompleteClienteId.Value)).Count != 0)
            MensajeGuardado("Ya se registró una promoción al cliente");
        else
            if (RN.Componentes.CPromocionCliente.TraerXIdClienteMensual(Convert.ToInt32(ClientePaqueteId.Value)).Count == 0)
            {
                List<RN.Entidades.ClientePaquete> lstCliePaque = RN.Componentes.CClientePaquete.TraerXId(Convert.ToInt32(ClientePaqueteId.Value));
                if (lstCliePaque.Count != 0)
                {
                    List<RN.Entidades.Paquete> lstPaque = RN.Componentes.CPaquete.TraerXId(lstCliePaque[0].PaqueteId);
                    if (lstPaque.Count != 0)
                    {
                        if (lstPaque[0].Tiempo == 1 && lstPaque[0].UnidadId == 1)
                        {
                            Datos.Value = string.Empty;
                            Combo.Value = string.Empty;
                            Adicionar.Value = string.Empty;
                            DeshabilitarChecks();
                            cbEstadoPago.Checked = true;
                            List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                            CargarPromociones();
                            ddlFormaPago.SelectedValue = "ef";
                            ShowDialogCargado("dialogPromocion", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
                        }
                        else
                            MensajeGuardado("Solo puede agregar promociones a paquete mensuales");
                    }
                }
            }
            else
                MensajeGuardado("Ya se registró una promoción al cliente");
    }
    private void CargarPromociones()
    {
        ddlPromocion.DataSource = RN.Componentes.CPromocion.TraerHabiles();
        ddlPromocion.DataTextField = "nombre";
        ddlPromocion.DataValueField = "id";
        ddlPromocion.DataBind();
        CargarMontoPromo();

    }
    private void CargarMontoPromo()
    {
        if (ddlPromocion.SelectedIndex != -1)
        {
            List<RN.Entidades.Promocion> lstPromocion = RN.Componentes.CPromocion.TraerXId(Convert.ToInt32(ddlPromocion.SelectedValue.ToString()));
            if (lstPromocion.Count != 0)
            {
                lblMontoDescuento.Text = lstPromocion[0].MontoDescuento.ToString();
            }
        }
        else
            lblMontoDescuento.Text = "0";
    }
    protected void btnGuardarPromocion_Click(object sender, EventArgs e)
    {
        if (ddlPromocion.SelectedIndex != -1)
        {
            List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
            TextLogs.WriteDebug("Insertando promocion cliente: " + ClienteControl.ClienteId);
            TextLogs.WriteInfo("Entrando a crear promocion cliente.");
            MembershipUser user = Membership.GetUser();
            RN.Entidades.PromocionCliente objPromo = new RN.Entidades.PromocionCliente();
            objPromo.ClientePaqueteId = Convert.ToInt32(ClientePaqueteId.Value);
            objPromo.Estado = true;
            objPromo.Fecha = DateTime.Now;
            objPromo.FechaAsignacion = DateTime.Now;
            objPromo.PromocionId = Convert.ToInt32(ddlPromocion.SelectedValue.ToString());
            objPromo.UsuarioId = user.ProviderUserKey.ToString();
            if (RN.Componentes.CPromocionCliente.Insertar(objPromo))
            {
                TextLogs.WriteInfo("La promocion ha sido guardada correctamente.");
                CloseDialogCargadoMensaje("dialogPromocion", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi, "Promoción registrada correctamente");
                CargarDatosPanel();
            }
        }
    }
    protected void btnCerrarPromocion_Click(object sender, EventArgs e)
    {
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        ClienteControl.CargarDatos();
        CargarDatosPanel();
        LimpiarTable();
        CloseDialogCargado("dialogPromocion", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }
    protected void lbEliminarPromocion_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(PromocionClienteId.Value))
        {
            if (RN.Componentes.CPromocionCliente.EliminarPromocionCliente(Convert.ToInt32(PromocionClienteId.Value)))
            {
                List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
                CargarDatosPanel();
                MensajeGuardadoCargado("Promoción eliminada correctamente", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
            }
        }
    }
    protected void btnCerrarImpresion_Click(object sender, EventArgs e)
    {
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        ClienteControl.CargarDatos();
        CargarDatosPanel();
        LimpiarTable();
        CloseDialogCargado("dialogImpresionLicencia", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }
    protected void btnImprimirRecibo_Click(object sender, EventArgs e)
    {
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        grdPagosRegistrados.DataBind();
        ShowDialogCargado("dialogRecibos", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }

    protected void grdPagosRegistrados_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TextLogs.WriteInfo("Cambiando índice de página.");
        TextLogs.WriteDebug("Nuevo índice: " + e.NewPageIndex);
        grdPagosRegistrados.PageIndex = e.NewPageIndex;
        grdPagosRegistrados.DataBind();
    }
    protected void grdPagosRegistrados_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdPagosRegistrados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Imprimir")
        {
            List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
            CargarPaquete();
            CargarDatosPanel();
            grdHorario.DataBind();
            grdServicios.DataBind();
            CargarReporteRecibo(Convert.ToInt32(e.CommandArgument));
            CloseDialogCargadoShowDialog("dialogRecibos", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi, "dialogImpresionRecibo");
        }
    }
    protected void btnImpresionRecibo_Click(object sender, EventArgs e)
    {
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        ClienteControl.CargarDatos();
        CargarDatosPanel();
        LimpiarTable();
        CloseDialogCargado("dialogImpresionRecibo", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }
    protected void grdAdicionales_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TextLogs.WriteInfo("Cambiando índice de página.");
        TextLogs.WriteDebug("Nuevo índice: " + e.NewPageIndex);
        grdAdicionales.PageIndex = e.NewPageIndex;
        grdAdicionales.DataBind();
    }
    protected void btnCerrarRecibos_Click(object sender, EventArgs e)
    {
        Datos.Value = string.Empty;
        Combo.Value = string.Empty;
        Adicionar.Value = string.Empty;
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        ClienteControl.CargarDatos();
        CargarDatosPanel();
        LimpiarTable();
        CloseDialogCargado("dialogRecibos", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }
    protected void txtFechaInicioPaquete_TextChanged(object sender, EventArgs e)
    {
        grdHorarioIn.DataBind();
    }
}
