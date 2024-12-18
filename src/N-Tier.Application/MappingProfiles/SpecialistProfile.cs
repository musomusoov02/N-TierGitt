using AutoMapper;
using N_Tier.Application.Models.AttendanceStatus;
using N_Tier.Application.Models.Specialist;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
    public class SpecialistProfile : Profile
    {
        public SpecialistProfile()
        {
            CreateMap<CreateSpecialistModel, Specialist>();

            CreateMap<Specialist, SpecialistResponseModel>();
        }
    }
}
