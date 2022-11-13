﻿using System;
using System.Threading.Tasks;
using CulDeSacApi.Models.Students;

namespace CulDeSacApi.Services.Foundations.StudentEvents
{
    public interface IStudentEventService
    {
        void ListenToStudentEvent(Func<Student, ValueTask> studentEventHandler);
    }
}
