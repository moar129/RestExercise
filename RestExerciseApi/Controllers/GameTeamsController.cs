using ClassLib;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestExerciseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameTeamsController : ControllerBase
    {
        private IGamingTeamRepo<GamingTeam> _repo;
        public GameTeamsController(IGamingTeamRepo<GamingTeam> repo) 
        {
            _repo = repo;
        }
        // GET: api/<GameTeamsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<GamingTeam>> Get()
        {
            var teams = _repo.Get();
            if (teams.Count() == 0 )
            {
                return NotFound("No gaming teams found.");
            }
            return Ok(teams);
        }

        // GET api/<GameTeamsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<GamingTeam> Get(int id)
        {
            var team = _repo.GetById(id);
            if (team == null)
            {
                return NotFound($"Gaming team with id {id} not found.");
            }
            return Ok(team);
        }

        // POST api/<GameTeamsController>
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public GamingTeam Post([FromBody] GamingTeam team)
        {
            return _repo.Add(team);
        }

        // PUT api/<GameTeamsController>/5
        [HttpPut("{id}")]
        public GamingTeam Put(int id, [FromBody] GamingTeam team)
        {
            return _repo.Update(id, team);
        }

        // DELETE api/<GameTeamsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
