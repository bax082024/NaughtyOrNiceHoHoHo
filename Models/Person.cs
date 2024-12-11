using Lists;
namespace Models
{
    public class Person
    {
        public string? Name { get; set; } = string.Empty;
        public bool ToiletPaperOutward { get; set; }
        public bool DonatesToCharity { get; set; }
        public bool WashedHands { get; set; }
        public List<string> NiceMusicGenre { get; set; } = new List<string>();
        public bool HomeAdress { get; set; } 
        public List<string> NiceCarModel { get; set; } = new List<string>();

    }

}

