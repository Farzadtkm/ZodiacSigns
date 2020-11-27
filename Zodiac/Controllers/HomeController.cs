using Microsoft.AspNetCore.Mvc;
using Zodiac.Models;
using Zodiac.Domain.Services;
using Microsoft.Extensions.Logging;
using System;

namespace Zodiac.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IEmailSender emailSender, ILogger<HomeController> logger)
        {
            _emailSender = emailSender;

            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ZodiacSigns()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(ContactUsViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var body = $"<p><b>Name</b> = {model.Name} </p>" +
                              $"<p><b>Phone Number</b> = {model.PhoneNumber} </p>" +
                              $"<p><b>Content</b> = {model.Text} </p>";

                _emailSender.Send("farzad.tkm@gmail.com", "zodiac contact", body);

                TempData["Message"] = "Message has been successfully send";
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "an error occured while sending a mail");

                TempData["Message"] = "an error occured while sending your message";
            }

            return RedirectToAction("ContactUs");
        }
    }
}
