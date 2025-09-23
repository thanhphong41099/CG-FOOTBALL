namespace VLeague.Models
{
    public class Player
    {
        public int PLAYER_ID { get; set; }
        public int TEAM_ID { get; set; }
        public int? STT { get; set; }
        public string Name { get; set; }
        public int? PLAY { get; set; }           // 1 đá chính, 2 dự bị
        public string DOB { get; set; }
        public string Nationality { get; set; }
        public string JerseyNo { get; set; }
        public string JerseyName { get; set; }
        public string Position { get; set; }
        public string Title { get; set; }
        public string Card { get; set; }
        public string Pos1 { get; set; }
        public string TShirt_LineUp1 { get; set; }
        public string TShirt_Sub1 { get; set; }
        public string TShirt_LineUp2 { get; set; }
        public string TShirt_Sub2 { get; set; }
    }
}
