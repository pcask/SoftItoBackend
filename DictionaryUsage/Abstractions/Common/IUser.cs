namespace DictionaryUsage.Abstractions.Common
{
    public interface IUser
    {
        string IdentityNo { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        bool IsActive { get; set; }
    }
}
