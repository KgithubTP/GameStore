using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string GenresEndpoint = $"{Prefix}/genres";
        public static readonly string DevelopersEndpoint = $"{Prefix}/developers";
        public static readonly string TitlesEndpoint = $"{Prefix}/titles";
        public static readonly string PlatformsEndpoint = $"{Prefix}/platforms";
        public static readonly string GamesEndpoint = $"{Prefix}/games";
        public static readonly string OrdersEndpoint = $"{Prefix}/orders";
        public static readonly string CustomersEndpoint = $"{Prefix}/customers";
    }
}
