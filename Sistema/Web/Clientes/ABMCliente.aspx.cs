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

public partial class Clientes_ABMCliente : MyPage  
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
        lblScriptShow.Text = string.Empty;
        if (!AppSecurity.HasAccess("Adm. Clientes"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página ABMCLiente.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }
        ClienteControl.userControlClick += new UserControlDelegate(UserControlDemo_userControlClick);
        ClienteControl.ClienteId = PaqueteId.Value;
        if (!IsPostBack)
        {
            ClienteControl.SetFocus();
            Search();
        }        
    }
    void UserControlDemo_userControlClick(ControlClienteEventHandler valor)
    {
        if (valor.SDML.Equals("Insertar"))
        {
            List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(valor.ICodigo);
            SetInformation(Helper.MessageType.Info, "El cliente ha sido registrado correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            SetViewPanel(true);
            Search();
        }
        if (valor.SDML.Equals("Actualizar"))
        {
            SetInformation(Helper.MessageType.Info, "El cliente ha sido actualizado correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            SetViewPanel(true);
            Search();
        }
        if (valor.SDML.Equals("Atras"))
        {
            TextLogs.WriteInfo("Panel de busqueda de cliente VISIBLE.");
            SetViewPanel(true);
        }
    }
    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(PaqueteId.Value))
        {
            MembershipUser user = Membership.GetUser();
            SetInformation(Helper.MessageType.Info, "El cliente ha sido guardado correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
        else
        {            
            SetViewPanel(true);
            ClienteControl.SetFocus();
            Search();
            SetInformation(Helper.MessageType.Info, "El Paquete ha sido guardado correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de cliente INVISIBLE.");
        SetViewPanel(false);
        ClienteControl.BotoneAtrasCerrar();
        Limpiar();
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de cliente VISIBLE.");
        SetViewPanel(true);
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
    protected void Seach_Click(object sender, EventArgs e)
    {
        if (revBuscarNombre.IsValid & revBuscarCorreo.IsValid & revBuscarCi.IsValid)
        {
            TextLogs.WriteInfo("Filtrando resultados del listado de paquetes.");
            ClienteControl.SetFocus();
            Search();
            Page.SetFocus(txtBuscarNombre);
        }
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para la Paquete: " + e.CommandArgument);

        if (e.CommandName == "Editar")
        {
            TextLogs.WriteInfo("Recuperando datos de la Paquete seleccionado.");
            SetViewPanel(false);
            LoadData(e.CommandArgument.ToString());
            return;
        }

        else if (e.CommandName == "Eliminar")
        {
            TextLogs.WriteInfo("Entrando a eliminar el cliente seleccionado.");
            RN.Componentes.CCliente.EliminarCliente(Convert.ToInt32(e.CommandArgument.ToString()));
            PaqueteId.Value = string.Empty;
            TextLogs.WriteInfo("El cliente ha sido eliminado.");
            SetInformation(Helper.MessageType.Info, "El cliente ha sido eliminado.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
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
        ClienteControl.SetFocus();
    }
    
    private void Search()
    {
        CargarEmpresas();
        lblInfo.Text = ResultGrid.Rows.Count.ToString();
        TextLogs.WriteDebug("Resultados encontrados en el grid: " + lblInfo.Text);
    }
    public bool EliminarVisible(object id)
    {
        string sId = (DataBinder.Eval(id, "id")).ToString();
        List<RN.Entidades.ClientePaquete> lstInscripcion = RN.Componentes.CClientePaquete.TraerXCIdCliente(Convert.ToInt32(DataBinder.Eval(id, "id").ToString()));
        if (lstInscripcion.Count == 0)
            return true;
        else
            return false;
    }
    public string IsApproved(object id)
    {
        string approved = (DataBinder.Eval(id, "estado")).ToString();
        if (approved.Equals("a"))
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
        PaqueteId.Value = string.Empty;
        ClienteControl.LimpiarCampos();
        TextLogs.WriteInfo("Valores del formulario limpiados.");
    }
    private void LoadData(string userName)
    {
        TextLogs.WriteInfo("Cargando datos de la Paquete a los controles del formulario.");
        TextLogs.WriteDebug("Cargando Paquete: " + userName);
        List<RN.Entidades.Cliente> lEmpresa = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(userName));
        PaqueteId.Value = userName;
        ClienteControl.BotoneAtrasCerrar();
        ClienteControl.ClienteId = userName;
        ClienteControl.ActualizarHiden();
        ClienteControl.CargarDatos();
        TextLogs.WriteInfo("Datos de paquetes cargados al formulario correctamente.");
    }
    private void CargarEmpresas()
    {
        ResultGrid.DataBind();
    }
}
