namespace HastaneAppv4.Models
{
    public class RandevuIlac
    {
        public int Id { get; set; }

        public int RandevuId { get; set; }
        public Randevu Randevu { get; set; }

        public int IlacId { get; set; }
        public Ilac Ilac { get; set; }
    }

}
