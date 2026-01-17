using Oop.Models;
namespace Oop
{
    public class Program
    {
        static void Main(string[] args)
        {
            //encapsulation

            // abstraction
            EmailService email = new EmailService();
            IMessagingService smsService = new SmsService(); //programming to an interface
             
            SendAlert(email, "example@example.com", "Hello via Email!");
            SendAlert(smsService, "1234567890", "Hello via SMS!");
        }
       static void SendAlert(IMessagingService service, string recipient, string message)
        {
            service.SendMessage(recipient, message);
        }
    
    }
}