using HomeTask.Data;
using HomeTask.Models;
using System.Web.Mvc;

namespace HomeTask.Controllers
{
    public class HomeController : Controller
    {
        private PersonRepo repository = new PersonRepo();

        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(FormCollection formData)
        {
            Person person = new Person();
            if (TryUpdateModel(person, formData))
            {
                repository.Add(person);
            }
            return RedirectToAction("Index");
        }
    }
}