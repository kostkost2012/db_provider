using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace DBProvider.Models
{
    public class Chat : IIdentifiable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }

        [JsonIgnore]
        public virtual ICollection<Membership> Memberships { get; set; }
        [JsonIgnore]
        public virtual ICollection<Message> Messages { get; set; }

        public static Chat GetRandom(DbSet<Profile> profiles)
        {
            var rand = new Random();
            var nameRand = new RandomNameGeneratorLibrary.PersonNameGenerator();
            var memberships = new List<Membership>();
            var dd = new Membership();
            RandomSeeder.For(20, (_) => { var m = new Membership(); (profiles.ToList().GetRandom() as Profile).Memberships.Add(m); memberships.Add(m); });

            var chat = new Chat()
            {
                Name = $"Chat{rand.Next() % 100}",
                CreatedAt = DateTime.Now.ToString(),
                Memberships = memberships,
                Messages = Enumerable.Range(0, rand.Next() % 50).Select(i =>
                 new Message()
                 {
                     Membership = memberships.GetRandom() as Membership,
                     Text = $"Hey {nameRand.GenerateRandomFirstName()}"
                 }).ToList()
            };
            //memberships.All(el => { el.Chat = chat; return true; });
            return chat;
            //var memberships = Enumerable.Range(0, rand.Next() % 20).Select(i => new Membership() { Profile =  }).ToList();

        }
    }
}