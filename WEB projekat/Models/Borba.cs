using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Borba")]

    public class Borba
    {      
        [Key]
        public int ID { get; set; }

        //[Required]
        
        public string Vreme { get; set; }

        [Required]
        public int PlanetaId1 { get; set; }

        [Required]
        public int PlanetaId2 { get; set; }



        [Required]
        public int PlanetaPobedink { get; set; }

       [JsonIgnore]
        public List<Planeta> BorbaPlanete {get; set;}
        
    }

}