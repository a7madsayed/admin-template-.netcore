namespace CompanyName.ProductName.Admin.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Country
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [MaxLength(2)]
        [Required]
        public string ISO2 { get; set; }

        [MaxLength(3)]
        [Required]
        public string ISO3 { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        [MaxLength(6)]
        [Required]
        public string PhoneCode { get; set; }

        [Required]
        public int NameTranslationId { get; set; }

        public Translation NameTranslation { get; set; }

        public Currency CountryCurrency { get; set; }
    }
}
