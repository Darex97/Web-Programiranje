using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Ratnik")]
    public class Ratnik
    {
        //prop
       
        [Key]
       
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string Ime { get; set; }
       
        [Required]
        [Range(1, 100)]
        
        public int Snaga { get; set; }


        [Required]
        public int PlanetaId { get; set; }

         [JsonIgnore]
         public Planeta RatnikPlaneta {get; set;}
// jednu od ove dve veze da porazmislim PUFLOVIC
         


    }

}