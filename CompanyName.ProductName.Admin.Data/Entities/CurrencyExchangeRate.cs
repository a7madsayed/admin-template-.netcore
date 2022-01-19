namespace CompanyName.ProductName.Admin.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CurrencyExchangeRate
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FromCurrencyId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ToCurrencyId { get; set; }

        [Required]
        public decimal BuyRate { get; set; }

        [Required]
        public decimal SellRate { get; set; }

        public Currency FromCurrency { get; set; }

        public Currency ToCurrency { get; set; }
    }
}
