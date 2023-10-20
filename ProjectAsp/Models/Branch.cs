

namespace ProjectAsp.Models;

public class Branch
{
    public int Id { get; set; }
    public string Branch_Name { get; set; }
    public string Branch_Location { get; set; }
    public enum Branch_type
    {
        Primary,
        Secondary
        
    }
    public Branch_type Type { get; set; }
    public int Comp_Id { get; set; }
    public Company company { get; set; }
     public int? Branch_Id { get; set; }
    public Branch Parent {get;set;}
    public virtual ICollection<Branch> Children { get; set; }

   
}