

namespace ProjectAsp.Dtos;

public class OperationDto
{
    public DateOnly Date { get; set; }
        public double Quantity { get; set; }
        public int Branch_Id { get; set; }
        public Branch Branch { get; set; }
      public int Prouduct_Id { get; set; }
    
 }
