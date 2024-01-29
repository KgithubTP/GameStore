namespace GameStore.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        public string? EmailAddress { get; set; }
        public string? Address { get; set; }
        public string? ContactNumber { get; set; }
        public List<Order>? Orders { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }  
    }
}