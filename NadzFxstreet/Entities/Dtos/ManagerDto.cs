using System;
using System.Collections.Generic;
using System.Text;

namespace NadzFxstreet.Entities.Dtos
{
    public class ManagerDto : BaseDto
    {
        public string teamName { get; set; }
        public int yellowCards { get; set; }
        public int redCards { get; set; }
    }
}
