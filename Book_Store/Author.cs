﻿
namespace Book_Store
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Books> Books { get; set; }


    }
}
