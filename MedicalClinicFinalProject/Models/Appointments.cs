using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace MedicalClinicFinalProject.Models
{
    public class Appointments
    {
        [Key]
        public int AppointmentID { get; set; }
        [ForeignKey("Patients")]
        public int PatientId { get; set; }
        [ForeignKey("Doctors")]
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string Status { get; set; }
        public string ReasonForVisit { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
