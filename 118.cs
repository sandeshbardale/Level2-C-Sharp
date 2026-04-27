using System;

// Interface for service
interface IMessageService
{
    void SendMessage(string message);
}

// Implementation of service
class EmailService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine("Email sent: " + message);
    }
}

// Consumer class depends on IMessageService
class Notification
{
    private IMessageService _messageService;

    // Constructor Injection
    public Notification(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Notify(string message)
    {
        _messageService.SendMessage(message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Inject dependency through constructor
        IMessageService service = new EmailService();
        Notification notification = new Notification(service);

        notification.Notify("Hello Payal!");

        Console.ReadLine();
    }
}