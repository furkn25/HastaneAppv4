namespace HastaneAppv4.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Ad { get; set; } 

        public ICollection<Kullanicilar> Kullanicilar { get; set; }
    }

}
