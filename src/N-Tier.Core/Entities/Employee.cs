using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities;

public class Employee : BaseEntity
{
    public int PersonId { get; set; } 
    public Person? Person { get; set; } 

    public int PositionId { get; set; } 
    public Position? Position { get; set; } 

    public decimal Salary { get; set; }
}
