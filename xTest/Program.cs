using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xTest
{
    class Program
    {
        private static string API_KEY = "48208BD4-716A-C94A-B16F-B023E18721407D2C5346-49BD-4A0B-9CBB-5FF78C77CD7A";
        static void Main(string[] args) {
            var details = GuildWars2API.GuildAPI.Details("E2C92543-0EAC-E411-AA11-AC162DAAE275");
        }
    }
}
