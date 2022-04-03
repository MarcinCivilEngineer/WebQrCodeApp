
using System;
using System.Collections.Generic;
using System.Linq;


using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using System.IO;

namespace WebBetardQRCodeLib
{
    public class LibMail
    {
        

        private string _smtp = "budowlaniec.home.pl";
        private int _smtpssl = 465;

        private string _pop3 = "budowlaniec.home.pl";
        private int _pop3ssl = 995;

        private string _user = "betard@budowlaniec.net";
        private string _pass = "BETmarcin123";

        public bool SendMail(string from, string toEmails, string dwEmails, string dwuEmails, string subject, string message, List<string> attaches=null)
        {

            var messageClass = new MimeMessage();

            if (from.Split(" ").ToList().Count() == 1)
            {
                messageClass.From.Add(new MailboxAddress(from, from));
            }
            else
            {
                messageClass.From.Add(new MailboxAddress(from.Replace(from.Split(" ")[0] + " ", ""), from.Split(" ")[0]));
            }

            if (toEmails != "")
            {
                foreach (string mail in toEmails.Split(", "))
                {
                    var mailSplit = mail.Split(" ").ToList();
                    if (mailSplit.Count() == 1)
                    {
                        messageClass.To.Add(new MailboxAddress(mail, mail));
                    }
                    else
                    {
                        messageClass.To.Add(new MailboxAddress(mail.Replace(mailSplit[0] + " ", ""), mailSplit[0]));
                    }
                }
            }


            if (dwEmails != "")
            {
                foreach (string mail in dwEmails.Split(", "))
                {
                    var mailSplit = mail.Split(" ").ToList();
                    if (mailSplit.Count() == 1)
                    {
                        messageClass.Cc.Add(new MailboxAddress(mail, mail));
                    }
                    else
                    {
                        messageClass.Cc.Add(new MailboxAddress(mail.Replace(mailSplit[0] + " ", ""), mailSplit[0]));
                    }
                }
            }

            if (dwuEmails != "")
            {
                foreach (string mail in dwuEmails.Split(", "))
                {
                    var mailSplit = mail.Split(" ").ToList();
                    if (mailSplit.Count() == 1)
                    {
                        messageClass.Bcc.Add(new MailboxAddress(mail, mail));
                    }
                    else
                    {
                        messageClass.Bcc.Add(new MailboxAddress(mail.Replace(mailSplit[0] + " ", ""), mailSplit[0]));
                    }
                }
            }

            //message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", "chandler@friends.com"));
            messageClass.Subject = subject;

            var body = new TextPart("html")
            {
                Text = message
            };

            var multipart = new Multipart("mixed");
            multipart.Add(body);

            if (attaches.Count() > 0)
            {
                foreach (var attach in attaches)
                {
                    var attachment = new MimePart()
                    {
                        Content = new MimeContent(File.OpenRead(attach), ContentEncoding.Default),
                        ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                        ContentTransferEncoding = ContentEncoding.Base64,
                        FileName = Path.GetFileName(attach)
                    };
                    multipart.Add(attachment);
                }
            }
            messageClass.Body = multipart;

            using (var client = new SmtpClient())
            {
                client.Connect(_smtp, _smtpssl, false);


                // Note: only needed if the SMTP server requires authentication

                if (_pass != "")
                {
                    client.Authenticate(_user,_pass );
                }
                //client.Authenticate(od, pass);
                client.Send(messageClass);

                client.Disconnect(true);
            }
            return true;

        }

    }
}
