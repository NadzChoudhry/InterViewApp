using NadzFxstreet.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PersistenceLayer.Models
{
    public partial class PlayersOfMatch : BaseEntity
    {
        [JsonProperty("Players")]
        public virtual Player Player { get; set; }
        public int? PlayerId { get; set; }

        public bool Home { get; set; }


    }
}
