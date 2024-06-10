using System;
using System.Collections.Generic;

namespace MusicGallery.Models
{
    public partial class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Genre { get; set; } = null!;

        public virtual ICollection<Album> Albums { get; set; }
    }
}
