using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Account_Login : MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        SetFocus();
    }
    protected void LoginUser_LoginError(object sender, EventArgs e)
    {
        Login l = (Login)sender;
        if (Membership.GetUser(l.UserName) == null)
        SetInformation(Helper.MessageType.Warning, GetLocalResourceObject("FailedUser").ToString());
        if (!AppSecurity.IsApproved(l.UserName))
            SetInformation(Helper.MessageType.Warning, GetLocalResourceObject("FailedUser").ToString());
        else if (AppSecurity.IsLocked(l.UserName))
            SetInformation(Helper.MessageType.Error, GetLocalResourceObject("UserLocked").ToString());
        else if (!Membership.ValidateUser(l.UserName, l.Password))
            SetInformation(Helper.MessageType.Warning, GetLocalResourceObject("FailedPassword").ToString());
        else
            SetInformation(Helper.MessageType.Warning, GetLocalResourceObject("Failed").ToString());

        lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open');  }); </script>";
        SetFocus();
        
    }
    public void SetFocus()
    {
        TextBox txt = (TextBox)LoginUser.FindControl("UserName");
        Page.SetFocus(txt);
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
