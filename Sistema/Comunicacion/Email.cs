using System;
using System.Net.Mail;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Comunicacion
{
    public class Email
    {
        private List<string> to;
        private List<string> cc;
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="pos">Posición</param>
        /// <returns>Destinatario</returns>
        public string this[int pos]
        {
            get 
            {
                return to[pos];
            }
            set 
            {
                to.Insert(pos, value);
            }
        }
        
        public List<string> To
        {
            get
            {
                return to;
            }
            set 
            {
                to = value;
            }
        }
        public List<string> Cc
        {
            get
            {
                return cc;
            }
            set
            {
                cc = value;
            }
        }
        public Email()
        {
            to = new List<string>();
            cc = new List<string>();
        }
        public void SendMail(bool html, string asunto, string mensaje)
        {
            SmtpClient client = new SmtpClient();
            Debug.WriteLine(client.Host);
            MailMessage msn = new MailMessage();
            Debug.WriteLine(msn.From.Address);

            AddTo(msn, to);
            AddCc(msn, cc);

            if (msn.To.Count <= 0)
                throw new SmtpException("No se definieron destinatarios");

            msn.Body = mensaje;
            msn.Subject = asunto;
            msn.IsBodyHtml = html;
            try
            {
                client.Send(msn);
            }
            catch (Exception x)
            {
                string s = x.Message;
            }
            
        }
        private void AddTo(MailMessage mensaje, List<string> to)
        {
            foreach (string mail in to)
            {
                if (ValidarEmail(mail))
                    mensaje.To.Add(mail);
            }
        }
        private void AddCc(MailMessage mensaje, List<string> cc)
        {
            foreach (string mail in cc)
            {
                if (ValidarEmail(mail))
                    mensaje.CC.Add(mail);
            }
        }
        private bool ValidarEmail(string email)
        {
            string strPattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex regProxy = new Regex(strPattern);
            return regProxy.IsMatch(email);
        }
    }
}
