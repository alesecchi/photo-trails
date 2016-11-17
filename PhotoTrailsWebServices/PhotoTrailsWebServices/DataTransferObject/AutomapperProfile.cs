using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoTrailsWebServices.DataTransferObject
{
    public class AutomapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<trail, TrailDTO>();
            CreateMap<trackpoint, TrackPointDTO>();
            CreateMap<Nullable<TimeSpan>, int?>().ConvertUsing(timespan => 
                timespan.HasValue ? (int)timespan.Value.TotalSeconds : (int?)null);
        }
    }
}