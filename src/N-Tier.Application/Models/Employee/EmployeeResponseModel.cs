using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Employee;

public class EmployeeResponseModel : BaseResponseModel
{
    public int PersonId { get; set; }
    public int PositionId { get; set; }
    public decimal Salary { get; set; }
}
