using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Web.Security;
using Instrumentacion;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            GetSiteMap();
        else
        {
            Page.Validate();
        }
    }
    private void GetSiteMap()
    {
        TextLogs.WriteInfo("Recuperando nodos del SiteMap");
        EvalNodes(SiteMap.RootNode.ChildNodes);
        TextLogs.WriteInfo("El menú del sitio fue cargado con los nodos del SiteMap permitidos para el rol de este usuario.");
    }
    private void EvalNodes(SiteMapNodeCollection nodes)
    {
        TextLogs.WriteInfo("Recuperando los roles del usuario actualmente logeado.");
        string[] roles = System.Web.Security.Roles.GetRolesForUser();
        string rol = string.Empty;
        // Solo se considera que un usuario puede tener 1 rol
        if (roles.Length > 0)
        {
            rol = roles[0];
            TextLogs.WriteDebug("El usuario tiene el Rol: " + rol);
        }

        foreach (SiteMapNode node in nodes)
        {
            if (node.HasChildNodes)
            {
                MenuItem item = new MenuItem(node.Title, string.Empty, string.Empty, node.Url);
                item.Selectable = false;
                NavigationMenu.Items.Add(item);
                if (!EvalNodes(node.ChildNodes, item, rol))
                {
                    NavigationMenu.Items.Remove(item);
                }
            }
            else
            {
                if (LoadMenu(node.Description, rol))
                    NavigationMenu.Items.Add(new MenuItem(node.Title, string.Empty, string.Empty, node.Url));
            }
        }
    }
    private bool EvalNodes(SiteMapNodeCollection nodes, MenuItem menuItem, string rol)
    {
        bool load = false;
        foreach (SiteMapNode node in nodes)
        {
            if (node.HasChildNodes)
            {
                MenuItem item = new MenuItem(node.Title, string.Empty, string.Empty, node.Url);
                item.Selectable = false;
                NavigationMenu.Items.Add(item);
                if (!EvalNodes(node.ChildNodes, item, rol))
                    NavigationMenu.Items.Remove(item);
                else
                    load = true;
            }
            else
            {
                if (LoadMenu(node.Description, rol))
                {                    
                    menuItem.ChildItems.Add(new MenuItem(node.Title, string.Empty, string.Empty, node.Url));
                    load = true;
                }
            }
        }
        return load;
    }

    private bool LoadMenu(string menuOption, string rol)
    {
        bool hasAccess = false;
        hasAccess = AppSecurity.HasAccess(menuOption, rol);
        if (hasAccess)
        {
            TextLogs.WriteDebug("El privilegio " + menuOption + " está autorizado para el rol " + rol);
            return true;
        }
        TextLogs.WriteDebug("El privilegio " + menuOption + " NO está autorizado para el rol " + rol);
        return false;
    }
}
