using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneAppv4.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public int HastaId { get; set; }
        public int DoktorId { get; set; }
        public DateTime Tarih { get; set; }
        public TimeSpan? Saat { get; set; }

        [ForeignKey("HastaId")]
        public Hasta? Hasta { get; set; }

        [ForeignKey("DoktorId")]
        public Doktor? Doktor { get; set; }

        public ICollection<RandevuIlac> RandevuIlaclari { get; set; } = new List<RandevuIlac>();
    }
}
