using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("CveceUProdavnici")]

    public class Cvece
    {
        [Key]
        public int ID { get; set; }

        public string Naziv { get; set; }

        public string Podrucje { get; set; }

        public string Cvet { get; set; }

        public string List { get; set; }

        public string Stablo { get; set; }

        public int BrPronadjenih { get; set; }

        [JsonIgnore]
        public Prodavnica Prodavnica {get; set;}
    }
}