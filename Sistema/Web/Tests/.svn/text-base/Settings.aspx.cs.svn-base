using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Tests_Settings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            ConfigureActiveDirectory();
    }
    private void ConfigureActiveDirectory()
    {
        lblDominio.Text = ConfigurationManager.AppSettings["LDAP_DomainName"];
        lblUsuarioLogin.Text = HttpContext.Current.User.Identity.Name;
        lblUsuarioWindows.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        lblUsuarioIntento.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace(ConfigurationManager.AppSettings["LDAP_DomainName"], string.Empty);
    }
}