using System;
using System.Collections.Generic;
using System.Text;

namespace NadzFxstreet.Entities.Dtos
{
    public class StatisticsDto : BaseDto
    {
        public int id { get; set; }
        public string teamName { get; set; }
        public int total { get; set; }
    }
}
