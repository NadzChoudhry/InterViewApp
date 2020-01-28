using System;
using System.Collections.Generic;
using System.Text;

namespace NadzFxstreet.Entities.Dtos
{
    public class MatchDto : BaseDto
    {
        public List<int> houseTeam { get; set; }
        public int houseManager { get; set; }
        public List<int> awayTeam { get; set; }
        public int awayManger { get; set; }
        public int referee { get; set; }
        public DateTime date { get; set; }
    }
}
