
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{

[Table("MeteoroloskiPodaci")]

public class MeteoroloskiPodaci{

    [Key]
    public int ID { get; set; }

    public string NazivMeseca { get; set; }
    public int Temperatura { get; set; }
    public int KolicinaPadavina { get; set; }
    public int SuncaniDani { get; set; }

    [JsonIgnore]
    public Grad Gradovi {get; set;}
}

}