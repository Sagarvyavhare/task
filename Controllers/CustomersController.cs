using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using nikhilTask.Models;
using nikhilTask.services;

namespace nikhilTask.Controllers
{
    public class CustomersController : Controller
    {
        readonly private ICustomer _customer;
        readonly private IFile _file;
        public CustomersController(ICustomer customer,IFile file) {
            _customer = customer;
            _file = file;
        }

        public IActionResult Index()
        {
            return View(_customer.GetAll());
        }
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer,IFormFile thumbnail)
        {
            customer.Createdtimestamp = DateTime.Now;
            customer.Lastupdatedtimestamp = DateTime.Now;
            if ((customer.Thumbnailurl=_file.SaveFile(thumbnail)).IsNullOrEmpty() || _customer.Add(customer).Equals(""))
            {
                TempData["error"] = "somthing went wrong";
                return View();
            }
            
            return RedirectToAction("index");
        }

        public IActionResult EditCustomer(int id)
        {
            return View(_customer.GetById(id));
        }

        [HttpPost]
        public IActionResult EditCustomer( Customer customer,IFormFile? thumbnail)
        {
            var user = _customer.GetById(customer.Id);
            customer.Lastupdatedtimestamp = DateTime.Now;
            if ( thumbnail != null && !user.Thumbnailurl.Contains(thumbnail.FileName))
            {
                _file.DeleteFile(user.Thumbnailurl);
                if ((customer.Thumbnailurl = _file.SaveFile(thumbnail)).IsNullOrEmpty() || _customer.Add(customer).Equals(""))
                {
                    TempData["error"] = "somthing went wrong";
                    return View();
                }
            }
            _customer.Update(customer);
            return View();
        }

        public IActionResult DeleteCustomer(int id)
        {
            _customer.Delete(id);
            return RedirectToAction("index");
        }
    }
}
