using HomeTask.Data;
using HomeTask.Models;
using System.Web.Mvc;

namespace HomeTask.Controllers
{
    public class HomeController : Controller
    {
        private static PersonRepo repository = new PersonRepo();

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

        [HttpGet]
        public ActionResult CreateUserQuery()
        {
            Person person = new Person();
            if (TryUpdateModel(person, new QueryStringValueProvider(this.ControllerContext)))
            {
                repository.Add(person);
            }
            return RedirectToAction("Index");
        }
    }
}