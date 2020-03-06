using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProvider
{
    class ConnectionSettings
    {
        public string DB_TYPE { get; set; }
        public string DB_HOST { get; set; }
        public string DB_PORT { get; set; }
        public string DB_USER { get; set; }
        public string DB_PASS { get; set; }
        public string DB_NAME { get; set; }

        public ConnectionSettings()
        {
            DB_TYPE = GetVar(nameof(DB_TYPE), "postgres");
            DB_HOST = GetVar(nameof(DB_HOST), "localhost");
            DB_USER = GetVar(nameof(DB_USER), "postgres");
            DB_PASS = GetVar(nameof(DB_PASS), "1234");
            DB_PORT = GetVar(nameof(DB_PORT), DB_TYPE == "mssql" ? "1433" : "5432");
            DB_NAME = GetVar(nameof(DB_NAME), "test");
        }

        public override string ToString()
        {
            switch (DB_TYPE)
            {
                case "mssql":
                    return $"Server={DB_HOST},{DB_PORT};User Id={DB_USER};Password={DB_PASS};Database={DB_NAME}";
                case "postgres":
                    return $"Host={DB_HOST};Port={DB_PORT};Username={DB_USER};Password={DB_PASS};Database={DB_NAME};CommandTimeout=120;";
                default:
                    throw new NotImplementedException("Unsopported");
            }
        }

        private string GetVar(string str, string def)
        {
            return (Environment.GetEnvironmentVariable(str) ?? def).ToLower();
        }
    }

    public static class Extensions
    {
        public static object GetRandom(this IList l)
        {
            if (l.Count == 0)
                return null;
            var rnd = new Random();
            return l[rnd.Next() % l.Count];
        }
    }
}
