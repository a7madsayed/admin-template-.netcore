namespace CompanyName.ProductName.Admin.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Language
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public int NameTranslationID { get; set; }

        [MaxLength(3)]
        [Required]
        public string Code { get; set; }

        public virtual Translation NameTranslation { get; set; }
    }
}
