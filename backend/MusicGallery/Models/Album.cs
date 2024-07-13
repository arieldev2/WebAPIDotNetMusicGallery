using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicGallery.Models
{
    public partial class Album
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int NumOfSongs { get; set; }
        public DateTime PublishedDate { get; set; }
        public int? ArtistId { get; set; }

        public virtual Artist? Artist { get; set; }
    }
}
