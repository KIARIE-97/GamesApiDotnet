using System;
using System.Collections.Generic;
using FIRSTAPP.Models;

namespace FIRSTAPP.Services
{
    public class HospitalService
    {
        private readonly List<Patient> _patients;
        private readonly List<Doctor> _doctors;
        private readonly List<Appointment> _appointments;
         
         public HospitalService()
        {
            _patients = new List<Patient>();
            _doctors = new List<Doctor>();
            _appointments = new List<Appointment>();

            // InitializeSampleData();
        }

        // private void InitializeSampleData()
        // {
        //     throw new NotImplementedException();
        // }
        public Patient RegisterPatient(string name, int Age, int id, int phone)
        {
            var patient = new Patient(name, Age, phone, id);
            _patients.Add(patient);
            return patient;
        }
        public Patient? FindPatientById(int patientId)
        {
            return _patients.Find(p => p.Id == patientId);
        }
        public List<Patient> GetAllPatients()
        {
            return _patients;
        }
    }
}