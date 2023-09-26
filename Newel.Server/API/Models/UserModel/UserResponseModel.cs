namespace API.Models.UserModel
{
    public class UserResponseModel : BaseResponseModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; } = string.Empty;
    }
}
