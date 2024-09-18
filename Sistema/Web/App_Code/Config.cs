using System;
using System.Web;

public class Config
{
	public Config()
	{
	}
    public static string GetPath(string address)
    {
        string link = AppSettings.GetParamValue("LINK");
        return string.Format("{0}{1}", link , address);
    }
}