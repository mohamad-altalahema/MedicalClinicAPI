using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace MedicalClinicFinalProject.Models
{
    public class Comments
    {
        [Key]
        public int CommentID { get; set; }
        [ForeignKey("Patients")]
        public int PatientId { get; set; }
        public string Description { get; set; }
        [Range(1, 5)] 
        public int Rate { get; set; }
        public DateTime PostedDate { get; set; }

    }
}
