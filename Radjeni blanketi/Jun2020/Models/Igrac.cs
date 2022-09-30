using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models{

    [Table("Igraci")]
    public class Igrac{

        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public int Godine { get; set; }
        public int Rank { get; set; }

        [JsonIgnore]
        public Mec MecNaKojiUcestvuju {get; set;}

    }
}