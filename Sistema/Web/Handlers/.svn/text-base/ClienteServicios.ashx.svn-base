<%@ WebHandler Language="C#" Class="ClienteCi" %>

using System;
using System.Web;
using System.Text;
using System.Data;

public class ClienteCi : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        StringBuilder resultado = new StringBuilder();
        RN.Entidades.Cliente daoComercio = new RN.Entidades.Cliente();
        string queryComercio = context.Request.QueryString["q"];

        if (string.IsNullOrEmpty(queryComercio))
            return;

        DataTable dtClientes = RN.Componentes.CCliente.TraerXOrCriterioPaquetesReporte(queryComercio, string.Empty, queryComercio, "a","");

        foreach (DataRow row in dtClientes.Rows)
        {
            resultado.Append(row["nombre"].ToString() + " " + row["apellidos"].ToString() + " - " + row["ci"].ToString() + " - " + row[8].ToString() + "|" + row["id"].ToString()).Append(Environment.NewLine);
        }

        context.Response.ContentType = "text/plain";
        context.Response.Write(resultado.ToString());
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}