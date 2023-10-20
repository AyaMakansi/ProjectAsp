

namespace ProjectAsp.Models;

public class Company
{   [Key]
    public int Comp_Id { get; set; }
    public string Comp_Name { get; set; }
    public string Website { get; set; }
    public DateOnly Date_Establishment { get; set; }
 
}