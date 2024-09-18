using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using Instrumentacion;

public partial class Reportes_rPagoGeneral : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!AppSecurity.HasAccess("ReportePagos"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder al reporte de Pagos");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }
        if (!IsPostBack)
        {
            txtFechaInicio.Text = DateTime.Now.ToShortDateString();
            txtFechaFin.Text = DateTime.Now.AddDays(1).ToShortDateString();
            CargarEmpresa();
            CargarPaquetes();
            CargarGrupos();
            CargarDisciplinas();
            CargarPromociones();
        }
    }
    private void CargarEmpresa()
    {
        ddlEmpresa.DataSource = RN.Componentes.CEmpresa.Traer();
        ddlEmpresa.DataTextField = "nombre";
        ddlEmpresa.DataValueField = "id";
        ddlEmpresa.DataBind();

    }
    private void CargarPaquetes()
    {
        ddlPaquete.DataSource = RN.Componentes.CPaquete.TraerXCriterio("","","true");
        ddlPaquete.DataTextField = "nombre";
        ddlPaquete.DataValueField = "id";
        ddlPaquete.DataBind();
    }
    private void CargarGrupos()
    {
        ddlGrupo.DataSource = RN.Componentes.CGrupo.TraerXCriterioD("","","1");
        ddlGrupo.DataTextField = "nombreServicioHorario";
        ddlGrupo.DataValueField = "id";
        ddlGrupo.DataBind();
    }
    private void CargarPromociones()
    {
        ddlPromociones.DataSource = RN.Componentes.CPromocion.TraerHabiles();
        ddlPromociones.DataTextField = "nombre";
        ddlPromociones.DataValueField = "id";
        ddlPromociones.DataBind();
    }
    private void CargarDisciplinas()
    {
        ddlDisciplina.DataSource = RN.Componentes.CServicio.TraerXCriterioD("","","1");
        ddlDisciplina.DataTextField = "nombre";
        ddlDisciplina.DataValueField = "id";
        ddlDisciplina.DataBind();
    }
    private void CargarReporte()
    {
        DataTable datos = RN.Componentes.CPagoCliente.TraerXFiltro(hdnAutoCompleteClienteId.Value, Convert.ToDateTime(txtFechaInicio.Text), Convert.ToDateTime(txtFechaFin.Text), ddlEmpresa.SelectedValue.ToString(), ddlGrupo.SelectedValue.ToString(), ddlFormaPago.SelectedValue.ToString(), ddlPaquete.SelectedValue.ToString(), ddlDisciplina.SelectedValue.ToString(), ddlPromociones.SelectedValue.ToString());
        rvPagos.Visible = true;

        rvPagos.LocalReport.DataSources.Clear();
        rvPagos.LocalReport.ReportPath = Server.MapPath("~/Reportes/rPagos.rdlc");
        rvPagos.LocalReport.SetParameters(new ReportParameter("FechaInicio", txtFechaInicio.Text, true));
        rvPagos.LocalReport.SetParameters(new ReportParameter("FechaFin", txtFechaFin.Text, true));
        rvPagos.LocalReport.DataSources.Add(new ReportDataSource("Pagos", datos));
        rvPagos.LocalReport.Refresh();
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (txtSearchCI.Text == "")
            hdnAutoCompleteClienteId.Value = string.Empty;
        CargarReporte();
    }
}