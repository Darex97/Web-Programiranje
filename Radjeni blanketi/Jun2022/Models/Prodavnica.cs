using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{

    [Table("Prodavnice")]

    public class Prodavnica
    {
        [Key]
        public int ID { get; set; }

        public string Naziv { get; set; }

        
        public List<Automobil> Automobili {get; set;}
        
    }
}