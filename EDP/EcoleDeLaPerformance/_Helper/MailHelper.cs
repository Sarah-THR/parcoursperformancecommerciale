using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace EcoleDeLaPerformance.Ui.Helper
{
    public class MailHelper
    {
        public void EnvoiMail(string supervisorMail, string userName, DateOnly startDate, DateOnly endDate)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("10.255.10.40")
                {
                    // Setup SmtpServer
                    Port = 25,
                    UseDefaultCredentials = false,
                    EnableSsl = false,
                    Credentials = null
                };

                mail.IsBodyHtml = true;
                mail.From = new MailAddress("ecoleperformance@xefi.fr");
                mail.To.Add(supervisorMail);

                mail.Subject = $"Ecole de la Performance Commercial - Briefing du {startDate.ToString("dd/MM/yyyy")}-{endDate.AddDays(-3).ToString("dd/MM/yyyy")} ";

                mail.Body = $@"<p>Bonjour,</p> <p>{userName} vient de mettre à jour son Briefing du {startDate.ToString("dd/MM/yyyy")}-{endDate.AddDays(-3).ToString("dd/MM/yyyy")}.</p> <p>Lien : https://ecoledelaperformance.xefi.fr/</p> <p>Bonne journée.</p>";

                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("-----------------");

                Console.WriteLine(ex.Message);
            }


        }

        public void SendMailNewAccount(string newAccountMail, string newAccountName, string creatorName, string creatorMail)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("10.255.10.40")
                {
                    // Setup SmtpServer
                    Port = 25,
                    UseDefaultCredentials = false,
                    EnableSsl = false,
                    Credentials = null
                };

                mail.IsBodyHtml = true;
                mail.From = new MailAddress(creatorMail, creatorName);
                mail.To.Add("s.tahar@xefi.fr");

                mail.Subject = $"Accès Ecole de la performance commerciale";

                mail.Body = $@"<p>Bonjour {newAccountName},</p> 
                            <p>Tu peux maintenant te connecter à la plateforme Ecole de la performance commerciale avec tes identifiants Microsoft. 😊</p> 
                            <p>Voici le lien pour te connecter : </p> <a href='https://ecoledelaperformance.xefi.fr'>https://ecoledelaperformance.xefi.fr</a>
                            <p>Bonne journée ! </p>";

                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("-----------------");

                Console.WriteLine(ex.Message);
            }


        }
    }
}
