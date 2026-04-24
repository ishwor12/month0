using JOBTRACKER.Services.Interface;

namespace JOBTRACKER.Services
{
    public class ConsoleNotificationService : INotificationService
    {
        public Task SendApplicationCreatedNotification(string company, string role)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[NOTIFY] New application created: {role} @ {company}");
            Console.ResetColor();
            return Task.CompletedTask;
        }

        public Task SendStatusChangeNotification(string company, string role, string oldStatus, string newStatus)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[NOTIFY] {company} | {role}: {oldStatus} → {newStatus}");
            Console.ResetColor();
            return Task.CompletedTask;
        }
    }
}
