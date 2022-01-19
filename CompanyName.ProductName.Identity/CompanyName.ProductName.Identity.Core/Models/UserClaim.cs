namespace CompanyName.Identity.Core.Models
{
    public class UserClaim : ClaimBase
    {
        public int UserId { get; set; }
    }
}
