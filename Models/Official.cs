namespace VLeague.Models
{
    public class Official
    {
        public int MATCH_ID { get; set; }
        public string TYPE { get; set; } // Referee, Assistant Ref1, Assistant Ref2, Fourth Official, VAR, AVAR
        public string NAME { get; set; }
    }
}
