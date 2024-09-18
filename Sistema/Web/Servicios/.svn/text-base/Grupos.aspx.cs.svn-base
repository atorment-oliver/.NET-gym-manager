using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Instrumentacion;
using System.Web.Profile;
using System.Data;

public partial class Servicios_Grupo : MyPage
{
    private bool bVacio = false;
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        ResultGrid.CssClass = "ui-widget-content";
        grdHorarioHor.CssClass = "ui-widget-content";
        grdHorario.CssClass = "ui-widget-content";
        if (ResultGrid.Rows.Count > 0)
        {
            ResultGrid.UseAccessibleHeader = true;
            ResultGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
            ResultGrid.HeaderRow.CssClass = "ui-widget-header";
            ResultGrid.FooterRow.TableSection = TableRowSection.TableFooter;

            if (ResultGrid.TopPagerRow != null)
                ResultGrid.TopPagerRow.TableSection = TableRowSection.TableHeader;

            if (ResultGrid.BottomPagerRow != null)
                ResultGrid.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        if (grdHorarioHor.Rows.Count > 0)
        {
            grdHorarioHor.UseAccessibleHeader = true;
            grdHorarioHor.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdHorarioHor.HeaderRow.CssClass = "ui-widget-header";
            grdHorarioHor.FooterRow.TableSection = TableRowSection.TableFooter;

            if (grdHorarioHor.TopPagerRow != null)
                grdHorarioHor.TopPagerRow.TableSection = TableRowSection.TableHeader;

            if (grdHorarioHor.BottomPagerRow != null)
                grdHorarioHor.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        if (grdHorario.Rows.Count > 0)
        {
            grdHorario.UseAccessibleHeader = true;
            grdHorario.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdHorario.HeaderRow.CssClass = "ui-widget-header";
            grdHorario.FooterRow.TableSection = TableRowSection.TableFooter;

            if (grdHorario.TopPagerRow != null)
                grdHorario.TopPagerRow.TableSection = TableRowSection.TableHeader;

            if (grdHorario.BottomPagerRow != null)
                grdHorario.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!AppSecurity.HasAccess("Servicios"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Grupos.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }

        if (!IsPostBack)
        {
            CargarSalas();
            CargarServicios();
            CargarBusquedaServicio();
            SetFocus();
            Search();            
        }
        lblScriptShow.Text = string.Empty;
    }
    private void CargarSalas()
    {
        ddlSala.DataSource = RN.Componentes.CSala.TraerXEstado("true");
        ddlSala.DataTextField = "nombre";
        ddlSala.DataValueField = "id";
        ddlSala.DataBind();
    }
    private void CargarServicios()
    {
        ddlServicio.DataSource = RN.Componentes.CServicio.TraerXCriterio(string.Empty, string.Empty, "1");
        ddlServicio.DataTextField = "nombre";
        ddlServicio.DataValueField = "id";
        ddlServicio.DataBind();
    }
    private void DeshabilitarFilas(bool bMarcado, int fila)
    {
        if (bMarcado)
        {
            foreach (GridViewRow row in grdHorario.Rows)
            {
                if (row.RowIndex != fila)
                {
                    CheckBox chkSelec;
                    chkSelec = (CheckBox)row.FindControl("cbLunes");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbMartes");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbMiercoles");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbJueves");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbViernes");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbSabado");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbDomingo");
                    chkSelec.Enabled = false;
                }
            }
        }
        else
        {
            bool FindeSemana = true;
            foreach (GridViewRow row in grdHorario.Rows)
            {
                CheckBox chkSelec;
                chkSelec = (CheckBox)row.FindControl("cbSabado");
                if (chkSelec.ToolTip.ToString().Equals("True"))
                {
                    chkSelec.Enabled = true;
                    FindeSemana = false;
                }
                else
                    FindeSemana = true;
                chkSelec = (CheckBox)row.FindControl("cbDomingo");
                if (chkSelec.ToolTip.ToString().Equals("True"))
                    chkSelec.Enabled = true;
                chkSelec = (CheckBox)row.FindControl("cbLunes");
                chkSelec.Enabled = FindeSemana;
                chkSelec = (CheckBox)row.FindControl("cbMartes");
                chkSelec.Enabled = FindeSemana;
                chkSelec = (CheckBox)row.FindControl("cbMiercoles");
                chkSelec.Enabled = FindeSemana;
                chkSelec = (CheckBox)row.FindControl("cbJueves");
                chkSelec.Enabled = FindeSemana;
                chkSelec = (CheckBox)row.FindControl("cbViernes");
                chkSelec.Enabled = FindeSemana;
                chkSelec = (CheckBox)row.FindControl("cbSabado");
                chkSelec.Enabled = FindeSemana;
                chkSelec = (CheckBox)row.FindControl("cbDomingo");
                chkSelec.Enabled = FindeSemana;
            }
        }
    }
    private void DeshabilitarFilas2(bool bMarcado, int fila)
    {
        if (bMarcado)
        {
            foreach (GridViewRow row in grdHorarioHor.Rows)
            {
                if (row.RowIndex != fila)
                {
                    CheckBox chkSelec;
                    chkSelec = (CheckBox)row.FindControl("cbLunes");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbMartes");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbMiercoles");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbJueves");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbViernes");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbSabado");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbDomingo");
                    chkSelec.Enabled = false;
                }
            }
        }
        else
        {
            bool FindeSemana = true;
            foreach (GridViewRow row in grdHorarioHor.Rows)
            {
                CheckBox chkSelec;
                chkSelec = (CheckBox)row.FindControl("cbSabado");
                if (chkSelec.ToolTip.ToString().Equals("True"))
                {
                    chkSelec.Enabled = true;
                    FindeSemana = false;
                }
                else
                    FindeSemana = true;
                chkSelec = (CheckBox)row.FindControl("cbDomingo");
                if (chkSelec.ToolTip.ToString().Equals("True"))
                    chkSelec.Enabled = true;
                chkSelec = (CheckBox)row.FindControl("cbLunes");
                chkSelec.Enabled = FindeSemana;
                chkSelec = (CheckBox)row.FindControl("cbMartes");
                chkSelec.Enabled = FindeSemana;
                chkSelec = (CheckBox)row.FindControl("cbMiercoles");
                chkSelec.Enabled = FindeSemana;
                chkSelec = (CheckBox)row.FindControl("cbJueves");
                chkSelec.Enabled = FindeSemana;
                chkSelec = (CheckBox)row.FindControl("cbViernes");
                chkSelec.Enabled = FindeSemana;
                chkSelec = (CheckBox)row.FindControl("cbSabado");
                chkSelec.Enabled = FindeSemana;
                chkSelec = (CheckBox)row.FindControl("cbDomingo");
                chkSelec.Enabled = FindeSemana;
            }
        }
    }
    private void DeshabilitarFilas()
    {
        List <RN.Entidades.GrupoDia> lstGDia = RN.Componentes.CGrupoDia.TraerXGrupoId(Convert.ToInt32(GrupoId.Value));
        int iCheckeo = 0;
        if (lstGDia.Count != 0)
        {
            //ddlSala.Enabled = false;
            bool finDeSemana = true;
            foreach (GridViewRow row in grdHorarioHor.Rows)
            {
                CheckBox chkSelec;
                CheckBox chkLunes;
                CheckBox chkMartes;
                CheckBox chkMiercoles;
                CheckBox chkJueves;
                CheckBox chkViernes;
                CheckBox chkSabado;
                CheckBox chkDomingo;
                chkSelec = (CheckBox)row.FindControl("cbSeleccion");
                chkLunes = (CheckBox)row.FindControl("cbLunes");
                chkMartes = (CheckBox)row.FindControl("cbMartes");
                chkMiercoles = (CheckBox)row.FindControl("cbMiercoles");
                chkJueves = (CheckBox)row.FindControl("cbJueves");
                chkViernes = (CheckBox)row.FindControl("cbViernes");
                chkSabado = (CheckBox)row.FindControl("cbSabado");
                chkDomingo = (CheckBox)row.FindControl("cbDomingo");
                if (chkLunes.Checked || chkMartes.Checked || chkMiercoles.Checked || chkJueves.Checked || chkViernes.Checked || chkSabado.Checked || chkDomingo.Checked)
                {
                    chkSelec = (CheckBox)row.FindControl("cbSeleccion");
                    chkSelec.Checked = true;
                    chkSelec = (CheckBox)row.FindControl("cbSabado");
                    if (chkSelec.ToolTip.ToString().Equals("True"))
                    {
                        chkSelec.Enabled = true;
                        finDeSemana = false;
                    }
                    else
                    {
                        chkSelec.Enabled = false;
                        finDeSemana = true;
                    }
                    chkSelec = (CheckBox)row.FindControl("cbDomingo");
                    if (chkSelec.ToolTip.ToString().Equals("True"))
                        chkSelec.Enabled = true;
                    else
                        chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbLunes");
                    chkSelec.Enabled = finDeSemana;
                    chkSelec = (CheckBox)row.FindControl("cbMartes");
                    chkSelec.Enabled = finDeSemana;
                    chkSelec = (CheckBox)row.FindControl("cbMiercoles");
                    chkSelec.Enabled = finDeSemana;
                    chkSelec = (CheckBox)row.FindControl("cbJueves");
                    chkSelec.Enabled = finDeSemana;
                    chkSelec = (CheckBox)row.FindControl("cbViernes");
                    chkSelec.Enabled = finDeSemana;
                    chkSelec = (CheckBox)row.FindControl("cbSabado");
                    chkSelec.Enabled = finDeSemana;
                    chkSelec = (CheckBox)row.FindControl("cbDomingo");
                    chkSelec.Enabled = finDeSemana;
                    iCheckeo++;
                }
                else
                {
                    chkSelec = (CheckBox)row.FindControl("cbSeleccion");
                    chkSelec.Checked = false;
                    chkSelec = (CheckBox)row.FindControl("cbLunes");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbMartes");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbMiercoles");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbJueves");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbViernes");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbSabado");
                    chkSelec.Enabled = false;
                    chkSelec = (CheckBox)row.FindControl("cbDomingo");
                    chkSelec.Enabled = false;
                }
            }
        }
        else
        {
            bool finDeSemana = true;
            foreach (GridViewRow row in grdHorarioHor.Rows)
            {
                CheckBox chkSelec;
                chkSelec = (CheckBox)row.FindControl("cbSabado");
                if (chkSelec.ToolTip.ToString().Equals("True"))
                {
                    chkSelec.Enabled = true;
                    finDeSemana = false;
                }
                else
                {
                    chkSelec.Enabled = false;
                    finDeSemana = true;
                }
                chkSelec = (CheckBox)row.FindControl("cbDomingo");
                if (chkSelec.ToolTip.ToString().Equals("True"))
                    chkSelec.Enabled = true;
                else
                    chkSelec.Enabled = false;
                chkSelec = (CheckBox)row.FindControl("cbLunes");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbMartes");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbMiercoles");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbJueves");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbViernes");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbSabado");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbDomingo");
                chkSelec.Enabled = finDeSemana;
            }
        }
        if (iCheckeo == 0)
        {
            bool finDeSemana = true;
            foreach (GridViewRow row in grdHorarioHor.Rows)
            {
                CheckBox chkSelec;
                chkSelec = (CheckBox)row.FindControl("cbSabado");
                if (chkSelec.ToolTip.ToString().Equals("True"))
                {
                    chkSelec.Enabled = true;
                    finDeSemana = false;
                }
                else
                {
                    chkSelec.Enabled = false;
                    finDeSemana = true;
                }
                chkSelec = (CheckBox)row.FindControl("cbDomingo");
                if (chkSelec.ToolTip.ToString().Equals("True"))
                    chkSelec.Enabled = true;
                else
                    chkSelec.Enabled = false;
                chkSelec = (CheckBox)row.FindControl("cbLunes");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbMartes");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbMiercoles");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbJueves");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbViernes");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbSabado");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbDomingo");
                chkSelec.Enabled = finDeSemana;
            }
        }
        
    }
    private void DeshabilitarFilasRegistro()
    {
        int iCheckeo = 0;
        bool finDeSemana = true;
        foreach (GridViewRow row in grdHorario.Rows)
        {
            CheckBox chkSelec;
            CheckBox chkLunes;
            CheckBox chkMartes;
            CheckBox chkMiercoles;
            CheckBox chkJueves;
            CheckBox chkViernes;
            CheckBox chkSabado;
            CheckBox chkDomingo;
            chkSelec = (CheckBox)row.FindControl("cbSeleccion");
            chkLunes = (CheckBox)row.FindControl("cbLunes");
            chkMartes = (CheckBox)row.FindControl("cbMartes");
            chkMiercoles = (CheckBox)row.FindControl("cbMiercoles");
            chkJueves = (CheckBox)row.FindControl("cbJueves");
            chkViernes = (CheckBox)row.FindControl("cbViernes");
            chkSabado = (CheckBox)row.FindControl("cbSabado");
            chkDomingo = (CheckBox)row.FindControl("cbDomingo");
            if (chkLunes.Checked || chkMartes.Checked || chkMiercoles.Checked || chkJueves.Checked || chkViernes.Checked || chkSabado.Checked || chkDomingo.Checked)
            {
                chkSelec = (CheckBox)row.FindControl("cbSeleccion");
                chkSelec.Checked = true;
                chkSelec = (CheckBox)row.FindControl("cbSabado");
                if (chkSelec.ToolTip.ToString().Equals("True"))
                {
                    chkSelec.Enabled = true;
                    finDeSemana = false;
                }
                else
                {
                    chkSelec.Enabled = false;
                    finDeSemana = true;
                }
                chkSelec = (CheckBox)row.FindControl("cbDomingo");
                if (chkSelec.ToolTip.ToString().Equals("True"))
                    chkSelec.Enabled = true;
                else
                    chkSelec.Enabled = false;
                chkSelec = (CheckBox)row.FindControl("cbLunes");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbMartes");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbMiercoles");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbJueves");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbViernes");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbSabado");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbDomingo");
                chkSelec.Enabled = finDeSemana;
                iCheckeo++;
            }
            else
            {
                chkSelec = (CheckBox)row.FindControl("cbSeleccion");
                chkSelec.Checked = false;
                chkSelec = (CheckBox)row.FindControl("cbLunes");
                chkSelec.Enabled = false;
                chkSelec = (CheckBox)row.FindControl("cbMartes");
                chkSelec.Enabled = false;
                chkSelec = (CheckBox)row.FindControl("cbMiercoles");
                chkSelec.Enabled = false;
                chkSelec = (CheckBox)row.FindControl("cbJueves");
                chkSelec.Enabled = false;
                chkSelec = (CheckBox)row.FindControl("cbViernes");
                chkSelec.Enabled = false;
                chkSelec = (CheckBox)row.FindControl("cbSabado");
                chkSelec.Enabled = false;
                chkSelec = (CheckBox)row.FindControl("cbDomingo");
                chkSelec.Enabled = false;
            }
        }
        if (iCheckeo == 0)
        {
            finDeSemana = true;
            foreach (GridViewRow row in grdHorario.Rows)
            {
                CheckBox chkSelec;
                chkSelec = (CheckBox)row.FindControl("cbSabado");
                if (chkSelec.ToolTip.ToString().Equals("True"))
                {
                    chkSelec.Enabled = true;
                    finDeSemana = false;
                }
                else
                {
                    chkSelec.Enabled = false;
                    finDeSemana = true;
                }
                chkSelec = (CheckBox)row.FindControl("cbDomingo");
                if (chkSelec.ToolTip.ToString().Equals("True"))
                    chkSelec.Enabled = true;
                else
                    chkSelec.Enabled = false;
                chkSelec = (CheckBox)row.FindControl("cbLunes");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbMartes");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbMiercoles");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbJueves");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbViernes");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbSabado");
                chkSelec.Enabled = finDeSemana;
                chkSelec = (CheckBox)row.FindControl("cbDomingo");
                chkSelec.Enabled = finDeSemana;
            }

        }
    }
    private bool VerificarCheck(bool bMarcado, GridViewRow row)
    {
        CheckBox chkSelec;
        CheckBox chkLunes;
        CheckBox chkMartes;
        CheckBox chkMiercoles;
        CheckBox chkJueves;
        CheckBox chkViernes;
        CheckBox chkSabado;
        CheckBox chkDomingo;
        chkSelec = (CheckBox)row.FindControl("cbSeleccion");
        chkLunes = (CheckBox)row.FindControl("cbLunes");
        chkMartes = (CheckBox)row.FindControl("cbMartes");
        chkMiercoles = (CheckBox)row.FindControl("cbMiercoles");
        chkJueves = (CheckBox)row.FindControl("cbJueves");
        chkViernes = (CheckBox)row.FindControl("cbViernes");
        chkSabado = (CheckBox)row.FindControl("cbSabado");
        chkDomingo = (CheckBox)row.FindControl("cbDomingo");
        if (chkLunes.Checked || chkMartes.Checked || chkMiercoles.Checked || chkJueves.Checked || chkViernes.Checked || chkSabado.Checked || chkDomingo.Checked)
            bMarcado = true;
        if (!chkLunes.Checked & !chkMartes.Checked & !chkMiercoles.Checked & !chkJueves.Checked & !chkViernes.Checked & !chkSabado.Checked & !chkDomingo.Checked)
            bMarcado = false;
        if (bMarcado)
        {
            chkSelec.Checked = true;
        }
        if (!bMarcado)
        {
            chkSelec.Checked = false;
        }
        return bMarcado;
    }
    public enum Dias
    {
        Lunes = 1,
        Martes = 2,
        Miercoles = 3,
        Jueves = 4,
        Viernes = 5,
        Sabado = 6,
        Domingo = 7

    }
    public bool EliminarVisible(object id)
    {
        string sId = (DataBinder.Eval(id, "id")).ToString();
        List<RN.Entidades.Inscripcion> lstInscripcion = RN.Componentes.CInscripcion.TraerXGrupoId(Convert.ToInt32(DataBinder.Eval(id, "id").ToString()));
        if (lstInscripcion.Count == 0)
            return true;
        else
            return false;
    }
    public bool EstaHabilitadoDomingo(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "finDeSemana"));
        if (approved)
        {
            if (!Convert.ToBoolean(DataBinder.Eval(id, "Domingo")))
                return true;
            else
                return false;
        }
        else
            return false;
    }
    public bool lblVisibleLunes(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Lunes"));
        string [] sGrupo = (DataBinder.Eval(id, "IdLunes")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return false;
        }
        if (approved)
        {
            if (!Convert.ToBoolean(DataBinder.Eval(id, "Lunes")))
                return true;
            else
                return false;
        }
        else
            return false;
    }
    public bool lblVisibleMartes(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Martes"));
        string[] sGrupo = (DataBinder.Eval(id, "IdMartes")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return false;
        }
        if (approved)
        {
            if (!Convert.ToBoolean(DataBinder.Eval(id, "Martes")))
                return true;
            else
                return false;
        }
        else
            return false;
    }
    public bool lblVisibleMiercoles(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Miercoles"));
        string[] sGrupo = (DataBinder.Eval(id, "IdMiercoles")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return false;
        }
        if (approved)
        {
            if (!Convert.ToBoolean(DataBinder.Eval(id, "Miercoles")))
                return true;
            else
                return false;
        }
        else
            return false;
    }
    public bool lblVisibleJueves(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Jueves"));
        string[] sGrupo = (DataBinder.Eval(id, "IdJueves")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return false;
        }
        if (approved)
        {
            if (!Convert.ToBoolean(DataBinder.Eval(id, "Jueves")))
                return true;
            else
                return false;
        }
        else
            return false;
    }
    public bool lblVisibleViernes(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Viernes"));
        string[] sGrupo = (DataBinder.Eval(id, "IdViernes")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return false;
        }
        if (approved)
        {
            if (!Convert.ToBoolean(DataBinder.Eval(id, "Viernes")))
                return true;
            else
                return false;
        }
        else
            return false;
    }
    public bool lblVisibleSabado(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Sabado"));
        string[] sGrupo = (DataBinder.Eval(id, "IdSabado")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return false;
        }
        if (approved)
        {
            if (!Convert.ToBoolean(DataBinder.Eval(id, "Sabado")))
                return true;
            else
                return false;
        }
        else
            return false;
    }
    public bool lblVisibleDomingo(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Domingo"));
        string[] sGrupo = (DataBinder.Eval(id, "IdDomingo")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return false;
        }
        if (approved)
        {
            if (!Convert.ToBoolean(DataBinder.Eval(id, "Domingo")))
                return true;
            else
                return false;
        }
        else
            return false;
    }
    public bool lblVisibleLunes1(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Lunes"));
        string[] sGrupo = (DataBinder.Eval(id, "IdLunes")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return false;
            else
                return true;
        }
        else
        {
            if (approved)
            {
                if (!Convert.ToBoolean(DataBinder.Eval(id, "Lunes")))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
    public bool lblVisibleLunes2(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Lunes"));
        string[] sGrupo = (DataBinder.Eval(id, "IdLunes")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return true;
            else
                return false;
        }
        else
        {
            if (approved)
            {
                if (!Convert.ToBoolean(DataBinder.Eval(id, "Lunes")))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
    public bool lblVisibleMartes2(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Martes"));
        string[] sGrupo = (DataBinder.Eval(id, "IdMartes")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return true;
            else
                return false;
        }
        else
        {
            if (approved)
            {
                if (!Convert.ToBoolean(DataBinder.Eval(id, "Martes")))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
    public bool lblVisibleMiercoles2(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Miercoles"));
        string[] sGrupo = (DataBinder.Eval(id, "IdMiercoles")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return true;
            else
                return false;
        }
        else
        {
            if (approved)
            {
                if (!Convert.ToBoolean(DataBinder.Eval(id, "Miercoles")))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
    public bool lblVisibleJueves2(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Jueves"));
        string[] sGrupo = (DataBinder.Eval(id, "IdJueves")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return true;
            else
                return false;
        }
        else
        {
            if (approved)
            {
                if (!Convert.ToBoolean(DataBinder.Eval(id, "Jueves")))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
    public bool lblVisibleViernes2(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Viernes"));
        string[] sGrupo = (DataBinder.Eval(id, "IdViernes")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return true;
            else
                return false;
        }
        else
        {
            if (approved)
            {
                if (!Convert.ToBoolean(DataBinder.Eval(id, "Viernes")))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
    public bool lblVisibleSabado2(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Sabado"));
        string[] sGrupo = (DataBinder.Eval(id, "IdSabado")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return true;
            else
                return false;
        }
        else
        {
            if (approved)
            {
                if (!Convert.ToBoolean(DataBinder.Eval(id, "Sabado")))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
    public bool lblVisibleDomingo2(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Domingo"));
        string[] sGrupo = (DataBinder.Eval(id, "IdDomingo")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return true;
            else
                return false;
        }
        else
        {
            if (approved)
            {
                if (!Convert.ToBoolean(DataBinder.Eval(id, "Domingo")))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
    public bool lblVisibleMartes1(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Martes"));
        string[] sGrupo = (DataBinder.Eval(id, "IdMartes")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return false;
            else
                return true;
        }
        else
        {
            if (approved)
            {
                if (!Convert.ToBoolean(DataBinder.Eval(id, "Martes")))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
    public bool lblVisibleMiercoles1(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Miercoles"));
        string[] sGrupo = (DataBinder.Eval(id, "IdMiercoles")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return false;
            else
                return true;
        }
        else
        {
            if (approved)
            {
                if (!Convert.ToBoolean(DataBinder.Eval(id, "Miercoles")))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
    public bool lblVisibleJueves1(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Jueves"));
        string[] sGrupo = (DataBinder.Eval(id, "IdJueves")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return false;
            else
                return true;
        }
        else
        {
            if (approved)
            {
                if (!Convert.ToBoolean(DataBinder.Eval(id, "Jueves")))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
    public bool lblVisibleViernes1(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Viernes"));
        string[] sGrupo = (DataBinder.Eval(id, "IdViernes")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return false;
            else
                return true;
        }
        else
        {
            if (approved)
            {
                if (!Convert.ToBoolean(DataBinder.Eval(id, "Viernes")))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
    public bool lblVisibleSabado1(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Sabado"));
        string[] sGrupo = (DataBinder.Eval(id, "IdSabado")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return false;
            else
                return true;
        }
        else
        {
            if (approved)
            {
                if (!Convert.ToBoolean(DataBinder.Eval(id, "Sabado")))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
    public bool lblVisibleDomingo1(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "Domingo"));
        string[] sGrupo = (DataBinder.Eval(id, "IdDomingo")).ToString().Split('=');
        if (sGrupo.Count() == 2)
        {
            if (sGrupo[1].Equals(GrupoId.Value))
                return false;
            else
                return true;
        }
        else
        {
            if (approved)
            {
                if (!Convert.ToBoolean(DataBinder.Eval(id, "Domingo")))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
    private void CargarBusquedaServicio()
    {
        ddlBuscarServicio.DataSource = RN.Componentes.CServicio.TraerXCriterioD("", "", "1");
        ddlBuscarServicio.DataTextField = "nombre";
        ddlBuscarServicio.DataValueField = "id";
        ddlBuscarServicio.DataBind();
        ListItem ls = new ListItem("Todos", "");
        ls.Selected = true;
        ddlBuscarServicio.Items.Add(ls);
    }
    private void MensajesError(System.Data.SqlClient.SqlException eVariable)
    {
        string sError = "No se pudo guardar la grupo";
        string sTipo = string.Empty;
        switch (eVariable.Number.ToString())
        {
            case "08001":
                sTipo = "Error de conexion con la base de datos";
                break;
            case "2627":
                sTipo = "Restriccion de nombre repetido";
                break;
            default:
                sTipo = "Error no clasificado";
                break;
        }
        TextLogs.WriteError(sError, eVariable);
        SetInformation(Helper.MessageType.Error, sTipo);
        lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
    }
    
    private void SetViewPanel(bool status)
    {
        pnlNuevo.Visible = !status;
        pnlVer.Visible = status;
        SetFocus();
    }
    private void SetFocus()
    {
        if (pnlNuevo.Visible)
        {
            Page.SetFocus(txtServicio);
            return;
        }
        ResultGrid.DataBind();
        Page.SetFocus(txtBuscarNombre);
    }
    private void Search()
    {
        CargarGrupos();
        lblInfo.Text = ResultGrid.Rows.Count.ToString();
        TextLogs.WriteDebug("Resultados encontrados en el grid: " + lblInfo.Text);
    }
    public string IsApproved(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "estado"));
        if (approved)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
    public string FinSemana(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "finDeSemana"));
        if (!approved)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
    public string IsLockedOut(object id)
    {
        bool locked = Convert.ToBoolean(DataBinder.Eval(id, "estado"));
        if (locked)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
    public bool PerteneceAGrupo(object id, string dia)
    {
        bool retorno = false;
        List <RN.Entidades.GrupoDia> objgDia;
        switch (dia)
        {
            case "Lunes":
                objgDia = RN.Componentes.CGrupoDia.TraerXGrupoIdDiaId(Convert.ToInt32(GrupoId.Value), Convert.ToInt32(Dias.Lunes),  Convert.ToInt32(DataBinder.Eval(id, "id")));
                if (objgDia.Count != 0)
                    retorno = true;
                else
                    retorno = false;
                break;
            case "Martes":
                objgDia = RN.Componentes.CGrupoDia.TraerXGrupoIdDiaId(Convert.ToInt32(GrupoId.Value), Convert.ToInt32(Dias.Martes), Convert.ToInt32(DataBinder.Eval(id, "id")));
                if (objgDia.Count != 0)
                    retorno = true;
                else
                    retorno = false;
                break;
            case "Miercoles":
                objgDia = RN.Componentes.CGrupoDia.TraerXGrupoIdDiaId(Convert.ToInt32(GrupoId.Value), Convert.ToInt32(Dias.Miercoles), Convert.ToInt32(DataBinder.Eval(id, "id")));
                if (objgDia.Count != 0)
                    retorno = true;
                else
                    retorno = false;
                break;
            case "Jueves":
                objgDia = RN.Componentes.CGrupoDia.TraerXGrupoIdDiaId(Convert.ToInt32(GrupoId.Value), Convert.ToInt32(Dias.Jueves), Convert.ToInt32(DataBinder.Eval(id, "id")));
                if (objgDia.Count != 0)
                    retorno = true;
                else
                    retorno = false;
                break;
            case "Viernes":
                objgDia = RN.Componentes.CGrupoDia.TraerXGrupoIdDiaId(Convert.ToInt32(GrupoId.Value), Convert.ToInt32(Dias.Viernes), Convert.ToInt32(DataBinder.Eval(id, "id")));
                if (objgDia.Count != 0)
                    retorno = true;
                else
                    retorno = false;
                break;
            case "Sabado":
                objgDia = RN.Componentes.CGrupoDia.TraerXGrupoIdDiaId(Convert.ToInt32(GrupoId.Value), Convert.ToInt32(Dias.Sabado), Convert.ToInt32(DataBinder.Eval(id, "id")));
                if (objgDia.Count != 0)
                    retorno = true;
                else
                    retorno = false;
                break;
            case "Domingo":
                objgDia = RN.Componentes.CGrupoDia.TraerXGrupoIdDiaId(Convert.ToInt32(GrupoId.Value), Convert.ToInt32(Dias.Domingo), Convert.ToInt32(DataBinder.Eval(id, "id")));
                if (objgDia.Count != 0)
                    retorno = true;
                else
                    retorno = false;
                break;
            default:
                retorno = false;
                break;
        }
        return retorno;
    }
    private void Limpiar()
    {
        GrupoId.Value = string.Empty;
        ServicioId.Value = string.Empty;
        txtNombre.Text = string.Empty;
        txtServicio.Text = string.Empty;
        txtCupo.Text = string.Empty;
        ddlSala.Enabled = true;
        passwordConfirmTR.Visible = true;
        DeshabilitarFilasRegistro();
        this.ddlServicio_SelectedIndexChanged(this, new EventArgs());
        TextLogs.WriteInfo("Valores del formulario limpiados.");
    }
    private void LoadData(string userName)
    {
        TextLogs.WriteInfo("Cargando datos de la grupo a los controles del formulario.");
        TextLogs.WriteDebug("Cargando grupo: " + userName);
        List<RN.Entidades.Grupo> lGrupo = RN.Componentes.CGrupo.TraerXId(Convert.ToInt32(userName));
        List<RN.Entidades.Servicio> lServ = RN.Componentes.CServicio.TraerXId(lGrupo[0].ServicioId);
        RN.Entidades.Horario lHora = RN.Componentes.CHorario.TraerXId(lGrupo[0].HorarioId);
        GrupoId.Value = userName;
        txtNombre.Text = lGrupo[0].Nombre;
        ServicioId.Value = lGrupo[0].ServicioId.ToString();
        txtServicio.Text = lServ[0].Nombre;
        if (lServ[0].Cupo == 0)
            txtCupo.Text = "";
        else
            txtCupo.Text = lServ[0].Cupo.ToString();
        ddlSala.SelectedValue = lHora.SalaId.ToString();
        grdHorario.Visible = false;
        grdHorarioHor.Visible = true;
        grdHorarioHor.DataBind();
        DeshabilitarFilas();
        cbEstado.Checked = Convert.ToBoolean(lGrupo[0].Estado.ToString());
        TextLogs.WriteInfo("Datos del usuario cargados al formulario correctamente.");
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
    private void CargarGrupos()
    {
        ResultGrid.DataBind();
        grdHorario.DataBind();
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Estableciendo la fecha de creación de la grupo.");
        cbEstado.Checked = true;
        TextLogs.WriteInfo("Panel de busqueda de Grupos INVISIBLE.");
        grdHorario.Visible = true;
        grdHorarioHor.Visible = false;
        SetViewPanel(false);
        Limpiar();        
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de Grupos VISIBLE.");
        SetViewPanel(true);
    }
    protected void Seach_Click(object sender, EventArgs e)
    {
        if (revBuscarNombre.IsValid)
        {
            TextLogs.WriteInfo("Filtrando resultados del listado de grupos.");
            SetFocus();
            Search();
        }
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para la grupo: " + e.CommandArgument);

        if (e.CommandName == "Editar")
        {
            TextLogs.WriteInfo("Recuperando datos de la grupo seleccionado.");
            SetViewPanel(false);
            LoadData(e.CommandArgument.ToString());
            return;
        }

        else if (e.CommandName == "Eliminar")
        {
            TextLogs.WriteInfo("Entrando a eliminar la grupo seleccionado.");
            GrupoId.Value = e.CommandArgument.ToString();
            RN.Componentes.CGrupo.EliminarPaquete(Convert.ToInt32(e.CommandArgument.ToString()));
            GrupoId.Value = string.Empty;

            TextLogs.WriteInfo("La grupo ha sido eliminada.");
            SetInformation(Helper.MessageType.Info, "La grupo ha sido eliminada.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }

        Search();
    }
    protected void ResultGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TextLogs.WriteInfo("Cambiando índice de página.");
        TextLogs.WriteDebug("Nuevo índice: " + e.NewPageIndex);
        ResultGrid.PageIndex = e.NewPageIndex;
        Search();
    }
    public void cbLunes_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        bool bMarcado = false;
        bMarcado = VerificarCheck(bMarcado, row);
        DeshabilitarFilas(bMarcado, row.RowIndex);
        bVacio = bMarcado;
    }
    public void cbMartes_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        bool bMarcado = false;
        bMarcado = VerificarCheck(bMarcado, row);
        DeshabilitarFilas(bMarcado, row.RowIndex);
        bVacio = bMarcado;
    }
    public void cbMiercoles_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        bool bMarcado = false;
        bMarcado = VerificarCheck(bMarcado, row);
        DeshabilitarFilas(bMarcado, row.RowIndex);
        bVacio = bMarcado;
    }
    public void cbJueves_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        bool bMarcado = false;
        bMarcado = VerificarCheck(bMarcado, row);
        DeshabilitarFilas(bMarcado, row.RowIndex);
        bVacio = bMarcado;
    }
    public void cbViernes_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        bool bMarcado = false;
        bMarcado = VerificarCheck(bMarcado, row);
        DeshabilitarFilas(bMarcado, row.RowIndex);
        bVacio = bMarcado;
    }
    public void cbSabado_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        bool bMarcado = false;
        bMarcado = VerificarCheck(bMarcado, row);
        DeshabilitarFilas(bMarcado, row.RowIndex);
        bVacio = bMarcado;
    }
    public void cbDomingo_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        bool bMarcado = false;
        bMarcado = VerificarCheck(bMarcado, row);
        DeshabilitarFilas(bMarcado, row.RowIndex);
        bVacio = bMarcado;
    }
    
    public void cbLunes_OnCheckedChanged2(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        bool bMarcado = false;
        bMarcado = VerificarCheck(bMarcado, row);
        DeshabilitarFilas2(bMarcado, row.RowIndex);
        bVacio = bMarcado;
    }
    public void cbMartes_OnCheckedChanged2(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        bool bMarcado = false;
        bMarcado = VerificarCheck(bMarcado, row);
        DeshabilitarFilas2(bMarcado, row.RowIndex);
        bVacio = bMarcado;
    }
    public void cbMiercoles_OnCheckedChanged2(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        bool bMarcado = false;
        bMarcado = VerificarCheck(bMarcado, row);
        DeshabilitarFilas2(bMarcado, row.RowIndex);
        bVacio = bMarcado;
    }
    public void cbJueves_OnCheckedChanged2(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        bool bMarcado = false;
        bMarcado = VerificarCheck(bMarcado, row);
        DeshabilitarFilas2(bMarcado, row.RowIndex);
        bVacio = bMarcado;
    }
    public void cbViernes_OnCheckedChanged2(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        bool bMarcado = false;
        bMarcado = VerificarCheck(bMarcado, row);
        DeshabilitarFilas2(bMarcado, row.RowIndex);
        bVacio = bMarcado;
    }
    public void cbSabado_OnCheckedChanged2(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        bool bMarcado = false;
        bMarcado = VerificarCheck(bMarcado, row);
        DeshabilitarFilas2(bMarcado, row.RowIndex);
        bVacio = bMarcado;
    }
    public void cbDomingo_OnCheckedChanged2(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
        bool bMarcado = false;
        bMarcado = VerificarCheck(bMarcado, row);
        DeshabilitarFilas2(bMarcado, row.RowIndex);
        bVacio = bMarcado;
    }
    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        RN.Entidades.Grupo objGrupo = new RN.Entidades.Grupo();
        List<RN.Entidades.GrupoDia> listaDias = new List<RN.Entidades.GrupoDia>();
        RN.Entidades.Servicio objServicio = new RN.Entidades.Servicio();
        if (string.IsNullOrEmpty(ServicioId.Value))
        {

            MembershipUser user = Membership.GetUser();
            TextLogs.WriteDebug("Insertando Servicio: " + txtNombre.Text);
            TextLogs.WriteInfo("Entrando a crear nuevo Servicio.");
            objServicio.Id = Convert.ToInt32(ddlServicio.SelectedValue.ToString());
            objServicio.Nombre = (ddlServicio.SelectedItem.ToString());
            objServicio.RestriccionHorario = true;
            if (txtCupo.Text == "")
                objServicio.Cupo = 0;
            else
                objServicio.Cupo = Convert.ToInt32(txtCupo.Text);
            objServicio.Estado = true;
            objServicio.UsuarioId = user.ProviderUserKey.ToString();
            objServicio.Fecha = DateTime.Now;
            //ServicioId.Value = RN.Componentes.CServicio.InsertarCodigo(objServicio).ToString();

            TextLogs.WriteInfo("Se creo una nuevo Servicio.");
            TextLogs.WriteInfo("El Servicio ha sido guardado correctamente.");
        }
        else
        {
            TextLogs.WriteDebug("Actualizando Servicio: " + ServicioId.Value);
            TextLogs.WriteInfo("Entrando a actualizar emrpesa.");
            MembershipUser user = Membership.GetUser();
            objServicio.Id = Convert.ToInt32(ddlServicio.SelectedValue.ToString());
            objServicio.Nombre = (ddlServicio.SelectedItem.ToString());
            objServicio.RestriccionHorario = true;
            if (txtCupo.Text == "")
                objServicio.Cupo = 0;
            else
                objServicio.Cupo = Convert.ToInt32(txtCupo.Text);
            objServicio.Estado = true;
            objServicio.UsuarioId = user.ProviderUserKey.ToString();
            objServicio.Fecha = DateTime.Now;
            //RN.Componentes.CServicio.Actualizar(objServicio);
            TextLogs.WriteInfo("Servicio actualizada.");
        }
        
        if (string.IsNullOrEmpty(GrupoId.Value) && string.IsNullOrEmpty(ServicioId.Value))
        {
            try
            {
                MembershipUser user = Membership.GetUser();
                TextLogs.WriteDebug("Insertando grupo: " + txtNombre.Text);
                TextLogs.WriteInfo("Entrando a crear nueva grupo.");
                CheckBox chk;
                string chkBoxIndex = string.Empty;

                int iCheckes = 0;
                foreach (GridViewRow row in grdHorario.Rows)
                {
                    CheckBox chkSelec;
                    chkSelec = (CheckBox)row.FindControl("cbSeleccion");
                    if (chkSelec.Checked)
                    {
                        iCheckes++;
                        objGrupo.Nombre = txtNombre.Text;
                        //objGrupo.ServicioId = Convert.ToInt32(ServicioId.Value);
                        objGrupo.HorarioId = Convert.ToInt32(grdHorario.DataKeys[row.RowIndex]["id"].ToString());
                        objGrupo.Estado = cbEstado.Checked;
                        objGrupo.UsuarioId = user.ProviderUserKey.ToString();
                        objGrupo.Fecha = DateTime.Now;
                        chkBoxIndex = (string)grdHorario.DataKeys[row.RowIndex].Value.ToString();
                        chk = (CheckBox)row.FindControl("cbLunes");

                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Lunes);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbMartes");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Martes);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbMiercoles");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Miercoles);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbJueves");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Jueves);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbViernes");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Viernes);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbSabado");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Sabado);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbDomingo");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Domingo);
                            listaDias.Add(objGrupoDia);
                        }
                        objGrupo.Detalle = listaDias;
                        if (listaDias.Count != 0)
                        {
                            RN.Workflows.WGrupo.InsertarGrupoActualizarServicio(objGrupo, objServicio);
                            TextLogs.WriteInfo("Se creo una nueva grupo.");
                            TextLogs.WriteInfo("La grupo ha sido guardado correctamente.");
                            SetViewPanel(true);
                            SetFocus();
                            Search();
                            SetInformation(Helper.MessageType.Info, "La grupo ha sido guardado correctamente.");
                            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                        }
                        else
                        {
                            SetInformation(Helper.MessageType.Info, "Debe seleccionar un horario.");
                            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                        }
                    }
                }
                if (iCheckes == 0)
                {
                    SetInformation(Helper.MessageType.Info, "Debe seleccionar un horario.");
                    lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                }
            }
            catch (System.Data.SqlClient.SqlException err)
            {
                MensajesError(err);
            }
            catch (Exception err)
            {
                TextLogs.WriteError("No se pudo guardar la grupo", err);
                SetInformation(Helper.MessageType.Error, "Error no clasificado");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
        }
        if (string.IsNullOrEmpty(GrupoId.Value) && !string.IsNullOrEmpty(ServicioId.Value))
        {
            try
            {
                MembershipUser user = Membership.GetUser();
                TextLogs.WriteDebug("Insertando grupo: " + txtNombre.Text);
                TextLogs.WriteInfo("Entrando a crear nueva grupo.");
                CheckBox chk;
                string chkBoxIndex = string.Empty;

                int iCheckes = 0;
                foreach (GridViewRow row in grdHorario.Rows)
                {
                    CheckBox chkSelec;
                    chkSelec = (CheckBox)row.FindControl("cbSeleccion");
                    if (chkSelec.Checked)
                    {
                        iCheckes++;
                        objGrupo.Nombre = txtNombre.Text;
                        objGrupo.ServicioId = Convert.ToInt32(ServicioId.Value);
                        objGrupo.HorarioId = Convert.ToInt32(grdHorario.DataKeys[row.RowIndex]["id"].ToString());
                        objGrupo.Estado = cbEstado.Checked;
                        objGrupo.UsuarioId = user.ProviderUserKey.ToString();
                        objGrupo.Fecha = DateTime.Now;
                        chkBoxIndex = (string)grdHorario.DataKeys[row.RowIndex].Value.ToString();
                        chk = (CheckBox)row.FindControl("cbLunes");

                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Lunes);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbMartes");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Martes);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbMiercoles");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Miercoles);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbJueves");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Jueves);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbViernes");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Viernes);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbSabado");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Sabado);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbDomingo");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Domingo);
                            listaDias.Add(objGrupoDia);
                        }
                        objGrupo.Detalle = listaDias;
                        if (listaDias.Count != 0)
                        {
                            RN.Workflows.WGrupo.InsertarGrupoActualizarServicio(objGrupo, objServicio);
                            TextLogs.WriteInfo("Se creo una nueva grupo.");
                            TextLogs.WriteInfo("La grupo ha sido guardado correctamente.");
                            SetViewPanel(true);
                            SetFocus();
                            Search();
                            SetInformation(Helper.MessageType.Info, "La grupo ha sido guardado correctamente.");
                            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                        }
                        else
                        {
                            SetInformation(Helper.MessageType.Info, "Debe seleccionar un horario.");
                            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                        }
                    }
                }
                if (iCheckes == 0)
                {
                    SetInformation(Helper.MessageType.Info, "Debe seleccionar un horario.");
                    lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                }
            }
            catch (System.Data.SqlClient.SqlException err)
            {
                MensajesError(err);
            }
            catch (Exception err)
            {
                TextLogs.WriteError("No se pudo guardar la grupo", err);
                SetInformation(Helper.MessageType.Error, "Error no clasificado");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
        }
        if (!string.IsNullOrEmpty(GrupoId.Value) && string.IsNullOrEmpty(ServicioId.Value))
        {
            try
            {
                MembershipUser user = Membership.GetUser();
                TextLogs.WriteDebug("Insertando grupo: " + txtNombre.Text);
                TextLogs.WriteInfo("Entrando a crear nueva grupo.");
                CheckBox chk;
                string chkBoxIndex = string.Empty;
                objGrupo.Id = Convert.ToInt32(GrupoId.Value);
                int iCheckes = 0;
                foreach (GridViewRow row in grdHorario.Rows)
                {
                    CheckBox chkSelec;
                    chkSelec = (CheckBox)row.FindControl("cbSeleccion");
                    if (chkSelec.Checked)
                    {
                        iCheckes++;
                        objGrupo.Nombre = txtNombre.Text;
                        //objGrupo.ServicioId = Convert.ToInt32(ServicioId.Value);
                        objGrupo.HorarioId = Convert.ToInt32(grdHorario.DataKeys[row.RowIndex]["id"].ToString());
                        objGrupo.Estado = cbEstado.Checked;
                        objGrupo.UsuarioId = user.ProviderUserKey.ToString();
                        objGrupo.Fecha = DateTime.Now;
                        chkBoxIndex = (string)grdHorario.DataKeys[row.RowIndex].Value.ToString();
                        chk = (CheckBox)row.FindControl("cbLunes");

                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Lunes);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbMartes");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Martes);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbMiercoles");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Miercoles);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbJueves");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Jueves);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbViernes");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Viernes);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbSabado");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Sabado);
                            listaDias.Add(objGrupoDia);
                        }

                        chk = (CheckBox)row.FindControl("cbDomingo");
                        if (chk.Checked & chk.Enabled)
                        {
                            RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                            objGrupoDia.GrupoId = 0;
                            objGrupoDia.DiaId = Convert.ToInt32(Dias.Domingo);
                            listaDias.Add(objGrupoDia);
                        }
                        objGrupo.Detalle = listaDias;
                        if (listaDias.Count != 0)
                        {
                            RN.Workflows.WGrupo.InsertarGrupoActualizarServicio(objGrupo, objServicio);
                            TextLogs.WriteInfo("Se creo una nueva grupo.");
                            TextLogs.WriteInfo("La grupo ha sido guardado correctamente.");
                            SetViewPanel(true);
                            SetFocus();
                            Search();
                            SetInformation(Helper.MessageType.Info, "La grupo ha sido guardado correctamente.");
                            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                        }
                        else
                        {
                            SetInformation(Helper.MessageType.Info, "Debe seleccionar un horario.");
                            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                        }
                    }
                }
                if (iCheckes == 0)
                {
                    SetInformation(Helper.MessageType.Info, "Debe seleccionar un horario.");
                    lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                }
            }
            catch (System.Data.SqlClient.SqlException err)
            {
                MensajesError(err);
            }
            catch (Exception err)
            {
                TextLogs.WriteError("No se pudo guardar la grupo", err);
                SetInformation(Helper.MessageType.Error, "Error no clasificado");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
        }
        if(!string.IsNullOrEmpty(GrupoId.Value) && !string.IsNullOrEmpty(ServicioId.Value))
        {
            try
            {
                TextLogs.WriteDebug("Actualizando grupo: " + GrupoId.Value);
                TextLogs.WriteInfo("Entrando a actualizar emrpesa.");
                int iHorario = 0;
                foreach (GridViewRow row in grdHorarioHor.Rows)
                {
                    CheckBox chkSelec;
                    CheckBox chkLunes;
                    CheckBox chkMartes;
                    CheckBox chkMiercoles;
                    CheckBox chkJueves;
                    CheckBox chkViernes;
                    CheckBox chkSabado;
                    CheckBox chkDomingo;
                    chkSelec = (CheckBox)row.FindControl("cbSeleccion");
                    chkLunes = (CheckBox)row.FindControl("cbLunes");
                    chkMartes = (CheckBox)row.FindControl("cbMartes");
                    chkMiercoles = (CheckBox)row.FindControl("cbMiercoles");
                    chkJueves = (CheckBox)row.FindControl("cbJueves");
                    chkViernes = (CheckBox)row.FindControl("cbViernes");
                    chkSabado = (CheckBox)row.FindControl("cbSabado");
                    chkDomingo = (CheckBox)row.FindControl("cbDomingo");
                    if (chkSelec.Checked || chkLunes.Checked || chkMartes.Checked || chkMiercoles.Checked || chkJueves.Checked || chkViernes.Checked || chkSabado.Checked || chkDomingo.Checked)
                    {
                        iHorario = Convert.ToInt32(grdHorarioHor.DataKeys[row.RowIndex].Value.ToString());
                    }
                }
                if (iHorario != 0)
                {
                    List<RN.Entidades.GrupoDia> listDiasActualizar = new List<RN.Entidades.GrupoDia>();
                    MembershipUser user = Membership.GetUser();
                    objGrupo.Id = Convert.ToInt32(GrupoId.Value);
                    objGrupo.Nombre = txtNombre.Text;
                    objGrupo.ServicioId = Convert.ToInt32(ServicioId.Value);
                    objGrupo.HorarioId = iHorario;
                    objGrupo.Estado = cbEstado.Checked;
                    objGrupo.UsuarioId = user.ProviderUserKey.ToString();
                    objGrupo.Fecha = DateTime.Now;
                    CheckBox chk;
                    string chkBoxIndex = string.Empty;
                    int iCheckes = 0;
                    foreach (GridViewRow row in grdHorarioHor.Rows)
                    {
                        CheckBox chkSelec;
                        chkSelec = (CheckBox)row.FindControl("cbSeleccion");
                        if (chkSelec.Checked)
                        {
                            iCheckes++;
                            objGrupo.Nombre = txtNombre.Text;
                            objGrupo.ServicioId = Convert.ToInt32(ServicioId.Value);
                            objGrupo.HorarioId = Convert.ToInt32(grdHorarioHor.DataKeys[row.RowIndex]["id"].ToString());
                            objGrupo.Estado = cbEstado.Checked;
                            objGrupo.UsuarioId = user.ProviderUserKey.ToString();
                            objGrupo.Fecha = DateTime.Now;
                            chkBoxIndex = (string)grdHorarioHor.DataKeys[row.RowIndex].Value.ToString();
                            chk = (CheckBox)row.FindControl("cbLunes");

                            if (chk.Checked & chk.Enabled)
                            {
                                RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                                objGrupoDia.GrupoId = Convert.ToInt32(GrupoId.Value);
                                objGrupoDia.DiaId = Convert.ToInt32(Dias.Lunes);
                                listDiasActualizar.Add(objGrupoDia);
                            }

                            chk = (CheckBox)row.FindControl("cbMartes");
                            if (chk.Checked & chk.Enabled)
                            {
                                RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                                objGrupoDia.GrupoId = Convert.ToInt32(GrupoId.Value);
                                objGrupoDia.DiaId = Convert.ToInt32(Dias.Martes);
                                listDiasActualizar.Add(objGrupoDia);
                            }

                            chk = (CheckBox)row.FindControl("cbMiercoles");
                            if (chk.Checked & chk.Enabled)
                            {
                                RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                                objGrupoDia.GrupoId = Convert.ToInt32(GrupoId.Value);
                                objGrupoDia.DiaId = Convert.ToInt32(Dias.Miercoles);
                                listDiasActualizar.Add(objGrupoDia);
                            }

                            chk = (CheckBox)row.FindControl("cbJueves");
                            if (chk.Checked & chk.Enabled)
                            {
                                RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                                objGrupoDia.GrupoId = Convert.ToInt32(GrupoId.Value);
                                objGrupoDia.DiaId = Convert.ToInt32(Dias.Jueves);
                                listDiasActualizar.Add(objGrupoDia);
                            }

                            chk = (CheckBox)row.FindControl("cbViernes");
                            if (chk.Checked & chk.Enabled)
                            {
                                RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                                objGrupoDia.GrupoId = Convert.ToInt32(GrupoId.Value);
                                objGrupoDia.DiaId = Convert.ToInt32(Dias.Viernes);
                                listDiasActualizar.Add(objGrupoDia);
                            }

                            chk = (CheckBox)row.FindControl("cbSabado");
                            if (chk.Checked & chk.Enabled)
                            {
                                RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                                objGrupoDia.GrupoId = Convert.ToInt32(GrupoId.Value);
                                objGrupoDia.DiaId = Convert.ToInt32(Dias.Sabado);
                                listDiasActualizar.Add(objGrupoDia);
                            }

                            chk = (CheckBox)row.FindControl("cbDomingo");
                            if (chk.Checked & chk.Enabled)
                            {
                                RN.Entidades.GrupoDia objGrupoDia = new RN.Entidades.GrupoDia();
                                objGrupoDia.GrupoId = Convert.ToInt32(GrupoId.Value);
                                objGrupoDia.DiaId = Convert.ToInt32(Dias.Domingo);
                                listDiasActualizar.Add(objGrupoDia);
                            }
                        }
                    }
                    if (iCheckes == 0)
                    {
                        SetInformation(Helper.MessageType.Info, "Debe seleccionar un horario.");
                        lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                    }
                    else
                    {
                        objGrupo.Detalle = listDiasActualizar;
                        TextLogs.WriteInfo("Actualizando los datos del grupo y dia: " + GrupoId.Value);
                        TextLogs.WriteDebug("Actualizando los datos del grupo y dia: " + GrupoId.Value);
                        RN.Workflows.WGrupo.Actualizar(objGrupo, objServicio);
                        TextLogs.WriteInfo("Grupo y dias Actualizado: " + GrupoId.Value);
                    }
                   
                    //listDiasActualizar.Add(objGrupoDia);
                    TextLogs.WriteInfo("Grupo actualizada.");
                    SetViewPanel(true);
                    SetFocus();
                    Search();
                    SetInformation(Helper.MessageType.Info, "La grupo ha sido guardado correctamente.");
                    lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                }
                else
                {
                    SetInformation(Helper.MessageType.Info, "Debe seleccionar un horario.");
                    lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                }
            }
            catch (System.Data.SqlClient.SqlException err)
            {
                MensajesError(err);
            }
            catch (Exception err)
            {
                TextLogs.WriteError("No se pudo guardar la grupo", err);
                SetInformation(Helper.MessageType.Error, "Error no clasificado");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
        }

    }
    protected void ddlSala_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (GrupoId.Value == string.Empty)
        {
            grdHorario.DataBind();
            DeshabilitarFilasRegistro();
        }
        else
        {
            grdHorarioHor.DataBind();
            DeshabilitarFilas();
        }
    }
    protected void ddlServicio_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<RN.Entidades.Servicio> lstServ = RN.Componentes.CServicio.TraerXId(Convert.ToInt32(ddlServicio.SelectedValue.ToString()));
        if (lstServ.Count != 0)
        {
            if (lstServ[0].Cupo == 0)
                txtCupo.Text = string.Empty;
            else
                txtCupo.Text = lstServ[0].Cupo.ToString();
        }
    }
    protected void lbAdicionarServicio_Click(object sender, EventArgs e)
    {
        ShowDialog("dialogServicios");
    }
    private void ShowDialog(string dialogId)
    {
        string script = string.Format(@"showDialog('{0}');", dialogId);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void CloseDialog(string dialogId)
    {
        string script = string.Format(@"closeDialog('{0}');", dialogId);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    protected void btnGuardarServicios_Click(object sender, EventArgs e)
    {
        MembershipUser user = Membership.GetUser();
        RN.Entidades.Servicio objServ = new RN.Entidades.Servicio();
        objServ.Fecha = DateTime.Now;
        objServ.RestriccionHorario = false;
        objServ.UsuarioId = user.ProviderUserKey.ToString();
        objServ.Estado = true;
        objServ.Nombre = txtNombreServicio.Text;
        objServ.Cupo = Convert.ToInt32(txtCupoServicio.Text);
        if (RN.Componentes.CServicio.Insertar(objServ))
        {
            CloseDialog("dialogServicios");
            CargarServicios();
        }
    }
    protected void btnCerrarServicios_Click(object sender, EventArgs e)
    {
        CloseDialog("dialogServicios");
        CargarServicios();
    }
    protected void lbNuevo_Click(object sender, EventArgs e)
    {
        ShowDialog("dialogServicios");
    }
}
