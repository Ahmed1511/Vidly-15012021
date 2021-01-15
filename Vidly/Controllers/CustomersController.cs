using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            var customer = new Customer();
            var MemberShipTypes = db.MemberShipTypes.ToList();
            NewCustomerViewModel customerViewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MemberShipTypes = MemberShipTypes
            };
            return View(customerViewModel);
        }

        public ActionResult Create(NewCustomerViewModel customerViewModel)
        {
            Customer customer = new Customer()
            {
                ID = customerViewModel.Customer.ID,
                Name = customerViewModel.Customer.Name,
                DateofBirth = customerViewModel.Customer.DateofBirth,
                Issubscribed = customerViewModel.Customer.Issubscribed,
                MemberShipType = customerViewModel.Customer.MemberShipType,
                MembershipTypeID = customerViewModel.Customer.MembershipTypeID


            };
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("index");

            }
            return View(customerViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.ID == id);
            var memberships = db.MemberShipTypes.ToList();
            NewCustomerViewModel customerViewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MemberShipTypes = memberships

            };

            return View("create", customerViewModel);
        }

        public ActionResult Edit(NewCustomerViewModel customerViewModel)
        {
            Customer customer = new Customer
            {
                ID = customerViewModel.Customer.ID,
                Name = customerViewModel.Customer.Name,
                DateofBirth = customerViewModel.Customer.DateofBirth,
                Issubscribed = customerViewModel.Customer.Issubscribed,
                MemberShipType = customerViewModel.Customer.MemberShipType,
                MembershipTypeID = customerViewModel.Customer.MembershipTypeID
            };
            customerViewModel.MemberShipTypes = db.MemberShipTypes.ToList();
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(customerViewModel);
        }
    }
}