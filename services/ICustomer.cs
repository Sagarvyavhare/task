using nikhilTask.Models;

namespace nikhilTask.services
{
    public interface ICustomer
    {
        Task<String> Add(Customer customer);
        String Update(Customer customer);
        String Delete(int id);
        List<Customer> GetAll();
        Customer GetById(int id);
    }
}
