using DoctorCounseloing.Domain.Abstractions;
using DoctorCounseloing.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Domain.Model
{
    public class Doctor : AuditableEntity<Guid>
    {
        public DescriptionLocalized Name { get; set; }
        public DescriptionLocalized Description { get; set; }
        public Guid ClinicId { get; set; }

        public ICollection<SchduleSLot> SchduleSLots { get; set; }
        public ICollection<Appointment> Appointments { get; set; }


        public Doctor()
        {

        }
        public Doctor(string nameAr, string nameEn, string descriptionAr, string descriptionEn , Guid clinicId) : base()
        {
            Name = new DescriptionLocalized(nameAr, nameEn);
            Description = new DescriptionLocalized(descriptionAr, descriptionEn);
            ClinicId = clinicId;
            Created = DateTime.Now;
            CreatedBy = "DoctorCounseloingUser";
        }
    }
}
