using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using FIRSTAPP.Models;
using FIRSTAPP.Services;
namespace FIRSTAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            var hosService = new HospitalService();
            var Patient1 = hosService.RegisterPatient("sara", 12, 1, 07654322);
            var Patient2 = hosService.RegisterPatient("dyh", 12, 2, 07654322);
            var foundPatient = hosService.FindPatientById(1);
            if (foundPatient != null)
            {
                Console.WriteLine(foundPatient.getdetails());
            }
            else
            {
                Console.WriteLine("patient not found");
            }
            foreach (var p in hosService.GetAllPatients())
            {
                Console.WriteLine(p.getdetails());
            }
            //next question is why do we need services
        }

    }
}