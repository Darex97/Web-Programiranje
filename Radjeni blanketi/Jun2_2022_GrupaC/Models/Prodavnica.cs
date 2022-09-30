using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("ProdavnicaeBiljaka")]

    public class Prodavnica
    {
        [Key]

        public int ID { get; set; }

        public string Ime { get; set; }

        public List<Cvece> Cvece {get; set;}
    }
}