using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendOdontoApp.API.Data.Entities
{
    public class ProcedureAppoinment
    {
        public int Id { get; set; }

        public ICollection<Procedure> Procedures { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
