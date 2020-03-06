using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DBProvider.Models
{
    public class ProbeType : IIdentifiable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int InputMethod { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Probe> Probes { get; set; }
    }
}