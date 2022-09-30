


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Meraci")]
    public class Merac
    {
       [Key]
       public int ID { get; set; }
       public string Naziv { get; set; }
       public int GranicaOd { get; set; }
       public int GranicaDo { get; set; }
       public int Podeok { get; set; }
       public string Boja { get; set; }
       public int TrenutnaVrednost { get; set; }
       public int MaxVrednost { get; set; }
       public int MinVrednost { get; set; }
       public int BrojMerenja { get; set; }
       public int ZbirIzmerenih { get; set; }


    }
}