using Hangar.Restaurant.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Hangar.Restaurant.Repository
{
    public class MailRepository : IMail
    {
        public void Contact(string email, string message)
        {
            throw new NotImplementedException();
        }

        public async Task ReservationAsync(string email, string name, DateTime dateAndTime, int person)
        {
            MailAddress from = new MailAddress("info@mail.restaurant");
            MailAddress to = new MailAddress(email);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Reservation at restaurant";
            message.IsBodyHtml = true;
            message.Body = "<h1>Live Dinner Restaurant<h1><br>" +
                "<h2>Dear Mr/Mrs " + name + ",</h2>" +
                "<h3>A table have been reserved for you. Hereunder are the details:</h3>" +
                "<h4>Name: " + name + "</h4>" +
                "<h4>Date: " + dateAndTime.Day + "/" + dateAndTime.Month + "/" + dateAndTime.Year + "</h4>" +
                "<h4>Time: " + dateAndTime.TimeOfDay + "</h4>" +
                "<h4>No. of person(s): " + person + "</h4>" +
                "<h4>Thank you.</h4>";

            SmtpClient smtp = new SmtpClient();
            await smtp.SendMailAsync(message);
        }

        public void Subscribe(string email)
        {
            throw new NotImplementedException();
        }
    }
}