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

public partial class Account_Users : MyPage
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
        if (!AppSecurity.HasAccess("Usuarios"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Users.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }

        if (!IsPostBack)
        {
            SetFocus();
            Search();
            LoadRoles();
        }
        lblScriptShow.Text = string.Empty;
    }
    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        MembershipCreateStatus status = MembershipCreateStatus.Success;
        MembershipUser user = null;
 
        if (string.IsNullOrEmpty(UserId.Value))
        {
            TextLogs.WriteDebug("Insertando usuario: " + UserName.Text + " " + Email.Text + " " + Aprobado.Checked);
            TextLogs.WriteInfo("Entrando a crear nuevo usuario."); 
            user = Membership.CreateUser(UserName.Text.Trim(), Password.Text.Trim(), Email.Text.Trim(), "Lugar de trabajo?", "VIPCENTER", Aprobado.Checked, out status);
            TextLogs.WriteInfo("Se creo un nuevo usuario.");
        }
        else
        {
            TextLogs.WriteDebug("Actualizando usuario: " + UserName.Text);
            TextLogs.WriteInfo("Entrando a actualizar usuario."); 
            Guid guidUser = new Guid(UserId.Value);
            user = Membership.GetUser(guidUser);
            user.Email = Email.Text.Trim();
            Membership.UpdateUser(user);
            TextLogs.WriteInfo("Usuario actualizado.");
            TextLogs.WriteDebug("Nuevo correo: " + user.Email);
        }

        if (user != null)
        {
            TextLogs.WriteInfo("Entrando a guardar el PROFILE del usuario."); 
            ProfileCommon profile = Profile.GetProfile(user.UserName);
            profile.FirstName = FirstName.Text.Trim();
            profile.LastName = LastName.Text.Trim();
            profile.Deleted = false;
            profile.Save();
            TextLogs.WriteInfo("Profile guardado.");
            TextLogs.WriteDebug("Nombre: " + profile.FirstName);
            TextLogs.WriteDebug("Apellido: " + profile.LastName);

            AppSecurity.SetRol(user.UserName, Rol.SelectedValue);
            TextLogs.WriteDebug("Usuario establecido en el rol: " + Rol.SelectedValue);

        }

        TextLogs.WriteDebug("El resultado de la operación fue: " + status.ToString());
        switch (status)
        {
            case MembershipCreateStatus.DuplicateEmail:
                break;
            case MembershipCreateStatus.DuplicateProviderUserKey:
                break;
            case MembershipCreateStatus.DuplicateUserName:
                TextLogs.WriteWarning("El nombre de usuario ingresado ya existe.", new Exception()); 
                SetInformation(Helper.MessageType.Warning, "El nombre de usuario ingresado ya existe, por favor ingrese un nombre de usuario diferente.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                break;
            case MembershipCreateStatus.InvalidEmail:
                TextLogs.WriteWarning("El correo electrónico ingresado es inválido.", new Exception()); 
                SetInformation(Helper.MessageType.Warning, "El correo electrónico ingresado es inválido, por favor ingrese un correo diferente.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                break;
            case MembershipCreateStatus.InvalidPassword:
                TextLogs.WriteWarning("La constraseña ingresada es inválida.", new Exception()); 
                SetInformation(Helper.MessageType.Warning, "La constraseña ingresada es inválida, por favor ingrese una contraseña diferente.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                break;
            case MembershipCreateStatus.InvalidUserName:
                TextLogs.WriteWarning("El nombre de usuario ingresado es inválido.", new Exception()); 
                SetInformation(Helper.MessageType.Warning, "El nombre de usuario ingresado es inválido, por favor ingrese un nombre de usuario diferente.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                break;
            case MembershipCreateStatus.Success:
                SetViewPanel(true);
                SetFocus();
                Search();
                TextLogs.WriteInfo("El usuario ha sido guardado correctamente."); 
                SetInformation(Helper.MessageType.Info, "El usuario ha sido guardado correctamente.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                break;
        }
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Estableciendo la fecha de creación del usuario.");
        FechaCreacion.Text = DateTime.Now.ToShortDateString();
        
        TextLogs.WriteInfo("Panel de busqueda de Usuarios INVISIBLE.");
        SetViewPanel(false);

        Limpiar();
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de Usuarios VISIBLE.");
        SetViewPanel(true);
    }
    protected void Seach_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Filtrando resultados del listado de usuarios.");
        SetFocus();
        Search();
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para el usuario: " + e.CommandArgument);
        if (e.CommandName == "Approved")
        {
            TextLogs.WriteInfo("Ingresando a aprobar o denegar al usuario.");
            Helper.Member member = AppSecurity.GetUser(e.CommandArgument.ToString());
            AppSecurity.ApproveUser(member.UserName, !member.IsApproved);

            TextLogs.WriteInfo("Operación realizada exitosamente.");
            SetInformation(Helper.MessageType.Info, "Operación realizada exitosamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
        else if (e.CommandName == "Locked")
        {
            TextLogs.WriteInfo("Ingresando a desbloquear el acceso al usuario.");
            AppSecurity.UnlockUser(e.CommandArgument.ToString());

            TextLogs.WriteInfo("El usuario ha sido desbloqueado.");
            SetInformation(Helper.MessageType.Info, "El usuario ha sido desbloqueado.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
        else if (e.CommandName == "Editar")
        {
            TextLogs.WriteInfo("Recuperando datos del usuario seleccionado.");
            SetViewPanel(false);
            LoadData(e.CommandArgument.ToString());
            return;
        }
        else if (e.CommandName == "Password")
        {
            TextLogs.WriteInfo("Ingresando a modificar contraseña del usuario.");
            AppSecurity.ChangePassword(e.CommandArgument.ToString(), Request.Form["__EVENTARGUMENT"]);
            TextLogs.WriteInfo("La contraseña ha sido modificada.");
            SetInformation(Helper.MessageType.Info, "La contraseña ha sido modificada.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
        else if (e.CommandName == "Eliminar")
        {
            TextLogs.WriteInfo("Verificando que el usuario no sea un cajero.");
            Helper.Member usuario = AppSecurity.GetUser(e.CommandArgument.ToString());
            List<RN.Entidades.Caja> caja = RN.Componentes.CCaja.TraerXCriterio(string.Empty, usuario.UserId.ToString(), string.Empty);
            if (caja != null && caja.Count > 0)
            {
                TextLogs.WriteInfo("El usuario no puede ser eliminado debido a que es cajero.");
                SetInformation(Helper.MessageType.Warning, "El usuario no ha sido eliminado, debido a que es un cajero.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                return;
            }


            TextLogs.WriteInfo("Entrando a eliminar al usuario seleccionado.");
            AppSecurity.EliminarUsuario(e.CommandArgument.ToString());
            TextLogs.WriteInfo("El usuario ha sido eliminado.");
            SetInformation(Helper.MessageType.Info, "El usuario ha sido eliminado.");
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
        SetFocus();
    }
    private void SetFocus()
    {
        if (pnlNuevo.Visible)
        {
            Page.SetFocus(UserName);
            return;
        }
        Page.SetFocus(FirstNameSearch);
    }
    private void Search()
    {
        ResultGrid.DataBind();
        lblInfo.Text = ResultGrid.Rows.Count.ToString();
        TextLogs.WriteDebug("Resultados encontrados en el grid: " + lblInfo.Text);
    }
    public string IsApproved(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "isApproved"));
        if (approved)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
    public string IsLockedOut(object id)
    {
        bool locked = Convert.ToBoolean(DataBinder.Eval(id, "isLockedOut"));
        if (locked)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
    public bool IsVisible(object id)
    {
        return DataBinder.Eval(id, "UserName").ToString() != "admin";
    }
    private void Limpiar()
    {
        UserId.Value = string.Empty;
        FirstName.Text = string.Empty;
        LastName.Text = string.Empty;
        UserName.Text = string.Empty;
        Password.Text = string.Empty;
        PasswordCompare.Text = string.Empty;
        Email.Text = string.Empty;
        FechaCreacion.Text = DateTime.Now.ToShortDateString();
        UltimaActividad.Text = "-";
        UltimoIngreso.Text = "-";
        Aprobado.Checked = false;

        UserName.Enabled = true;
        passwordTR.Visible = true;
        passwordConfirmTR.Visible = true;
        TextLogs.WriteInfo("Valores del formulario limpiados.");
    }
    private void LoadData(string userName)
    {
        TextLogs.WriteInfo("Cargando datos del usuario a los controles del formulario.");
        TextLogs.WriteDebug("Cargando usuario: " + userName);
        MembershipUser user = Membership.GetUser(userName);
        ProfileCommon profile = Profile.GetProfile(user.UserName);

        UserId.Value = user.ProviderUserKey.ToString();
        FirstName.Text = profile.FirstName;
        LastName.Text = profile.LastName;
        UserName.Text = user.UserName;
        Email.Text = user.Email;
        FechaCreacion.Text = user.CreationDate.ToShortDateString();
        UltimaActividad.Text = user.LastActivityDate.ToShortDateString();
        UltimoIngreso.Text = user.LastLoginDate.ToShortDateString();
        Aprobado.Checked = user.IsApproved;
        string[] roles = Roles.GetRolesForUser(user.UserName);
        Rol.SelectedValue = roles[0];

        UserName.Enabled = false;
        passwordTR.Visible = false;
        passwordConfirmTR.Visible = false;
        TextLogs.WriteInfo("Datos del usuario cargados al formulario correctamente.");
    }
    private void LoadRoles()
    {
        String[] roles = Roles.GetAllRoles();
        Rol.DataSource = roles;
        Rol.DataBind();
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
 }
