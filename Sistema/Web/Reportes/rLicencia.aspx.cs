using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using Instrumentacion;
using System.Web.Security;

public partial class Reportes_rLicencia : System.Web.UI.Page
{
    DataTable dtLicencia;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!AppSecurity.HasAccess("rLicencias"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder al reporte de Licencias");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }

        //if (!IsPostBack)
        //{
        //    CargarReporte();
        //}

    }
    private void CargarReporte()
    {
        string sCliente = "TODOS";
        MembershipUser user = Membership.GetUser();
        if (ClientePaqueteId.Value == "")
        {
            ClientePaqueteId.Value = "0";
        }
        else
        {
            List<RN.Entidades.ClientePaquete> lstPa = RN.Componentes.CClientePaquete.TraerXId(Convert.ToInt32(ClientePaqueteId.Value));
            if (lstPa.Count != 0)
            {
                List<RN.Entidades.Cliente> lstClie  = RN.Componentes.CCliente.TraerXId(lstPa[0].ClienteId);
                if (lstClie.Count != 0)
                {
                    sCliente = lstClie[0].Nombre + " " + lstClie[0].Apellidos;
                }
            }
            
        }
        dtLicencia = RN.Componentes.CLicencia.TraerXCriterioD(txtBuscarNombre.Text, Convert.ToInt32(ClientePaqueteId.Value), txtBuscarFechaInicio.Text, txtBuscarFechaFinal.Text, "1");
        rvHorario.Visible = true;
        rvHorario.LocalReport.DataSources.Clear();
        rvHorario.LocalReport.ReportPath = Server.MapPath("~/Reportes/rLicencia.rdlc");
        if (txtBuscarFechaInicio.Text == "")
            txtBuscarFechaInicio.Text = "01/01/1900";
        if (txtBuscarFechaFinal.Text == "")
            txtBuscarFechaFinal.Text = DateTime.Now.ToShortDateString();
        rvHorario.LocalReport.SetParameters(new ReportParameter("FechaInicio", txtBuscarFechaInicio.Text, true));
        rvHorario.LocalReport.SetParameters(new ReportParameter("FechaFin", txtBuscarFechaFinal.Text, true));
        rvHorario.LocalReport.SetParameters(new ReportParameter("Usuario", user.UserName, true));
        rvHorario.LocalReport.SetParameters(new ReportParameter("Cliente", sCliente, true));
        rvHorario.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dtLicencia));
        rvHorario.LocalReport.Refresh();
    }
    protected void Seach_Click(object sender, EventArgs e)
    {
        CargarReporte();
    }
}