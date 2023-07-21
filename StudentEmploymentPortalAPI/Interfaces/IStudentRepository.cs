﻿using StudentEmploymentPortalAPI.Models.DomainModels;

namespace StudentEmploymentPortalAPI.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> GetStudents();
    }
}
