namespace CompanyName.Identity.Infrastructure.Notification
{
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity.UI.Services;

    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var MailFrom = "email@gmail.com";//DependencyResolver.Current.GetService<IApplicationConfiguration>().GetAppSettingValueByKey(Core.AppSettingData.MailFrom);
            var MailUserName = "email@gmail.com";//DependencyResolver.Current.GetService<IApplicationConfiguration>().GetAppSettingValueByKey(Core.AppSettingData.MailUserName);
            var MailPWD = "P@$$w0rd";//DependencyResolver.Current.GetService<IApplicationConfiguration>().GetAppSettingValueByKey(Core.AppSettingData.MailPWD);
            var MailSMTP = "smtp.gmail.com";//DependencyResolver.Current.GetService<IApplicationConfiguration>().GetAppSettingValueByKey(Core.AppSettingData.MailSMTP);
            var MailPort = "587";//DependencyResolver.Current.GetService<IApplicationConfiguration>().GetAppSettingValueByKey(Core.AppSettingData.MailPort);
            var EnableSsl = "true";//DependencyResolver.Current.GetService<IApplicationConfiguration>().GetAppSettingValueByKey(Core.AppSettingData.EnableSsl);

            var client = new SmtpClient();
            var credential = new NetworkCredential
            {
                UserName = MailUserName,
                Password = MailPWD
            };
            client.UseDefaultCredentials = false;
            client.Credentials = credential;
            client.Host = MailSMTP;
            client.Port = int.Parse(MailPort);
            client.EnableSsl = bool.Parse(EnableSsl);
            var msg = new MailMessage()
            {
                From = new MailAddress(MailFrom),
                Body = htmlMessage,
                Subject = subject,
                IsBodyHtml = true
            };
            
            msg.To.Add(new MailAddress(email));
            
            return client.SendMailAsync(msg);
        }
    }
}
