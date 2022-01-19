namespace CompanyName.Identity.Core.Models
{
    public class UserLogin : UserLoginKey
    {
        public string ProviderDisplayName { get; set; }

        public int UserId { get; set; }
    }

    public class UserLoginKey
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
