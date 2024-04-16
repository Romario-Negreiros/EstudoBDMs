namespace EstudoBDM.DTOs
{
    public class UserDTOs
    {   
        public class LoginUserDTO
        {
            public string? Name { get; set; }
            public string[]? Scopes { get; set; }
        }
        public class LoggedUserDTO
        {
            public bool Authenticated { get; set; }
            public DateTime Expiration { get; set; }
            public string Token { get; set; } = default!;
            public string Message { get; set; } = default!;
        }
    }
}
