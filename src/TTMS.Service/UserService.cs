namespace TTMS.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<(bool, string, UserResponse?)> CreateUserAsync(CreateUserRequest request)
        {
            await Task.CompletedTask;
            return (true, "", null);
        }
    }
}
