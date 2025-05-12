namespace HastaneAppv4.Models
{
    public class Ilac
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }

        public ICollection<RandevuIlac> RandevuIlaclar { get; set; }
    }

}
