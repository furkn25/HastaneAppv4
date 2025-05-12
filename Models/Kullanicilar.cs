    namespace HastaneAppv4.Models
{
    public class Kullanicilar
    {
        public int Id { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? Sifre { get; set; }
    
        public int RolId { get; set; }
        public Role? Rol { get; set; }
    }

}
