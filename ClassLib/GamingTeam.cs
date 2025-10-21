namespace ClassLib
{
    public class GamingTeam
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int MembersCount { get; set; }
        public string Game { get; set; }
        public int WinCount { get; set; }
        public int LossCount { get; set; }
        public GamingTeam() { }

        public override string ToString()
        {
            return $"Id: {Id}, TeamName: {TeamName}, MembersCount: {MembersCount}, Game: {Game}, WinCount: {WinCount}, LossCount: {LossCount}";
        }
    }
}
