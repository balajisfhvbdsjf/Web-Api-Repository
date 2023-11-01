using Web_Api_Repository.Models.Domain;

namespace Web_Api_Repository.Repository.IService
{
    public interface IEmployeeService
    {
        Task <Employee> CreateAsync (Employee employee);
        Task<IEnumerable<Employee>> GetAllAsync ();
        Task<Employee> GetById(Guid id);
        Task<Employee>UpdateAsync (Employee employee);
        Task<Employee> DeleteAsync(Guid id);
    }
}
