using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Book_Store
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Money { get; set; }


    }
}
