using System;
using System.Collections.Generic;
using Demo.PersistenceLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NadzFxstreet.Entities.Dtos;
using NadzFxstreet.Repositories.Interfaces;

namespace NadzFxStreetWeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefereeController : ControllerBase
    {
        private readonly ISqlRefereeRepository _repository;

        public RefereeController(ISqlRefereeRepository refereeRepository)
        {
            this._repository = refereeRepository;
        }

        // GET: api/Referee
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Referee>> GetReferees()
        {
            try
            {
                var res = this._repository.GetAllReferees();
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

        // GET: api/Referee/5
        [HttpGet("{id}", Name = "Referee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Referee> Get(int id)
        {
            try
            {
                var res = this._repository.GetRefereeById(id);
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

        // POST: api/Referee
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<int> Post([FromBody] RefereeDto dto)
        {

            try
            {
                var newReferee = new Referee();
                newReferee.Name = dto.name;
                newReferee.MinutesPlayed = dto.minutesPlayed;

                var res = this._repository.Add(newReferee);
                return Created("POST: api/Referee", res.Id);
            }
            catch (Exception exp)
            {
                return BadRequest();
            }
        }

        // PUT: api/Referee/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] RefereeDto dto)
        {
            try
            {
                var r = this._repository.GetRefereeById(id);
                r.Name = dto.name;
                r.MinutesPlayed = dto.minutesPlayed;

                var refreshed = this._repository.Update(r);
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
