namespace MusicGallery.DTOs{
    public class AlbumDTO{
    
        public string Title { get; set;} = string.Empty;
        public int NumOfSongs { get; set;} 
        public DateTime PublishedDate {get; set;} 
        public int ArtistId { get; set;}

        
    }
}