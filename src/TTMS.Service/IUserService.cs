namespace TTMS.Service
{
    public interface IUserService
    {
        Task<UserResponse?> CreateUserAsync(CreateUserRequest request);
    }
}
