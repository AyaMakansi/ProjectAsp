using ProjectAsp.Models;

namespace ProjectAsp.Dtos;

public class BranchDto
{
    public string Branch_Name { get; set; }
    public string Branch_Location { get; set; }
    public int Comp_Id { get; set; }
    public Branch.Branch_type Type { get; set; }
    //public List<SecondryBranhchDto>? Children { get; set; } = new();
    public virtual ICollection<Branch>? Children {get; set;}
    /*public class SecondryBranhchDto
    {
        public string Branch_Name { get; set; }
        public string Branch_Location { get; set; }
        public Branch.Branch_type Type { get; set; }
         public Branch Parent{get;set;}
    }*/
}