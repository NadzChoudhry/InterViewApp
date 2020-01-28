using Demo.PersistenceLayer.Models;
using NadzFxstreet.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.PersistenceLayer.Models
{
    public partial class Manager : BaseEntity
    {
        [JsonProperty("teamName")]
        public string TeamName { get; set; }

        //[JsonProperty("team")]
        //public virtual Team Team { get; set; }
        //public int TeamId { get; set; }

        [JsonProperty("yellowCards")]
        public int YellowCards { get; set; }

        [JsonProperty("redCards")]
        public int RedCards { get; set; }
    }
}
