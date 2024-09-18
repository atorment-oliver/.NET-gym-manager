<%@ WebHandler Language="C#" Class="Cliente" %>

using System;
using System.Web;
using System.Text;
using System.Data;

public class Cliente : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        StringBuilder resultado = new StringBuilder();
        RN.Entidades.Cliente daoComercio = new RN.Entidades.Cliente();
        string queryComercio = context.Request.QueryString["q"];

        if (string.IsNullOrEmpty(queryComercio))
            return;

        System.Collections.Generic.List<RN.Entidades.Cliente> dtCliente = RN.Componentes.CCliente.TraerXCriterio(queryComercio, string.Empty, string.Empty, "a");

        foreach (RN.Entidades.Cliente row in dtCliente)
        {
            resultado.Append(row.Nombre.ToString() + " " + row.Apellidos.ToString() + "|" + row.Id.ToString()).Append(Environment.NewLine);
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