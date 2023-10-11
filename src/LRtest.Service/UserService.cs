namespace LRtest.Service
{
    /*
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<(bool, string, UserResponse?)> CreateUserAsync(CreateUserRequest request)
        {
            if (!Regex.IsMatch(request.Email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
            {
                return (false, "邮箱格式不正确", null);
            }

            if (request.Id == null)
            {
                var result = await _userRepository.InsertUserAsync(request);
                return (true, "", result);
            }
            else
            {
                var result = await _userRepository.UpdateUserAsync(request);
                return (true, "", result);
            }
        }
    }*/
}
