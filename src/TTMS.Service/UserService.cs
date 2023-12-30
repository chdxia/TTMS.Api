namespace TTMS.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse?> CreateUserAsync(CreateUserRequest request)
        {
            await Task.CompletedTask;
            return null;
        }
    }
}
