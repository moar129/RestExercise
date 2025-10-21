using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class GamingTeamRepo : IGamingTeamRepo<GamingTeam>
    {
        private int _nextId = 1;
        private List<GamingTeam> _gamingTeams = new List<GamingTeam>();
        public GamingTeamRepo() 
        {
            // Initialize with some sample data
            _gamingTeams.Add(new GamingTeam("Shadow Hunters", 5, "Valorant", 12, 3) { Id= _nextId++});
            _gamingTeams.Add(new GamingTeam("Dragon Slayers", 4, "League of Legends", 8, 7) { Id = _nextId++ });
            _gamingTeams.Add(new GamingTeam("Cyber Warriors", 6, "CS:GO", 15, 2) { Id = _nextId++ });
            _gamingTeams.Add(new GamingTeam("Pixel Pioneers", 5, "Minecraft", 10, 5) { Id = _nextId++ });
        }
        public GamingTeam Add(GamingTeam gt)
        {
            gt.Id = _nextId++;
            _gamingTeams.Add(gt);
            return gt;
        }
        public GamingTeam? GetById(int id)
        {
            return _gamingTeams.FirstOrDefault(gt => gt.Id == id);
        }

        public IEnumerable<GamingTeam> Get()
        {
            IEnumerable<GamingTeam> gamingTeams = _gamingTeams;
            return gamingTeams;
        }

        public GamingTeam? Update(int id, GamingTeam obj)
        {
            var existingTeam = GetById(id);
            if (existingTeam != null)
            {
                existingTeam.TeamName = obj.TeamName;
                existingTeam.MembersCount = obj.MembersCount;
                existingTeam.Game = obj.Game;
                existingTeam.WinCount = obj.WinCount;
                existingTeam.LossCount = obj.LossCount;
            }
            return existingTeam;
        }

        public GamingTeam? Delete(int id)
        {
            var teamToDelete = GetById(id);
            if (teamToDelete == null)
                return null;
            _gamingTeams.Remove(teamToDelete);
            return teamToDelete;
        }
    }
}
