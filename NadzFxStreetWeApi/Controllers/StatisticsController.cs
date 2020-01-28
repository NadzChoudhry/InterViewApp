using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NadzFxstreet.Entities.Dtos;
using NadzFxstreet.Repositories.Interfaces;

namespace NadzFxStreetWeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly ISqlPlayerRepository _repository;

        public StatisticsController(ISqlPlayerRepository playerRepository)
        {
            this._repository = playerRepository;
        }
        [HttpGet("redcards")]
        public ActionResult<List<StatisticsDto>> RedCards()
        {
            var res = _repository.GetRedCards();
            return res;
        }


        [HttpGet("yellowcards")]
        public ActionResult<List<StatisticsDto>> YellowCards()
        {
            var res = _repository.GetYellowCards();
            return res;
        }

        [HttpGet("minutes")]
        public ActionResult<List<MinutesDto>> Minutes()
        {
            var res = _repository.GetMinutes();
            return res;
        }
    }
}
