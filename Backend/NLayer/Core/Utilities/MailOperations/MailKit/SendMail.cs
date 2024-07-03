using MimeKit;
using NLayer.Core.Entities.Authentication;
using MailKit.Net.Smtp;

namespace NLayer.Core.Utilities.MailOperations.MailKit;

public static class SendMail
{
    public static void SendConfirmCodeMail(int code, AppUser value)
    {
        MimeMessage mimeMessage = new MimeMessage();
        MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "omer1805.ok@gmail.com");
        MailboxAddress mailboxAddressTo = new MailboxAddress("User", value.Email);
        mimeMessage.From.Add(mailboxAddressFrom);
        mimeMessage.To.Add(mailboxAddressTo);
        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = "Kayıt işlemi gerçekleştirmek için onay kodunuz : " + code;
        mimeMessage.Body = bodyBuilder.ToMessageBody();
        mimeMessage.Subject = "Fantastic Universe Confirm Code";
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Connect("smtp.gmail.com", 587, false);
        smtpClient.Authenticate("omer1805.ok@gmail.com", "lvzs fsto vhkp cnia");
        smtpClient.Send(mimeMessage);
        smtpClient.Disconnect(true);
    }

    public static int GenerateConfirmCode()
    {
        Random random = new Random();
        return random.Next(100000, 1000000);
    }
}
