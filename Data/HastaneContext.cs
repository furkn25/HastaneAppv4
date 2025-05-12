using Microsoft.EntityFrameworkCore;
using HastaneAppv4.Models;

namespace HastaneAppv4.Data
{
    public class HastaneContext : DbContext
    {
        public HastaneContext(DbContextOptions<HastaneContext> options)
            : base(options)
        {
        }


        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Klinik> Klinikler { get; set; }
        public DbSet<Ilac> Ilaclar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<RandevuIlac> RandevuIlaclar { get; set; }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<Role> Roller { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // İlişkileri tanımlayın
            modelBuilder.Entity<Doktor>()
                .HasOne(d => d.Klinik)
                .WithMany(k => k.Doktorlar)
                .HasForeignKey(d => d.KlinikId);

            // Diğer entity konfigürasyonları...
        }
    }
}