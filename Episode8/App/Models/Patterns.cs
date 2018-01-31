namespace Episode8.Models
{
    public class Patterns
    {
        // Proxy
        public interface IUserService
        {
            void Register(string email, string password);
        }

        public class UserServiceProxy : IUserService
        {
            private IUserService _service;
            public UserServiceProxy(IUserService service)
            {
                _service = service;
            }

            void IUserService.Register(string email, string password)
            {
                _service.Register(email, password);
                // do some extra stuff
            }
        }
    }
}