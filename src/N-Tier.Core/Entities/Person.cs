using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities;

public class Person
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public int Phone { get; set; }
    public Gender? Gender { get; set; }
    public string Adress { get; set; }

}
public enum Gender
{
    male,female
}

