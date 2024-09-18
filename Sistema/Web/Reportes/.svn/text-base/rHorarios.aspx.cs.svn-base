using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using Instrumentacion;

public partial class Reportes_rHorarios : System.Web.UI.Page
{
    DataTable dtHorario;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!AppSecurity.HasAccess("rHorarios"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder al reporte de Horarios");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }

        if (!IsPostBack)
        {
            CargarReporte();
        }
       
    }
    private void CargarReporte()
    {
        dtHorario = RN.Componentes.CHorario.TraerReporte();
        rvHorario.Visible = true;
        rvHorario.LocalReport.DataSources.Clear();
        rvHorario.LocalReport.ReportPath = Server.MapPath("~/Reportes/rHorario.rdlc");
        rvHorario.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dtHorario));
        rvHorario.LocalReport.Refresh();
    }    
}