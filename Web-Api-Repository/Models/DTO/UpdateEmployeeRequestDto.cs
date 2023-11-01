namespace Web_Api_Repository.Models.DTO
{
    public class UpdateEmployeeRequestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public int Phone { get; set; }
        public DateTime DOB { get; set; }
    }
}
