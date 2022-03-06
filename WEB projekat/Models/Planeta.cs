using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Planeta")]

    public class Planeta
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int GalaksijaID { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ImePlanete { get; set; }

        public List<Ratnik> PlanetaRatnici { get; set; }

        [JsonIgnore]
        public Galaksija PlanetaUGalaksiji { get; set; }


        public List<Borba> PlanetineBorbe { get; set; }

    }

}