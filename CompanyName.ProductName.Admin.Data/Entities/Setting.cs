namespace CompanyName.ProductName.Admin.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Setting
    {
        [Key]
        [MaxLength(50)]
        [Required]
        public string Key { get; set; }

        [MaxLength(100)]
        [Required]
        public string Value { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
