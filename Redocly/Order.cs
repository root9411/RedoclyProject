namespace Redocly
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? OrderValue { get; set; }
    }
}
