namespace TTMS.Service
{
    public interface IUserService
    {
        Task<(bool, string, UserResponse?)> CreateUserAsync(CreateUserRequest request);
    }
}
