namespace Models
{
    public class Person
    {
        public string? Name { get; set; }
        public bool ToiletPaperOutward { get; set; }
        public bool DonatesToCharity { get; set; }
        public bool WashedHands { get; set; }
        public List<string> MusicGenres { get; set; } = new List<string>();
        public string HomeAdress { get; set; } = string.Empty;
        public string CarModel { get; set; } = string.Empty;
    }

}

