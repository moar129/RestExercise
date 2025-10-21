namespace RestExerciseApi.DTOs
{
    public class GamingTeamDTO
    {
        public int? Id { get; set; }
        public string? TeamName { get; set; }
        public int? MembersCount { get; set; }
        public string? Game { get; set; }
        public int? WinCount { get; set; }
        public int? LossCount { get; set; }
        public int? TotalMatches { get; set; }
        public double? WinRate { get; set; }
        public GamingTeamDTO() { }
    }
}
