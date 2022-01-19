namespace CompanyName.ProductName.Admin.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Translation
    {
        public Translation() => TranslationEntries = new HashSet<TranslationEntry>();

        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string DefaultValue { get; set; }

        public virtual ICollection<TranslationEntry> TranslationEntries { get; set; }
    }
}
