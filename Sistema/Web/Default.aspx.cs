using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RN;

public partial class _Default : MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {           
        Helper.Member user = AppSecurity.GetUser(HttpContext.Current.User.Identity.Name);
        if (user == null)
            Response.Redirect("./Account/Login.aspx");

        List<RN.Entidades.Caja> caja = RN.Componentes.CCaja.TraerXCriterio(string.Empty, user.UserId.ToString(), "true");
        if (caja != null && caja.Count > 0)
        {
            List<RN.Entidades.MovimientoCaja> movimiento = RN.Componentes.CMovimientoCaja.EstaAbierto(caja[0].Id.ToString());
            if (movimiento == null || movimiento.Count == 0)
                Response.Redirect("./Caja/Caja.aspx");
            else
            {
                if (AppSecurity.HasAccess("Clientes"))
                    Response.Redirect("./Clientes/Clientes.aspx");
                else
                    Mensaje("El cajero no tiene configurado el acceso al formulario de Administración de los clientes del gimnasio");
            }
        }
    }
    private void Mensaje(string mensaje)
    {
        string script = string.Format(@"$.msgBox('" + mensaje + "');");
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
}
