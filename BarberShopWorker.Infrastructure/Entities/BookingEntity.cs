using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShopWorker.Infrastructure.Entities
{
    public class BookingEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime BookingDateTime { get; set; }
    }
}
