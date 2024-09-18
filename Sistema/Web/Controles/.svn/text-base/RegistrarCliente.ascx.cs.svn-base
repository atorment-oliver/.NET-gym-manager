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
using RN.Entidades;
using System.Configuration;


public partial class Controles_RegistrarCliente : System.Web.UI.UserControl
{
    public string clienteId;
    public bool bAlerta;
    public event UserControlDelegate userControlClick;
    protected void Page_Load(object sender, EventArgs e)
    {
        ActualizarHiden();
        if (!IsPostBack)
        {
            CargarEmpresas();
            CargarDatos();
            NavegarEnter();
        }
    }
    private void NavegarEnter()
    {
        txtNombre.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        txtApellidos.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        //txtFechaIngreso.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        //txtFechaNacimento.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        txtDireccion.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        txtTelefono.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        txtCelular.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        txtCelular2.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        txtCi.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        txtCorreo.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        txtOcupacion.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        txtLugarTrabajo.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        txtTelefonoTrabajo.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        txtCorreo.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        rblGenero.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        rblEstado.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        rblHijos.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        ddlEmpresa.Attributes.Add("onKeyDown", "SiguienteObjeto();");
        cbNotificaciones.Attributes.Add("onKeyDown", "SiguienteObjeto();");
    }
    private void MensajeGuardado()
    {
        string script = string.Format(@"$.msgBox('El cliente se guardo correctamente');");
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    private void Mensaje(string mensaje)
    {
        string script = string.Format(@"$.msgBox('{0}');", mensaje);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }
    public void SetFocus()
    {
        Page.SetFocus(txtNombre);
    }
    public void CargarDatos()
    {
        Cargar(ClienteIdH.Value);
    }
    public void BotoneAtrasCerrar()
    {
        btnCerrar.Visible = false;
        btnAtras.Visible = true;
    }
    public string ClienteId
    {
        get { return clienteId; }
        set { clienteId = value; }
    }
    public bool BAlerta
    {
        get { return bAlerta; }
        set { bAlerta = value; }
    }
    public bool EmpresaVisible
    {
        get { return trEmpresa.Visible; }
        set { trEmpresa.Visible = value; }
    }
    public void ActualizarHiden()
    {
        if (String.IsNullOrEmpty(this.clienteId))
            ClienteIdH.Value = string.Empty;
        else
            ClienteIdH.Value = clienteId;
    }
    private void Cargar(string userName)
    {
        if (!String.IsNullOrEmpty(ClienteIdH.Value))
        {
            TextLogs.WriteInfo("Cargando datos del cliente los controles del formulario.");
            TextLogs.WriteDebug("Cargando cliente: " + userName);
            List<RN.Entidades.Cliente> lEmpresa = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(userName));
            txtNombre.Text = lEmpresa[0].Nombre;
            txtApellidos.Text = lEmpresa[0].Apellidos;
            txtDireccion.Text = lEmpresa[0].Direccion;
            txtTelefono.Text = lEmpresa[0].Telefono;
            txtCelular.Text = lEmpresa[0].Celular;
            txtCi.Text = lEmpresa[0].Ci;
            txtCorreo.Text = lEmpresa[0].Correo;
            txtOcupacion.Text = lEmpresa[0].Ocupacion;
            txtLugarTrabajo.Text = lEmpresa[0].LugarTrabajo;
            txtTelefonoTrabajo.Text = lEmpresa[0].TelefonoTrabajo;
            txtCorreoTrabajo.Text = lEmpresa[0].CorreoTrabajo;
            txtFechaNacimento.Text = lEmpresa[0].FechaNacimiento.ToShortDateString();
            rblGenero.SelectedValue = lEmpresa[0].Genero.ToUpper();
            rblEstado.SelectedValue = lEmpresa[0].EstadoCivil;
            rblHijos.Checked = lEmpresa[0].TieneHijos;
            txtNumeroHijos.Text = lEmpresa[0].NumeroHijos.ToString();
            txtFechaIngreso.Text = lEmpresa[0].FechaIngreso.ToShortDateString();
            txtNumeroCliente.Text = lEmpresa[0].NumeroCliente.ToString();
            ddlEstado.SelectedValue = lEmpresa[0].Estado;
            cbNotificaciones.Checked = lEmpresa[0].RecibirNotificaciones;
            ddlEmpresa.SelectedValue = lEmpresa[0].EmpresaId.ToString();
            ddlEstado.Enabled = false;
            TextLogs.WriteInfo("Datos del cliente cargados al formulario correctamente.");
        }
        else
        {
            LimpiarCampos();
        }
    }
    public void LimpiarCampos()
    {
        txtNombre.Text = string.Empty;
        txtApellidos.Text = string.Empty;
        txtDireccion.Text = string.Empty;
        txtTelefono.Text = string.Empty;
        txtCelular.Text = string.Empty;
        txtCi.Text = string.Empty;
        txtCorreo.Text = string.Empty;
        txtOcupacion.Text = string.Empty;
        txtLugarTrabajo.Text = string.Empty;
        txtTelefonoTrabajo.Text = string.Empty;
        txtCorreoTrabajo.Text = string.Empty;
        txtFechaIngreso.Text = DateTime.Now.ToShortDateString();
        txtFechaNacimento.Text = Convert.ToDateTime("01/01/1990").ToShortDateString();
        //txtFechaIngreso.Enabled = false;
        txtNumeroCliente.Enabled = false;
        rblHijos.Checked = false;
        txtNumeroHijos.Text = string.Empty;
        txtNumeroCliente.Text = "-";//RN.Componentes.CCliente.TraerMaximoNumero().ToString();
        //ddlEstado.SelectedIndex = 0;
        cbNotificaciones.Checked = false;
        //ddlEmpresa.SelectedValue = "0";
        TextLogs.WriteInfo("Campos del formulario han sido limpiados.");
    }
    private void CargarEmpresas()
    {
        DataTable dtUsuarios =  RN.Componentes.CEmpresa.TraerXCriterioData("","","","");
        ddlEmpresa.DataSource = dtUsuarios;
        ddlEmpresa.DataTextField = "nombre";
        ddlEmpresa.DataValueField = "id";
        ddlEmpresa.DataBind();
        //ListItem lis = new ListItem("Sin empresa", "0");
        //lis.Selected = true;
        //ddlEmpresa.Items.Add(lis);
    }
    private void MensajesError(System.Data.SqlClient.SqlException eVariable)
    {
        string sError = "No se pudo guardar la empresa";
        string sTipo = string.Empty;
        switch (eVariable.Number.ToString())
        {
            case "08001":
                sTipo = "Error de conexion con la base de datos";
                break;
            case "2627":
                sTipo = "Restriccion de CI repetido";
                break;
            case "2601":
                sTipo = "Ya se tiene registrado el CI";
                break;
            default:
                sTipo = "Error no clasificado";
                break;
        }
        TextLogs.WriteError(sError, eVariable);
        Mensaje(sTipo);
    }
    protected void RegistrarButton_Click(object sender, EventArgs e)
    {
        GuardarCliente();
    }
    public void GuardarCliente()
    {
        if (userControlClick != null)
        {
            ControlClienteEventHandler control = new ControlClienteEventHandler();
            RN.Entidades.Cliente objCliente = new RN.Entidades.Cliente();
            if (string.IsNullOrEmpty(ClienteIdH.Value))
            {
                List<RN.Entidades.Cliente> lstClie = RN.Componentes.CCliente.ValidarDatos(txtNombre.Text, txtApellidos.Text, txtCi.Text);
                if (lstClie.Count == 0)
                {
                    MembershipUser user = Membership.GetUser();
                    TextLogs.WriteDebug("Insertando cliente: " + txtNombre.Text + " " + txtApellidos.Text);
                    TextLogs.WriteInfo("Entrando a crear nuevo tipo de paquete.");
                    objCliente.Nombre = txtNombre.Text;
                    objCliente.Apellidos = txtApellidos.Text;
                    objCliente.Direccion = txtDireccion.Text;
                    objCliente.Telefono = txtTelefono.Text;
                    objCliente.Celular = txtCelular.Text;
                    objCliente.Celular2 = txtCelular2.Text;
                    if (!string.IsNullOrEmpty(txtCi.Text.ToString()))
                        objCliente.Ci = txtCi.Text + ddlCi.SelectedValue.ToString();
                    else
                        objCliente.Ci = string.Empty;
                    objCliente.Correo = txtCorreo.Text;
                    objCliente.Ocupacion = txtOcupacion.Text;
                    objCliente.LugarTrabajo = txtLugarTrabajo.Text;
                    objCliente.TelefonoTrabajo = txtTelefonoTrabajo.Text;
                    objCliente.CorreoTrabajo = txtCorreoTrabajo.Text;
                    if (!string.IsNullOrEmpty(txtFechaNacimento.Text))
                        objCliente.FechaNacimiento = Convert.ToDateTime(txtFechaNacimento.Text);
                    else
                        objCliente.FechaNacimiento = new DateTime(1900, 01, 01);

                    objCliente.Genero = rblGenero.SelectedValue.ToString();
                    objCliente.EstadoCivil = rblEstado.SelectedValue.ToString();
                    objCliente.TieneHijos = rblHijos.Checked;
                    if (String.IsNullOrEmpty(txtNumeroHijos.Text))
                        objCliente.NumeroHijos = Convert.ToInt32(0);
                    else
                        objCliente.NumeroHijos = Convert.ToInt32(txtNumeroHijos.Text);
                    objCliente.FechaIngreso = Convert.ToDateTime(txtFechaIngreso.Text);
                    //objCliente.NumeroCliente = Convert.ToInt32(txtNumeroCliente.Text);
                    objCliente.NumeroCliente = 0;
                    objCliente.Estado = ddlEstado.SelectedValue.ToString();
                    objCliente.RecibirNotificaciones = cbNotificaciones.Checked;
                    objCliente.Fecha = DateTime.Now;
                    if (user != null)
                        objCliente.UsuarioId = user.ProviderUserKey.ToString();
                    else
                        objCliente.UsuarioId = ConfigurationManager.AppSettings["UsuarioExterno"].ToString();
                    objCliente.EmpresaId = Convert.ToInt32(ddlEmpresa.SelectedValue.ToString());
                    int iCodigo = -1;
                    try
                    {
                         iCodigo = RN.Componentes.CCliente.InsertarId(objCliente);
                    }
                    catch (System.Data.SqlClient.SqlException err)
                    {
                        iCodigo = -1;
                        MensajesError(err);
                    }
                    catch (Exception err)
                    {
                        TextLogs.WriteWarning("No se pudo guardar el cliente", err);
                    }
                    if (iCodigo != -1)
                    {
                        control.SDML = "Insertar";
                        control.ICodigo = iCodigo;
                    }
                    else
                        control.SDML = string.Empty;
                    TextLogs.WriteInfo("Se creo un nuevo cliente.");
                    TextLogs.WriteInfo("El cliente ha sido guardado correctamente.");
                }
                else
                {
                    control.SDML = "";
                    control.ICodigo = 0;
                    bAlerta = false;
                    Mensaje("Ya se encuentra registrado el Cliente y el CI");
                }
                if (bAlerta)
                    MensajeGuardado();
            }
            else
            {

                TextLogs.WriteDebug("Actualizando cliente: " + ClienteIdH.Value);
                TextLogs.WriteInfo("Entrando a actualizar cliente.");
                MembershipUser user = Membership.GetUser();
                objCliente.Id = Convert.ToInt32(ClienteIdH.Value);
                objCliente.Nombre = txtNombre.Text;
                objCliente.Apellidos = txtApellidos.Text;
                objCliente.Direccion = txtDireccion.Text;
                objCliente.Telefono = txtTelefono.Text;
                objCliente.Celular = txtCelular.Text;
                objCliente.Celular2 = txtCelular2.Text;
                if (!string.IsNullOrEmpty(txtCi.Text.ToString()))
                    objCliente.Ci = txtCi.Text + ddlCi.SelectedValue.ToString();
                else
                    objCliente.Ci = string.Empty;
                objCliente.Correo = txtCorreo.Text;
                objCliente.Ocupacion = txtOcupacion.Text;
                objCliente.LugarTrabajo = txtLugarTrabajo.Text;
                objCliente.TelefonoTrabajo = txtTelefonoTrabajo.Text;
                objCliente.CorreoTrabajo = txtCorreoTrabajo.Text;
                if (!string.IsNullOrEmpty(txtFechaNacimento.Text))
                    objCliente.FechaNacimiento = Convert.ToDateTime(txtFechaNacimento.Text);
                else
                    objCliente.FechaNacimiento = new DateTime(1900, 01, 01);
                objCliente.Genero = rblGenero.SelectedValue.ToString();
                objCliente.EstadoCivil = rblEstado.SelectedValue.ToString();
                objCliente.TieneHijos = rblHijos.Checked;
                if (String.IsNullOrEmpty(txtNumeroHijos.Text))
                    objCliente.NumeroHijos = Convert.ToInt32(0);
                else
                    objCliente.NumeroHijos = Convert.ToInt32(txtNumeroHijos.Text);
                objCliente.FechaIngreso = Convert.ToDateTime(txtFechaIngreso.Text);
                objCliente.NumeroCliente = Convert.ToInt32(txtNumeroCliente.Text);
                objCliente.Estado = ddlEstado.SelectedValue.ToString();
                objCliente.RecibirNotificaciones = cbNotificaciones.Checked;
                objCliente.Fecha = DateTime.Now;
                if(user != null)
                    objCliente.UsuarioId = user.ProviderUserKey.ToString();
                else
                    objCliente.UsuarioId = ConfigurationManager.AppSettings["UsuarioExterno"].ToString();
                objCliente.EmpresaId = Convert.ToInt32(ddlEmpresa.SelectedValue.ToString());
                bool bPromocion = false;
                List<RN.Entidades.PromocionCliente> objPromo = RN.Componentes.CPromocionCliente.TraerXIdClienteMensual(Convert.ToInt32(ClienteIdH.Value));
                if (objPromo.Count != 0)
                {
                    List<RN.Entidades.Promocion> objPr = RN.Componentes.CPromocion.TraerXId(objPromo[0].PromocionId);
                    if (objPr.Count != 0)
                    {
                        bPromocion = true;
                    }
                }
                if ((!bPromocion) && (objCliente.EmpresaId == 0))
                {
                    try
                    {
                        if (RN.Componentes.CCliente.Actualizar(objCliente))
                            control.SDML = "Actualizar";
                        else
                            control.SDML = string.Empty;
                    }
                    catch (System.Data.SqlClient.SqlException err)
                    {
                        control.SDML = string.Empty;
                        MensajesError(err);
                    }
                    catch (Exception err)
                    {
                        TextLogs.WriteWarning("No se pudo guardar el cliente", err);
                    }
                    TextLogs.WriteInfo("Cliente actualizado.");
                    control.SDML = "Actualizar";
                    if (bAlerta)
                        MensajeGuardado();
                }
                if((!bPromocion) && (objCliente.EmpresaId != 0))
                {
                    try
                    {
                        if (RN.Componentes.CCliente.Actualizar(objCliente))
                            control.SDML = "Actualizar";
                        else
                            control.SDML = string.Empty;
                    }
                    catch (System.Data.SqlClient.SqlException err)
                    {
                        control.SDML = string.Empty;
                        MensajesError(err);
                    }
                    catch (Exception err)
                    {
                        TextLogs.WriteWarning("No se pudo guardar el cliente", err);
                    }
                    TextLogs.WriteInfo("Cliente actualizado.");
                    control.SDML = "Actualizar";
                    if (bAlerta)
                        MensajeGuardado();
                }
                if ((bPromocion) && (objCliente.EmpresaId == 0))
                {
                    try
                    {
                        if (RN.Componentes.CCliente.Actualizar(objCliente))
                            control.SDML = "Actualizar";
                        else
                            control.SDML = string.Empty;
                    }
                    catch (System.Data.SqlClient.SqlException err)
                    {
                        control.SDML = string.Empty;
                        MensajesError(err);
                    }
                    catch (Exception err)
                    {
                        TextLogs.WriteWarning("No se pudo guardar el cliente", err);
                    }
                    TextLogs.WriteInfo("Cliente actualizado.");
                    control.SDML = "Actualizar";
                    if (bAlerta)
                        MensajeGuardado();
                }
                if ((bPromocion) && (objCliente.EmpresaId != 0))
                {
                    Mensaje("No se puede modificar el cliente ya que tiene asignada una promoción.");
                    //control.SDML = "Actualizar";
                }
                control.SDML = "Actualizar";
            }
            userControlClick(control);
        }    
    }
    
    protected void rblHijos_CheckedChanged(object sender, EventArgs e)
    {
        if (rblHijos.Checked == true)
        {
            trHijos.Visible = true;

        }
        else
        {
            trHijos.Visible = false;
            txtNumeroHijos.Text = "0";
        }
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        if (userControlClick != null)
        {
            ControlClienteEventHandler control = new ControlClienteEventHandler();
            control.SDML = "Cerrar";
            userControlClick(control);
        }
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        if (userControlClick != null)
        {
            ControlClienteEventHandler control = new ControlClienteEventHandler();
            control.SDML = "Atras";
            userControlClick(control);
        }
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
                txtNombre.Focus();
            }
            catch (Exception error)
            {
                txtFechaIngreso.Text = DateTime.Now.ToShortDateString();
            }
        }
    }
    protected void txtFechaNacimento_TextChanged(object sender, EventArgs e)
    {
        if (txtFechaNacimento.Text != "")
        {
            char[] delitadores = new char[] { '/', '-' };

            string[] args = this.txtFechaNacimento.Text.Split(delitadores);

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
                if ((txtFechaNacimento.Text.Trim().Length == 4))
                {
                    args = new string[3];
                    args[0] = txtFechaNacimento.Text.Trim().Substring(0, 1).PadLeft(2, '0'); ;
                    args[1] = txtFechaNacimento.Text.Trim().Substring(1, 1).PadLeft(2, '0'); ;
                    args[2] = txtFechaNacimento.Text.Trim().Substring(2, 2);
                }
                if ((txtFechaNacimento.Text.Trim().Length == 6))
                {
                    args = new string[3];
                    args[0] = txtFechaNacimento.Text.Trim().Substring(0, 2).PadLeft(2, '0'); ;
                    args[1] = txtFechaNacimento.Text.Trim().Substring(2, 2).PadLeft(2, '0'); ;
                    args[2] = txtFechaNacimento.Text.Trim().Substring(4, 2);
                }
                if ((txtFechaNacimento.Text.Trim().Length == 7))
                {
                    args = new string[3];
                    args[0] = txtFechaNacimento.Text.Trim().Substring(0, 2).PadLeft(2, '0'); ;
                    args[1] = txtFechaNacimento.Text.Trim().Substring(2, 1).PadLeft(2, '0'); ;
                    args[2] = txtFechaNacimento.Text.Trim().Substring(3, 4);
                }
                if ((txtFechaNacimento.Text.Trim().Length == 8))
                {
                    args = new string[3];
                    args[0] = txtFechaNacimento.Text.Trim().Substring(0, 2).PadLeft(2, '0'); ;
                    args[1] = txtFechaNacimento.Text.Trim().Substring(2, 2).PadLeft(2, '0'); ;
                    args[2] = txtFechaNacimento.Text.Trim().Substring(4, 4);
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
                txtFechaNacimento.Text = Fecha;
                txtTelefono.Focus();
            }
            catch (Exception error)
            {
                txtFechaNacimento.Text = DateTime.Now.ToShortDateString();
            }
        }   
    }
}