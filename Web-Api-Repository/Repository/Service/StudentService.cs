using Microsoft.EntityFrameworkCore;
using Web_Api_Repository.DbContexts;
using Web_Api_Repository.Models.Domain;
using Web_Api_Repository.Repository.IService;

namespace Web_Api_Repository.Repository.Service
{
    public class StudentService: IStudentService
    {
        private readonly StudentDbContext _dbContext;

        public StudentService(StudentDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            await _dbContext.Students.AddAsync( student );
            await _dbContext.SaveChangesAsync();
            return student;

        }
        public async Task<IEnumerable<Student>>GetAllAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }
        public async Task<Student> GetById(int id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Student> UpdateAsync(Student student)
        {
            var existingStudent=await _dbContext.Students.FirstOrDefaultAsync( x => x.Id == student.Id);
            if (existingStudent != null)
            {
                _dbContext.Entry(existingStudent).CurrentValues.SetValues(student);
                await _dbContext.SaveChangesAsync();
                return student;
            }
            return null;
        }
        public async Task<Student>DeleteAsync(int id)
        {
            var existingStudent=await _dbContext.Students.FirstOrDefaultAsync(x=>x.Id == id);
            if (existingStudent is not null)
            {
                _dbContext.Students.Remove(existingStudent);
                await _dbContext.SaveChangesAsync();
                return existingStudent;
            }
            else
            {
                return existingStudent;
            }
        }
    }
}
