using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthForYou.Models
{
    public class MedicalTeam
    {
        [Key]
        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }

        public string Expertise { get; set; }
        public int YearsOfexp { get; set; }
        public ICollection<Appointment> Appointments { get; set; }


    }
}
