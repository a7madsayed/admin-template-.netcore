namespace CompanyName.Identity.Core.Models
{
    public class UserToken : UserTokenKey
    {
        public string Value { get; set; }
    }

    public class UserTokenKey
    {
        public int UserId { get; set; }

        public string LoginProvider { get; set; }

        public string Name { get; set; }
    }
}
