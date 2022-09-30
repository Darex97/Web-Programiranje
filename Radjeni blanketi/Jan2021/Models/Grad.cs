
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{

[Table("Gradovi")]

public class Grad{
    
    [Key]
    public int ID { get; set; }

    public string NazivGrada { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public List<MeteoroloskiPodaci> MeteoroloskiPodataci { get; set;}
}
}