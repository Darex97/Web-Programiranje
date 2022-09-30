using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Pretraga")]

    public class Pretraga
    {
        [Key]   
        public int ID { get; set; }

        public string Podrucje { get; set; }

        public string Cvet { get; set; }

        public string List { get; set; }

        public string Stablo { get; set; }

        public string DatumPretrage { get; set; }
    }
}