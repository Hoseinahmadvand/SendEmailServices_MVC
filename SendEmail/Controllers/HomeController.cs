using Microsoft.AspNetCore.Mvc;
using SendEmail.Helper;
using SendEmail.Models;

namespace SendEmail.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View("Index", new Contact());
        }
        [HttpPost]
        [Route("Send")]
        public IActionResult Send(Contact contact)
        {
            var IPaddress = HttpContext.Connection.RemoteIpAddress.ToString();

            string content = "نام و نام خانوادگی" + contact.Name;
            contact.Email = "ایمیل" + contact.Email;
            contact.Phone = "موبایل" + contact.Phone;
            contact.Adress = "آدرس" + contact.Adress;
            contact.Subject = "موضوع" + contact.Subject;
            contact.Content = "متن" + content;
            contact.IPCustomer = "IP" + IPaddress;
            if (MailHelper.Send(contact.Email, contact.Attachments, "coinb693@gmail.com", contact.Subject, content))
            {
                ViewBag.msg = "Success";
            }
            else
            {
                ViewBag.msg = "faild";
            }

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}