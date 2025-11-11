using ClassLib;
using Microsoft.AspNetCore.Cors;
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
        [EnableCors("AllowAll")]
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
                return NotFound($"Item with id {id} not found.");
            }
            return Ok(team);
        }

        // POST api/<GameTeamsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public ActionResult<GamingTeam> Post([FromBody] GamingTeam team)
        {
            try
            {
                var newTeam = ConvertDTOToGamingTeam(team);
                var createdTeam = _repo.Add(newTeam);
                return Created($"api/GameTeams/{createdTeam.Id}", createdTeam);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<GameTeamsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [EnableCors("ZealandOnly")]
        [HttpPut("{id}")]
        public ActionResult<GamingTeam> Put(int id, [FromBody] GamingTeam team)
        {
            try
            {
                var updatedTeamData = ConvertDTOToGamingTeam(team);
                var updatedTeam = _repo.Update(id, updatedTeamData);
                if (updatedTeam == null)
                {
                    return NotFound($"Item with id {id} not found.");
                }
                return Ok(updatedTeam);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<GameTeamsController>/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [DisableCors]
        [HttpDelete("{id}")]
        public ActionResult<GamingTeam> Delete(int id)
        {
            try
            {
                var deletedTeam = _repo.Delete(id);
                if (deletedTeam == null)
                {
                    return NotFound($"Item with id {id} not found.");
                }
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private GamingTeam ConvertDTOToGamingTeam(GamingTeam dto)
        {
            if (dto.TeamName == null) throw new ArgumentNullException("TeamName cannot be null");
            if (dto.MembersCount < 1) throw new ArgumentOutOfRangeException("MembersCount must be at least 1");
            if (dto.Game == null) throw new ArgumentNullException("Game cannot be null");

            GamingTeam team = new GamingTeam() { TeamName = dto.TeamName, MembersCount = dto.MembersCount, Game = dto.Game, WinCount = dto.WinCount, LossCount = dto.LossCount };
            return team;
        }
    }
}
