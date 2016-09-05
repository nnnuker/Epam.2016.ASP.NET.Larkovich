using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication.Infrastructure;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ProductController : Controller
    {
        //public ProductController()
        //{
        //    this.ActionInvoker = new CustomActionInvoker();
        //}

        // GET: Product
        public ViewResult Index()
        {
            return View("Result", new Result
            {
                ControllerName = "Product",
                ActionName = "Index"
            });
        }

        [Local]
        [ActionName("Index")]
        public ViewResult LocalIndex()
        {
            return View("Result", new Result
            {
                ControllerName = "Product",
                ActionName = "LocalIndex"
            });
        }

        public ViewResult List()
        {
            return View("Result", new Result
            {
                ControllerName = "Product",
                ActionName = "List"
            });
        }

        public async Task<ActionResult> Data()
        {
            var data = await Task<string>.Factory.StartNew(() => {
                RemoteService service = new RemoteService();
                return service.GetRemoteData();
            });
            
            return View((object)data);
        }

        //public ActionResult Data()
        //{
        //    RemoteService service = new RemoteService();
        //    string data = service.GetRemoteData();
        //    return View((object)data);
        //}
    }
}