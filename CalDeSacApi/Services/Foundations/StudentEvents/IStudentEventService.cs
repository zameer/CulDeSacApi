using CalDeSacApi.Models.Students;

namespace CalDeSacApi.Services.Foundations.StudentEvents
{
    public interface IStudentEventService
    {
        void ListenToStudentEvent(Func<Student, ValueTask> studentEventHandler);
    }
}
