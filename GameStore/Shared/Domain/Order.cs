namespace GameStore.Shared.Domain
{
    public class Order : BaseDomainModel
    {
        public DateTime DatePlaced { get; set; }
        public int GameId { get; set; }
        public virtual Game? Game { get; set; }
        public int CustomerId { get; set;}
        public virtual Customer? Customer { get; set; }
    }
}