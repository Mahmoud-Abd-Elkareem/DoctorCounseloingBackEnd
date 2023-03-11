using DoctorCounseloing.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Domain.Model
{
    public class SchduleSLot : AuditableEntity<Guid>
    {
        public int day { get; set; }
        public int UTCHour { get; set; }

        public Guid DoctorId { get; private set; }
        public Doctor Doctor { get; set; }

        public SchduleSLot()
        {

        }

        public SchduleSLot(int day, int utcHour, Guid doctorId) : base()
        {

            this.day = day;
            UTCHour = utcHour;
            DoctorId = doctorId;
            Created = DateTime.Now;
            CreatedBy = "DoctorCounseloingUser";
        }

    }
}
