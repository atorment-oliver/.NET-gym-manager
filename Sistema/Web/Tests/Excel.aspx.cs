using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class Tests_Excel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {           
        string strSQL = "SELECT * FROM [Empleados$]";

        CAD.ExcelConexion excel = new CAD.ExcelConexion();
        DataSet resultado = excel.EjecutarConsulta(strSQL);
        
        grdDatos.DataSource = resultado;
        grdDatos.DataBind();

    }
}