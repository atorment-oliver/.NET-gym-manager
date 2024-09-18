using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;
using RN;
using System.Web.Security;
using Instrumentacion;

public partial class Clientes_ClientesExcel : System.Web.UI.Page
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        ResultGrid.CssClass = "ui-widget-content";
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
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlEjemplo.NavigateUrl = "../Files/Demo.xlsx";
            //hlEjemplo.NavigateUrl = Config.GetPath("Files/Demo.xlsx");
        }
    }
    protected void UploadBtn_Click(object sender, EventArgs e)
    {
        if (FileUpLoad1.HasFile)
        {
            HttpPostedFile myFile = FileUpLoad1.PostedFile;
            int nFileLen = myFile.ContentLength;
            TextLogs.WriteDebug("Subiendo Archivo");
            // make sure the size of the file is > 0
            if (nFileLen > 0)
            {
                try
                {
                    string strFilename = Path.GetFileName(myFile.FileName);
                    string ext = System.IO.Path.GetExtension(myFile.FileName);
                    string sDireccion = ConfigurationManager.AppSettings["DirExcel"].ToString();
                    FileUpLoad1.SaveAs(sDireccion + "CargaEmpleado" + ext);
                    string strSQL = "SELECT * FROM [Empleados$]";
                    CAD.ExcelConexion excel = new CAD.ExcelConexion();
                    DataSet resultado = excel.EjecutarConsulta(strSQL);
                    resultado.Tables[0].Columns.Add("CiCompleto", typeof(string));
                    for (int i = 0; i < resultado.Tables[0].Rows.Count; i++ )
                    {
                        resultado.Tables[0].Rows[i]["CiCompleto"] = string.Format("{0}{1}", resultado.Tables[0].Rows[i]["Ci"].ToString(), resultado.Tables[0].Rows[i]["Localidad"].ToString());
                    }
                    this.Context.Session["ClientesExcel"] = resultado;
                    dMensaje.Visible = true;
                    lblInfo.Text = resultado.Tables[0].Rows.Count.ToString();
                    ResultGrid.DataSource = resultado;
                    ResultGrid.DataBind();
                    btnImportar.Enabled = true;
                    UploadBtn.Enabled = false;
                }
                catch (Exception error)
                {
                    TextLogs.WriteError("No se pudo subir el excel importacion de clientes", error);
                }
            }
        }
        else
        {
            MensajeGuardado("Debe seleccionar un excel con los datos de clientes.");
        }
    }
    protected void btnImportar_Click(object sender, EventArgs e)
    {
        if (this.Context.Session["ClientesExcel"] != null)
        {
            TextLogs.WriteDebug("Iniciando importacion de clientes");
            DataSet dsCliente = (DataSet)this.Context.Session["ClientesExcel"];
            List<RN.Entidades.ClienteDistribucion> lstClientes = new List<RN.Entidades.ClienteDistribucion>();
            RN.Entidades.ClienteDistribucion objCliente;
            MembershipUser user = Membership.GetUser();
            foreach (DataRow Row in dsCliente.Tables[0].Rows)
            {
                if ((!string.IsNullOrEmpty(Row["nombre"].ToString())) & (!string.IsNullOrEmpty(Row["apellidos"].ToString())) & (!string.IsNullOrEmpty(Row["correo"].ToString())))
                {
                    try
                    {
                        objCliente = new RN.Entidades.ClienteDistribucion();
                        objCliente.Nombre = Row["nombre"].ToString();
                        objCliente.Apellidos = Row["apellidos"].ToString();
                        objCliente.Direccion = "";
                        objCliente.Telefono = "";
                        objCliente.Celular = "";
                        objCliente.Ci = Row["CiCompleto"].ToString();
                        objCliente.Correo = Row["correo"].ToString();
                        objCliente.Ocupacion = "";
                        objCliente.LugarTrabajo = "";
                        objCliente.TelefonoTrabajo = "";
                        objCliente.CorreoTrabajo = "";
                        //if (!string.IsNullOrEmpty(Row["fechaNacimiento"].ToString()))
                        //    objCliente.FechaNacimiento = Convert.ToDateTime(Row["fechaNacimiento"].ToString());
                        //else
                        //    objCliente.FechaNacimiento = Convert.ToDateTime("01/01/1990");
                        objCliente.Genero = "M";
                        objCliente.EstadoCivil = "s";
                        objCliente.FechaNacimiento = Convert.ToDateTime("01/01/1990");
                        //if (!string.IsNullOrEmpty(Row["tieneHijos"].ToString()))
                        //{
                        //    if((Row["tieneHijos"].ToString()=="si") || (Row["tieneHijos"].ToString() == "SI"))  
                        //        objCliente.TieneHijos = true;
                        //    else
                        //        objCliente.TieneHijos = false;
                        //}
                        //else
                        //    objCliente.TieneHijos = false;
                        objCliente.TieneHijos = false;
                        //if (!string.IsNullOrEmpty(Row["numeroHijos"].ToString()))
                        //    objCliente.NumeroHijos = Convert.ToInt32(Row["numeroHijos"].ToString());
                        //else
                        objCliente.NumeroHijos = 0;
                        if (string.IsNullOrEmpty(Row["empresaId"].ToString()))
                            objCliente.EmpresaId = 0;
                        else
                            objCliente.EmpresaId = Convert.ToInt32(Row["empresaId"].ToString());
                        objCliente.FechaIngreso = Convert.ToDateTime(Row["fechaIngreso"].ToString());
                        if (string.IsNullOrEmpty(Row["fechaInicio"].ToString()))
                        {
                            objCliente.FechaInicio = Convert.ToDateTime("01/01/1900");
                        }
                        else
                            objCliente.FechaInicio = Convert.ToDateTime(Row["fechaInicio"].ToString());
                        objCliente.RecibirNotificaciones = true;
                        objCliente.UsuarioId = user.ProviderUserKey.ToString();
                        objCliente.Fecha = DateTime.Now;
                        objCliente.Estado = "a";
                        if (string.IsNullOrEmpty(Row["distribucion"].ToString()))
                            objCliente.Distribucion = 0;
                        else
                            objCliente.Distribucion = Convert.ToInt32(Row["distribucion"].ToString());
                        lstClientes.Add(objCliente);
                    }
                    catch (Exception error)
                    {
                        TextLogs.WriteError("No se pudo cargar los datos del cliente", error);
                        MensajeGuardado("Existe un error en los datos del excel.");
                    }
                }
            }
            if (lstClientes.Count != 0)
            {
                try
                {
                    if (RN.Workflows.WCliente.InsertarFecha(lstClientes))
                    {
                        TextLogs.WriteDebug("Insertando listado de clientes");
                        MensajeGuardado("Se has importado los clientes satosfactoriamente.");
                        this.Context.Session["ClientesExcel"] = null;
                        ResultGrid.DataSource = null;
                        ResultGrid.DataBind();
                        btnImportar.Enabled = false;
                        UploadBtn.Enabled = true;
                        lblInfo.Text = "0";
                    }
                    else
                    {
                        MensajeGuardado("Existe un error en los datos del excel.");                        
                    }
                }
                catch (Exception error)
                {
                    TextLogs.WriteError("No se pudo cargar los datos del cliente", error);
                    MensajeGuardado("Existe un error en los datos del excel.");
                    UploadBtn.Enabled = true;
                    btnImportar.Enabled = false;
                }
            }
            else
            {
                MensajeGuardado("No ha cargado datos en el excel.");
            }
        }
    }
    private void MensajeGuardado(string mensaje)
    {
        string script = string.Format(@"$.msgBox('" + mensaje + "');");
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), UniqueID, script, true);
    }

}