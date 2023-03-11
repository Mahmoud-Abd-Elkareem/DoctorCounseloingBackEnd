using DoctorCounseloing.Domain.Abstractions;
using DoctorCounseloing.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Domain.Model
{
    public class Clinic : AuditableEntity<Guid>
    {
        public DescriptionLocalized Name { get; set; }
        public DescriptionLocalized Description { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

        public Clinic()
        {

        }
        public Clinic(string nameAr, string nameEn, string descriptionAr, string descriptionEn) : base()
        {
            Name = new DescriptionLocalized(nameAr, nameEn);
            Description = new DescriptionLocalized(descriptionAr, descriptionEn);
            Created = DateTime.Now;
            CreatedBy = "DoctorCounseloingUser";
        }

        public static Clinic AddClinic(string nameAr, string nameEn, string descriptionAr, string descriptionEn)
        {
            var note = new Clinic(nameAr, nameEn, descriptionAr, descriptionEn);
            return note;
        }

        public void UpdateClinic(string nameAr, string nameEn, string descriptionAr, string descriptionEn)
        {
            Name = new DescriptionLocalized(nameAr, nameEn);
            Description = new DescriptionLocalized(descriptionAr, descriptionEn);
        }
    }
}
