using DoctorCounseloing.Domain.Abstractions;

namespace DoctorCounseloing.Domain.ValueObjects
{
    public class DescriptionLocalized : ValueObject
    {
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string Description => GetLocalizedPropertyValue(nameof(Description));

        public static implicit operator string(DescriptionLocalized name) => name.Description;

        public DescriptionLocalized() { }
        public DescriptionLocalized(string descriptionAr, string descriptionEn)
        {
            DescriptionAr = descriptionAr;
            DescriptionEn = descriptionEn;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DescriptionAr;
            yield return DescriptionEn;
        }
    }
}
