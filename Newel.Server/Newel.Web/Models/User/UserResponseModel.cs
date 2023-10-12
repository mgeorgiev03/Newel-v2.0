namespace Newel.Web.Models.User
{
    public class UserResponseModel : BaseResponseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; } = string.Empty;

        public ICollection<Guid> ListGuids { get; set; }
    }
}
