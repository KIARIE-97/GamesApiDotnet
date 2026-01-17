namespace FIRSTAPP.Models
{
    public abstract class Person : IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int PhoneNo { get; set; }


        //constructor
        protected Person(string Name, int Age, int PhoneNo)
        {
            this.Name = Name;
            this.Age = Age;
            this.PhoneNo = PhoneNo;
        }

        //methods
        public string getdetails()
        {
            return $"{Name} of age {Age}";
        }
    }
    public class Patient : Person
    {
        public int Id { get; set; }
        public List<Appointment> Appointments { get; private set; }
        public Patient(string Name, int Age, int PhoneNo, int Id) : base(Name, Age, PhoneNo)
        {
            this.Id = Id;
            Appointments = new List<Appointment>();
        }
    }

    public class Doctor : Person, IAppt
    {
        public int Docid { get; set; }
        public bool isAvailable { get; set; }
        public List<Appointment> Appointments { get; private set; }

        public Doctor(string Name, int Age, int PhoneNo, int Docid) : base(Name, Age, PhoneNo)
        {
            this.Docid = Docid;
            Appointments = new List<Appointment>();
            isAvailable = true;
        }
        public List<Appointment> GetAppointments() => Appointments;
        public bool IsAvailableAt(DateTime date, TimeSpan Duration)
        {
            var endTime = date.Add(Duration);
            foreach (var appointment in Appointments)
            {
                var appoitmentEnd = appointment.Apptdate.Add(appointment.Duration);
                if (date < appoitmentEnd && endTime > appointment.Apptdate)
                    return false;
            }
            return true;
        }
        public void AddAppt(Appointment appointment)
        {
            if (IsAvailableAt(appointment.Apptdate, appointment.Duration))
            {
                Appointments.Add(appointment);
            }
            else
            {
                throw new InvalidOperationException("doctor is unavailable at the requested time");
            }
        }
    }
    public class Appointment
    {
        public int Apptid { get; set; }
        public Patient Patient { set; get; }
        public Doctor Doctor { get; set; }
        public EAppointmentType Apptype { get; set; }
        public EApptStatus ApptStatus { get; set; }
        public DateTime Apptdate;
        public TimeSpan Duration { get; set; }

        public Appointment(int Apptid, Patient Patient, Doctor Doctor, DateTime Apptdate, TimeSpan Duration)
        {
            this.Apptid = Apptid;
            this.Patient = Patient;
            this.Apptdate = Apptdate;
            this.Duration = Duration;
            this.Doctor = Doctor;
            ApptStatus = EApptStatus.Scheduled;

            Doctor.AddAppt(this);
            Patient.Appointments.Add(this);
        }
        public void CompleteAppt()
        {
            ApptStatus = EApptStatus.Completed;
        }
        public void CancelAppt()
        {
            ApptStatus = EApptStatus.Cancelled;
        }
        public override string ToString()
        {
            return $"Appointment {Apptid}: {Patient.getdetails()} with Dr. {Doctor.getdetails()} " +
                   $"on {Apptdate:MMM dd, yyyy HH:mm} - Status: {ApptStatus}";
        }
    }
    public class MedicalRecord(int RecordId, Patient Patient, Doctor Doctor, DateTime VisitDate)
    {
        public int RecordId { get; set; } = RecordId;
        public Patient Patient { get; set; } = Patient;
        public Doctor Doctor { get; set; } = Doctor;
        public DateTime VisitDate { get; set; } = VisitDate;
        public string? Treatment { get; set; }
        public string? Diagnosis { get; set; }
        public string? Symptoms { get; set; }
        public string? Prescription { get; set; }

        public void UpdatePrescription(string prescription)
        {
            Prescription = prescription;
        }
        public override string ToString()
        {
            return  $"Medical Record {RecordId}: {Patient.getdetails()} - {VisitDate:MMM dd, yyyy} - Diagnosis: {Diagnosis}";
        }
    }
}

