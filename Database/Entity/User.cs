﻿using Microsoft.AspNetCore.Identity;

namespace Database.Entity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public float Money { get; set; }

    }


}