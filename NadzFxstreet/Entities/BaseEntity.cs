using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NadzFxstreet.Entities
{
    public abstract class BaseEntity
    {
        [JsonProperty("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }


    }
}
