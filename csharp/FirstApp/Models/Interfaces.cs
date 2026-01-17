namespace FIRSTAPP.Models
{
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
        int PhoneNo { get; set; }
        string getdetails();
    }

    public interface IAppt
    {
        bool isAvailable { get; set; }
        List<Appointment> GetAppointments();
    }
}