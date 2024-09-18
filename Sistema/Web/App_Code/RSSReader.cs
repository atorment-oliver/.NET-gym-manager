using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Instrumentacion;

public class RSSReader
{
    private string url;
    private decimal compra;
    private decimal venta;
    private DateTime fecha;

    public string URL
    {
        get { return url; }
        set { url = value; }
    }
    public decimal Compra
    {
        get { return compra; }
        set { compra = value; }
    }
    public decimal Venta
    {
        get { return venta; }
        set { venta = value; }
    }
    public DateTime Fecha
    {
        get { return fecha; }
        set { fecha = value; }
    }
	public RSSReader()
	{
        url = string.Empty;
        compra = 1;
        venta = 1;
        fecha = DateTime.MinValue;
	}

    public void LoadXML()
    {
        try
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new Exception("No se ingreso una URL para buscar el XML del BCB.");
            }

            TextLogs.WriteInfo("Recuperando XML del Banco Central");
            TextLogs.WriteDebug("Recuperando XML de la página del Banco Central: " + url);
            using (XmlReader reader = XmlReader.Create(url))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(reader);
                TextLogs.WriteInfo("XML Cargado.");
                TextLogs.WriteDebug(xmlDoc.InnerText);

                TextLogs.WriteInfo("Recuperando Tag 'Descripcion' del XML.");
                XmlNodeList list = xmlDoc.GetElementsByTagName("description");
                if (list == null)
                {
                    TextLogs.WriteError("Error al recuperar campos del XML.", new Exception("No se encontró ningún Tag 'Descripcion' en el XML."));
                    return;
                }
                                
                TextLogs.WriteInfo("Se encontró Tag 'Descripcion' en el XML.");
                TextLogs.WriteDebug("Se encontrarón " + list.Count + " Tags 'Descripcion' en el XML.");

                if (list.Count < 2)
                {
                    TextLogs.WriteError("Error al recuperar campos del XML.", new Exception("El XML no contiene 2 Tags 'Descripcion'."));
                    return;
                }

                TextLogs.WriteInfo("Recuperando el segundo Tag 'Descripcion' del XML, ya que en el formato del BCB en este están los tipos de cambio de Compra y Venta.");
                string text = list[1].InnerText;
                TextLogs.WriteDebug("Contenido del 2do Tag 'Descripcion' del XML: " + text);

                char[] separador = { ';' };
                string[] items = text.Split(separador, StringSplitOptions.RemoveEmptyEntries);

                if (list.Count < 3)
                {
                    TextLogs.WriteError("Error al recuperar campos del XML.", new Exception("El XML no contiene 3 elementos en el Tags 'Descripcion' que deberia contener la Fecha, tipo de cambio de compra y tipo de camboi de venta."));
                    return;
                }

                TextLogs.WriteInfo("Cargando la Fecha.");
                text = items[0];
                TextLogs.WriteInfo("Formateando la Fecha.");
                try
                {
                    fecha = Convert.ToDateTime(text.Remove(0, 6));
                }
                catch (Exception x)
                {
                    TextLogs.WriteError("No se pudo formatear la fecha con el texto: " + text, x);
                }                

                TextLogs.WriteInfo("Cargando tipo de cambio de Venta.");
                text = items[1];
                TextLogs.WriteInfo("Formateando tipo de cambio de Venta.");
                try
                {
                    venta = Convert.ToDecimal(items[1].Remove(0, 8));
                }
                catch (Exception x)
                {
                    TextLogs.WriteError("No se pudo formatear el tipo de cambio de Venta con el texto: " + text, x);
                }

                TextLogs.WriteInfo("Cargando tipo de cambio de Compra.");
                text = items[2];
                TextLogs.WriteInfo("Formateando tipo de cambio de Compra.");
                try
                {
                    compra = Convert.ToDecimal(items[2].Remove(0, 9));
                }
                catch (Exception x)
                {
                    TextLogs.WriteError("No se pudo formatear el tipo de cambio de Compra con el texto: " + text, x);
                }
            }
        }
        catch (Exception x)
        {
            TextLogs.WriteError("No se pudo recuperar el tipo de cambio del Banco Central: " + url, x);
        }
    }
}