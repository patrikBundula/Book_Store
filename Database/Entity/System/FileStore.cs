using System;
using System.ComponentModel.DataAnnotations;

namespace Database.Entity.System
{
    public class FileStore
    {
        public uint Id { get; set; }
        public Guid Guid { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public DateTime UploadedAt { get; set; }

        [Required]
        [MaxLength(16)]
        public string Extension { get; set; }

        [Required]
        public string SHA512Hash { get; set; }

        [Required]
        public long Size { get; set; }

        [Required]
        public uint Version { get; set; }
    }
}
