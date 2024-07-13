namespace MusicGallery.ViewModels
{
    public class AlbumViewModel
    {

        public string Title { get; set; } = string.Empty;
        public int NumOfSongs { get; set; }
        public DateTime PublishedDate { get; set; }
        public int ArtistId { get; set; }


    }
}