using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<Customer> Get()
        {
            var Customers = db.Customers.Include("MemberShipType").ToList();
            return Customers;
        }

        public Customer Get(int id)
        {
            var Customer = db.Customers.Include("MemberShipType").SingleOrDefault(c => c.ID == id);

            return Customer;
        }
        [HttpDelete]
        public void Delete(int id)
        {
            var customerinDb = Get(id);
            db.Customers.Remove(customerinDb);
            db.SaveChanges();

        }





    }
}
