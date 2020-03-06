using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DBProvider.Models
{
    public class User : IIdentifiable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        [JsonIgnore]
        public string PasswordSalt { get; set; }
        public string CreatedAt { get; set; }

        [JsonIgnore]
        public virtual Profile Profile { get; set; }

        public static User GetRandom()
        {
            var rand = new Random();
            var nameRand = new RandomNameGeneratorLibrary.PersonNameGenerator();
            return new User()
            {
                Name = $"User{rand.Next() % 100}",
                PasswordHash = $"1234",
                PasswordSalt = $"",
                CreatedAt = DateTime.Now.ToString(),
                Profile = Profile.GetRandom()
            };
        }
    }
}
