using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using Instrumentacion;
using VIPCENTERDataSetTableAdapters;

public partial class Reportes_rClientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!AppSecurity.HasAccess("ReporteClientesActivos"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder al reporte de Clientes");
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
        ddlPaquete.DataSource = RN.Componentes.CPaquete.TraerXCriterio("", "", "true");
        ddlPaquete.DataTextField = "nombre";
        ddlPaquete.DataValueField = "id";
        ddlPaquete.DataBind();
    }
    private void CargarGrupos()
    {
        ddlGrupo.DataSource = RN.Componentes.CGrupo.TraerXCriterioD("", "", "1");
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
        ddlDisciplina.DataSource = RN.Componentes.CServicio.TraerXCriterioD("", "", "1");
        ddlDisciplina.DataTextField = "nombre";
        ddlDisciplina.DataValueField = "id";
        ddlDisciplina.DataBind();
    }
    private void CargarReporte()
    {
        //VIPCENTERDataSetTableAdapters.Clientes_ActivosTableAdapter clientes= new Clientes_ActivosTableAdapter();
        //VIPCENTERDataSet.Clientes_ActivosDataTable datos = clientes.ClientesActivos();
        DataTable datos = RN.Componentes.CCliente.TraerXFiltro3(hdnAutoCompleteClienteId.Value, Convert.ToDateTime(txtFechaInicio.Text), DateTime.Now, ddlEmpresa.SelectedValue.ToString(), ddlGrupo.SelectedValue.ToString(), /*ddlFormaPago.SelectedValue.ToString()*/ string.Empty, ddlPaquete.SelectedValue.ToString(), ddlDisciplina.SelectedValue.ToString(), ddlPromociones.SelectedValue.ToString(), "", ddlEstadoNRI.SelectedValue.ToString(), "d");
        rvClientes.Visible = true;

        Helper.Member usuario = AppSecurity.GetUser(User.Identity.Name);

        rvClientes.LocalReport.DataSources.Clear();
        rvClientes.LocalReport.ReportPath = Server.MapPath("~/Reportes/rClientesActivos.rdlc");
        rvClientes.LocalReport.SetParameters(new ReportParameter("FechaActual", DateTime.Now.ToShortDateString(), true));
        rvClientes.LocalReport.SetParameters(new ReportParameter("UsuarioActual", usuario.FirstName + " " + usuario.LastName, true));
        //rvClientes.LocalReport.SetParameters(new Report suñParameter("FechaInicio", txtFechaInicio.Text, true));
        //rvClientes.LocalReport.SetParameters(new ReportParameter("FechaFin", txtFechaFin.Text, true));
        rvClientes.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", datos.AsDataView()));
        rvClientes.LocalReport.Refresh();
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        CargarReporte();
    }
}