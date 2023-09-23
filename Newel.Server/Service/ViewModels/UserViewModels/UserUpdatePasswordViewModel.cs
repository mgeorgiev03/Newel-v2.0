namespace Service.ViewModels.UserViewModels
{
    public class UserUpdatePasswordViewModel
    {
        public Guid Id { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? RepeatNewPassword { get; set; }
    }
}
