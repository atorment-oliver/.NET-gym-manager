<%@ Application Language="C#" %>
<%@ Import Namespace="Instrumentacion" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Configuro mi herramienta de LOGEO cuando se prende la aplicación por primera vez.
        TextLogs.Configure();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        // Recupero el último error de la aplicación y registro el mismo en los LOGS como un ERROR.
        // La configuración de "customErrors" del Web.Config redirigirá al usuario a una página de error. 
        Exception ex = Server.GetLastError();
        TextLogs.WriteError("Error: ", ex);
    }

    void Session_Start(object sender, EventArgs e) 
    {
        this.Session.Add("strIdioma", "ES-es");
        TextLogs.WriteDebug("Registrando el idioma por defecto de la aplicación: " + Session["strIdioma"].ToString());
        
        // Valido que la base de datos y la versión del sistema cuadren para permitir el acceso.
        if (!AppSettings.isCorrectVersion)
        {
            string message = string.Format("Versión aplicación: {0} - Versión base de datos: {1} ", AppSettings.GetSystemVersion, AppSettings.GetDBVersion);
            TextLogs.WriteWarning("La versión de la aplicación y la base de datos no coinciden.", new Exception(message));
            Response.Redirect(Config.GetPath("Errores/Version.aspx"));
            return;
        }
        
        TextLogs.WriteDebug("La forma de inicio de sesión está configurada como automática?: " + AppSettings.IsLoginAutomatic);
        if (!AppSettings.IsLoginAutomatic)
        {
            return;
        }
        
        // Si el usuario actual es anonimo, lo autentico.
        if (HttpContext.Current.User == null || HttpContext.Current.User.Identity.Name == string.Empty || !HttpContext.Current.User.Identity.IsAuthenticated)
        {            
            TextLogs.WriteInfo("El usuario es anónimo, preparando para autenticarlo.");
            Authenticate();
        }                   
    }
         
    void Session_End(object sender, EventArgs e) 
    {
    }
    private void Authenticate()
    {
        // Obtengo el usuario identificado en el sistema operativo.
        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace(ConfigurationManager.AppSettings["LDAP_DomainName"], string.Empty);
        TextLogs.WriteDebug("Se recupero el usuario logeado al sistema operativo: " + userName);
        
        // Si el usuario no existe en la base de datos, no hago ninguna acción.
        if (!AppSecurity.UserExists(userName))
        {
            TextLogs.WriteInfo("El usuario no existe en la base de datos.");
            return;
        }
        TextLogs.WriteInfo("El usuario existe en la base de datos.");

        // Busco los roles del usuario recabado
        string[] roles = System.Web.Security.Roles.GetRolesForUser(userName);
        TextLogs.WriteDebug("El usuario cuenta con " + roles.Length + " roles");

        FormsAuthentication.Initialize();
        Response.Cookies.Add(this.SetAutorizacion(true, userName, roles));
        TextLogs.WriteDebug("Redireccionando al usuario a la ruta: " + Request.Url.AbsolutePath);
        this.Response.Redirect(Request.Url.AbsolutePath);
    }
    private HttpCookie SetAutorizacion(bool cookieRemember, string userName, string[] roles)
    {
        string rolesList = string.Empty;
        foreach (string rol in roles)
        {
            rolesList += rol + ",";
        }
        TextLogs.WriteDebug("Los roles asignados al usuario son: " + rolesList);

        try
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddMinutes(300), cookieRemember, rolesList, FormsAuthentication.FormsCookiePath);
            string strHash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, strHash);
            
            TextLogs.WriteInfo("Cookie creada.");
            
            if (ticket.IsPersistent)
                cookie.Expires = ticket.Expiration;
            return cookie;
        }
        catch (Exception e)
        {
            throw (e);
        }
    }
    void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        if (HttpContext.Current.User != null)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.User.Identity is FormsIdentity)
                {
                    FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                    FormsAuthenticationTicket ticket = id.Ticket;
                    string userData = ticket.UserData;
                    string[] roles = userData.Split(',');
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, roles);
                    TextLogs.WriteInfo("Usuario autenticado.");
                }
            }
        }
    }
       
</script>
