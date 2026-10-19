using System.Diagnostics;
using ContactBook.Interfaces;
using ContactBook.Models;
using ContactBook.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactService _contactService;
        

        public HomeController(ILogger<HomeController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var contacts = _contactService.GetAll();
            return View(contacts);
        }

        public IActionResult ContactDetail(int id)
        {
            return View(_contactService.GetById(id));
        }
        [HttpPost] 
        public IActionResult ContactDetail(Contact contact)
        {
            _contactService.Update(contact);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ContactDelete(int id)
        {
            _contactService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _contactService.Add(contact);
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
