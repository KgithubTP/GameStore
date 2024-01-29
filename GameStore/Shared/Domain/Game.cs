using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Shared.Domain
{
    public class Game : BaseDomainModel
    {
        public int? Year { get; set; }
        public int? Price { get; set; }
        public int TitleId { get; set; }
        public virtual Title? Title { get; set; }
        public int DeveloperId { get; set; }
        public virtual Developer? Developer { get; set; }
        public int GenreId { get; set; }
        public virtual Genre? Genre { get; set; }
        public int PlatformId { get; set; }
        public virtual Platform? Platform { get; set;}
        //public int ReviewId { get; set; }
       // public virtual Review? Review {  get; set; }
        public virtual List<Order>? Orders { get; set; }
    }
}
