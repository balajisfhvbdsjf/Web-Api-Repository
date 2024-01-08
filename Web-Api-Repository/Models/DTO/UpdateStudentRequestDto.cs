﻿namespace Web_Api_Repository.Models.DTO
{
    public class UpdateStudentRequestDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public string Password { get; set; }
    }
}
