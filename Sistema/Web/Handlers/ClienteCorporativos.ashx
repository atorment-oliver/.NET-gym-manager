<%@ WebHandler Language="C#" Class="ClienteCorporativos" %>

using System;
using System.Web;
using System.Text;
using System.Data;

public class ClienteCorporativos : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        StringBuilder resultado = new StringBuilder();
        RN.Entidades.Cliente daoComercio = new RN.Entidades.Cliente();
        string query = context.Request.QueryString["q"];
        
        DataTable clientes = RN.Componentes.CCliente.TraerConEmpresa(query);

        foreach (DataRow cliente in clientes.Rows)
        {
            resultado.Append(cliente["nombreCliente"].ToString() + "|" + cliente["id"].ToString()).Append(Environment.NewLine);
        }

        context.Response.ContentType = "text/plain";
        context.Response.Write(resultado.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}