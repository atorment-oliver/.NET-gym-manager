using System;
using System.Web;
using Configuration;
using System.Configuration;
using SystemConfig;

public class AppSettings
{
    private static readonly string TipoCambio = "Contable.TipoCambio";
	public AppSettings()
	{
	}
    public static int GetPasswordRecoveryLength
    {
        get
        {
            SystemSection section = ConfigurationManager.GetSection("systemManagement") as SystemSection;
            return section.RecoveryPasswordLength;
        }
    }
    public static string GetSystemVersion
    {
        get
        {
            SystemSection section = ConfigurationManager.GetSection("systemManagement") as SystemSection;
            return section.VersionSistema.Numero;
        }
    }
    public static string GetDBVersion
    {
        get
        {
            RN.Entidades.Version version = RN.Componentes.CVersion.ObtenerUltimaVersion();
            if (version == null)
                return string.Empty;
            return version.Numero;
        }
    }
    public static bool isCorrectVersion
    {
        get
        {
            char []separator = {'.'};
            string []listDBVersion = GetDBVersion.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] listSystemVersion = GetSystemVersion.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            string bdVersion = string.Empty;
            string systemVersion = string.Empty;

            if (listDBVersion.Length > 2)
                bdVersion = string.Format("{0}.{1}", listDBVersion[0], listDBVersion[1]);

            if (listSystemVersion.Length > 2)
                systemVersion = string.Format("{0}.{1}", listSystemVersion[0], listSystemVersion[1]);

            return bdVersion.Equals(systemVersion);
        }
    }
    public static string GetRevisionID
    {
        get
        {
            SystemSection section = ConfigurationManager.GetSection("systemManagement") as SystemSection;
            return section.RevisionCaja.Id;
        }
    }
    public static bool IsLoginAutomatic
    {
        get
        {
            SystemSection section = ConfigurationManager.GetSection("systemManagement") as SystemSection;
            return section.Login.Type == Login.LoginTypes.Automatic;
        }
    }
    public static bool SendCopy
    {
        get
        {
            MailManagementSection section = ConfigurationManager.GetSection("mailManagement") as MailManagementSection;
            return section.SendCopy;
        }
    }
    public static bool SendHtml
    {
        get
        {
            MailManagementSection section = ConfigurationManager.GetSection("mailManagement") as MailManagementSection;
            return section.SendHTML;
        }
    }
    public static Configuration.Template GetTemplate(string name)
    {
        MailManagementSection section = ConfigurationManager.GetSection("mailManagement") as MailManagementSection;
        foreach (Template template in section.Templates)
        {
            if (template.Name.ToLower() == name.ToLower())
                return template;
        }
        return null;
    }
    public static string GetParamValue(string name)
    {
        MailManagementSection section = ConfigurationManager.GetSection("mailManagement") as MailManagementSection;
        foreach (Param param in section.Params)
        {
            if (param.Name.ToLower() == name.ToLower())
                return param.Value;
        }
        return string.Empty;
    }
    public static string LoadFile(string name)
    {
        System.IO.StreamReader reader = new System.IO.StreamReader(HttpContext.Current.Server.MapPath("../Templates/" + name));
        string file = reader.ReadToEnd();
        reader.Close();

        file = file.Replace("[EMPRESA]", GetParamValue("EMPRESA"));
        file = file.Replace("[LINK]", GetParamValue("LINK"));
        return file;
    }
    public static string ParametroTipoCambio()
    {
        return TipoCambio;
    }
}