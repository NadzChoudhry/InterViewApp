using Demo.PersistenceLayer.Models;
using NadzFxstreet.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.PersistenceLayer.Models
{
    public partial class Player : BaseEntity
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("yellowCards")]
        public int YellowCards { get; set; }

        [JsonProperty("redCards")]
        public int RedCards { get; set; }

        [JsonProperty("minutesPlayed")]
        public int MinutesPlayed { get; set; }

        [JsonProperty("teamName")]
        public string TeamName { get; set; }

        //[JsonProperty("team")]
        //public virtual Team Team { get; set; }
        //[JsonProperty("teamId")]
        //public int TeamId { get; set; }

    }
}
