using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("ProdukcijskeKuce")]

public class ProdukcijskaKuca
{
    [Key]
    public int ID { get; set; }
    
    public string Naziv { get; set; }

    public List<Film> Filmovi {get; set;}
}
}