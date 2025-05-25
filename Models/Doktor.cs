
using HastaneAppv4.Models;

using System.Collections.Generic;

namespace HastaneAppv4.Models
{
    public class Doktor
    {
        public int? Id { get; set; }
        public string Ad { get; set; } 
        public ICollection<Doktor> Doktorlar { get; set; } = new List<Doktor>();
        public string? Soyad { get; set; }
        public string Brans { get; set; }
        public int? KlinikId { get; set; }
        public Klinik? Klinik { get; set; }

        public string AdSoyad => $"{Ad} {Soyad}"; 
    }
}