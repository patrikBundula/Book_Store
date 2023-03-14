using Microsoft.AspNetCore.Identity;
using DataBase;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public float Money { get; set; }

    }


}
