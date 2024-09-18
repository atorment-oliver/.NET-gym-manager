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
public partial class Account_Roles : System.Web.UI.Page
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        ResultGrid.CssClass = "ui-widget-content";
        Privilegios.CssClass = "ui-widget-content";
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
        if (Privilegios.Rows.Count > 0)
        {
            Privilegios.UseAccessibleHeader = true;
            Privilegios.HeaderRow.TableSection = TableRowSection.TableHeader;
            Privilegios.HeaderRow.CssClass = "ui-widget-header";
            Privilegios.FooterRow.TableSection = TableRowSection.TableFooter;

            if (Privilegios.TopPagerRow != null)
                Privilegios.TopPagerRow.TableSection = TableRowSection.TableHeader;

            if (Privilegios.BottomPagerRow != null)
                Privilegios.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!AppSecurity.HasAccess("Roles"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Roles.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }

        if (!IsPostBack)
        {
            SetFocus();
            Search();
        }
        lblScriptShow.Text = string.Empty;
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de Usuarios INVISIBLE.");
        SetViewPanel(false);

        Limpiar();
    }
    protected void CreateRolButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Id.Value))
        {
            if (Roles.RoleExists(Rol.Text.Trim()))
            {
                SetInformation(Helper.MessageType.Warning, "El nombre de rol ingresado ya existe. Por favor ingrese un nombre diferente.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                return;
            }

            Roles.CreateRole(Rol.Text.Trim());
        }
        else
        {
            // Elimino todos los privilegios del rol
            AppSecurity.EliminarPrivilegios(Rol.Text.Trim());
        }

        int nroPrivilegs = 0;
        string privileges = string.Empty;
        for (int i = 0; i < Privilegios.Rows.Count; i++)
        {
            GridViewRow row = Privilegios.Rows[i];
            bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

            if (isChecked)
            {
                nroPrivilegs++;
                privileges += Privilegios.Rows[i].Cells[0].Text + ",";                
            }
        }

        if (nroPrivilegs < 1)
        {
            SetInformation(Helper.MessageType.Warning, "Debe seleccionar 1 PRIVILEGIO de la lista mínimamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            return;
        }

        char[] separator = { ',' };
        string[] privilegesList = privileges.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                
        foreach (string privilegeId in privilegesList)
        {
            AppSecurity.InsertarPrivilegio(Rol.Text.Trim(), Convert.ToInt32(privilegeId));
        }

        SetViewPanel(true);
        SetFocus();
        Search();
        SetInformation(Helper.MessageType.Info, "El rol ha sido guardado correctamente.");
        lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de Usuarios VISIBLE.");
        SetViewPanel(true);
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para el rol: " + e.CommandArgument);
        if (e.CommandName == "Editar")
        {
            TextLogs.WriteInfo("Recuperando datos del rol seleccionado.");
            SetViewPanel(false);
            Id.Value = e.CommandArgument.ToString();
            LoadData(e.CommandArgument.ToString());
            Privilegios.DataBind();
            return;
        }
        else if (e.CommandName == "Eliminar")
        {
            TextLogs.WriteInfo("Ingresando a eliminar el rol.");
            if (AppSecurity.EliminarPrivilegios(e.CommandArgument.ToString()) && Roles.DeleteRole(e.CommandArgument.ToString()))
            {
                Id.Value = string.Empty;

                TextLogs.WriteInfo("El rol ha sido eliminado.");
                SetInformation(Helper.MessageType.Info, "El rol ha sido eliminado.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
            else
            {
                SetInformation(Helper.MessageType.Error, "Ocurrió un problema al eliminar el rol. Verifique con el administrador del sistema.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
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
            Page.SetFocus(Rol);
            return;
        }
        Page.SetFocus(btnNuevo);
    }
    private void Search()
    {
        ResultGrid.DataBind();
        lblInfo.Text = ResultGrid.Rows.Count.ToString();
        TextLogs.WriteDebug("Resultados encontrados en el grid: " + lblInfo.Text);
    }
    private void Limpiar()
    {
        Id.Value = string.Empty;
        Rol.Text = string.Empty;

        Rol.Enabled = true;
        Privilegios.DataBind();
        TextLogs.WriteInfo("Valores del formulario limpiados.");
    }
    private void LoadData(string rolName)
    {
        TextLogs.WriteInfo("Cargando datos del rol a los controles del formulario.");
        TextLogs.WriteDebug("Cargando rol: " + rolName);

        Rol.Text = rolName;
        Rol.Enabled = false;

        TextLogs.WriteInfo("Datos del rol cargados al formulario correctamente.");
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
    public bool IsVisible(object id)
    {
        string rolName = DataBinder.Eval(id, "RolName").ToString();
        return rolName.ToLower() != "administrator" && Roles.GetUsersInRole(rolName).Length == 0;
    }
    public bool IsAssigned(object id)
    {
        if (string.IsNullOrEmpty(Rol.Text.Trim()))
            return false;

        string privilegeName = DataBinder.Eval(id, "Nombre").ToString();
        return AppSecurity.HasAccess(privilegeName, Rol.Text);
    }
}