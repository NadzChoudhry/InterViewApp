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
    public class ManagerController : ControllerBase
    {
        private readonly ISQLManagerRepository _repository;

        public ManagerController(ISQLManagerRepository managerRepository)
        {
            this._repository = managerRepository;
        }
        // GET: api/Manager
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Manager>> GetManagers()
        {

            try
            {
                var res = this._repository.GetAllManagers();
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

        // GET: api/Manager/5
        [HttpGet("{id}", Name = "Manager")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ManagerDto> Get(int id)
        {
            try
            {
                var res = this._repository.GetManageDtoById(id);
                if (res == null)
                {
                    return NoContent();
                }
                return res;
            }
            catch (Exception exp)
            {
                return BadRequest();
            }

        }

        // POST: api/Manager
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<int> Post([FromBody] ManagerDto dto)
        {
            try
            {
                var newManager = new Manager()
                {
                    Name = dto.name,
                    RedCards = dto.redCards,
                    TeamName = dto.teamName,
                    YellowCards = dto.yellowCards
                };
                this._repository.Add(newManager);

                return Created("POST: api/Manager", newManager.Id);
            }
            catch (Exception exp)
            {
                return BadRequest();
            }
        }

        // PUT: api/Manager/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ManagerDto dto)
        {
            try
            {
                var m = this._repository.GetManagerById(id);

                if (m != null)
                {
                    m.Name = dto.name;
                    m.RedCards = dto.redCards;
                    m.TeamName = dto.teamName;
                    m.YellowCards = dto.yellowCards;
                }

                this._repository.Update(m);
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
            var res = true;
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
