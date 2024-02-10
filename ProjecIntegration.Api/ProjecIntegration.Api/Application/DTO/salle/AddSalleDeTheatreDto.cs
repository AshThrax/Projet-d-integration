﻿using AutoMapper;
using ProjecIntegration.Api.Application.Common.Mapping;
using ProjecIntegration.Api.Application.DTO.complexe;
using ProjecIntegration.Api.Application.DTO.representation;

namespace ProjecIntegration.Api.Application.DTO
{
    public class AddSalleDeTheatreDto : BaseDto, IMapFrom<SalleDeTheatre>
    {
        
        public DateTime Added { get; set; }
        public string Name { get; set; }

        public int PlaceMax { get; set; }

        public int PlaceCurrent { get; set; }
        public IList<RepresentationDto> Representations { get; set; }

        public ComplexeDto Complexe { get; set; }
        public int ComplexeId { get; set; } 
        public AddSalleDeTheatreDto()
        {
            Representations = new List<RepresentationDto>();
        }

        public void MappingProfile(Profile profile)
        {
           
            profile.CreateMap<AddSalleDeTheatreDto, SalleDeTheatre>();
        }
    }
}