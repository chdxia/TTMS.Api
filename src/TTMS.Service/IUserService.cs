namespace TTMS.Service
{
    public interface IUserService
    {
        Task<UserLoginResponse> UserLoginAsync(UserLoginRequest request);
    }
}
