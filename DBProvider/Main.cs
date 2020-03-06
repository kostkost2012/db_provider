using DBProvider.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;

namespace DBProvider
{
    public class MainDBContext : DbContext
    {
        private ConnectionSettings _connectionSettings;

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Probe> Probes { get; set; }
        public DbSet<ProbeType> ProbeTypes { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Message> Messages { get; set; }
        public MainDBContext() : base()
        {
            _connectionSettings = new ConnectionSettings();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (_connectionSettings.DB_TYPE)
            {
                case "mssql":
                    optionsBuilder.UseSqlServer(_connectionSettings.ToString());
                    break;
                case "postgres":
                    optionsBuilder.UseNpgsql(_connectionSettings.ToString());
                    break;
                default:
                    throw new NotImplementedException("Unsupported db type");
            }
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
