using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NadzFxstreet.Entities;

namespace Demo.PersistenceLayer.Models
{
    public partial class Match : BaseEntity
    {

        [JsonProperty("houseTeamManager")]
        public virtual Manager HouseTeamManager { get; set; }

        [JsonProperty("awayTeamManager")]
        public virtual Manager AwayTeamManager { get; set; }

        [JsonProperty("referee")]
        public virtual Referee Referee { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("houseTeamPlayers")]
        public virtual List<PlayersOfMatch> HouseTeamPlayers { get; set; }
        [JsonProperty("awayTeamPlayers")]
        public virtual List<PlayersOfMatch> AwayTeamPlayers { get; set; }

    }
}
