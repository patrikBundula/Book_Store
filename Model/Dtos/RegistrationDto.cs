namespace Model.Dtos
{
    public class RegistrationDto
    {
        public string FirstName { get; init; }
        public string LastName { get; set; }
        public string Username { get; init; }

        public string Email { get; init; }

        public string Password { get; set; }

        public string Role { get; init; }
    }
}
