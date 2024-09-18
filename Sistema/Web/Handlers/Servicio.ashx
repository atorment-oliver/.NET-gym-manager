<%@ WebHandler Language="C#" Class="Servicio" %>

using System;
using System.Web;
using System.Text;
using System.Data;

public class Servicio : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        StringBuilder resultado = new StringBuilder();
        RN.Entidades.Cliente daoComercio = new RN.Entidades.Cliente();
        string queryComercio = context.Request.QueryString["q"];

        if (string.IsNullOrEmpty(queryComercio))
            return;

        System.Collections.Generic.List<RN.Entidades.Servicio> dtCliente = RN.Componentes.CServicio.TraerXCriterio(queryComercio, string.Empty, "1");

        foreach (RN.Entidades.Servicio row in dtCliente)
        {
            resultado.Append(row.Nombre.ToString() + "|" + row.Id.ToString() + "|" + row.Cupo.ToString()).Append(Environment.NewLine);
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