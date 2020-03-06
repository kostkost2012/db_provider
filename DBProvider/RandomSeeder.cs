using DBProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProvider
{
    class RandomSeeder
    {
        public void Seed(MainDBContext db)
        {
            For(10, (_) => db.Users.Add(User.GetRandom()));
            db.SaveChanges();
            For(10, (i) => db.Chats.Add(Chat.GetRandom(db.Profiles)));
            db.SaveChanges();
            For(10, (i) => db.Probes.Add(Probe.GetRandom(db.Profiles)));
            db.SaveChanges();
        }

        public static Action<int, Action<int>> For = (count, act) => Enumerable.Range(0, count).All((i) => { act(i); return true; });
    }
}
