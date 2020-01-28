using System;
using System.Collections.Generic;
using System.Text;

namespace NadzFxstreet.Entities.Dtos
{
    public class MinutesDto : BaseDto
    {
        public int id { get; set; }
        public int total { get; set; }

        public string tipo { get; set; }
    }
}
