using System;
using System.Collections.Generic;

namespace MusicGallery.Models
{
    public partial class Album
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int NumOfSongs { get; set; }
        public DateTime PublishedDate { get; set; }
        public int? ArtistId { get; set; }

        public virtual Artist? Artist { get; set; }
    }
}
