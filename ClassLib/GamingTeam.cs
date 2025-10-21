namespace ClassLib
{
    public class GamingTeam
    {
        private string _teamName;
        private int _membersCount;
        private string _game;
        public int Id { get; set; }
        public string TeamName 
        {
            get { return _teamName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("TeamName cannot be null or empty.");
                }
                if (value.Length < 1)
                {
                    throw new ArgumentException("TeamName must be at least 1 characters long.");
                }
                _teamName = value;
            } 
        }
        public int MembersCount 
        {
            get { return _membersCount; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("MembersCount must be at least 1");
                }
                _membersCount = value;
            } 
        }
        public string Game 
        {
            get { return _game; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Game cannot be null or empty.");
                }
                if (value.Length < 1)
                {
                    throw new ArgumentException("Game must be at least 1 characters long.");
                }
                _game = value;
            } 
        }
        public int WinCount { get; set; }
        public int LossCount { get; set; }
        public int TotalMatches { get; set; }
        public double? WinRate { get; set; }
        public GamingTeam() { }

        public GamingTeam(string teamName, int membersCount, string game, int winCount, int lossCount)
        {
            TeamName = teamName;
            MembersCount = membersCount;
            Game = game;
            WinCount = winCount;
            LossCount = lossCount;
            TotalMatches = winCount + lossCount;
            if (TotalMatches != 0)
                WinRate = (double)WinCount / TotalMatches * 100;
            
        }


        public override string ToString()
        {
            return $"Id: {Id}, TeamName: {TeamName}, MembersCount: {MembersCount}, Game: {Game}, WinCount: {WinCount}, LossCount: {LossCount}";
        }
    }
}
