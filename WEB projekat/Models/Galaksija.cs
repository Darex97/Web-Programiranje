using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

 //  [JsonIgnore]
      //  public List<Borba> GalaksijaBorbe {get; set;} // ja dodao sad
        
       // [JsonIgnore]
        public List<Planeta> GalaksijaPlanete {get; set;}

    }

}