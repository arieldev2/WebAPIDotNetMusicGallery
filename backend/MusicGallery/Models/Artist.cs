using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicGallery.Models
{
    public partial class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Genre { get; set; } = null!;

        public virtual ICollection<Album> Albums { get; set; }
    }
}
