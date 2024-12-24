using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalClinicFinalProject.Models
{
    public class Doctors
    {
        [Key]
        public int DoctorID { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string Specialization { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string AvailabilitySchedule { get; set; }
        public int ConsultationFee { get; set; }
        public string Education { get; set; }
        public int Experience { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}