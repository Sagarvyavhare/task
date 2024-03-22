using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using nikhilTask.Models;

namespace nikhilTask.services
{
    public class CustomerService : ICustomer
    {
        readonly private NikhilTaskContext _db;
        readonly private IFile _file;
        public CustomerService()
        {
            //_db = new NikhilTaskContext();
            //_file = new FileService();
        }
        public CustomerService(IFile file, NikhilTaskContext db)
        {
            _db = db;
            _file = file;
        }
        
        
        public async Task<string> Add(Customer customer)
        {
            try
            {
                await _db.Customers.AddAsync(customer);
                await _db.SaveChangesAsync();
                return "Customer Added";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        
        
        public string Delete(int id)
        {
            var customer =_db.Customers.Find(id);
            if (customer != null)
            {
                var address =_db.Addresstbls.FirstOrDefault(address=> address.Id.Equals(customer.Addressid));
                _db.Customers.Remove(customer);
                _db.Addresstbls.Remove(address);
                _file.DeleteFile(customer.Thumbnailurl);
                _db.SaveChanges();
            }
            return "customer deleted";
        }
        public string Update(Customer customer)
        {
            try
            {
                Addresstbl? address = customer.Address;
                customer.Address = null;
                 _db.SaveChanges();
                 return "Customer updated";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public List<Customer> GetAll()
        {
            return _db.Customers.ToList();
        }
        
        public Customer GetById(int id)
        {
            Customer customer = null;
            customer = _db.Customers.Find(id);
            customer.Address = _db.Addresstbls.FirstOrDefault(address => address.Id.Equals(customer.Addressid));
            return customer;
        }
    }
}
