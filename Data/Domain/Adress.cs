using Core.DomainDrivenDesign;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain
{
    public class Address : ValueObject
    {
        [Required]
        [StringLength(100)]
        public string Province { get; private set; }
        [Required]
        [StringLength(100)]
        public string District { get; private set; }
        [Required]
        [StringLength(100)]
        public string Street { get; private set; }
        [Required]
        [StringLength(100)]
        public string ZipCode { get; private set; }
        [Required]
        [StringLength(100)]
        public string Line { get; private set; }

        public Address(string province, string district, string street, string zipCode, string line)
        {
            Province = province;
            District = district;
            Street = street;
            ZipCode = zipCode;
            Line = line;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Province;
            yield return District;
            yield return Street;
            yield return ZipCode;
            yield return Line;
        }
    }
}