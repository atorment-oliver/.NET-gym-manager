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
using Microsoft.Reporting.WebForms;
using System.Configuration;

public partial class Clientes_ClienteConsulta : System.Web.UI.Page
{
    DataTable dtListado = new DataTable();
    DataTable dtLicencia;
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Context.Session["Inscripciones"] != null)
            dtListado = (DataTable)this.Context.Session["Inscripciones"];
        else
            this.Context.Session["Inscripciones"] = dtListado;
        if (!AppSecurity.HasAccess("Clientes"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Clientes.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }

        MembershipUser user = Membership.GetUser();
        List<RN.Entidades.Caja> caja = RN.Componentes.CCaja.TraerXCriterio(string.Empty, user.ProviderUserKey.ToString(), "true");
        if (caja != null && caja.Count > 0)
        {
            TextLogs.WriteInfo("Verificando si cajero abrio su caja.");
            List<RN.Entidades.MovimientoCaja> objCaja = RN.Componentes.CMovimientoCaja.EstaAbierto(caja[0].Id.ToString());
            if (objCaja.Count == 0 || objCaja[0].Estado == false)
            {
                TextLogs.WriteInfo("El usuario no abrió su caja, redireccionandolo a la página de apertura de caja.");
                Response.Redirect("../Caja/Caja.aspx");
            }
        }

        if (!IsPostBack)
        {
            CargarDatosPanel();
        }
    }
    
    private void LimpiarTable()
    {
        dtListado.Rows.Clear();
        this.Context.Session["Inscripciones"] = null;
    }
    
   
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        MembershipUser user = Membership.GetUser();
       
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
    protected void lbName_Click(object sender, EventArgs e)
    {
        var editLink = ((LinkButton)sender);
    }
    private void MensajeGuardado(string mensaje)
    {
        string script = string.Format(@"$.msgBox('" + mensaje + "');");
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void MensajeGuardadoCargado(string mensaje, string id, string nombre, string ci)
    {
        string script = string.Format(@"$.msgBox('{0}');CargarBusqueda('{1}','{2}','{3}')", mensaje, id, nombre, ci);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void CloseDialog(string dialogId)
    {
        string script = string.Format(@"closeDialog('{0}')", dialogId);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void CloseDialogMensaje(string dialogId, string mensaje)
    {
        string script = string.Format(@"$.msgBox('{1}');closeDialog('{0}')", dialogId, mensaje);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void CloseDialogCargado(string dialogId, string id, string nombre, string ci)
    {
        string script = string.Format(@"closeDialog('{0}');CargarBusqueda('{1}','{2}','{3}')", dialogId, id, nombre, ci);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void CloseDialogMensajeCargadoShowDialog(string dialogId, string mensaje, string id, string nombre, string ci, string shodialog)
    {
        string script = string.Format(@"$.msgBox('{0}');closeDialog('{1}');CargarBusqueda('{2}','{3}','{4}');showDialog('{5}');TestCheckBox();", mensaje, dialogId, id, nombre, ci, shodialog);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void CloseDialogCargadoShowDialog(string dialogId, string id, string nombre, string ci, string shodialog)
    {
        string script = string.Format(@"closeDialog('{0}');CargarBusqueda('{1}','{2}','{3}');showDialog('{4}')", dialogId, id, nombre, ci, shodialog);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void CloseDialogCargado(string dialogId)
    {
        string script = string.Format(@"closeDialog('{0}');", dialogId);
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
        ClientScript.RegisterClientScriptBlock(this.GetType(), "popup", "<script language=JavaScript> " + script + " $(window).load(function () { $('#basic-modal-content').modal(); }); </script>");
    }
    private void CloseDialogCargadoMensaje(string dialogId, string id, string nombre, string ci, string mensaje)
    {
        string script = string.Format(@"closeDialog('{0}');CargarBusqueda('{1}','{2}','{3}');$.msgBox('{4}')", dialogId, id, nombre, ci, mensaje);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void ShowDialog(string dialogId)
    {
        string script = string.Format(@"showDialog('{0}');LimpiarBusqueda();", dialogId);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void ShowDialogCargado(string dialogId, string id, string nombre, string ci)
    {
        string script = string.Format(@"showDialog('{0}');;CargarBusqueda('{1}','{2}','{3}')", dialogId, id, nombre, ci);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void LimpiarBusqueda()
    {
        string script = string.Format(@"LimpiarBusqueda();");
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    public void MensajeGuardado()
    {
        //SetInformation(Helper.MessageType.Info, "El cliente se ha sido guardado correctamente.");
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "popup", "<script language=JavaScript> $(window).load(function () { $('.osx').click(); }); </script>");
        MensajeGuardado("El cliente se ha sido guardado correctamente.");
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        CargarDatosPanel();
    }
    private void CargarDatosPanel()
    {
        if (!String.IsNullOrEmpty(hdnAutoCompleteClienteId.Value.ToString()))
        {
            int iCliente = CargarDatosCliente();
        }
        else
        {
            lblNumeroCliente.Text = "-";
            lblNombreCliente.Text = "-";
            lblEmpresaCliente.Text = "-";
            lblCiCliente.Text = "-";
            lblEdadCliente.Text = "-";
            lblDireccionCliente.Text = "-";
            lblTelefonoCliente.Text = "-";
            lblFechaIngreso.Text = "-";
            lblEmpresaCliente.Text = "-";
            lblTelefonoEmpresa.Text = "-";
            lblPersonaEmpresa.Text = "-";
            lblCoberturaEmpresa.Text = "-";
            lblCoberturaEmpresaMonto.Text = "-";
          
          
        }
    }


    public int Edad(DateTime fechaNacimiento)
    {
        int edad = DateTime.Now.Year - fechaNacimiento.Year;
        DateTime nacimientoAhora = fechaNacimiento.AddYears(edad);
        if (DateTime.Now.CompareTo(nacimientoAhora) < 0)
        {
            edad--;
        }

        return edad;
    }
    private int CargarDatosCliente()
    {
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value.ToString()));
        if (lstCliente.Count != 0)
        {
            lblNumeroCliente.Text = lstCliente[0].NumeroCliente.ToString();
            lblNombreCliente.Text = string.Format("{0} {1}", lstCliente[0].Nombre.ToString(), lstCliente[0].Apellidos.ToString());
            lblEdadCliente.Text = Edad(lstCliente[0].FechaNacimiento).ToString();
            lblFechaIngreso.Text = lstCliente[0].FechaIngreso.ToShortDateString();

            lblCiCliente.Text = string.IsNullOrEmpty(lstCliente[0].Ci) ? "-" : lstCliente[0].Ci + lstCliente[0].CiCi;
            lblDireccionCliente.Text = string.IsNullOrEmpty(lstCliente[0].Direccion) ? "-" : lstCliente[0].Direccion;
            lblTelefonoCliente.Text = string.IsNullOrEmpty(lstCliente[0].Telefono) ? "-" : lstCliente[0].Telefono;
            txtSearchCI.Text = lstCliente[0].Nombre + " " + lstCliente[0].Apellidos + " - " + lstCliente[0].Ci + lstCliente[0].CiCi;
            CargarDatosEmpresa(lstCliente[0].EmpresaId);
            return lstCliente[0].Id;
        }
        else
            return 0;
    }
    private void CargarDatosEmpresa(int codigo)
    {
        List<RN.Entidades.Empresa> lstEmpresa = RN.Componentes.CEmpresa.TraerXId(codigo);
        if (lstEmpresa.Count != 0)
        {
            pnlEmpresa.Visible = true;
            lblEmpresaCliente.Text = lstEmpresa[0].Nombre.ToString();
            lblTelefonoEmpresa.Text = lstEmpresa[0].Telefono.ToString();
            lblPersonaEmpresa.Text = lstEmpresa[0].NombrePersonaContacto.ToString();
        }
        else
        {
            pnlEmpresa.Visible = false;
        }
    }
    
   
   
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        txtSearchCI.Text = string.Empty;
        hdnAutoCompleteClienteId.Value = string.Empty;
        CargarDatosPanel();
        ShowDialog("dialogCliente");
    }

    
   
   
    public string GetPrecioPaquete(object item)
    {
        double monto = Convert.ToDouble(DataBinder.Eval(item, "precioPaquete"));
        return monto.ToString("f2");
    }
    public string GetPrecioDescuento(object item)
    {
        double monto = Convert.ToDouble(DataBinder.Eval(item, "Descuento"));
        return monto.ToString("f2");
    }
    public string GetPrecioTotal(object item)
    {
        double monto = Convert.ToDouble(DataBinder.Eval(item, "Total"));
        return monto.ToString("f2");
    }
   
    public string ListarDias(object id)
    {
        string sDias = string.Empty;
        int gId = Convert.ToInt32(DataBinder.Eval(id, "GrupoId"));
        if (gId != 0)
        {
            List<RN.Entidades.GrupoDia> lDias = RN.Componentes.CGrupoDia.TraerXGrupoId(gId);
            foreach (RN.Entidades.GrupoDia row in lDias)
            {
                switch (row.DiaId)
                {
                    case 1:
                        sDias = "Lun ";
                        break;
                    case 2:
                        sDias = sDias + "Mar ";
                        break;
                    case 3:
                        sDias = sDias + "Mier ";
                        break;
                    case 4:
                        sDias = sDias + "Jue ";
                        break;
                    case 5:
                        sDias = sDias + "Vie ";
                        break;
                    case 6:
                        sDias = sDias + "Sab ";
                        break;
                    case 7:
                        sDias = sDias + "Dom ";
                        break;
                    default:
                        sDias = "";
                        break;
                }
            }
        }
        return sDias;
    }
    public string IsApproved(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "estado"));
        if (approved)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
   
    public string Adicional(object id)
    {
        int approved = Convert.ToInt32(DataBinder.Eval(id, "adicional"));
        if (approved != -1)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
    public bool HabilitarAdicional(object id)
    {
        int approved = Convert.ToInt32(DataBinder.Eval(id, "adicional"));
        if (approved == -1)
            return true;
        else
            return false;
    }
   
    public string IdNombre(object id)
    {
        string valor = (DataBinder.Eval(id, "id")).ToString();
        string nombre = (DataBinder.Eval(id, "nombreServicio")).ToString();
        return valor + "=" + nombre;
    }
    public bool HabilitarEliminar()
    {
        /*List<RN.Entidades.PagoCliente> lstPago = RN.Componentes.CPagoCliente.TraerXIdClientePaquete(Convert.ToInt32(hdnAutoCompleteClienteId.Value), Convert.ToInt32(ClientePaqueteId.Value));
        if (lstPago.Count != 0)
            return false;
        else
            return true;*/
        return true;
    }
    public bool HabilitarModificar()
    {
        //List<RN.Entidades.PagoCliente> lstPago = RN.Componentes.CPagoCliente.TraerXIdClientePaquete(Convert.ToInt32(hdnAutoCompleteClienteId.Value), Convert.ToInt32(ClientePaqueteId.Value));
        //if (lstPago.Count != 0)
        //    return false;
        //else
        return true;
    }
    protected void txtFechaIngreso_TextChanged(object sender, EventArgs e)
    {
        if (txtFechaIngreso.Text != "")
        {
            char[] delitadores = new char[] { '/', '-' };

            string[] args = this.txtFechaIngreso.Text.Split(delitadores);

            //- Verificar si tiene dd/mm/yyyy ó dd-mm-yyyy
            if (args.Length == 3)
            {
                //- Hacer el recorrido de las partes de la fecha para hacer el autocomplete
                for (int i = 0; i < args.Length - 1; i++)
                {
                    //- Si tiene menos de 2 caracteres significa que se tendrá que agregar el 0
                    if (args[i].Length < 2)
                    {
                        args[i] = args[i].PadLeft(2, '0');
                    }
                }
            }
            if (args.Count() < 3)
            {
                if ((txtFechaIngreso.Text.Trim().Length == 4))
                {
                    args = new string[3];
                    args[0] = txtFechaIngreso.Text.Trim().Substring(0, 1).PadLeft(2, '0'); ;
                    args[1] = txtFechaIngreso.Text.Trim().Substring(1, 1).PadLeft(2, '0'); ;
                    args[2] = txtFechaIngreso.Text.Trim().Substring(2, 2);
                }
                if ((txtFechaIngreso.Text.Trim().Length == 6))
                {
                    args = new string[3];
                    args[0] = txtFechaIngreso.Text.Trim().Substring(0, 2).PadLeft(2, '0'); ;
                    args[1] = txtFechaIngreso.Text.Trim().Substring(2, 2).PadLeft(2, '0'); ;
                    args[2] = txtFechaIngreso.Text.Trim().Substring(4, 2);
                }
                if ((txtFechaIngreso.Text.Trim().Length == 7))
                {
                    args = new string[3];
                    args[0] = txtFechaIngreso.Text.Trim().Substring(0, 2).PadLeft(2, '0'); ;
                    args[1] = txtFechaIngreso.Text.Trim().Substring(2, 1).PadLeft(2, '0'); ;
                    args[2] = txtFechaIngreso.Text.Trim().Substring(3, 4);
                }
                if ((txtFechaIngreso.Text.Trim().Length == 8))
                {
                    args = new string[3];
                    args[0] = txtFechaIngreso.Text.Trim().Substring(0, 2).PadLeft(2, '0'); ;
                    args[1] = txtFechaIngreso.Text.Trim().Substring(2, 2).PadLeft(2, '0'); ;
                    args[2] = txtFechaIngreso.Text.Trim().Substring(4, 4);
                }
            }
            if (args.Count() > 1)
            {
                if (args[2].Length == 2)
                {
                    args[2] = string.Format("{0}{1}", "19", args[2].ToString());
                }
            }
            String Fecha = args[0].PadLeft(2, '0') + "/" + args[1].PadLeft(2, '0') + "/" + args[2];
            try
            {
                DateTime.Parse(Fecha);
                txtFechaIngreso.Text = Fecha;
            }
            catch (Exception error)
            {
                txtFechaIngreso.Text = DateTime.Now.ToShortDateString();
            }
        }
    }
    protected void btnConsultaMedica_Click(object sender, EventArgs e)
    {
        List<RN.Entidades.Cliente> objCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        ShowDialogCargado("dialogConsulta", objCliente[0].Id.ToString(), objCliente[0].Nombre + " " + objCliente[0].Apellidos, objCliente[0].Ci + objCliente[0].CiCi);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(hdnAutoCompleteClienteId.Value))
        {
            CloseDialog("dialogConsulta");
            return;
        }
        List<RN.Entidades.Cliente> lstCliente = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(hdnAutoCompleteClienteId.Value));
        LimpiarTable();
        CloseDialogCargado("dialogConsulta", lstCliente[0].Id.ToString(), lstCliente[0].Nombre + " " + lstCliente[0].Apellidos, lstCliente[0].Ci + lstCliente[0].CiCi);
    }
}
