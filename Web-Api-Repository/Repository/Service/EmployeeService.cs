using Microsoft.EntityFrameworkCore;
using Web_Api_Repository.DbContexts;
using Web_Api_Repository.Models.Domain;
using Web_Api_Repository.Repository.IService;

namespace Web_Api_Repository.Repository.Service
{
    public class EmployeeService:IEmployeeService
    {
        private readonly StudentDbContext _dbContext;

        public EmployeeService(StudentDbContext dbContext )
        {
           _dbContext = dbContext;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            await _dbContext.Employees.AddAsync( employee );
            await _dbContext.SaveChangesAsync();    
            return employee;
        }
        public async Task<IEnumerable<Employee>>GetAllAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }
        public async Task<Employee> GetById(Guid id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync( x => x.Id == id );
        }
        public async Task<Employee>UpdateAsync(Employee employee)
        {
            var existingEmployee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
            if (existingEmployee != null)
            {
                _dbContext.Entry(existingEmployee).CurrentValues.SetValues(employee);
                await _dbContext.SaveChangesAsync();
                return employee;
            }
            return null;
        }
        public async Task<Employee> DeleteAsync(Guid id)
        {
            var existingEmployee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if(existingEmployee != null)
            {
                _dbContext.Employees.Remove(existingEmployee);
                await _dbContext.SaveChangesAsync();
                return existingEmployee;
            }
                else
            {
                return existingEmployee;
            }
        }

    }
}
