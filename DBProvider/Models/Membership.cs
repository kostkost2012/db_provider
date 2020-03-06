using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DBProvider.Models
{
    public class Membership : IIdentifiable
    {
        [Key]
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int ChatId { get; set; }
        public string Permissions { get; set; }
        public string LastBeenAt { get; set; }

        [JsonIgnore]
        public virtual Profile Profile { get; set; }
        [JsonIgnore]
        public virtual Chat Chat { get; set; }
        [JsonIgnore]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
