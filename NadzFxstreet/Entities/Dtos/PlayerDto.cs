using System;
using System.Collections.Generic;
using System.Text;

namespace NadzFxstreet.Entities.Dtos
{
    public class PlayerDto : BaseDto
    {
        public int number { get; set; }
        public string teamName { get; set; }
        public int yellowCards { get; set; }
        public int redCards { get; set; }
        public int minutesPlayed { get; set; }
    }
}
