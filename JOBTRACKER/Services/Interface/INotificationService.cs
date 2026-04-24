namespace JOBTRACKER.Services.Interface
{
    public interface INotificationService
    {
        Task SendStatusChangeNotification
            (string company, string role,string oldStatus, string newStatus);
        
        Task SendApplicationCreatedNotification
            (string company, string role);
    }
}
