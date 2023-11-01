using Web_Api_Repository.Models.Domain;

namespace Web_Api_Repository.Repository.IService
{
    public interface IStudentService
    {
        Task<Student> CreateAsync(Student student);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetById(int id);
        Task<Student> UpdateAsync(Student student);
        Task<Student> DeleteAsync(int id);
    }
}
