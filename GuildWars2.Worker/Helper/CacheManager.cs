using System;
using System.Collections.Generic;
using System.Text;

namespace GuildWars2.Worker.Helper
{
    internal static class CacheManager
    {
        internal readonly static TimeSpan CACHE_DURATION = new TimeSpan(0, 5, 0);

        public static string GenerateKey(Type classType, int id) {
            return $"{classType.FullName}--{id}";
        }
    }
}
