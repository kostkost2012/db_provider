using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DBProvider.Models
{
    public class Probe : IIdentifiable
    {
        [Key]
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string CreatedAt { get; set; }
        public int ProbeTypeId { get; set; }
        public string Value { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(ProfileId))]
        public virtual Profile Profile { get; set; }
        [JsonIgnore]
        public virtual ProbeType ProbeType { get; set; }

        static public Probe GetRandom(DbSet<Profile> profiles) 
        {
            return new Probe()
            {
                ProbeType = new ProbeType() { Name = "tt", InputMethod = 1 },
                Profile = profiles.ToList().GetRandom() as Profile,
                Value = "val"
            };
        }
    }
}
