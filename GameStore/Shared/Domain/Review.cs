using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Shared.Domain
{
    public class Review : BaseDomainModel
    {
        public string? Name { get; set; }
        public int GameId { get; set; }
        public virtual Game? Game { get; set; }
    }
}
