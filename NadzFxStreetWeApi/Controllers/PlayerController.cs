using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.PersistenceLayer.Models;
using Demo.PersistenceLayer.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NadzFxstreet.Entities.Dtos;
using NadzFxstreet.Repositories.Interfaces;

namespace NadzFxStreetWeApi.Controllers
{




    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ISqlPlayerRepository _repository;

        public PlayerController(ISqlPlayerRepository playerRepository)
        {
            this._repository = playerRepository;
        }

        // GET: api/Player
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<PlayerDto>> GetPlayers()
        {
            try
            {
                var res = this._repository.GetAllPlayers();
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

        // GET: api/Player/5
        [HttpGet("{id}", Name = "Player")]
        public ActionResult<PlayerDto> Get(int id)
        {

            try
            {
                var res = this._repository.GetPlayerDtoById(id);
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

        // POST: api/Player
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Player> Post([FromBody] PlayerDto player)
        {
            try
            {
                var newP = new Player()
                {
                    Name = player.name,
                    MinutesPlayed = player.minutesPlayed,
                    Number = player.number,
                    RedCards = player.redCards,
                    TeamName = player.teamName,
                    YellowCards = player.yellowCards

                };

                this._repository.Add(newP);
                return Created("POST: api/Player", newP.Id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // PUT: api/Player/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PlayerDto dto)
        {
            try
            {
                var recovered = this._repository.GetPlayerById(id);

                recovered.Name = dto.name;
                recovered.MinutesPlayed = dto.minutesPlayed;
                recovered.Number = dto.number;
                recovered.RedCards = dto.redCards;
                recovered.TeamName = dto.teamName;
                recovered.YellowCards = dto.yellowCards;

                this._repository.Update(recovered);
            }
            catch (Exception exp)
            {

                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
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
