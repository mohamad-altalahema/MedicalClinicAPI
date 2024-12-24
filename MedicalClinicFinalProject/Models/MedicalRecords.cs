using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace MedicalClinicFinalProject.Models
{
    public class MedicalRecords
    {
        [Key]
        public int RecordID { get; set; }
        [ForeignKey("Patients")]
        public int PatientId { get; set; }
        [ForeignKey("Doctors")]
        public int DoctorID { get; set; }
        public DateTime VisitDate {get; set;}
        public string Diagnosis { get; set; }
        public string Notes { get; set; }
        public string Prescription { get; set; }
        public string TestsRecommended { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
