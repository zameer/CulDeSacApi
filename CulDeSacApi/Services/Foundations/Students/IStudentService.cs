﻿using CulDeSacApi.Models.Students;

namespace CulDeSacApi.Services.Foundations.Students
{
    public interface IStudentService
    {
        ValueTask<Student> AddStudentAsync(Student student);
    }
}
