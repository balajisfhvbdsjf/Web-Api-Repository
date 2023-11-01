namespace Web_Api_Repository.Models.DTO
{
    public class CreateStudentRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }

    }
}
