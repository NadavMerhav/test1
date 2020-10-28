using HealthForYou.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthForYou.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public string UserId { get; set; }
        public int Doctorid { get; set; }
        public MedicalTeam Doctor { get; set; }
        public HealthForYouUser User { get; set; }

    }
}
