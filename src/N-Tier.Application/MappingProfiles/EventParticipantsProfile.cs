﻿using AutoMapper;
using N_Tier.Application.Models.AttendanceStatus;
using N_Tier.Application.Models.EventParticipants;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
    public class EventParticipantsProfile : Profile
    {
        public EventParticipantsProfile()
        {
            CreateMap<CreateEventParticipantsModel, EventParticipants>();

            CreateMap<EventParticipants, EventParticipantsResponseModel>();
        }
    }
}
