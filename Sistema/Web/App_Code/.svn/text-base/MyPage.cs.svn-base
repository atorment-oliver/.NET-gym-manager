using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Globalization;
using Instrumentacion;

public class MyPage : System.Web.UI.Page
{
	public MyPage()
	{
		
	}
    protected override void InitializeCulture()
    {        
        string strLenguaje = this.Session["strIdioma"].ToString();
        TextLogs.WriteDebug("Estableciendo idioma " + strLenguaje + " al sistema");
        Thread.CurrentThread.CurrentCulture = new CultureInfo(strLenguaje);
        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        base.InitializeCulture();
    }
}