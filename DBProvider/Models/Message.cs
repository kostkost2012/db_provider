using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace DBProvider.Models
{
    public class Message : IIdentifiable
    {
        [Key]
        public int Id { get; set; }
        public int MembershipId { get; set; }
        public string Text { get; set; }
        public string CreatedAt { get; set; }

        [JsonIgnore]
        public virtual Membership Membership { get; set; }

        public static Message GetRandom(DbSet<Membership> memberships)
        {
            var nameRand = new RandomNameGeneratorLibrary.PersonNameGenerator();
            var placeRand = new RandomNameGeneratorLibrary.PlaceNameGenerator();
            return new Message()
            {
                CreatedAt = DateTime.Now.ToString(),
                Text = $"{nameRand.GenerateRandomFirstName()} {nameRand.GenerateRandomLastName()} at {placeRand.GenerateRandomPlaceName()}",
                Membership = memberships.ToList().GetRandom() as Membership
            };
        }
    }
}