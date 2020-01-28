using NadzFxstreet.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.PersistenceLayer.Models
{
    public partial class Referee : BaseEntity
    {
        [JsonProperty("minutesPlayed")]
        public int MinutesPlayed { get; set; }
    }
}
