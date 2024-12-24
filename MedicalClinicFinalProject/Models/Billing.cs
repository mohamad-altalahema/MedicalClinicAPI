using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace MedicalClinicFinalProject.Models
{
    public class Billing
    {
        [Key]
        public int BillID { get; set; }
        [ForeignKey("Appointments")]
        public int AppointmentID { get; set; }
        [ForeignKey("Patients")]
        public int PatientId { get; set; }    
        public int TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
