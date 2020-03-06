using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DBProvider.Models
{
    public class Profile : IIdentifiable
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string AvatarRaw { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
        public int Gender { get; set; }
        public string Description { get; set; }
        public string AdditionalInfo { get; set; }

        [JsonIgnore]
        public virtual Role Role { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual ICollection<Probe> Probes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Membership> Memberships { get; set; }

        public static Profile GetRandom()
        {
            var rand = new Random();
            var nameRand = new RandomNameGeneratorLibrary.PersonNameGenerator();
            return new Profile()
            {
                FirstName = nameRand.GenerateRandomFirstName(),
                LastName = nameRand.GenerateRandomLastName(),
                Gender = 2,
                Role = new Role() { Name=$"Role"}
            };
        }
    }
}
