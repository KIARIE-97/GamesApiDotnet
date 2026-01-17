namespace Oop.Models 
{
    public interface IMessagingService
    {
        void SendMessage(string recipient, string message);
    }
    public class EmailService : IMessagingService
    {
        public void SendMessage(string recipient, string message)
        {
            Console.WriteLine($"Sending Email to {recipient}: {message}");
        }
    }
    public class SmsService : IMessagingService
    {
        public void SendMessage(string recipient, string message)
        {
            Console.WriteLine($"Sending SMS to {recipient}: {message}");
            // Here, you'd have the actual logic to send an SMS.
        }
    }

}