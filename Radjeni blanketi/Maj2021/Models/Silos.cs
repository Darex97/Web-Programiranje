using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models{

    [Table("Silosi")]
    public class Silos{

        [Key]
        public int ID { get; set; }

        public string Oznaka { get; set; }

        public int Kapacitet { get; set; }

        public int TrenutnaPopunjenost { get; set; }

        [JsonIgnore]
        public Fabrika Mojafabrika  {get;set;}
    }
}