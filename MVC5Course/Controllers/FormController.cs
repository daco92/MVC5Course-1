using System.Web.Mvc;
using System.Linq;

namespace MVC5Course.Controllers
{
    public class FormController : BaseController
    {
        // GET: Form
        public ActionResult Index()
        {
            ViewData.Model = db.Product.OrderBy(c => c.ProductId).Take(20);
            return View();
        }

        
        public ActionResult Edit(int id)//一樣有ModelBinding，只有id
        {
            ViewData.Model = db.Product.Find(id);
            return View();
        }


        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)//全部的modelBinding
        {
            var product = db.Product.Find(id);
            if (TryUpdateModel(product,includeProperties:new string[] { "ProductName" }))
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}