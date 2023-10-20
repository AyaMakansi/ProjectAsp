
using ProjectAsp.Models;

namespace ProjectAsp.Models;

public class Operation
{
    public DateOnly Date { get; set; }
    public double Quantity { get; set; }
    public int Branch_Id { get; set; }

    public Branch branch { get; set; }

    public int Prouduct_Id { get; set; }

    public Product product { get; set; }
}