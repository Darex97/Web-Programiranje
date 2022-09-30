using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models{

    [Table("Fabrika")]
    public class Fabrika{

        [Key]
        public int ID { get; set; }

        public string Naziv { get; set; }

        public List<Silos> silosi {get; set;}

    }
}