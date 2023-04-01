namespace BarberShop.Infrastructure.Entities
{
    public class BookingEntity
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime BookingDateTime { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
