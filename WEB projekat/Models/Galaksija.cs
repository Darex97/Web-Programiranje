using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Galaksija")]

    public class Galaksija
    {      
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ImeGalaksije { get; set; }


        

        public List<Planeta> GalaksijaPlanete {get; set;}

    }

}