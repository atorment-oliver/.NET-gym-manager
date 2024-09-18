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

public partial class Clientes_Empresas : MyPage
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
        if (!AppSecurity.HasAccess("Empresas"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Empresas.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }

        if (!IsPostBack)
        {
            SetFocus();
            Search();
        }
        lblScriptShow.Text = string.Empty;
    }
    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        TextBox txtCosto;
        List<RN.Entidades.EmpresaPaquete> lstEmpresa = new List<RN.Entidades.EmpresaPaquete>();
        RN.Entidades.EmpresaD objEmpresa = new RN.Entidades.EmpresaD();
        if (string.IsNullOrEmpty(EmpresaId.Value))
        {
            try
            {
                MembershipUser user = Membership.GetUser();
                TextLogs.WriteDebug("Insertando empresa: " + txtNombre.Text + " " + txtCorreo.Text + " " + ddlEstado.SelectedValue.ToString());
                TextLogs.WriteInfo("Entrando a crear nueva empresa.");
                objEmpresa.Nombre = txtNombre.Text;
                objEmpresa.Descripcion = txtDescripcion.Text;
                objEmpresa.NombrePersonaContacto = txtPersonaContacto.Text;
                objEmpresa.Telefono = txtTelefono.Text;
                objEmpresa.Correo = txtCorreo.Text;
                objEmpresa.Direccion = txtDireccion.Text;
                objEmpresa.FechaRegistro = DateTime.Now;
                objEmpresa.Estado = cbEstado.Checked;
                objEmpresa.UsuarioId = user.ProviderUserKey.ToString();
                objEmpresa.Fecha = DateTime.Now;
                
                foreach (GridViewRow row2 in grdPaquetes.Rows)
                {
                    RN.Entidades.EmpresaPaquete objEmpresaPaquete = new RN.Entidades.EmpresaPaquete();
                    objEmpresaPaquete.EmpresaId = Convert.ToInt32(0);
                    objEmpresaPaquete.PaqueteId = Convert.ToInt32(grdPaquetes.DataKeys[row2.RowIndex].Value.ToString()); ;
                    txtCosto = (TextBox)row2.FindControl("txtPrecioPaquete");
                    objEmpresaPaquete.Costo = Convert.ToDecimal(txtCosto.Text);
                    lstEmpresa.Add(objEmpresaPaquete);
                }
                objEmpresa.Detalle = lstEmpresa;
                RN.Workflows.WEmpresa.Insertar(objEmpresa);
                TextLogs.WriteInfo("Se creo una nueva empresa.");
                SetViewPanel(true);
                SetFocus();
                Search();
                TextLogs.WriteInfo("La empresa ha sido guardado correctamente.");
                SetInformation(Helper.MessageType.Info, "La empresa ha sido guardado correctamente.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
            catch (System.Data.SqlClient.SqlException err)
            {
                MensajesError(err);
            }
            catch (Exception err)
            {
                TextLogs.WriteError("No se pudo guardar la empresa", err);
                SetInformation(Helper.MessageType.Error, "Error no clasificado");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
        }
        else
        {
            try
            {
                TextLogs.WriteDebug("Actualizando empresa: " + EmpresaId.Value);
                TextLogs.WriteInfo("Entrando a actualizar emrpesa.");
                MembershipUser user = Membership.GetUser();
                objEmpresa.Id = Convert.ToInt32(EmpresaId.Value);
                objEmpresa.Nombre = txtNombre.Text;
                objEmpresa.Descripcion = txtDescripcion.Text;
                objEmpresa.NombrePersonaContacto = txtPersonaContacto.Text;
                objEmpresa.Telefono = txtTelefono.Text;
                objEmpresa.Correo = txtCorreo.Text;
                objEmpresa.Direccion = txtDireccion.Text;
                objEmpresa.FechaRegistro = DateTime.Now;
                objEmpresa.Estado = cbEstado.Checked;
                objEmpresa.UsuarioId = user.ProviderUserKey.ToString();
                objEmpresa.Fecha = DateTime.Now;
                foreach (GridViewRow row2 in grdPaquetes.Rows)
                {
                    RN.Entidades.EmpresaPaquete objEmpresaPaquete = new RN.Entidades.EmpresaPaquete();
                    objEmpresaPaquete.EmpresaId = Convert.ToInt32(EmpresaId.Value);
                    objEmpresaPaquete.PaqueteId = Convert.ToInt32(grdPaquetes.DataKeys[row2.RowIndex].Value.ToString()); ;
                    txtCosto = (TextBox)row2.FindControl("txtPrecioPaquete");
                    objEmpresaPaquete.Costo = Convert.ToDecimal(txtCosto.Text);
                    lstEmpresa.Add(objEmpresaPaquete);
                }
                objEmpresa.Detalle = lstEmpresa;

                RN.Workflows.WEmpresa.Actualizar(objEmpresa);
                TextLogs.WriteInfo("Empresa actualizada.");
                SetViewPanel(true);
                SetFocus();
                Search();
                SetInformation(Helper.MessageType.Info, "La empresa ha sido guardado correctamente.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
            catch (System.Data.SqlClient.SqlException err)
            {
                MensajesError(err);
            }
            catch (Exception err)
            {
                TextLogs.WriteError("No se pudo guardar la empresa", err);
                SetInformation(Helper.MessageType.Error, "Error no clasificado");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
        }

    }
    private void MensajesError(System.Data.SqlClient.SqlException eVariable)
    {
        string sError = "No se pudo guardar la empresa";
        string sTipo = string.Empty;
        switch(eVariable.Number.ToString())
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
        TextLogs.WriteInfo("Estableciendo la fecha de creación de la empresa.");
        txtFechaCreacion.Text = DateTime.Now.ToShortDateString();
        cbEstado.Checked = true;
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
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para la empresa: " + e.CommandArgument);

        if (e.CommandName == "Editar")
        {
            TextLogs.WriteInfo("Recuperando datos de la empresa seleccionado.");
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
            Page.SetFocus(txtNombre);
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
        txtNombre.Text = string.Empty;
        txtDescripcion.Text = string.Empty;
        txtPersonaContacto.Text = string.Empty;
        txtTelefono.Text = string.Empty;
        txtCorreo.Text = string.Empty;
        txtDireccion.Text = string.Empty;
        txtFechaCreacion.Text = DateTime.Now.ToShortDateString();

        passwordTR.Visible = true;
        passwordConfirmTR.Visible = true;
        TextLogs.WriteInfo("Valores del formulario limpiados.");
    }
    private void LoadData(string userName)
    {
        TextLogs.WriteInfo("Cargando datos de la empresa a los controles del formulario.");
        TextLogs.WriteDebug("Cargando empresa: " + userName);
        List<RN.Entidades.Empresa> lEmpresa = RN.Componentes.CEmpresa.TraerXId(Convert.ToInt32(userName));
        EmpresaId.Value = userName;
        txtNombre.Text = lEmpresa[0].Nombre;
        txtDescripcion.Text = lEmpresa[0].Descripcion;
        txtPersonaContacto.Text = lEmpresa[0].NombrePersonaContacto;
        txtTelefono.Text = lEmpresa[0].Telefono;
        txtCorreo.Text = lEmpresa[0].Correo;
        txtDireccion.Text = lEmpresa[0].Direccion;
        txtFechaCreacion.Text = lEmpresa[0].FechaRegistro.ToString();
        cbEstado.Checked = Convert.ToBoolean(lEmpresa[0].Estado.ToString());
        TextLogs.WriteInfo("Datos del usuario cargados al formulario correctamente.");
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
    protected void grdPaquetes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdPaquetes.DataBind();
    }
}
