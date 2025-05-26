namespace HastaneAppv4.Models
{
    public class Klinik
    {
        public int Id { get; set; }
        public string Ad { get; set; }
       
            public ICollection<Doktor> Doktorlar { get; set; } = new List<Doktor>(); 
   
    }

}
