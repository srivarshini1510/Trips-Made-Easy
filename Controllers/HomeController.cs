using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Net.Mail;
using System.Linq;
using Microsoft.AspNet.Identity;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Controllers
{
    public class HomeController : Controller
    {
        private HotelReservationEntities1 hotelent=new HotelReservationEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Chennai()
        {

            return View();
        }
        public ActionResult Mumbai()
        {

            return View();
        }
        public ActionResult Banglore()
        {

            return View();
        }
        public ActionResult Hotel(string hotelnm)
        {
            var hotels = (from h in hotelent.hotels
                          where h.hotelname == hotelnm
                          select h).FirstOrDefault();
            HotelViewModel hm = new HotelViewModel();
            hm.hotelnm = hotelnm;
            hm.description = hotels.description;
            hm.amenities = hotels.amenities;
            hm.roomdetails = hotels.roomdetails;
            hm.imagenm = hotels.imagenm;
            hm.address = hotels.address;
            return View(hm);
        }
        public void Email(string hotelnm, string fromdate, string todate)
        {
           
                MailMessage mail = new MailMessage();
                var user = User.Identity.GetUserName();
                mail.To.Add(user);

                mail.From = new MailAddress("subhasrinarain@gmail.com");
                mail.Subject = hotelnm + " - Your Booking has been confirmed";
                string Body = "Hi " + user +
                    "Greetings from TripsMadeEasy.com. Your booking with " + hotelnm + " from " + fromdate + " to " + todate + " has been confirmed. Also please find below the emergency link. When you click on the link, your emergency contacts as well as the hotel personnals will be alerted for immediate help."
                    + "https://emergencylink";
                mail.Body = Body;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("subhasrinarain@gmail.com ", "loudspeaker123");

                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;
                smtp.Send(mail);
              
            
           
            
        }
    }
}