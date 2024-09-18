using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Instrumentacion;

public partial class Account_PasswordRecovery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.SetFocus(UserName);
    }
    protected void PasswordRecovery_Click(object sender, EventArgs e)
    {
        Comunicacion.Email mail = new Comunicacion.Email();
        Helper.Member member = AppSecurity.GetUser(UserName.Text.Trim());
        string newPassword = GenerateRandomPassword();

        if (member == null || AppSecurity.UserIsDeleted(UserName.Text.Trim()))
        {
            TextLogs.WriteDebug("Se ingresó un nombre de usuario inexistente: " + UserName.Text);
            TextLogs.WriteError("Error:", new Exception("El nombre de usuario ingresado no existe."));
            SetInformation(Helper.MessageType.Error, "El nombre de usuario ingresado no existe en el sistema.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            return;
        }

        if (!member.IsApproved || member.IsLockedOut)
        {
            TextLogs.WriteDebug("El usuario: " + UserName.Text + " se encuentra bloqueado. Acceso al sistema: " + member.IsApproved + " Bloqueo: " + member.IsLockedOut);
            TextLogs.WriteError("Error:", new Exception("El usuario ingresado se encuentra bloqueado."));
            SetInformation(Helper.MessageType.Error, "El usuario ingresado se encuentra bloqueado por cantidad de intentos fallidos o bloqueado por el administrador del sistema.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            return;
        }

        if (string.IsNullOrEmpty(member.Email))
        {
            TextLogs.WriteDebug("El usuario " + UserName.Text + " no cuenta con un correo electrónico registrado.");
            TextLogs.WriteError("Error:", new Exception("El usuario no cuenta con un correo electrónico registrado."));
            SetInformation(Helper.MessageType.Error, "Este usuario no cuenta con un correo electrónico registrado. <br/>Por favor comuniquese con el administrador del sistema para que registre su correo electrónico.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            return;
        }

        if (AppSecurity.ChangePassword(UserName.Text, newPassword))
        {
            TextLogs.WriteDebug("Se generó una nueva contraseña de acceso para el usuario: " + UserName.Text);
            TextLogs.WriteInfo("Preparando para enviar correo al usuario.");
            mail.To.Add(member.Email);

            TextLogs.WriteInfo("Iniciando recuperación del template 'PasswordRecovery' del web.config.");
            Configuration.Template template = AppSettings.GetTemplate("PasswordRecovery");
            if (template == null)
            {
                TextLogs.WriteInfo("No se pudo recuperar el template 'PasswordRecovery' del web.config.");
                SetInformation(Helper.MessageType.Error, "Ocurrió un error al recuperar la plantilla de correo para enviar el mail de cambio de contraseña. <br/>Por favor intente comuniquese con el administrador del sistema.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                return;
            }
            TextLogs.WriteDebug("Iniciando carga del archivo de texto " + template.File + " a memoria.");
            TextLogs.WriteInfo("Iniciando carga del archivo de texto a memoria.");
            string file = AppSettings.LoadFile(template.File);
            TextLogs.WriteInfo("Reemplazando el password en el archivo.");
            file = file.Replace("[PASSWORD]", newPassword);

            TextLogs.WriteInfo("Preparando para enviar mail."); 
            TextLogs.WriteDebug("Preparando para enviar mail con el asunto: " + template.Subject);
            TextLogs.WriteDebug("El mail se enviará en formato HTML?: " + AppSettings.SendHtml);
            TextLogs.WriteDebug("El mail se enviará con copia: " + AppSettings.SendCopy);
            try
            {
                if (AppSettings.SendCopy)
                {
                    TextLogs.WriteDebug("La copia del mail se enviará a: " + template.CopyTo);
                    mail.Cc.Add(template.CopyTo);
                }
                TextLogs.WriteDebug("Contenido del mail cargado con la siguiente información:\r\n" + file);
                mail.SendMail(AppSettings.SendHtml, template.Subject, file);

                TextLogs.WriteInfo("Se envió a su correo electrónico una nueva contraseña de acceso al sistema.");
                SetInformation(Helper.MessageType.Info, "Se envío a su correo electrónico una nueva contraseña de acceso al sistema.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
            catch (Exception x)
            {
                TextLogs.WriteDebug("Se generó la contraseña: " + newPassword + " pero no se puedo enviar el mail al usuario " + UserName.Text);
                TextLogs.WriteError("Se generó la contraseña pero no se pudo enviar al usuario.", x);
                SetInformation(Helper.MessageType.Error, "Ocurrió un error al enviar la nueva contraseña. <br/>Por favor intente comuniquese con el administrador del sistema.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                return;
            }
        }
        else
        {
            TextLogs.WriteDebug("No se pudo generar una nueva contraseña de acceso para el usuario: " + UserName.Text);
            TextLogs.WriteError("Ocurrió un error al generar una nueva contraseña para el usuario.", new Exception("El sistema no pudo generar una nueva contraseña."));
            SetInformation(Helper.MessageType.Error, "Ocurrió un error al generar una nueva contraseña para el usuario. <br/>Por favor intente nuevamente o comuniquese con el administrador del sistema.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Default.aspx");
    }
    public void SetInformation(Helper.MessageType type, string message)
    {
        popupMessage.Text = message;
        switch (type)
        {
            case Helper.MessageType.Info:
                popupTitle.Text = "INFORMACION";
                break;
            case Helper.MessageType.Warning:
                popupTitle.Text = "ADVERTENCIA";
                break;
            case Helper.MessageType.Error:
                popupTitle.Text = "ERROR";
                break;
            default:
                break;
        }
    }
    private string GenerateRandomPassword()
    {
        int nroCaracteres = AppSettings.GetPasswordRecoveryLength;
        string newPassword = string.Empty;
        Random random = new Random();

        for (int pos = 0; pos < nroCaracteres; pos++)
        {            
            int number = random.Next(10);
            newPassword += number;
        }
        return newPassword;
    }
}