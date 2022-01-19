namespace CompanyName.Identity.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserToken
    {
        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string LoginProvider { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Name { get; set; }

        public string Value { get; set; }

        public User User { get; set; }
    }
}
