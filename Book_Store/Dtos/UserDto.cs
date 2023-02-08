using System.ComponentModel.DataAnnotations;

namespace Book_Store.Dtos
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }


        public string Password { get; set; }

        public float Money = 0;




    }
}
