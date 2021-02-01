using CustomerService.DTO;
using CustomerService.Model;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController: ControllerBase{
        private readonly CustomerDatabaseContext _customerDatabaseContext;
        public CustomerController(CustomerDatabaseContext context)
        {
            _customerDatabaseContext = context;
        }
        [HttpGet]
        public IActionResult Get(){
            var customers = this._customerDatabaseContext.Customers;
            if(customers!=null)
                return Ok(customers);
            return NotFound();
        }
        [HttpPost]
        public IActionResult Post([FromBody]CustomerDTO customer){
            this._customerDatabaseContext.Customers.Add(new Model.Entity.Customer{
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                Address = customer.Address,
                CustomerID = customer.CustomerID
            });
            this._customerDatabaseContext.SaveChanges();
            return Ok(customer);
        }
    }
}