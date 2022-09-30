using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Filmovi")]

public class Film
{
    [Key]
    public int ID { get; set; }

    public string Naziv { get; set; }

    public string Kategorija { get; set; }

    public int BrOcena { get; set; }

    public int UkupnaOcena {get; set;}

    [JsonIgnore]
    public ProdukcijskaKuca Produkcija {get; set;}
    
    
}
}