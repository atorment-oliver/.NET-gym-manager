using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class Clientes_Impresion : System.Web.UI.Page
{
    string ClientePaqueteId;
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientePaqueteId = Request.QueryString["param"];
        if (!IsPostBack)
        {
            CargarReporte();
        }
    }
    private void CargarReporte()
    {
        DataTable dtLicencia;
        string sCliente = "TODOS";
        MembershipUser user = Membership.GetUser();
        if (ClientePaqueteId == "")
        {
            ClientePaqueteId = "0";
        }
        dtLicencia = RN.Componentes.CLicencia.TraerXIdImp(Convert.ToInt32(ClientePaqueteId));
        rvLicencias.Visible = true;
        rvLicencias.LocalReport.DataSources.Clear();
        rvLicencias.LocalReport.ReportPath = Server.MapPath("~/Reportes/rImpresionLicencia.rdlc");
        rvLicencias.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dtLicencia));
        rvLicencias.LocalReport.Refresh();
    }
    protected void Seach_Click(object sender, EventArgs e)
    {
        CargarReporte();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        CargarReporte();
    }
}