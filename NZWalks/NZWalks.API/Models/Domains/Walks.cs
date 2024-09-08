namespace NZWalks.API.Models.Domains
{
    public class Walks
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public Regions Regions { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
