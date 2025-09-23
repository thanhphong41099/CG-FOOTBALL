namespace VLeague.Models
{
    public class WeatherItem
    {
        public int MATCH_ID { get; set; }
        public string CONDITION { get; set; } // CLOUD/WEATHER/TEMP/HUM/WIND
        public string VALUE { get; set; }
        public string IMG_ID { get; set; }
        public string LINK_IMAGE { get; set; }
    }
}
