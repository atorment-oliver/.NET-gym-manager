using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Instrumentacion;

public partial class Account_ChangePassword : MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox currentPassword = (TextBox)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("CurrentPassword");
        Page.SetFocus(currentPassword);
    }
    protected void ChangeUserPassword_ChangePasswordError(object sender, EventArgs e)
    {
        TextLogs.WriteWarning("La contraseña anterior es incorrecta.", new Exception());
        SetInformation(Helper.MessageType.Error, "La contraseña anterior es incorrecta.");
        lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
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
    protected void ChangeUserPassword_ChangedPassword(object sender, EventArgs e)
    {
        TextLogs.WriteDebug("La contraseña del usuario " + User.Identity.Name + " fue cambiada exitosamente.");
        TextLogs.WriteInfo("Contraseña fue cambiada exitosamente.");
        SetInformation(Helper.MessageType.Info, "La contraseña fue cambiada exitosamente.");
        lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
    }
}
