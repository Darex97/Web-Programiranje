
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models{
    [Table("Mecevi")]
    public class Mec{

        [Key]
        public int ID { get; set; }
        public string Lokacija { get; set; }
        public string Datum { get; set; }
        public int S1 { get; set; }
        public int S2 { get; set; }
        public int PS11 { get; set; }
        public int PS12 { get; set; }
        public int PS21 { get; set; }
        public int PS22 { get; set; }

        public List<Igrac> Igraci {get; set;}

        
    }
}