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

public partial class Parametros_Caja : MyPage
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
        if (!AppSecurity.HasAccess("ConfiguracionCajas"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Configuración Caja.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }

        if (!IsPostBack)
        {
            SetFocus();
            Search();
            CargarCajeros();
        }
        lblScriptShow.Text = string.Empty;
    }
    private void CargarCajeros()
    {
        DataTable dtCajeros = AppSecurity.GetUsersList("", "", "", false, true);
        dtCajeros = Concatenar(dtCajeros);
        ddlCajero.DataSource = dtCajeros;
        ddlCajero.DataTextField = "NombreCompleto";
        ddlCajero.DataValueField = "UserId";
        ddlCajero.DataBind();
        ListItem lis = new ListItem("Todos", "");
        lis.Selected = true;
        ddlCajero.Items.Add(lis);

        DataTable dtUsuarios = AppSecurity.GetUsersList("", "", "", false, true);
        dtUsuarios = ConcatenarValidando(dtUsuarios);
        ddlCajeros.DataSource = dtUsuarios;
        ddlCajeros.DataTextField = "NombreCompleto";
        ddlCajeros.DataValueField = "UserId";
        ddlCajeros.DataBind();
    }
    public string CargarNombre(object id)
    {
        MembershipUser user = Membership.GetUser(DataBinder.Eval(id, "cajeroId"));
        DataTable dtUs = AppSecurity.GetUsersList(user.UserName,"","",false,true);
        if (dtUs != null)
            return dtUs.Rows[0]["FirstName"].ToString() + " " + dtUs.Rows[0]["LastName"].ToString();
        else
            return string.Empty;
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
    private DataTable ConcatenarValidando(DataTable data)
    {
        DataTable dtInforme = new DataTable();
        for (int i = 0; i < data.Columns.Count; i++)
        {
            dtInforme.Columns.Add(data.Columns[i].ColumnName, typeof(String));
        }
        dtInforme.Columns.Add("NombreCompleto");
        for (int i = 0; i < data.Rows.Count; i++)
        {
            if (RN.Componentes.CCaja.TraerXCriterio("", data.Rows[i]["UserId"].ToString(), "").Count == 0 && data.Rows[i]["UserName"].ToString().ToLower() != "admin")
                dtInforme.Rows.Add(data.Rows[i][0].ToString(), data.Rows[i][1].ToString(), data.Rows[i][2].ToString(), data.Rows[i][3].ToString(), data.Rows[i][4].ToString(), data.Rows[i][5].ToString(), data.Rows[i][6].ToString(), data.Rows[i][7].ToString(), data.Rows[i][8].ToString(), data.Rows[i][9].ToString(), string.Format("{0} {1}", data.Rows[i]["FirstName"].ToString(), data.Rows[i]["LastName"].ToString()));
        }
        return dtInforme;
    }
    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        RN.Entidades.Caja objCaja = new RN.Entidades.Caja();
        if (string.IsNullOrEmpty(CajaId.Value))
        {
            try
            {
                MembershipUser user = Membership.GetUser();
                TextLogs.WriteDebug("Insertando caja: " + txtnumero.Text);
                TextLogs.WriteInfo("Entrando a crear nueva caja.");
                objCaja.CajeroId = ddlCajeros.SelectedValue.ToString();
                objCaja.FechaCreacion = DateTime.Now;
                objCaja.Estado = cbEstado.Checked;
                objCaja.Numero = Convert.ToInt32(txtnumero.Text);
                RN.Componentes.CCaja.Insertar(objCaja);
                TextLogs.WriteInfo("Se creo una nueva caja.");
                SetFocus();
                SetViewPanel(true);
                Search();
                TextLogs.WriteInfo("El caja ha sido guardada correctamente.");
                SetInformation(Helper.MessageType.Info, "El caja ha sido guardada correctamente.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
            catch (System.Data.SqlClient.SqlException err)
            {
                MensajesError(err);
            }
            catch (Exception err)
            {
                TextLogs.WriteError("No se pudo guardar la caja", err);
                SetInformation(Helper.MessageType.Error, "Error no clasificado");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
        }
        else
        {
            try
            {
                TextLogs.WriteDebug("Actualizando caja: " + CajaId.Value);
                TextLogs.WriteInfo("Entrando a actualizar caja.");
                MembershipUser user = Membership.GetUser();
                objCaja.Id = Convert.ToInt32(CajaId.Value);
                objCaja.CajeroId = ddlCajeros.SelectedValue.ToString();
                objCaja.FechaCreacion = DateTime.Now;
                objCaja.Estado = cbEstado.Checked;
                objCaja.Numero = Convert.ToInt32(txtnumero.Text);
                RN.Componentes.CCaja.Actualizar(objCaja);
                TextLogs.WriteInfo("caja Actualizada.");
                SetFocus();
                SetViewPanel(true);
                Search();
                SetInformation(Helper.MessageType.Info, "El caja se ha guardado correctamente.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
            catch (System.Data.SqlClient.SqlException err)
            {
                MensajesError(err);
            }
            catch (Exception err)
            {
                TextLogs.WriteError("No se pudo guardar la caja", err);
                SetInformation(Helper.MessageType.Error, "Error no clasificado");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
        }
    }
    private void MensajesError(System.Data.SqlClient.SqlException eVariable)
    {
        string sError = "No se pudo guardar la caja";
        string sTipo = string.Empty;
        switch (eVariable.Number.ToString())
        {
            case "08001":
                sTipo = "Error de conexion con la base de datos";
                break;
            case "2627":
                sTipo = "El número de caja ya se encuentra ingresado.";
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
        cbEstado.Checked = true;
        TextLogs.WriteInfo("Panel de busqueda de caja INVISIBLE.");
        SetViewPanel(false);

        Limpiar();
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de caja VISIBLE.");
        SetViewPanel(true);
    }
    private void MensajesErrorEliminar(System.Data.SqlClient.SqlException eVariable)
    {
        string sError = "No se pudo eliminar la caja";
        string sTipo = string.Empty;
        switch (eVariable.Number.ToString())
        {
            case "08001":
                sTipo = "Error de conexion con la base de datos";
                break;
            case "547":
                sTipo = "No se puede eliminar la caja debido a que el cajero ha realizado operaciones. Proceda a \"Inactivar\" al cajero.";
                break;
            default:
                sTipo = "Error no clasificado";
                break;
        }
        TextLogs.WriteError(sError, eVariable);
        SetInformation(Helper.MessageType.Error, sTipo);
        lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
    }
    protected void Seach_Click(object sender, EventArgs e)
    {
        if (revBuscarNumero.IsValid)
        {
            TextLogs.WriteInfo("Filtrando resultados del listado de caja.");
            SetFocus();
            Search();
        }
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para el caja: " + e.CommandArgument);

        if (e.CommandName == "Editar")
        {
            TextLogs.WriteInfo("Recuperando datos del caja seleccionado.");
            SetViewPanel(false);
            LoadData(e.CommandArgument.ToString());
            return;
        }

        else if (e.CommandName == "Eliminar")
        {
            try
            {
                TextLogs.WriteInfo("Entrando a eliminar el caja seleccionado.");
                RN.Componentes.CCaja.EliminarCaja(Convert.ToInt32(e.CommandArgument.ToString()));
                TextLogs.WriteInfo("El caja ha sido eliminada.");
                SetInformation(Helper.MessageType.Info, "El caja ha sido eliminada.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
            catch (System.Data.SqlClient.SqlException err)
            {
                MensajesErrorEliminar(err);
            }
            catch (Exception err)
            {
                TextLogs.WriteError("No se pudo eliminar la caja.", err);
                SetInformation(Helper.MessageType.Error, "Error no clasificado");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
        }

        Search();
    }
    protected void ResultGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TextLogs.WriteInfo("Cambiando índice de página.");
        TextLogs.WriteDebug("nueva índice: " + e.NewPageIndex);
        ResultGrid.PageIndex = e.NewPageIndex;
        Search();
    }

    private void SetViewPanel(bool status)
    {
        pnlNueva.Visible = !status;
        pnlVer.Visible = status;
        SetFocus();
    }
    private void SetFocus()
    {
        if (pnlNueva.Visible)
        {
            Page.SetFocus(txtnumero);
            return;
        }
        Page.SetFocus(txtBuscarNumero);
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
        CajaId.Value = string.Empty;
        txtnumero.Text = Convert.ToString(RN.Componentes.CCaja.TraerUltimoId() + 1);
        CajaNumero.Value = string.Empty;
        cbEstado.Checked = true;
        CargarCajeros();
        TextLogs.WriteInfo("Valores del formulario limpiados.");
    }
    private void LoadData(string userName)
    {
        TextLogs.WriteInfo("Cargando datos del caja a los controles del formulario.");
        TextLogs.WriteDebug("Cargando caja: " + userName);
        List<RN.Entidades.Caja> lEmpresa = RN.Componentes.CCaja.TraerXId(Convert.ToInt32(userName));
        CajaId.Value = userName;

        AdicionarUsuario(lEmpresa[0].CajeroId.ToString());
        ddlCajeros.SelectedValue = lEmpresa[0].CajeroId.ToString();
        txtnumero.Text = lEmpresa[0].Numero.ToString();
        CajaNumero.Value = lEmpresa[0].Numero.ToString();
        cbEstado.Checked = Convert.ToBoolean(lEmpresa[0].Estado.ToString().ToLower());        
        TextLogs.WriteInfo("Datos del caja cargados al formulario correctamente.");
    }
    private void AdicionarUsuario(string id)
    {
        MembershipUser user = Membership.GetUser(System.Guid.Parse(id));
        DataTable dtUs = AppSecurity.GetUsersList(user.UserName,"","",false,true);
        ListItem lis;
        if (dtUs != null)
        {
            ddlCajeros.Items.Clear();
            lis = new ListItem(dtUs.Rows[0]["FirstName"].ToString() + " " + dtUs.Rows[0]["LastName"].ToString(), id);
            ddlCajeros.Items.Add(lis);
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
}
