namespace Assignment1HT24_HT2024_DA204E_AQ7150.Classes
{
    internal class Album
    {
        private string albumName;
        private string artistName;
        private int numberOfTracks;

        public Album()
        {
            albumName = string.Empty;
            artistName = string.Empty;
            numberOfTracks = -1;
        }

        public void Start()
        {
            ReadAlbumName();
            ReadArtistName();
            ReadTracks();
            DisplayAlbumInfo();
        }

        private void ReadTracks()
        {
            numberOfTracks = Utility.GetIntInput($"How many tracks does {albumName} have?");
        }

        private void ReadArtistName()
        {
            artistName = Utility.ReadInput($"What is the name of the Artist or band for {albumName}?");
        }

        private void ReadAlbumName()
        {
            albumName = Utility.ReadInput("What is the name of your favorite music album?");
        }

        private void DisplayAlbumInfo()
        {
            Console.WriteLine($"\nAlbum Name: {albumName}" +
                $"\nArtist/Band: {artistName}" +
                $"\nNumberOfTracks: {numberOfTracks}" +
                $"\nEnjoy Listening!");
        }

        
    }
}