namespace CompanyName.ProductName.Admin.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SystemResource
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string IdentityName { get; set; }

        public int NameTranslationID { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual Translation NameTranslation { get; set; }
    }
}
