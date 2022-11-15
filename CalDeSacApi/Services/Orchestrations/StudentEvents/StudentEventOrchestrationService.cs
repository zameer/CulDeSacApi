using CalDeSacApi.Services.Foundations.StudentEvents;

namespace CalDeSacApi.Services.Orchestrations.StudentEvents
{
    public class StudentEventOrchestrationService : IStudentEventOrchestrationService
    {
        private readonly IStudentEventService studentEventService;

        public StudentEventOrchestrationService(
            IStudentEventService studentEventService)
        {
            this.studentEventService = studentEventService;
        }

        public void ListenToStudentEvents()
        {
            this.studentEventService.ListenToStudentEvent(async (student) => { });
        }
    }
}
