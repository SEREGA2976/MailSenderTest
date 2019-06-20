using System;
using System.Net;
using System.Net.Mail;
namespace MailSenderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //SmtpClient client = new SmtpClient("smtp yandex", 25);
            // MailMessage msg = new MailMessage();
            using (var client = new SmtpClient("smtp yandex", 25)
            {
                Credentials = new NetworkCredential("UserName", "Password"),
                EnableSsl = true
            })
            {
                using (var msg = new MailMessage
                {
                    From = new MailAddress("sender@yandex.ru", "Отправитель"),
                    To =
                {
                    new MailAddress("recipient@gmail.com", "Получатель")

                },
                    Subject = "Тема письма",
                    Body = "Тело письма",
                    Attachments =
                {
                    new Attachment("FileName.zip")
                }
                })
                {
                    client.Send(msg);
                    client.Dispose();
                    msg.Dispose();
                }
            }

        }

    }
}
