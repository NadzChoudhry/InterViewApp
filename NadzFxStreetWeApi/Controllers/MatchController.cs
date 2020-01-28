using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.PersistenceLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NadzFxstreet.Entities.Dtos;
using NadzFxstreet.Repositories.Interfaces;

namespace NadzFxStreetWeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly ISqlMatchRepository _repository;
        private readonly ISqlPlayerRepository _repositoryPlayer;
        private readonly ISqlRefereeRepository _repositoryreferee;
        private readonly ISQLManagerRepository _repositoryManager;


        public MatchController(ISqlMatchRepository matchRepository,
            ISqlPlayerRepository repositoryPlayer,
            ISqlRefereeRepository repositoryreferee,
            ISQLManagerRepository repositoryManager)
        {
            this._repository = matchRepository;
            this._repositoryPlayer = repositoryPlayer;
            this._repositoryreferee = repositoryreferee;
            this._repositoryManager = repositoryManager;
        }

        // GET: api/Match
        [HttpGet()]
        public ActionResult<List<Match>> Get()
        {

            try
            {
                var res = this._repository.GetAllMatches();
                if (res == null)
                {
                    return NoContent();
                }
                return Ok(res);
            }
            catch (Exception exp)
            {
                return BadRequest();
            }
        }

        // GET: api/Match/5
        [HttpGet("{id}", Name = "MatchId")]
        public ActionResult<Match> Get(int id)
        {

            try
            {
                var res = this._repository.GetMatchById(id);
                if (res == null)
                {
                    return NoContent();
                }
                return Ok(res);
            }
            catch (Exception exp)
            {
                return BadRequest();
            }
        }

        // POST: api/Match
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> Post([FromBody] MatchDto dto)
        {
            try
            {
                if (dto.houseTeam.Count != 11 || dto.awayTeam.Count != 11)
                {
                    return BadRequest();
                }
                var newM = new Match()
                {
                    Name = dto.name,
                    HouseTeamManager = this._repositoryManager.GetManagerById(dto.houseManager),
                    AwayTeamManager = this._repositoryManager.GetManagerById(dto.awayManger),
                    Referee = this._repositoryreferee.GetRefereeById(dto.referee),
                    Date = DateTimeOffset.Now,
                    HouseTeamPlayers = new List<PlayersOfMatch>(),
                    AwayTeamPlayers = new List<PlayersOfMatch>()
                };


                dto.houseTeam.ForEach(id =>
                {
                    var p = this._repositoryPlayer.GetPlayerById(id);
                    if (p != null)
                    {
                        newM.HouseTeamPlayers.Add(new PlayersOfMatch()
                        {
                            Home = true,
                            Player = p,
                            PlayerId = p.Id
                        });
                    }
                });

                dto.awayTeam.ForEach(id =>
                {
                    var p = this._repositoryPlayer.GetPlayerById(id);
                    if (p != null)
                    {
                        newM.AwayTeamPlayers.Add(new PlayersOfMatch()
                        {
                            Home = false,
                            Player = p,
                            PlayerId = p.Id
                        });
                    }
                });

                this._repository.Add(newM);

                return Created(" POST: api/Match", newM.Id);
            }
            catch (Exception exp)
            {
                return BadRequest();
            }

        }

        // PUT: api/Match/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MatchDto dto)
        {
            try
            {
                var m = this._repository.GetMatchById(id);


                m.Name = dto.name;
                m.HouseTeamManager = this._repositoryManager.GetManagerById(dto.houseManager);
                m.AwayTeamManager = this._repositoryManager.GetManagerById(dto.awayManger);
                m.Referee = this._repositoryreferee.GetRefereeById(dto.referee);
                m.Date = DateTimeOffset.Now;
                this._repository.RemovePlayer(m.HouseTeamPlayers);
                this._repository.RemovePlayer(m.AwayTeamPlayers);

                dto.houseTeam.ForEach(id =>
                {
                    var p = this._repositoryPlayer.GetPlayerById(id);
                    if (p != null)
                    {
                        m.HouseTeamPlayers.Add(new PlayersOfMatch()
                        {
                            Home = true,
                            Player = p,
                            PlayerId = p.Id
                        });
                    }
                });

                dto.awayTeam.ForEach(id =>
                {
                    var p = this._repositoryPlayer.GetPlayerById(id);
                    if (p != null)
                    {
                        m.AwayTeamPlayers.Add(new PlayersOfMatch()
                        {
                            Home = false,
                            Player = p,
                            PlayerId = p.Id
                        });
                    }
                });
                this._repository.Update(m);
            }
            catch (Exception exp)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                this._repository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
