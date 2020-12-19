using Microsoft.EntityFrameworkCore;

namespace Lab6.Models
{
    // Класс контекста данных
    public partial class BaseparkingContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Parking> Parkings { get; set; }
        public virtual DbSet<Staffs> Staffs { get; set; }
        public BaseparkingContext(DbContextOptions<BaseparkingContext> options) : base(options)
        {
        }
    }
}
