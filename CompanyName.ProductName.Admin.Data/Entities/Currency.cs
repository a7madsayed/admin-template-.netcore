namespace CompanyName.ProductName.Admin.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Currency
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(3)]
        [Required]
        public string Code { get; set; }

        [Required]
        public int NameTranslationId { get; set; }

        [Required]
        public int? CodeTranslationId { get; set; }

        public int? UnitNameTranslationId { get; set; }

        public int? PluralNameTranslationId { get; set; }

        public int? PluralUnitNameTranslationId { get; set; }

        public byte UnitPrecision { get; set; }

        public bool IsNameFeminine { get; set; }

        public bool IsUnitNameFeminine { get; set; }

        public bool IsActive { get; set; }

        public virtual Translation NameTranslation { get; set; }

        public virtual Translation CodeTranslation { get; set; }

        public virtual Translation UnitNameTranslation { get; set; }

        public virtual Translation PluralNameTranslation { get; set; }

        public virtual Translation PluralUnitNameTranslation { get; set; }
    }
}
